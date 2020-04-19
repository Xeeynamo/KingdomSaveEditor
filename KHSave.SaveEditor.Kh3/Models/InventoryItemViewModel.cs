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
using KHSave.Lib3.Models;
using KHSave.SaveEditor.Common.Models;
using KHSave.Lib3.Types;
using KHSave.SaveEditor.Common.Services;

namespace KHSave.SaveEditor.Kh3.Models
{
    public class InventoryItemViewModel :
        EnumIconTypeModel<InventoryType>,
        SearchEngine.IName, SearchEngine.ICount
    {
        private readonly InventoryEntry inventoryEntry;
        private bool isSelected;

        public InventoryItemViewModel(InventoryEntry inventoryEntry, int index)
        {
            this.inventoryEntry = inventoryEntry;
            Value = (InventoryType)index;
        }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }

        public override string Name => InfoAttribute.GetInfo(Value);

        public int Count
        {
            get => inventoryEntry.Count;
            set
            {
                inventoryEntry.Count = (byte)Math.Min(byte.MaxValue, Math.Max(byte.MinValue, value));
                OnPropertyChanged(nameof(Count));
            }
        }

        public bool Obtained { get => inventoryEntry.Obtained; set => inventoryEntry.Obtained = value; }
        public bool Unseen { get => inventoryEntry.Unseen; set => inventoryEntry.Unseen = value; }
        public bool ShopVisible
        {
            get => inventoryEntry.ShopFlag1 | inventoryEntry.ShopFlag2;
            set
            {
                inventoryEntry.ShopFlag1 = inventoryEntry.ShopFlag2 = value;
                OnPropertyChanged(nameof(ShopSeen));
                OnPropertyChanged(nameof(Flag3));
            }
        }
        public bool ShopSeen
        {
            get => inventoryEntry.ShopFlag1; set
            {
                inventoryEntry.ShopFlag1 = value;
                OnPropertyChanged(nameof(ShopVisible));
            }
        }
        public bool Flag3
        {
            get => inventoryEntry.ShopFlag2; set
            {
                inventoryEntry.ShopFlag2 = value;
                OnPropertyChanged(nameof(ShopVisible));
            }
        }
        public bool Flag4 { get => inventoryEntry.Flag4; set => inventoryEntry.Flag4 = value; }
        public bool Flag5 { get => inventoryEntry.Flag5; set => inventoryEntry.Flag5 = value; }
        public bool Flag6 { get => inventoryEntry.Flag6; set => inventoryEntry.Flag6 = value; }
        public bool Flag7 { get => inventoryEntry.Flag7; set => inventoryEntry.Flag7 = value; }
    }
}
