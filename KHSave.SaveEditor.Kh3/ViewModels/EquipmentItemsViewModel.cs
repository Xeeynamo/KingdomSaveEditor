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
using System.Collections.Generic;
using KHSave.Lib3.Models;
using KHSave.SaveEditor.Kh3.Models;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
    public class EquipmentItemsViewModel<T>
        where T : struct, IConvertible
    {
        public EquipmentItemEntryViewModel<T> Item1 { get; }
        public EquipmentItemEntryViewModel<T> Item2 { get; }
        public EquipmentItemEntryViewModel<T> Item3 { get; }
        public EquipmentItemEntryViewModel<T> Item4 { get; }
        public EquipmentItemEntryViewModel<T> Item5 { get; }
        public EquipmentItemEntryViewModel<T> Item6 { get; }
        public EquipmentItemEntryViewModel<T> Item7 { get; }
        public EquipmentItemEntryViewModel<T> Item8 { get; }

        public EquipmentItemsViewModel(IReadOnlyList<EquipmentItem> items)
        {
            Item1 = new EquipmentItemEntryViewModel<T>(items[0]);
            Item2 = new EquipmentItemEntryViewModel<T>(items[1]);
            Item3 = new EquipmentItemEntryViewModel<T>(items[2]);
            Item4 = new EquipmentItemEntryViewModel<T>(items[3]);
            Item5 = new EquipmentItemEntryViewModel<T>(items[4]);
            Item6 = new EquipmentItemEntryViewModel<T>(items[5]);
            Item7 = new EquipmentItemEntryViewModel<T>(items[6]);
            Item8 = new EquipmentItemEntryViewModel<T>(items[7]);
        }
    }

    public class EquipmentItemsViewModel
    {
        public EquipmentItemEntryViewModel Item1 { get; }
        public EquipmentItemEntryViewModel Item2 { get; }
        public EquipmentItemEntryViewModel Item3 { get; }
        public EquipmentItemEntryViewModel Item4 { get; }
        public EquipmentItemEntryViewModel Item5 { get; }
        public EquipmentItemEntryViewModel Item6 { get; }
        public EquipmentItemEntryViewModel Item7 { get; }
        public EquipmentItemEntryViewModel Item8 { get; }

        public EquipmentItemsViewModel(IReadOnlyList<EquipmentItem> items)
        {
            Item1 = new EquipmentItemEntryViewModel(items[0]);
            Item2 = new EquipmentItemEntryViewModel(items[1]);
            Item3 = new EquipmentItemEntryViewModel(items[2]);
            Item4 = new EquipmentItemEntryViewModel(items[3]);
            Item5 = new EquipmentItemEntryViewModel(items[4]);
            Item6 = new EquipmentItemEntryViewModel(items[5]);
            Item7 = new EquipmentItemEntryViewModel(items[6]);
            Item8 = new EquipmentItemEntryViewModel(items[7]);
        }
    }
}
