using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KH02.SaveEditor.Models;
using KHSave;
using KHSave.Attributes;
using KHSave.Types;
using Xe.Tools.Models;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
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

		private readonly Kh3 save;

		public CustomListModel<RecordUsageType> Shotlocks { get; }

		public RecordsViewModel(Kh3 save)
		{
			this.save = save;
			Shotlocks = new CustomListModel<RecordUsageType>(save.RecordShotlocks);
		}
	}
}
