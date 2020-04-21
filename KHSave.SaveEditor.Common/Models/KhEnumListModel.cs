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
using KHSave.Attributes;

namespace KHSave.SaveEditor.Common.Models
{
	public class KhEnumListModel<TModel, TEnum, TValue> : GenericEnumListModel<TModel, TEnum, TValue>
		where TEnum : struct, IConvertible
		where TModel : GenericEntryModel<string, TValue>
	{
		public KhEnumListModel(
			Func<TValue> valueGetter,
			Action<TValue> valueSetter,
			Func<TEnum, TValue> enumValueGetter,
			Func<TEnum, string> enumNameGetter = null,
			Func<TModel, bool> filter = null) :
			base(valueGetter, valueSetter, enumValueGetter, enumNameGetter ?? DefaultNameGetter, filter ?? DefaultFilter)
		{ }

		private static string DefaultNameGetter(TEnum value) => InfoAttribute.GetInfo(value);

		private static bool DefaultFilter(TModel model) => Global.CanDisplay(model.Value);
	}

	public class KhEnumListModel<TModel, TEnum> : KhEnumListModel<TModel, TEnum, TEnum>
		where TEnum : struct, IConvertible
		where TModel : GenericEntryModel<string, TEnum>
	{
		public KhEnumListModel(
			Func<TEnum> valueGetter,
			Action<TEnum> valueSetter,
			Func<TEnum, string> enumNameGetter = null,
			Func<TModel, bool> filter = null) :
			base(valueGetter, valueSetter, x => x, enumNameGetter, filter)
		{ }
	}

	public class KhEnumListModel<TEnum> : KhEnumListModel<GenericEntryModel<string, TEnum>, TEnum>
		where TEnum : struct, IConvertible
	{
		public KhEnumListModel(
			Func<TEnum> valueGetter,
			Action<TEnum> valueSetter,
			Func<TEnum, string> enumNameGetter = null,
			Func<GenericEntryModel<string, TEnum>, bool> filter = null) :
			base(valueGetter, valueSetter, enumNameGetter, filter)
		{ }

		public KhEnumListModel() :
			this(() => default(TEnum), x => { })
		{ }
	}
}
