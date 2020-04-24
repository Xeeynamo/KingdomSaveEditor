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
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class GlobalViewModel
    {
        private readonly SaveFf7Remake _save;

        public GlobalViewModel(SaveFf7Remake save)
        {
            _save = save;
            CharacterType = new KhEnumListModel<CharacterType>();
        }

        public KhEnumListModel<CharacterType> CharacterType { get; }

        public CharacterType PlayableCharacter { get => (CharacterType)_save.PlayableCharacter; set => _save.PlayableCharacter = (byte)value; }
        public byte CurrentChapterId { get => _save.CurrentChapterId; set => _save.CurrentChapterId = value; }
    }
}
