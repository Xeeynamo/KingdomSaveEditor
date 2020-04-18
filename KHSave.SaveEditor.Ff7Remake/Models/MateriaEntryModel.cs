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
        }

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

        public int Id { get => _materia.Id; set => _materia.Id = value; }
        public string Timestamp => _materia.UnixTimestamp.FromUnixEpoch().ToString();
        public int AbilityPoint { get => _materia.AbilityPoint; set => _materia.AbilityPoint = value; }
        public byte Unknown00 { get => _materia.Unknown00; set => _materia.Unknown00 = value; }
        public byte Unknown01 { get => _materia.Unknown01; set => _materia.Unknown01 = value; }
        public byte Unknown02 { get => _materia.Unknown02; set => _materia.Unknown02 = value; }
        public int Unknown0c { get => _materia.Unknown0c; set => _materia.Unknown0c = value; }
        public int Unknown14 { get => _materia.Unknown14; set => _materia.Unknown14 = value; }
        public int Unknown1c { get => _materia.Unknown1c; set => _materia.Unknown1c = value; }
    }
}
