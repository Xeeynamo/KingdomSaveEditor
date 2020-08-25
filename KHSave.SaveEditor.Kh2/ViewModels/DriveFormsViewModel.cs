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
using KHSave.Lib2;
using KHSave.Lib2.Models;
using KHSave.Lib2.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Kh2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class DriveFormViewModel : BaseNotifyPropertyChanged
    {
        private static readonly KeyValuePair<EquipmentType, string>[] _abilityTypes =
            new KeyValuePair<EquipmentType, string>[]
            {
                new KeyValuePair<EquipmentType, string>(EquipmentType.Empty, "Empty")
            }
            .Concat(
                Enum.GetValues(typeof(EquipmentType))
                    .Cast<EquipmentType>()
                    .Where(x => InfoAttribute.GetItemTypes(x).Any(v => v == "Ability"))
                    .Select(x => new KeyValuePair<EquipmentType, string>(x, InfoAttribute.GetInfo(x)))
            ).ToArray();

        private readonly IDriveForm _driveForm;
        private readonly DriveFormType _type;

        public DriveFormViewModel(IDriveForm driveForm, DriveFormType type)
        {
            _driveForm = driveForm;
            _type = type;
            Weapon = new ItemComboBoxModel<EquipmentType>(() => _driveForm.Weapon, x => _driveForm.Weapon = x);
            Abilities = _driveForm.Abilities.Select((_, i) => new AbilityModel(i, _driveForm.Abilities)).ToList();
        }

        public IEnumerable<KeyValuePair<EquipmentType, string>> AbilityTypes => _abilityTypes;
        public ItemComboBoxModel<EquipmentType> Weapon { get; }

        public string Name => _type.ToString();
        public byte Level { get => _driveForm.Level; set => _driveForm.Level = value; }
        public int Experience { get => _driveForm.Experience; set => _driveForm.Experience = value; }
        public List<AbilityModel> Abilities { get; set; }
    }

    public class DriveFormsViewModel : GenericListModel<DriveFormViewModel>
    {
        private readonly ISaveKh2 save;

        public DriveFormsViewModel(ISaveKh2 save) :
            this(save.DriveForms.Select((x, index) => new DriveFormViewModel(x, GetDriveFormType(index, save.IsFinalMix))))
        {
            this.save = save;
        }

        public DriveFormsViewModel(IEnumerable<DriveFormViewModel> list) :
            base(list)
        {

        }

        public Visibility Visible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility NotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(DriveFormViewModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(Visible));
            OnPropertyChanged(nameof(NotVisible));
        }

        protected override DriveFormViewModel OnNewItem()
        {
            throw new System.NotImplementedException();
        }

        private static DriveFormType GetDriveFormType(int index, bool isFinalMix)
        {
            if (!isFinalMix && index >= (int)DriveFormType.Limit)
                index++;

            return (DriveFormType)index;
        }
    }
}
