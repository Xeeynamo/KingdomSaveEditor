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
using System.Collections.Generic;
using System.Linq;

namespace KHSave.SaveEditor.Common.Models
{
	public class GenericEnumListModel<TModel, TEnum, TValue> : GenericListModel<TModel, TValue>
		where TEnum : struct, IConvertible
		where TModel : GenericEntryModel<string, TValue>
	{
		public GenericEnumListModel(
			Func<TValue> valueGetter,
			Action<TValue> valueSetter,
			Func<TEnum, TValue> enumValueGetter,
			Func<TEnum, string> enumNameGetter = null,
			Func<TModel, bool> filter = null) :
			base(GetModels(enumValueGetter, enumNameGetter, filter), valueGetter, valueSetter)
		{ }

		private static IEnumerable<TModel> GetModels(
			Func<TEnum, TValue> enumValueGetter,
			Func<TEnum, string> enumNameGetter,
			Func<TModel, bool> filter)
		{
			var type = typeof(TEnum);
			if (type.IsEnum == false)
			{
				throw new InvalidOperationException($"{type} is not an enum.");
			}

			var items = Enum.GetValues(type)
				.Cast<TEnum>()
				.Select(e =>
				{
					var item = Activator.CreateInstance<TModel>() as GenericEntryModel<string, TValue>;
					item.Value = enumValueGetter(e);
					item.Name = enumNameGetter?.Invoke(e) ?? e.ToString();

					return (TModel)item;
				});

			return filter != null ? items.Where(filter) : items;
		}
	}

	public class GenericEnumListModel<TModel, TEnum> : GenericEnumListModel<TModel, TEnum, TEnum>
		where TEnum : struct, IConvertible
		where TModel : GenericEntryModel<string, TEnum>
	{
		public GenericEnumListModel(
			Func<TEnum> valueGetter,
			Action<TEnum> valueSetter,
			Func<TEnum, string> enumNameGetter = null,
			Func<TModel, bool> filter = null) :
			base(valueGetter, valueSetter, x => x, enumNameGetter, filter)
		{ }
	}
}
