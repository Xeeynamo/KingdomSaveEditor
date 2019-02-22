using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using KHSave;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;

namespace KH02.SaveEditor.ViewModels
{
	public class MainWindowViewModel : BaseNotifyPropertyChanged
	{
		public Kh3 Save { get; set; }

		public string Title => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;

		public RelayCommand OpenCommand { get; }
		public RelayCommand SaveCommand { get; }
		public RelayCommand SaveAsCommand { get; }
		public RelayCommand ExitCommand { get; }
		public RelayCommand GetLatestVersionCommand { get; }
		public RelayCommand AboutCommand { get; }

		public bool IsAdvancedMode { get; set; }

		public PlayersViewModel Players { get; set; }

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
			using (var file = File.Open(fileName, FileMode.Open))
			{
				Save = Kh3.Read(file);
			}

			Players = new PlayersViewModel(Save.Pc.Select(x => new PlayerViewModel(x)));

			OnPropertyChanged(nameof(Players));
		}
	}
}
