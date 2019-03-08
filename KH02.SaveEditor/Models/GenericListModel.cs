using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools;

namespace KH02.SaveEditor.Models
{
	public class GenericListModel<TModel, TName, TValue> : BaseNotifyPropertyChanged, IEnumerable<TModel>
		where TModel : GenericEntryModel<TName, TValue>
	{
		private readonly Func<TValue> valueGetter;
		private readonly Action<TValue> valueSetter;
		private readonly TModel[] items;

		public GenericListModel(IEnumerable<TModel> items, Func<TValue> valueGetter, Action<TValue> valueSetter)
		{
			this.valueGetter = valueGetter;
			this.valueSetter = valueSetter;
			this.items = items.ToArray();
		}

		public TValue SelectedValue
		{
			get => valueGetter();
			set => valueSetter(value);
		}

		public IEnumerator<TModel> GetEnumerator() => items.AsEnumerable().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => items.AsEnumerable().GetEnumerator();

		public GenericEntryModel<TName, TValue> this[int i] => items[i];
	}

	public class GenericListModel<TModel, TValue> : GenericListModel<TModel, string, TValue>
		where TModel : GenericEntryModel<string, TValue>
	{

		public GenericListModel(IEnumerable<TModel> items, Func<TValue> valueGetter, Action<TValue> valueSetter) :
			base(items, valueGetter, valueSetter)
		{ }
	}
}
