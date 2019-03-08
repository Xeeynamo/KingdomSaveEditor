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

using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KH02.SaveEditor.Exceptions;
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

		public RelayCommand ImportCommand { get; }

		public string Description => $"Photo #{Index}";

		public PhotoEntryViewModel(PhotoEntry entry, int index)
		{
			_entry = entry;
			Index = index + 1;

			CreateThumbnailImage();

			ExportCommand = new RelayCommand(o =>
			{
				var fd = FileDialog.Factory(Window, FileDialog.Behavior.Save, ("Jpeg image", "jpg"));
				fd.DefaultFileName = $"Kingdom Hearts III - Photo {Index}.jpg";

				if (fd.ShowDialog() == true)
				{
					try
					{
						Export(fd.FileName);
					}
					catch (Exception e)
					{
						MessageBox.Show(Window, $"Unable to export the photo due to the following error:\n{e.Message}", "Error", MessageBoxButton.OK,
							MessageBoxImage.Error);
					}
				}
			}, x => true);

			ImportCommand = new RelayCommand(o =>
			{
				var fd = FileDialog.Factory(Window, FileDialog.Behavior.Open, ("Jpeg image", "jpg"));
				fd.DefaultFileName = $"Kingdom Hearts III - Photo {Index}.jpg";

				if (fd.ShowDialog() == true)
				{
					try
					{
						Import(fd.FileName);
					}
					catch (ImageTooLargeException e)
					{
						MessageBox.Show(Window, e.Message, "Error", MessageBoxButton.OK,
							MessageBoxImage.Error);
					}
					catch (Exception e)
					{
						MessageBox.Show(Window, $"Unable to import the photo due to the following error:\n{e.Message}", "Error", MessageBoxButton.OK,
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
				stream.Write(_entry.Data, 0, _entry.Length);
			}
		}

		public void Import(string fileName)
		{
			using (var stream = File.Open(fileName, FileMode.Open))
			{
				if (stream.Length > _entry.Data.Length)
					throw new ImageTooLargeException(_entry.Data.Length);

				_entry.Data = new byte[_entry.Data.Length];
				_entry.Length = (int)stream.Length;
				stream.Read(_entry.Data, 0, _entry.Data.Length);
			}
		}

		public void Delete()
		{
			_entry.Length = 0;
			_entry.Data = new byte[_entry.Data.Length];
			CreateThumbnailImage();
		}

		private void CreateThumbnailImage()
		{
			if (_entry.Length > 0)
			{
				using (var memStream = new MemoryStream(_entry.Data))
				{
					Image = BitmapFrame.Create(memStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
				}
			}
			else
			{
				Image = null;
			}

			OnPropertyChanged(nameof(Image));
		}
	}
}