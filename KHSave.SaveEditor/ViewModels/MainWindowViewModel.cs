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
using KHSave.SaveEditor.Views;

namespace KHSave.SaveEditor.ViewModels
{
	public class MainWindowViewModel : BaseNotifyPropertyChanged
	{
		private string fileName;

		public SaveKh3 Save { get; set; }

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

		public bool IsFileLoad => Save != null;

		public RelayCommand OpenCommand { get; }
		public RelayCommand SaveCommand { get; }
		public RelayCommand SaveAsCommand { get; }
		public RelayCommand ExitCommand { get; }
		public RelayCommand GetLatestVersionCommand { get; }
		public RelayCommand AboutCommand { get; }

		public bool IsAdvancedMode
		{
			get => Global.IsAdvancedMode;
			set
			{
				Global.IsAdvancedMode = value;
				RefreshUi();
			}
		}

		public bool IsUpdateCheckingEnabled
		{
			get => Properties.Settings.Default.IsUpdateCheckingEnabled;
			set
			{
				Properties.Settings.Default.IsUpdateCheckingEnabled = value;
				Properties.Settings.Default.Save();
				OnPropertyChanged();
			}
		}

		public bool IsItTimeForCheckingNewVersion => Properties.Settings.Default.LastUpdateCheck.AddDays(1) < DateTime.UtcNow;

		public SystemViewModel KhSystem { get; set; }
		public InventoryViewModel Inventory { get; set; }
		public PlayersViewModel Players { get; set; }
		public StoryViewModel Story { get; set; }
		public ShortcutsViewModel Shortcuts { get; set; }
		public RecordsViewModel Records { get; set; }
		public PhotosViewModel Photos { get; set; }

		public MainWindowViewModel()
		{
			OpenCommand = new RelayCommand(o =>
			{
				var fd = FileDialog.Factory(null, FileDialog.Behavior.Open, ("Kingdom Hearts III Save", "bin"));
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
						Save.Write(stream);
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
						Save.Write(stream);
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
				var contributors = string.Join("\n", new string[]
				{
					"Keytotruth, additional coding and offsets",
					"Troopah, for providing the icons",
					"Sonicshadowsilver2, for story flags and records offsets",
				}.Select(name => $" - {name}")
				.ToList());

				var aboutDialog = new AboutDialog(Assembly.GetExecutingAssembly());
				aboutDialog.Author += "\n\nContributors:\n" + contributors + "\n - Every other contributor on GitHub repo\n";

				aboutDialog.ShowDialog();
			}, x => true);
		}

		public void Open(string fileName)
		{
			FileName = fileName;
			using (var file = File.Open(fileName, FileMode.Open))
			{
				Save = SaveKh3.Read(file);
			}

			RefreshUi();
		}

		public void RefreshUi()
		{
			KhSystem = new SystemViewModel(Save);
			Inventory = new InventoryViewModel(Save.Inventory);
			Players = new PlayersViewModel(Save.Pc);
			Story = new StoryViewModel(Save);
			Shortcuts = new ShortcutsViewModel(Save);
			Records = new RecordsViewModel(Save);
			Photos = new PhotosViewModel(Save.Photos);

			OnPropertyChanged(nameof(IsFileLoad));
			OnPropertyChanged(nameof(KhSystem));
			OnPropertyChanged(nameof(Inventory));
			OnPropertyChanged(nameof(Players));
			OnPropertyChanged(nameof(Story));
			OnPropertyChanged(nameof(Shortcuts));
			OnPropertyChanged(nameof(Records));
			OnPropertyChanged(nameof(Photos));
		}

		public void UpdateLastTimeForCheckingNewVersion()
		{
			Properties.Settings.Default.LastUpdateCheck = DateTime.UtcNow;
			Properties.Settings.Default.Save();
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
