/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

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
using Xe.Tools;

namespace KHSave.SaveEditor.Common.Models
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
