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
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class Unknown3ViewModel : BaseNotifyPropertyChanged
    {
        private readonly SaveFf7Remake _save;
        private int _selectedIndex;

        public Unknown3ViewModel(SaveFf7Remake save)
        {
            _save = save;
            CharacterTypes = new KhEnumListModel<CharacterType>();
        }

        public KhEnumListModel<CharacterType> CharacterTypes { get; }

        public IEnumerable<int> Items => _save.ChunkCommon.UnknownStructure3.Select((_, i) => i);
        public bool IsItemSelected => SelectedIndex >= 0;
        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(IsItemSelected));
                OnPropertyChanged(nameof(Character));
                OnPropertyChanged(nameof(Unknown01));
                OnPropertyChanged(nameof(Unknown02));
                OnPropertyChanged(nameof(Unknown03));
                OnPropertyChanged(nameof(Unknown04));
                OnPropertyChanged(nameof(Unknown08));
                OnPropertyChanged(nameof(Unknown0c));
                OnPropertyChanged(nameof(Unknown10));
                OnPropertyChanged(nameof(Character1));
                OnPropertyChanged(nameof(Character2));
                OnPropertyChanged(nameof(Character3));
                OnPropertyChanged(nameof(Character4));
                OnPropertyChanged(nameof(Character5));
                OnPropertyChanged(nameof(Character6));
                OnPropertyChanged(nameof(Character7));
                OnPropertyChanged(nameof(Character8));
                OnPropertyChanged(nameof(Character9));
                OnPropertyChanged(nameof(Character10));
                OnPropertyChanged(nameof(Character11));
                OnPropertyChanged(nameof(Character12));
                OnPropertyChanged(nameof(Unknown20));
                OnPropertyChanged(nameof(Unknown24));
                OnPropertyChanged(nameof(Unknown28));
                OnPropertyChanged(nameof(Unknown2c));
            }
        }

        public UnknownStructure3 SelectedValue => _save.ChunkCommon.UnknownStructure3[_selectedIndex];

        public CharacterType Character { get => (CharacterType)SelectedValue.Character; set => SelectedValue.Character = (byte)value; }
        public byte Unknown01 { get => SelectedValue.Unknown01; set => SelectedValue.Unknown01 = value; }
        public byte Unknown02 { get => SelectedValue.Unknown02; set => SelectedValue.Unknown02 = value; }
        public byte Unknown03 { get => SelectedValue.Unused03; set => SelectedValue.Unused03 = value; }
        public int Unknown04 { get => SelectedValue.Unknown04; set => SelectedValue.Unknown04 = value; }
        public int Unknown08 { get => SelectedValue.Unknown08; set => SelectedValue.Unknown08 = value; }
        public int Unknown0c { get => SelectedValue.Unknown0c; set => SelectedValue.Unknown0c = value; }
        public int Unknown10 { get => SelectedValue.Unknown10; set => SelectedValue.Unknown10 = value; }
        public CharacterType Character1 { get => (CharacterType)SelectedValue.Characters[0]; set => SelectedValue.Characters[0] = (byte)value; }
        public CharacterType Character2 { get => (CharacterType)SelectedValue.Characters[1]; set => SelectedValue.Characters[1] = (byte)value; }
        public CharacterType Character3 { get => (CharacterType)SelectedValue.Characters[2]; set => SelectedValue.Characters[2] = (byte)value; }
        public CharacterType Character4 { get => (CharacterType)SelectedValue.Characters[3]; set => SelectedValue.Characters[3] = (byte)value; }
        public CharacterType Character5 { get => (CharacterType)SelectedValue.Characters[4]; set => SelectedValue.Characters[4] = (byte)value; }
        public CharacterType Character6 { get => (CharacterType)SelectedValue.Characters[5]; set => SelectedValue.Characters[5] = (byte)value; }
        public CharacterType Character7 { get => (CharacterType)SelectedValue.Characters[6]; set => SelectedValue.Characters[6] = (byte)value; }
        public CharacterType Character8 { get => (CharacterType)SelectedValue.Characters[7]; set => SelectedValue.Characters[7] = (byte)value; }
        public CharacterType Character9 { get => (CharacterType)SelectedValue.Characters[8]; set => SelectedValue.Characters[8] = (byte)value; }
        public CharacterType Character10 { get => (CharacterType)SelectedValue.Characters[9]; set => SelectedValue.Characters[9] = (byte)value; }
        public CharacterType Character11 { get => (CharacterType)SelectedValue.Characters[10]; set => SelectedValue.Characters[10] = (byte)value; }
        public CharacterType Character12 { get => (CharacterType)SelectedValue.Characters[11]; set => SelectedValue.Characters[11] = (byte)value; }
        public int Unknown20 { get => SelectedValue.Unused20; set => SelectedValue.Unused20 = value; }
        public int Unknown24 { get => SelectedValue.Unused24; set => SelectedValue.Unused24 = value; }
        public int Unknown28 { get => SelectedValue.Unused28; set => SelectedValue.Unused28 = value; }
        public int Unknown2c { get => SelectedValue.Unused2c; set => SelectedValue.Unused2c = value; }
    }
}
