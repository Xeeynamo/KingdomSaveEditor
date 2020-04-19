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
using KHSave.SaveEditor.Common.Services;
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

        public InventroyEntryModel(SaveFf7Remake save, int index, Inventory inventory)
        {
            _inventory = inventory;
        }

        public string Name => InfoAttribute.GetInfo(Type);
        public ImageSource Icon => IconService.Icon(Type);

        public uint Id { get => _inventory.UnixTimestamp; set => _inventory.UnixTimestamp = value; }
        public int Unknown04 { get => _inventory.Unknown04; set => _inventory.Unknown04 = value; }
        public int Count { get => _inventory.Count; set => _inventory.Count = value; }
        public InventoryType Type
        {
            get => (InventoryType)_inventory.Type;
            set
            {
                _inventory.Type = (int)value;
                OnPropertyChanged(nameof(Icon));
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Unknown10 { get => _inventory.Unknown10; set => _inventory.Unknown10 = value; }
        public int Unknown14 { get => _inventory.Unknown14; set => _inventory.Unknown14 = value; }
    }
}
