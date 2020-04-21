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
using KHSave.LibFf7Remake;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Ff7Remake.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class EquipmentEntryModel : BaseNotifyPropertyChanged, SearchEngine.IName
    {
        private readonly MateriaEquipment _equipment;
        private readonly MateriaViewModel _materiaVm;

        public EquipmentEntryModel(MateriaEquipment equipment, MateriaViewModel vm)
        {
            _equipment = equipment;
            _materiaVm = vm;
            EquipmentType = new KhEnumListModel<EnumIconTypeModel<InventoryType>, InventoryType>(() => Type, x => Type = x);
            CharacterTypes = new KhEnumListModel<CharacterType>(() => Character, x => Character = x);
        }
        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public KhEnumListModel<EnumIconTypeModel<InventoryType>, InventoryType> EquipmentType { get; }
        public KhEnumListModel<CharacterType> CharacterTypes { get; }
        public ObservableCollection<MateriaEntryModel> Materia => _materiaVm.Items;

        public string Name
        {
            get
            {
                if (Character != KHSave.LibFf7Remake.Types.CharacterType.Unequip)
                    return InfoAttribute.GetInfo(Character);

                var type = Type;
                if (type < 0)
                    return "<no equipment>";

                return InfoAttribute.GetInfo(type);
            }
        }
        public ImageSource Icon
        {
            get
            {
                var type = Type;
                if (type < 0)
                    return null;

                return IconService.Icon(Type);
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

        public InventoryType Type
        {
            get => (InventoryType)_equipment.ItemId;
            set
            {
                _equipment.ItemId = (int)value;
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
    }
}
