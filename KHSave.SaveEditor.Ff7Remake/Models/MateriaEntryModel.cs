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

using KHSave.Extensions;
using KHSave.LibFf7Remake;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Ff7Remake.Data;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class MateriaEntryModel :
        BaseNotifyPropertyChanged,
        SearchEngine.IName
    {
        private Materia _materia;

        public MateriaEntryModel(Materia materia)
        {
            _materia = materia;

            ItemType = ItemModel.GetItemModels();
            CharacterType = new KhEnumListModel<CharacterType>(() => Character, x => Character = x);
        }

        public IEnumerable<ItemModel> ItemType { get; }
        public KhEnumListModel<CharacterType> CharacterType { get; }

        public string Name => ItemsPreset.Get(ItemId)?.Name;
        public ImageSource Icon => IconService.Icon(ItemsPreset.Get(ItemId)?.Icon);

        public int ItemId
        {
            get => _materia.ItemId;
            set
            {
                if (ItemId == (int)InventoryType.Disabled ||
                    ItemId == (int)InventoryType.Empty)
                {
                    _materia.UnixTimestamp = DateTime.Now.ToUnixEpoch();
                    OnPropertyChanged(nameof(Timestamp));
                }

                _materia.ItemId = value;
                OnPropertyChanged(nameof(Icon));
                OnPropertyChanged(nameof(Name));

                if (ItemId == (int)InventoryType.Disabled ||
                    ItemId == (int)InventoryType.Empty)
                {
                    _materia.UnixTimestamp = 0;
                    OnPropertyChanged(nameof(Timestamp));
                }
            }
        }

        public string Timestamp => _materia.UnixTimestamp.FromUnixEpoch().ToString();
        public int AbilityPoint { get => _materia.AbilityPoint; set { _materia.AbilityPoint = value; OnPropertyChanged(); } }
        public byte Level { get => _materia.Level; set => _materia.Level = value; }
        public CharacterType Character { get => (CharacterType)_materia.Character; set => _materia.Character = (byte)value; }
        public int Index { get => _materia.Index; set => _materia.Index = value; }
    }
}
