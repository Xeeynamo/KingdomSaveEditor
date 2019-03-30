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

using KHSave.Models;
using KHSave.Types;
using System;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Models
{
	public class EquipmentItemEntryViewModel<T> : BaseNotifyPropertyChanged
		where T : struct, IConvertible
	{
		public EquipmentItem Item { get; }

		public bool Enabled
		{
			get => Item.Enabled;
			set
			{
				Item.Enabled = value;
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
			get => Item.Enabled;
			set
			{
				Item.Enabled = value;
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
				case KHSave.Types.ItemType.Consumable:
				case KHSave.Types.ItemType.ConsumableMirrored:
					ValueSet = NewList<ConsumableType>();
					break;
				case KHSave.Types.ItemType.Tent:
					ValueSet = NewList<TentType>();
					break;
				case KHSave.Types.ItemType.Weapon:
					ValueSet = NewList<WeaponType>();
					break;
				case KHSave.Types.ItemType.Armor:
					ValueSet = NewList<ArmorType>();
					break;
				case KHSave.Types.ItemType.Accessory:
					ValueSet = NewList<AccessoryType>();
					break;
				case KHSave.Types.ItemType.Snack:
					ValueSet = NewList<SnackType>();
					break;
				case KHSave.Types.ItemType.Synthesis:
					ValueSet = NewList<SynthesisType>();
					break;
				case KHSave.Types.ItemType.Food:
					ValueSet = NewList<FoodType>();
					break;
				case KHSave.Types.ItemType.KeyItem:
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
