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

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;
using KHSave.SaveEditor.Kh3.ViewModels;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Properties;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.Trssv;
using KHSave.SaveEditor.Kh02.ViewModels;
using KHSave.Lib2;
using KHSave.LibRecom;
using KHSave.SaveEditor.Kh2.ViewModels;
using KHSave.SaveEditor.Common.Exceptions;
using KHSave.SaveEditor.KhRecom.ViewModels;
using KHSave.Archives;
using KHSave.SaveEditor.Common.Views;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Interfaces;

namespace KHSave.SaveEditor.ViewModels
{
    public enum SaveType
    {
        Unload,
        Unknown,
        Archive,
        KingdomHearts2,
        KingdomHeartsRecom,
        KingdomHearts02,
        KingdomHearts3
    }

    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private readonly IFileDialogManager fileDialogManager;
        private readonly IWindowManager windowManager;
        private readonly IUpdater updater;
        private SaveType saveType = SaveType.Unload;
        private object dataContext;

        private string OriginalTitle => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;

        private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

        public string Title => fileDialogManager.IsFileOpen ?
            $"{fileDialogManager.CurrentFileName} | {OriginalTitle}" : OriginalTitle;

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
                OnPropertyChanged(nameof(IsKhRecomSave));
                OnPropertyChanged(nameof(VisibilityKhRecom));
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
        public bool IsKhRecomSave => SaveKind == SaveType.KingdomHeartsRecom;
        public Visibility VisibilityKhRecom => IsKhRecomSave ? Visibility.Visible : Visibility.Collapsed;
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
            get => updater.IsAutomaticUpdatesEnabled;
			set
			{
                updater.IsAutomaticUpdatesEnabled = value;
                OnPropertyChanged();
			}
		}

		public MainWindowViewModel(
            IFileDialogManager fileDialogManager,
            IWindowManager windowManager,
            IUpdater updater)
        {
            this.fileDialogManager = fileDialogManager;
            this.windowManager = windowManager;
            this.updater = updater;

            OpenCommand = new RelayCommand(o => fileDialogManager.Open(Open));

            SaveCommand = new RelayCommand(o => fileDialogManager.Save(Save),
                x => fileDialogManager.IsFileOpen);

            SaveAsCommand = new RelayCommand(o => fileDialogManager.SaveAs(Save),
                x => fileDialogManager.IsFileOpen);

            ExitCommand = new RelayCommand(x => Window.Close());

			GetLatestVersionCommand = new RelayCommand(x =>
			{
				Task.Run(async () =>
				{
                    var found = await updater.ForceCheckLastVersionAsync();
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

        public void TestOpen(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
                Open(stream);
        }

        public void Open(Stream stream)
		{
            try
            {
                if (!TryOpen(stream))
                    throw new SaveNotSupportedException("The specified save game is not recognized.");

                InvokeRefreshUi();
                OnPropertyChanged(nameof(Title));
            }
            catch (SaveNotSupportedException ex)
            {
                MessageBox.Show(ex.Message, ex.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save(Stream stream)
        {
            WriteToStream.WriteToStream(stream);
            OnPropertyChanged(nameof(Title));
        }

        public bool TryOpen(Stream stream) =>
            TryOpenKh2(stream) ||
            TryOpenKhRecom(stream) ||
            TryOpenKh02(stream) ||
            TryOpenKh3(stream) ||
            TryOpenArchive(stream);

        private bool Open(IArchiveFactory archiveFactory, Stream stream) =>
            Open(archiveFactory.Read(stream));

        private bool Open(IArchive archive)
        {
            var result = windowManager.Push<ArchiveManagerView>(
                onSetup: window => window.Archive = archive,
                onSuccess: window => Open(archive, window.SelectedEntry));

            if (result == false)
                SaveKind = SaveType.Unload;

            return true;
        }

        private bool Open(IArchive archive, IArchiveEntry archiveEntry)
        {
            bool result;

            using (var stream = new MemoryStream(archiveEntry.Data))
                result = TryOpen(stream);

            // archiveEntry.Name
            // archiveEntry.DateCreated
            // archiveEntry.DateModified

            WriteToStream = new ArchiveWriteToStream(WriteToStream, archive, archiveEntry);

            return result;
        }

        public bool TryOpenArchive(Stream stream)
        {
            if (!ArchiveFactories.TryGetFactory(stream, out var archiveFactory))
                return false;

            stream.Position = 0;
            return Open(archiveFactory, stream);
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

        public bool TryOpenKhRecom(Stream stream)
        {
            if (!SaveKhRecom.IsValid(stream))
                return false;

            var saveViewModel = new KhRecomViewModel(stream);
            DataContext = saveViewModel;
            RefreshUi = saveViewModel;
            WriteToStream = saveViewModel;
            SaveKind = SaveType.KingdomHeartsRecom;

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

        public void InvokeRefreshUi() => RefreshUi?.RefreshUi();
	}
}
