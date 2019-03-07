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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KHSave.Attributes;
using Xe.Tools.Models;

namespace KH02.SaveEditor.Models
{
	public class GenericEnumModel<TModel, TEnum, TValue> : IEnumerable<TModel>
		where TEnum : struct, IConvertible
		where TModel : EnumItemModel<TValue>
	{
		private readonly TModel[] items;

		public GenericEnumModel(Func<TEnum, TValue> valueGetter, Func<TEnum, string> nameGetter = null)
		{
			var type = typeof(TEnum);
			if (type.IsEnum == false)
			{
				throw new InvalidOperationException($"{type} is not an enum.");
			}

			items = Enum.GetValues(type)
				.Cast<TEnum>()
				.Select(e =>
				{
					var item = Activator.CreateInstance<TModel>() as EnumItemModel<TValue>;
					item.Value = valueGetter(e);
					item.Name = nameGetter != null ? nameGetter(e) : InfoAttribute.GetInfo(e);

					return (TModel)item;
				})
				.Where(x => Global.CanDisplay(x.Value))
				.ToArray();
		}

		private static string DefaultNameGetter(TEnum value) => InfoAttribute.GetInfo(value);

		public IEnumerator<TModel> GetEnumerator()
		{
			return items.AsEnumerable().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public EnumItemModel<TValue> this[int i] => items[i];
	}

	public class GenericEnumModel<TModel, T> : GenericEnumModel<TModel, T, T>
		where T : struct, IConvertible
		where TModel : EnumItemModel<T>
	{
		public GenericEnumModel(Func<T, string> nameGetter = null) :
			base(x => x, nameGetter)
		{ }
	}

	public class GenericEnumModel<T> : GenericEnumModel<EnumItemModel<T>, T>
		where T : struct, IConvertible
	{
	}
}
