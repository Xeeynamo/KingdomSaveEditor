using System.IO;
using System.Linq;
using KHSave;

namespace KH02.SaveEditor.ViewModels
{
	public class MainWindowViewModel
	{
		public Kh3 Save { get; set; }

		public PlayersViewModel Players { get; set; }

		public void Open(string fileName)
		{
			using (var file = File.Open(fileName, FileMode.Open))
			{
				Save = Kh3.Read(file);
			}

			Players = new PlayersViewModel(Save.Pc.Select(x => new PlayerViewModel(x)));
		}
	}
}
