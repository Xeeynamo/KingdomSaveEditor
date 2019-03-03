/*
    Kingdom Hearts 0.2 and 3 Save Editor
    Copyright (C) 2019  Luciano Ciccariello

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
using System.Windows;
using KHSave;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;

namespace KH02.SaveEditor.ViewModels
{
	public class MainWindowViewModel : BaseNotifyPropertyChanged
	{
		private string fileName;
		private bool _isAdvancedMode;

		public Kh3 Save { get; set; }

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
			get => Properties.Settings.Default.AdvancedMode;
			set
			{
				Properties.Settings.Default.AdvancedMode = value;
				Properties.Settings.Default.Save();

				_isAdvancedMode = value;
				System.IsAdvancedMode = value;
			}
		}

		public SystemViewModel System { get; set; }
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
				Save = Kh3.Read(file);
			}

			System = new SystemViewModel(Save) {IsAdvancedMode = IsAdvancedMode};
			Inventory = new InventoryViewModel(Save.Inventory);
			Players = new PlayersViewModel(Save.Pc);
			Story = new StoryViewModel(Save.Storyflags);
			Shortcuts = new ShortcutsViewModel(Save);
			Records = new RecordsViewModel(Save);
			Photos = new PhotosViewModel(Save.Photos);

			OnPropertyChanged(nameof(IsFileLoad));
			OnPropertyChanged(nameof(System));
			OnPropertyChanged(nameof(Inventory));
			OnPropertyChanged(nameof(Players));
			OnPropertyChanged(nameof(Story));
			OnPropertyChanged(nameof(Shortcuts));
			OnPropertyChanged(nameof(Records));
			OnPropertyChanged(nameof(Photos));
		}
	}
}
