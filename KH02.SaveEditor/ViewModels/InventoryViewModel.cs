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

using System.Collections.Generic;
using System.Linq;
using KH02.SaveEditor.Models;
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
