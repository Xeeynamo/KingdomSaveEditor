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

namespace KH02.SaveEditor.Models
{
	public class ItemComboBoxModel<T>
		where T : struct, IConvertible
	{
		private readonly Func<T> _getter;
		private readonly Action<T> _setter;
		public GenericEnumModel<EnumIconTypeModel<T>, T> EquipmentType { get; }

		public T ItemId
		{
			get => _getter();
			set => _setter(value);
		}

		public ItemComboBoxModel(Func<T> getter, Action<T> setter)
		{
			_getter = getter;
			_setter = setter;

			EquipmentType = new GenericEnumModel<EnumIconTypeModel<T>, T>();
		}
	}
}
