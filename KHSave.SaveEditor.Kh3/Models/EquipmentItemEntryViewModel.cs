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

using KHSave.Lib3.Models;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.Lib3.Types;
using System;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh3.Models
{
    public class EquipmentItemEntryViewModel<T> : BaseNotifyPropertyChanged
        where T : struct, IConvertible
    {
        public EquipmentItem Item { get; }

        public bool Enabled
        {
            get => Item.Enabled != 0;
            set
            {
                Item.Enabled = (byte)(value ? 1 : 0);
                OnPropertyChanged();
            }
        }

        public KhEnumListModel<EnumIconTypeModel<T>, T> ValueSet { get; }

        public KhEnumListModel<EnumIconTypeModel<ItemType>, ItemType> ItemType { get; }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public EquipmentItemEntryViewModel(EquipmentItem item)
        {
            Item = item;
            ValueSet = new KhEnumListModel<EnumIconTypeModel<T>, T>(
                () => (T)(object)item.Id,
                x => item.Id = (byte)(object)x);
            ItemType = new KhEnumListModel<EnumIconTypeModel<ItemType>, ItemType>(
                () => item.ItemType,
                x => item.ItemType = x);
        }
    }

    public class EquipmentItemEntryViewModel : BaseNotifyPropertyChanged
    {
        public EquipmentItem Item { get; }

        public bool Enabled
        {
            get => Item.Enabled != 0;
            set
            {
                Item.Enabled = (byte)(value ? 1 : 0);
                OnPropertyChanged();
            }
        }

        public object ValueSet { get; private set; }

        public KhEnumListModel<EnumIconTypeModel<ItemType>, ItemType> ItemType { get; }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public EquipmentItemEntryViewModel(EquipmentItem item)
        {
            Item = item;
            ItemType = new KhEnumListModel<EnumIconTypeModel<ItemType>, ItemType>(
                () => item.ItemType,
                x => DisplayItemType(item.ItemType = x));

            DisplayItemType(item.ItemType);
        }

        public void DisplayItemType(ItemType itemType)
        {
            switch (itemType)
            {
                case KHSave.Lib3.Types.ItemType.Consumable:
                case KHSave.Lib3.Types.ItemType.ConsumableMirrored:
                    ValueSet = NewList<ConsumableType>();
                    break;
                case KHSave.Lib3.Types.ItemType.Tent:
                    ValueSet = NewList<TentType>();
                    break;
                case KHSave.Lib3.Types.ItemType.Weapon:
                    ValueSet = NewList<WeaponType>();
                    break;
                case KHSave.Lib3.Types.ItemType.Armor:
                    ValueSet = NewList<ArmorType>();
                    break;
                case KHSave.Lib3.Types.ItemType.Accessory:
                    ValueSet = NewList<AccessoryType>();
                    break;
                case KHSave.Lib3.Types.ItemType.Snack:
                    ValueSet = NewList<SnackType>();
                    break;
                case KHSave.Lib3.Types.ItemType.Synthesis:
                    ValueSet = NewList<SynthesisType>();
                    break;
                case KHSave.Lib3.Types.ItemType.Food:
                    ValueSet = NewList<FoodType>();
                    break;
                case KHSave.Lib3.Types.ItemType.KeyItem:
                    ValueSet = NewList<KeyItemType>();
                    break;
                default:
                    ValueSet = null;
                    break;
            }

            OnPropertyChanged(nameof(ValueSet));
        }

        private object NewList<T>()
        where T : struct, IConvertible
        {
            return new KhEnumListModel<EnumIconTypeModel<T>, T>(
                () => (T)(object)Item.Id,
                x => Item.Id = (byte)(object)x);
        }
    }
}
