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

		public RelayCommand OpenCommand { get; }
		public RelayCommand SaveCommand { get; }
		public RelayCommand SaveAsCommand { get; }
		public RelayCommand ExitCommand { get; }
		public RelayCommand GetLatestVersionCommand { get; }
		public RelayCommand AboutCommand { get; }

		public bool IsAdvancedMode { get; set; }

		public SystemViewModel System { get; set; }
		public InventoryViewModel Inventory { get; set; }
		public PlayersViewModel Players { get; set; }
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
					"Keytotruth"
				}.Select(name => $" - {name}")
				.ToList());

				var aboutDialog = new AboutDialog(Assembly.GetExecutingAssembly());
				aboutDialog.Author += "\n\nAdditional developers:\n" + contributors + "\n - Every other contributor on GitHub repo\n";

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

			System = new SystemViewModel(Save);
			Inventory = new InventoryViewModel(Save.Inventory);
			Players = new PlayersViewModel(Save.Pc);
			Photos = new PhotosViewModel(Save.Photos);

			OnPropertyChanged(nameof(System));
			OnPropertyChanged(nameof(Inventory));
			OnPropertyChanged(nameof(Players));
			OnPropertyChanged(nameof(Photos));
		}
	}
}
