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
using KHSave.LibFf7Remake.Chunks;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Ff7Remake.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class ChapterEntryModel : BaseNotifyPropertyChanged
    {
        private readonly ChunkChapter _chapter;
        private readonly int _index;

        public ChapterEntryModel(ChunkChapter chapter, int index)
        {
            _chapter = chapter;
            _index = index;
            CharacterStatusTypes = new KhEnumListModel<CharacterStatusType>(() => default, x => { });
            Objects = new Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry>(
                chapter.Objects.Select(x => new ChapterObjectEntry(x)));
        }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public KhEnumListModel<CharacterStatusType> CharacterStatusTypes { get; }

        public bool IsChapterEnabled => !(_chapter.CharacterStatus?.All(x => x == 0) ?? true);
        public Visibility ChapterVisibility => IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ChapterDisabledVisibility => !IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;

        public string Name
        {
            get
            {
                if (_index == SaveFf7Remake.ChapterCount)
                    return "Current?";

                switch (_index)
                {
                    case 0: return "Chapter 1";
                    case 1: return "Chapter 2";
                    case 2: return "Chapter 3,12";
                    case 3: return "Chapter 4";
                    case 4: return "Chapter 5";
                    case 5: return "Chapter 6";
                    case 6: return "Chapter 7";
                    case 7: return "Unused";
                    case 8: return "Ch. 8,9,13,14";
                    case 9: return "Ch. 10";
                    case 10: return "Ch. 11";
                    case 11: return "Unused";
                    case 12: return "Unused";
                    case 13: return "?????";
                    case 14: return "Unused";
                    case 15: return "Chapter 15";
                    case 16: return "Ch. 16,17,18";
                    case 17: return "Unused";
                    default: return $"Chapter ID {_index}";
                }
            }
        }

        public IEnumerable<BgmModel> BgmList => BgmPreset.Get();
        public bool IsChapterInPlay { get => _chapter.IsChapterInPlay != 0; set => _chapter.IsChapterInPlay = (byte)(value ? 1 : 0); }
        public byte ChapterId { get => _chapter.ChapterId; set => _chapter.ChapterId = value; }
        public int Bgm { get => _chapter.Bgm; set { _chapter.Bgm = (ushort)value; OnPropertyChanged(); } }

        public ChapterCharacterEntryModel Entity0 => new ChapterCharacterEntryModel(_chapter, 0);
        public ChapterCharacterEntryModel Entity1 => new ChapterCharacterEntryModel(_chapter, 1);
        public ChapterCharacterEntryModel Entity2 => new ChapterCharacterEntryModel(_chapter, 2);
        public ChapterCharacterEntryModel Entity3 => new ChapterCharacterEntryModel(_chapter, 3);
        public ChapterCharacterEntryModel Entity4 => new ChapterCharacterEntryModel(_chapter, 4);
        public ChapterCharacterEntryModel Entity5 => new ChapterCharacterEntryModel(_chapter, 5);
        public ChapterCharacterEntryModel Entity6 => new ChapterCharacterEntryModel(_chapter, 6);
        public ChapterCharacterEntryModel Entity7 => new ChapterCharacterEntryModel(_chapter, 7);
        public ChapterCharacterEntryModel Entity8 => new ChapterCharacterEntryModel(_chapter, 8);
        public ChapterCharacterEntryModel Entity9 => new ChapterCharacterEntryModel(_chapter, 9);
        public ChapterCharacterEntryModel Entity10 => new ChapterCharacterEntryModel(_chapter, 10);
        public ChapterCharacterEntryModel Entity11 => new ChapterCharacterEntryModel(_chapter, 11);

        public Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry> Objects { get; }
    }
}
