/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

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
using System.Windows;
using KHSave.Models;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Kh3.Models;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
	public class InventoryViewModel : GenericListModel<InventoryItemViewModel>
	{
		public RelayCommand Research0Command { get; }
		public RelayCommand Research1Command { get; }
		public RelayCommand Research2Command { get; }
		public RelayCommand Research3Command { get; }
		public RelayCommand Research4Command { get; }

		public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
		public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

		public InventoryViewModel(IEnumerable<InventoryEntry> list) :
			this(list.Select((item, index) => new InventoryItemViewModel(item, index)))
		{ }

		public InventoryViewModel(IEnumerable<InventoryItemViewModel> list) :
			base(list.Where(x => Global.CanDisplay(x.Value)))
		{
			Research0Command = new RelayCommand(o => DoResearch(500), x => true);
			Research1Command = new RelayCommand(o => DoResearch(600), x => true);
			Research2Command = new RelayCommand(o => DoResearch(700), x => true);
			Research3Command = new RelayCommand(o => DoResearch(800), x => true);
			Research4Command = new RelayCommand(o => DoResearch(900), x => true);
		}

		private void DoResearch(int startIndex, int count = 100)
		{
			for (var i = 0; i < count; i++)
			{
				Items[startIndex + i].Count = i + 1;
			}
		}

		protected override InventoryItemViewModel OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}
}
