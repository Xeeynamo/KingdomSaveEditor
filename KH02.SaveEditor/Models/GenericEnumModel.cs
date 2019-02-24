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
	public class GenericEnumModel<TModel, T> : IEnumerable<TModel>
		where T : struct, IConvertible
		where TModel : EnumItemModel<T>
	{
		private readonly TModel[] items;

		public GenericEnumModel()
		{
			var type = typeof(T);
			if (type.IsEnum == false)
			{
				throw new InvalidOperationException($"{type} is not an enum.");
			}

			items = Enum.GetValues(type)
				.Cast<T>()
				.Select(e =>
				{
					var item = Activator.CreateInstance<TModel>() as EnumItemModel<T>;
					item.Value = e;
					item.Name = InfoAttribute.GetInfo(e);

					return (TModel)item;
				}).ToArray();
		}

		public IEnumerator<TModel> GetEnumerator()
		{
			return items.AsEnumerable().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public EnumItemModel<T> this[int i] => items[i];
	}

	public class GenericEnumModel<T> : GenericEnumModel<EnumItemModel<T>, T>
		where T : struct, IConvertible
	{
	}
}
