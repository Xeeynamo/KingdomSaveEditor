/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using KHSave.SaveEditor.VersionCheck;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;
using Xe.VersionCheck;
using KHSave.SaveEditor.Kh3.ViewModels;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Properties;
using KHSave.SaveEditor.Views;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.Trssv;
using KHSave.SaveEditor.Kh02.ViewModels;
using KHSave.Lib2;
using KHSave.SaveEditor.Kh2.ViewModels;
using KHSave.SaveEditor.Common.Exceptions;

namespace KHSave.SaveEditor.ViewModels
{
    public enum SaveType
    {
        Unload,
        Unknown,
        KingdomHearts2,
        KingdomHearts02,
        KingdomHearts3
    }

    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private string fileName;
        private SaveType saveType = SaveType.Unload;
        private object dataContext;

        private string OriginalTitle => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;

        private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

        public string Title => string.IsNullOrEmpty(FileName) ? OriginalTitle : $"{Path.GetFileName(FileName)} | {OriginalTitle}";

        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public bool IsFileLoad { get; private set; }

        public RelayCommand OpenCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand SaveAsCommand { get; }
        public RelayCommand ExitCommand { get; }
        public RelayCommand GetLatestVersionCommand { get; }
        public RelayCommand AboutCommand { get; }

        public object DataContext
        {
            get => dataContext;
            set
            {
                dataContext = value;
                OnPropertyChanged();
            }
        }
        public IRefreshUi RefreshUi { get; private set; }
        public IWriteToStream WriteToStream { get; private set; }

        public SaveType SaveKind
        {
            get => saveType;
            set
            {
                saveType = value;
                OnPropertyChanged(nameof(IsUnload));
                OnPropertyChanged(nameof(VisibilityUnload));
                OnPropertyChanged(nameof(IsUnknown));
                OnPropertyChanged(nameof(VisibilityUnknown));
                OnPropertyChanged(nameof(IsKh2Save));
                OnPropertyChanged(nameof(VisibilityKh2));
                OnPropertyChanged(nameof(IsKh02Save));
                OnPropertyChanged(nameof(VisibilityKh02));
                OnPropertyChanged(nameof(IsKh3Save));
                OnPropertyChanged(nameof(VisibilityKh3));
            }
        }
        public bool IsUnload => SaveKind == SaveType.Unload;
        public Visibility VisibilityUnload => IsUnload ? Visibility.Visible : Visibility.Collapsed;
        public bool IsUnknown => SaveKind == SaveType.Unknown;
        public Visibility VisibilityUnknown => IsUnknown ? Visibility.Visible : Visibility.Collapsed;
        public bool IsKh2Save => SaveKind == SaveType.KingdomHearts2;
        public Visibility VisibilityKh2 => IsKh2Save ? Visibility.Visible : Visibility.Collapsed;
        public bool IsKh02Save => SaveKind == SaveType.KingdomHearts02;
        public Visibility VisibilityKh02 => IsKh02Save ? Visibility.Visible : Visibility.Collapsed;
        public bool IsKh3Save => SaveKind == SaveType.KingdomHearts3;
        public Visibility VisibilityKh3 => IsKh3Save ? Visibility.Visible : Visibility.Collapsed;

        public bool IsAdvancedMode
		{
			get => Global.IsAdvancedMode;
			set
			{
				Global.IsAdvancedMode = value;
				InvokeRefreshUi();
			}
		}

		public bool IsUpdateCheckingEnabled
		{
			get => Settings.Default.IsUpdateCheckingEnabled;
			set
			{
				Settings.Default.IsUpdateCheckingEnabled = value;
				Settings.Default.Save();
				OnPropertyChanged();
			}
		}

		public bool IsItTimeForCheckingNewVersion => Settings.Default.LastUpdateCheck.AddDays(1) < DateTime.UtcNow;

