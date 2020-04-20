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

using KHSave.LibFf7Remake.Chunks;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common.Models;
using System.Linq;
using System.Windows;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class ChapterEntryModel
    {
        private readonly ChunkChapter _chapter;
        private readonly int _index;

        public ChapterEntryModel(ChunkChapter chapter, int index)
        {
            _chapter = chapter;
            _index = index;
            CharacterStatusTypes = new KhEnumListModel<CharacterStatusType>(() => default, x => { });
        }

        public KhEnumListModel<CharacterStatusType> CharacterStatusTypes { get; }

        public bool IsChapterEnabled => !(_chapter.CharacterStatus?.All(x => x == 0) ?? true);
        public Visibility ChapterVisibility => IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ChapterDisabledVisibility => !IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;

        public string Name => $"Chapter {_index + 1}";

        public bool IsChapterInPlay { get => _chapter.IsChapterInPlay != 0; set => _chapter.IsChapterInPlay = (byte)(value ? 1 : 0); }
        public byte ChapterId { get => (byte)(_chapter.ChapterId + 1); set => _chapter.ChapterId = (byte)(value - 1); }
        public ushort Bgm { get => _chapter.Bgm; set => _chapter.Bgm = value; }

        public CharacterStatusType PartyMember0 { get => _chapter.CharacterStatus[0]; set => _chapter.CharacterStatus[0] = value; }
        public CharacterStatusType PartyMember1 { get => _chapter.CharacterStatus[1]; set => _chapter.CharacterStatus[1] = value; }
        public CharacterStatusType PartyMember2 { get => _chapter.CharacterStatus[2]; set => _chapter.CharacterStatus[2] = value; }
        public CharacterStatusType PartyMember3 { get => _chapter.CharacterStatus[3]; set => _chapter.CharacterStatus[3] = value; }
        public CharacterStatusType PartyMember4 { get => _chapter.CharacterStatus[4]; set => _chapter.CharacterStatus[4] = value; }
        public CharacterStatusType PartyMember5 { get => _chapter.CharacterStatus[5]; set => _chapter.CharacterStatus[5] = value; }
        public CharacterStatusType PartyMember6 { get => _chapter.CharacterStatus[6]; set => _chapter.CharacterStatus[6] = value; }
        public CharacterStatusType PartyMember7 { get => _chapter.CharacterStatus[7]; set => _chapter.CharacterStatus[7] = value; }

        public PositionModel Entity0 => new PositionModel(_chapter.Positions[0]);
        public PositionModel Entity1 => new PositionModel(_chapter.Positions[1]);
        public PositionModel Entity2 => new PositionModel(_chapter.Positions[2]);
        public PositionModel Entity3 => new PositionModel(_chapter.Positions[3]);
        public PositionModel Entity4 => new PositionModel(_chapter.Positions[4]);
        public PositionModel Entity5 => new PositionModel(_chapter.Positions[5]);
        public PositionModel Entity6 => new PositionModel(_chapter.Positions[6]);
        public PositionModel Entity7 => new PositionModel(_chapter.Positions[7]);
        public PositionModel Entity8 => new PositionModel(_chapter.Positions[8]);
        public PositionModel Entity9 => new PositionModel(_chapter.Positions[9]);
        public PositionModel Entity10 => new PositionModel(_chapter.Positions[10]);
        public PositionModel Entity11 => new PositionModel(_chapter.Positions[11]);
    }
}
