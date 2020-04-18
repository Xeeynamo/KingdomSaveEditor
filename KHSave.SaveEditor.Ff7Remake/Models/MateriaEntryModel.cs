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

using KHSave.Extensions;
using KHSave.LibFf7Remake;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Services;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class MateriaEntryModel :
        BaseNotifyPropertyChanged,
        SearchEngine.IName
    {
        private SaveFf7Remake save;
        private int _index;
        private Materia _materia;

        public MateriaEntryModel(SaveFf7Remake save, int index, Materia materia)
        {
            this.save = save;
            _index = index;
            _materia = materia;

            ItemType = new KhEnumListModel<EnumIconTypeModel<InventoryType>, InventoryType>(() => Type, x => Type = x);
            CharacterType = new KhEnumListModel<CharacterType>(() => Character, x => Character = x);
        }

        public KhEnumListModel<EnumIconTypeModel<InventoryType>, InventoryType> ItemType { get; }
        public KhEnumListModel<CharacterType> CharacterType { get; }

        public string Name => Attributes.InfoAttribute.GetInfo(Type);
        public ImageSource Icon => IconService.Icon(Type);

        public InventoryType Type
        {
            get => _materia.Type;
            set
            {
                _materia.Type = value;
                OnPropertyChanged(nameof(Icon));
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Timestamp => _materia.UnixTimestamp.FromUnixEpoch().ToString();
        public int AbilityPoint { get => _materia.AbilityPoint; set => _materia.AbilityPoint = value; }
        public byte Level { get => _materia.Level; set => _materia.Level = value; }
        public CharacterType Character { get => (CharacterType)_materia.Character; set => _materia.Character = (byte)value; }
    }
}
