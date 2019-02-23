using System;
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

		private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

		public int Index { get; }

		public ImageSource Image { get; set; }

		public RelayCommand ExportCommand { get; }

		public string Description => $"Photo #{Index}";

		public PhotoEntryViewModel(PhotoEntry entry, int index)
		{
			_entry = entry;
			Index = index + 1;

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
				fd.DefaultFileName = $"Kingdom Hearts III - Photo {Index}.jpg";

				if (fd.ShowDialog() == true)
				{
					try
					{
						Export(fd.FileName);
					}
					catch (Exception e)
					{
						MessageBox.Show(Window, "Unable to export the photo", "Error", MessageBoxButton.OK,
							MessageBoxImage.Error);
					}
				}
			}, x => true);
		}

		public void Export(string fileName)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(fileName));
			using (var stream = File.Open(fileName, FileMode.Create))
			{
				stream.Write(_entry.Data, 0, _entry.Data.Length);
			}
		}

		public void Delete()
		{
			_entry.Length = 0;
			_entry.Data = new byte[_entry.Data.Length];
			OnPropertyChanged(nameof(Image));
		}
	}
}