using System.Collections.Generic;
using System.Linq;
using KHSave.Models;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class PhotosViewModel : GenericListModel<PhotoEntryViewModel>
	{
		public PhotosViewModel(IEnumerable<PhotoEntry> list) :
			this(list.Select((pc, index) => new PhotoEntryViewModel(pc, index)))
		{

		}

		public PhotosViewModel(IEnumerable<PhotoEntryViewModel> list) :
			base(list.Where(x => x.Image != null))
		{

		}

		protected override PhotoEntryViewModel OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}
}
