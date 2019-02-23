using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using KHSave.Models;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
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
						MessageBox.Show(Window, "Unable to export the photo", "Error", MessageBoxButton.OK,
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
