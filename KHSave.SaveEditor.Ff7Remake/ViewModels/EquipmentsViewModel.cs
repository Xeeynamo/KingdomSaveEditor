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

using KHSave.LibFf7Remake;
using KHSave.SaveEditor.Ff7Remake.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class EquipmentsViewModel : GenericListModel<EquipmentEntryModel>
    {
        private readonly SaveFf7Remake _save;

        public EquipmentsViewModel(SaveFf7Remake save, MateriaViewModel materiaVm) :
            this(save.Equipments.Select((x, i) => new EquipmentEntryModel(save, x, materiaVm)))
        {
            _save = save;
        }

        private EquipmentsViewModel(IEnumerable<EquipmentEntryModel> list) :
            base(list)
        { }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(EquipmentEntryModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }

        protected override EquipmentEntryModel OnNewItem() =>
            throw new System.NotImplementedException();
    }
}
