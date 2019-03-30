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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using KHSave.Models;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.ViewModels
{
	public class PhotosViewModel : GenericListModel<PhotoEntryViewModel>
	{
		private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

		public string Info => $"Photos: {Items.Count}";

		public RelayCommand ExportAllCommand { get; }

		public RelayCommand DeleteAllCommand { get; }

		public PhotosViewModel(IEnumerable<PhotoEntry> list) :
			this(list.Select((pc, index) => new PhotoEntryViewModel(pc, index)))
		{

		}

		public PhotosViewModel(IEnumerable<PhotoEntryViewModel> list) :
			base(list.Where(x => x.Image != null))
		{
			ExportAllCommand = new RelayCommand(o =>
			{
				var fd = FileDialog.Factory(Window, FileDialog.Behavior.Folder);

				if (fd.ShowDialog() == true)
				{
					try
					{
						var path = fd.FileName;
						foreach (var item in Items)
						{
							item.Export(Path.Combine(path, $"Kingdom Hearts III - Photo {item.Index}.jpg"));
						}
					}
					catch (Exception e)
					{
						MessageBox.Show(Window, $"Unable to export all the photo due to the following error:\n{e.Message}", "Error", MessageBoxButton.OK,
							MessageBoxImage.Error);
					}
				}
			}, x => true);

			DeleteAllCommand = new RelayCommand(o =>
			{
				const string msg = "Do you really want to delete all the photos?\nYou still can not save if you change your mind.";
				var result = MessageBox.Show(Window, msg, "Delete all photos", MessageBoxButton.YesNo,
					MessageBoxImage.Warning);

				if (result == MessageBoxResult.Yes)
				{
					foreach (var item in Items)
					{
						item.Delete();
					}
				}

				Items.Clear();
				OnPropertyChanged(nameof(Info));
				OnPropertyChanged(nameof(Items));

			}, x => true);
		}

		protected override PhotoEntryViewModel OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}
}