		public MainWindowViewModel()
		{
			OpenCommand = new RelayCommand(o =>
			{
				var fd = FileDialog.Factory(null, FileDialog.Behavior.Open, new[]
                {
                    ("Kingdom Hearts 2 Save", "bin"),
                    ("Kingdom Hearts 0.2 Save", "sav"),
                    ("Kingdom Hearts III Save", "bin"),
                });
				if (fd.ShowDialog() == true)
				{
					Open(fd.FileName);
				}
			}, x => true);

			SaveCommand = new RelayCommand(o =>
			{
				if (!string.IsNullOrEmpty(FileName))
				{
					using (var stream = File.Open(FileName, FileMode.Create))
					{
                        WriteToStream.WriteToStream(stream);

                    }
				}
				else
				{
					SaveAsCommand.Execute(o);
				}
			}, x => true);

			SaveAsCommand = new RelayCommand(o =>
			{
				var fd = FileDialog.Factory(Window, FileDialog.Behavior.Save, ("Kingdom Hearts III Save", "bin"));
				fd.DefaultFileName = FileName;

				if (fd.ShowDialog() == true)
				{
					FileName = fd.FileName;
					using (var stream = File.Open(fd.FileName, FileMode.Create))
                    {
                        WriteToStream.WriteToStream(stream);
                    }
				}
			}, x => true);

			ExitCommand = new RelayCommand(x =>
			{
				Window.Close();
			}, x => true);

			GetLatestVersionCommand = new RelayCommand(x =>
			{
				Task.Run(async () =>
				{
					var found = await CheckLastVersionAsync(true);
					if (found == false)
					{
						Application.Current.Dispatcher.Invoke(() =>
						{
							MessageBox.Show("No new versions has been found.",
								"Check update",
								MessageBoxButton.OK,
								MessageBoxImage.Information);
						});
					}
				});
			});

            AboutCommand = new RelayCommand(x =>
			{
				var contributors = string.Join("\n", (new string[]
				{
					"Keytotruth, additional coding and offsets",
					"Troopah, for providing the icons",
					"Sonicshadowsilver2, for story flags and records offsets",
                    "TALESIOFIFREAK, for the ability list",
                    "SilverCam , for the gummiship inventory items",
				}).Select(name => $" - {name}")
				.ToList());

                Assembly assembly = Assembly.GetExecutingAssembly();
                var assemblyName = assembly.GetName();
                var aboutDialog = new AboutDialog(assembly)
                {
                    Version = $"{assemblyName.Version.Major}.{assemblyName.Version.Minor}.{assemblyName.Version.Build}"
                };
                aboutDialog.Author += "\n\nContributors and special thanks:\n" + contributors + "\n - Every other contributor on GitHub repo\n";

				aboutDialog.ShowDialog();
			}, x => true);
		}

		public void Open(string fileName)
		{
            try
            {
                using (var file = File.Open(fileName, FileMode.Open))
                    Open(file);

                if (SaveKind == SaveType.Unknown)
                    throw new SaveNotSupportedException("The specified save game is not recognized.");

                FileName = fileName;
                InvokeRefreshUi();
            }
            catch (SaveNotSupportedException ex)
            {
                MessageBox.Show(ex.Message, ex.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
		}

        public void Open(Stream stream)
        {
            bool isOpen = TryOpenKh2(stream) || TryOpenKh02(stream) || TryOpenKh3(stream);
            if (isOpen == false)
                SaveKind = SaveType.Unknown;
        }

        public bool TryOpenKh2(Stream stream)
        {
            if (!SaveKh2.IsValid(stream))
                return false;

            var saveViewModel = new Kh2ViewModel(stream);
            DataContext = saveViewModel;
            RefreshUi = saveViewModel;
            WriteToStream = saveViewModel;
            SaveKind = SaveType.KingdomHearts2;

            return true;
        }

        public bool TryOpenKh02(Stream stream)
        {
            if (!SaveKh02.IsValid(stream))
                return false;

            var saveViewModel = new Kh02ViewModel(stream);
            DataContext = saveViewModel;
            RefreshUi = saveViewModel;
            WriteToStream = saveViewModel;
            SaveKind = SaveType.KingdomHearts02;

            return true;
        }

        public bool TryOpenKh3(Stream stream)
        {
            if (!SaveKh3.IsValid(stream))
                return false;

            var saveViewModel = new Kh3ViewModel(stream);
            DataContext = saveViewModel;
            RefreshUi = saveViewModel;
            WriteToStream = saveViewModel;
            SaveKind = SaveType.KingdomHearts3;

            return true;
        }

        public void InvokeRefreshUi() => RefreshUi.RefreshUi();


        public void UpdateLastTimeForCheckingNewVersion()
		{
			Settings.Default.LastUpdateCheck = DateTime.UtcNow;
			Settings.Default.Save();
		}

		public async Task<bool> CheckLastVersionAsync(bool forceUpdateCheck = false)
		{
			if (forceUpdateCheck == false)
			{
				if (IsItTimeForCheckingNewVersion == false)
					return false;
			}

			UpdateLastTimeForCheckingNewVersion();
			var checkCurrentVersion = new DesktopCheckCurrentVersion();
			var checkLastVersion = new GithubCheckLatestVersion("xeeynamo", "kh3saveeditor");
			var releaseUpdater = new VersionChecker(checkCurrentVersion, checkLastVersion);

			var lastVersion = await releaseUpdater.GetLatestVersionAsync();
			if (lastVersion != null)
			{
				Application.Current.Dispatcher.Invoke(() =>
				{
					new UpdateWindow(lastVersion).ShowDialog();
				});

				return true;
			}

			return false;
		}
	}
}
