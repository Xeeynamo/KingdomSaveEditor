using KHSave;
using System.Collections.Generic;
using System.Linq;
using KH02.SaveEditor.Models;
using KH02.SaveEditor.Views;
using KHSave.Models;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class InventoryViewModel : GenericListModel<InventoryItemViewModel>
	{
		public InventoryViewModel(IEnumerable<InventoryEntry> list) :
			this(list.Select((item, index) => new InventoryItemViewModel(item, index)))
		{ }

		public InventoryViewModel(IEnumerable<InventoryItemViewModel> list) :
			base(list)
		{ }

		protected override InventoryItemViewModel OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}
}
