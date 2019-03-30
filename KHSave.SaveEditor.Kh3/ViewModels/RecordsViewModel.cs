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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KHSave.Attributes;
using KHSave.Types;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
	public class RecordsViewModel
	{
		public class CustomListModel<T> :
			GenericListModel<RecordItemModel<T>>,
			IEnumerable<RecordItemModel<T>>
			where T : struct, IConvertible
		{
			public CustomListModel(List<short> list)
				: base(list.Select((x, i) => new RecordItemModel<T>(list, i)))
			{
			}

			public CustomListModel(IEnumerable<RecordItemModel<T>> list)
				: base(list)
			{
			}

			public IEnumerator<RecordItemModel<T>> GetEnumerator()
			{
				return Items.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return Items.GetEnumerator();
			}

			protected override RecordItemModel<T> OnNewItem()
			{
				throw new System.NotImplementedException();
			}
		}

		public class RecordItemModel<T>
			where T : struct, IConvertible
		{
			private readonly List<short> items;
			private readonly int index;

			public RecordItemModel(List<short> items, int index)
			{
				this.items = items;
				this.index = index;
			}

			public string Name => InfoAttribute.GetInfo((T)(object)index);

			public short Value
			{
				get => items[index];
				set => items[index] = value;
			}
		}

		private readonly SaveKh3 save;

		public CustomListModel<RecordUsageType> Shotlocks { get; }

		public RecordsViewModel(SaveKh3 save)
		{
			this.save = save;
			Shotlocks = new CustomListModel<RecordUsageType>(save.RecordShotlocks);
		}
	}
}
