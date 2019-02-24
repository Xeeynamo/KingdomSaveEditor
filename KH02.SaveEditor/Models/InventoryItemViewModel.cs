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
using KHSave.Attributes;
using KHSave.Models;
using KHSave.Types;
using Xe.Tools;

namespace KH02.SaveEditor.Models
{
	public class InventoryItemViewModel : EnumIconTypeModel<InventoryType>
	{
		private readonly InventoryEntry inventoryEntry;

		public InventoryItemViewModel(InventoryEntry inventoryEntry, int index)
		{
			this.inventoryEntry = inventoryEntry;
			Value = (InventoryType)index;
		}

		public string Name => InfoAttribute.GetInfo(Value);

		public int Count
		{
			get => inventoryEntry.Count;
			set
			{
				inventoryEntry.Count = (byte)Math.Min(byte.MaxValue, Math.Max(byte.MinValue, value));
				OnPropertyChanged(nameof(Count));
			}
		}
	}
}
