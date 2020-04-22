﻿/*
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

using KHSave.Attributes;
using KHSave.Extensions;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class InventroyEntryModel :
        BaseNotifyPropertyChanged,
        SearchEngine.IName,
        SearchEngine.ICount
    {
        private readonly Inventory _inventory;

        public InventroyEntryModel(Inventory inventory)
        {
            _inventory = inventory;
            ItemTypes = new KhEnumListModel<EnumIconTypeModel<InventoryType>, InventoryType>();
        }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public Uri AddItemRequestUrl =>
            new Uri($"https://github.com/Xeeynamo/KH3SaveEditor/issues/new?assignees=Xeeynamo&labels=ff7r-item&template=ff7r-missing-item-name-request.md&title=FF7R+Missing+item+name+request+(Item%20ID%20{ItemId})");
        public KhEnumListModel<EnumIconTypeModel<InventoryType>, InventoryType> ItemTypes { get; }

        public string Name => InfoAttribute.GetInfo(Type);
        public ImageSource Icon => IconService.Icon(Type);

        public bool IsNameImplemented => !(Name?.All(x => char.IsNumber(x)) ?? true);
        public Visibility NameRequestVisibility => IsNameImplemented ? Visibility.Collapsed : Visibility.Visible;

        public string Timestamp => _inventory.UnixTimestamp.FromUnixEpoch().ToString();
        public int Count { get => _inventory.Count; set { _inventory.Count = value; OnPropertyChanged(); } }
        public InventoryType Type
        {
            get => _inventory.Type;
            set
            {
                if (Type == InventoryType.Disabled ||
                    Type == InventoryType.Empty)
                {
                    _inventory.UnixTimestamp = DateTime.Now.ToUnixEpoch();
                    OnPropertyChanged(nameof(Timestamp));
                }

                _inventory.Type = value;
                OnPropertyChanged(nameof(Icon));
                OnPropertyChanged(nameof(Name));

                if (Type == InventoryType.Disabled ||
                    Type == InventoryType.Empty)
                {
                    _inventory.UnixTimestamp = 0;
                    OnPropertyChanged(nameof(Timestamp));
                }

                OnPropertyChanged(nameof(Type));
            }
        }
        public int ItemId { get => (int)Type; set => Type = (InventoryType)value; }

        public int Unknown04 { get => _inventory.Unknown04; set => _inventory.Unknown04 = value; }
        public int Unknown10 { get => _inventory.Unknown10; set => _inventory.Unknown10 = value; }
        public int Unknown14 { get => _inventory.Unknown14; set => _inventory.Unknown14 = value; }
    }
}
