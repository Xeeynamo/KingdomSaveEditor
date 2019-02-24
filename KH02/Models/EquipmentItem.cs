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

using KHSave.Attributes;
using KHSave.Types;

namespace KHSave.Models
{
	public class EquipmentItem
	{
		[Data] public byte Id { get; set; }
		[Data] public ItemType ItemType { get; set; }

		[Data(4)] public bool Enabled { get; set; }
	}

	public class WeaponEquipmentItem : EquipmentItem
	{
		public WeaponType WeaponId
		{
			get => (WeaponType)Id;
			set => Id = (byte)value;
		}
	}

	public class ArmorEquipmentItem : EquipmentItem
	{
		public ArmorType ArmorId
		{
			get => (ArmorType)Id;
			set => Id = (byte)value;
		}
	}

	public class AccessoryEquipmentItem : EquipmentItem
	{
		public AccessoryType AccessoryId
		{
			get => (AccessoryType)Id;
			set => Id = (byte)value;
		}
	}

	public class ConsumableEquipmentItem : EquipmentItem
	{
		public ConsumableType ConsumableId
		{
			get => (ConsumableType)Id;
			set => Id = (byte)value;
		}
	}
}
