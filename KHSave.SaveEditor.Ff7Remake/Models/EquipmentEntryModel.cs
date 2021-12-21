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

using KHSave.Attributes;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Ff7Remake.Data;
using KHSave.SaveEditor.Ff7Remake.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class EquipmentEntryModel : BaseNotifyPropertyChanged, SearchEngine.IName
    {
        private readonly int _arrayIndex;
        private readonly WeaponFound[] _weaponFound;
        private readonly MateriaEquipment _equipment;
        private readonly MateriaViewModel _materiaVm;

        public EquipmentEntryModel(int index, WeaponFound[] weaponFound, MateriaEquipment equipment, MateriaViewModel vm)
        {
            _arrayIndex = index;
            _weaponFound = weaponFound;
            _equipment = equipment;
            _materiaVm = vm;
            EquipmentType = ItemModel.GetItemModels();
            CharacterTypes = new KhEnumListModel<CharacterType>(() => Character, x => Character = x);
        }

        private bool IsWeapon => _arrayIndex >= 0; // 8

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public Visibility AsWeaponVisibility => IsWeapon ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ItemTypeVisibility => Global.IsAdvancedMode || Character == CharacterType.None ? Visibility.Visible : Visibility.Collapsed;
        public bool IsVisible => Global.IsAdvancedMode || Character <= CharacterType.Red13 || Character == CharacterType.None;

        public IEnumerable<ItemModel> EquipmentType { get; }
        public KhEnumListModel<CharacterType> CharacterTypes { get; }
        public ObservableCollection<MateriaEntryModel> Materia => _materiaVm.Items;

        public string Name
        {
            get
            {
                if (Character != CharacterType.None)
                    return InfoAttribute.GetInfo(Character);

                var type = ItemId;
                if (type < 0)
                    return "<no equipment>";

                return ItemsPreset.Get(ItemId)?.Name;
            }
        }

        public ImageSource Icon
        {
            get
            {
                string iconName;
                switch (Character)
                {
                    case CharacterType.Cloud:
                        iconName = "WeaponCloud";
                        break;
                    case CharacterType.Barret:
                        iconName = "WeaponBarret";
                        break;
                    case CharacterType.Tifa:
                        iconName = "WeaponTifa";
                        break;
                    case CharacterType.Aerith:
                        iconName = "WeaponAerith";
                        break;
                    case CharacterType.Red13:
                        iconName = "Weapon";
                        break;
                    case CharacterType.Yuffie:
                        iconName = "WeaponYuffie";
                        break;
                    case CharacterType.Sonon:
                        iconName = "WeaponSonon";
                        break;
                    case CharacterType.None:
                        if (ItemId > 0)
                            iconName = ItemsPreset.Get(ItemId)?.Icon;
                        else
                            iconName = null;
                        break;
                    default:
                        iconName = null;
                        break;
                }

                return IconService.Icon(iconName);
            }
        }

        private WeaponFound WeaponFound => _weaponFound[_arrayIndex];

        public int Index
        {
            get => IsWeapon ? WeaponFound.Index : -1;
            set
            {
                WeaponFound.Index = value;
                OnPropertyChanged();
            }
        }

        public ImageSource MateriaIcon1 => GetMateriaIcon(0);
        public ImageSource MateriaIcon2 => GetMateriaIcon(1);
        public ImageSource MateriaIcon3 => GetMateriaIcon(2);
        public ImageSource MateriaIcon4 => GetMateriaIcon(3);
        public ImageSource MateriaIcon5 => GetMateriaIcon(4);
        public ImageSource MateriaIcon6 => GetMateriaIcon(5);
        public ImageSource MateriaIcon7 => GetMateriaIcon(6);
        public ImageSource MateriaIcon8 => GetMateriaIcon(7);

        public CharacterType Character
        {
            get => (CharacterType)_equipment.Character;
            set
            {
                _equipment.Character = (byte)value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Icon));
            }
        }

        public int ItemId
        {
            get => _equipment.ItemId;
            set
            {
                if (value <= 0)
                    Index = -1;
                else if (value > 0 && Index == -1)
                    Index = GetFirstEmptyIndexSlot();

                _equipment.ItemId = value;
                WeaponFound.ItemId = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Icon));
            }
        }

        public int MateriaSlot1 { get => _equipment.MateriaIndex[0] + 1; set { _equipment.MateriaIndex[0] = value - 1; OnPropertyChanged(nameof(MateriaIcon1)); } }
        public int MateriaSlot2 { get => _equipment.MateriaIndex[1] + 1; set { _equipment.MateriaIndex[1] = value - 1; OnPropertyChanged(nameof(MateriaIcon2)); } }
        public int MateriaSlot3 { get => _equipment.MateriaIndex[2] + 1; set { _equipment.MateriaIndex[2] = value - 1; OnPropertyChanged(nameof(MateriaIcon3)); } }
        public int MateriaSlot4 { get => _equipment.MateriaIndex[3] + 1; set { _equipment.MateriaIndex[3] = value - 1; OnPropertyChanged(nameof(MateriaIcon4)); } }
        public int MateriaSlot5 { get => _equipment.MateriaIndex[4] + 1; set { _equipment.MateriaIndex[4] = value - 1; OnPropertyChanged(nameof(MateriaIcon5)); } }
        public int MateriaSlot6 { get => _equipment.MateriaIndex[5] + 1; set { _equipment.MateriaIndex[5] = value - 1; OnPropertyChanged(nameof(MateriaIcon6)); } }
        public int MateriaSlot7 { get => _equipment.MateriaIndex[6] + 1; set { _equipment.MateriaIndex[6] = value - 1; OnPropertyChanged(nameof(MateriaIcon7)); } }
        public int MateriaSlot8 { get => _equipment.MateriaIndex[7] + 1; set { _equipment.MateriaIndex[7] = value - 1; OnPropertyChanged(nameof(MateriaIcon8)); } }

        private ImageSource GetMateriaIcon(int index)
        {
            var materiaId = _equipment.MateriaIndex[index];
            if (materiaId < 0)
                return null;

            var materia = Materia.FirstOrDefault(x => x.Index - 1 == materiaId);
            return materia?.Icon;
        }

        private int GetFirstEmptyIndexSlot()
        {
            var lastIndex = 8;

            foreach (var weapon in _weaponFound
                .Where(x => x.Index >= lastIndex)
                .OrderBy(x => x.Index))
            {
                if (weapon.Index == lastIndex)
                    lastIndex = weapon.Index + 1;
                else
                    return lastIndex;
            }

            return lastIndex;
        }
    }
}
