using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KHSave.Models;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;

namespace KH02.SaveEditor.ViewModels
{
	public class PhotoEntryViewModel : BaseNotifyPropertyChanged
	{
		private readonly PhotoEntry _entry;
		private readonly int _index;

		private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

		public ImageSource Image { get; set; }

		public RelayCommand ExportCommand { get; }

		public string Description => $"Photo #{_index + 1}";

		public PhotoEntryViewModel(PhotoEntry entry, int index)
		{
			_entry = entry;
			_index = index;

			if (_entry.Length > 0)
			{
				using (var memStream = new MemoryStream(_entry.Data))
				{
					Image = BitmapFrame.Create(memStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
				}
			}

			ExportCommand = new RelayCommand(o =>
			{
				var fd = FileDialog.Factory(Window, FileDialog.Behavior.Save, ("Kingdom Hearts III Save", "bin"));
				fd.DefaultFileName = $"Kingdom Hearts III - Photo {_index + 1}.jpg";

				if (fd.ShowDialog() == true)
				{
					using (var stream = File.Open(fd.FileName, FileMode.Create))
					{
						stream.Write(_entry.Data, 0, _entry.Data.Length);
					}
				}
			}, x => true);
		}
	}
}