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
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class GlobalViewModel : BaseNotifyPropertyChanged
    {
        private readonly SaveFf7Remake _save;

        public GlobalViewModel(SaveFf7Remake save)
        {
            _save = save;
            CharacterType = new KhEnumListModel<CharacterType>();
        }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public KhEnumListModel<CharacterType> CharacterType { get; }

        public CharacterType PlayableCharacter { get => (CharacterType)_save.PlayableCharacter; set => _save.PlayableCharacter = (byte)value; }
        public byte CurrentChapter
        {
            get => _save.CurrentChapter;
            set
            {
                switch (_save.CurrentChapter = value)
                {
                    case 1:
                        CurrentChapterId = 0;
                        CurrentChapterChunk = CurrentChapterChunk2 = 0;
                        break;
                    case 2:
                        CurrentChapterId = 1;
                        CurrentChapterChunk = CurrentChapterChunk2 = 1;
                        break;
                    case 3:
                        CurrentChapterId = 2;
                        CurrentChapterChunk = CurrentChapterChunk2 = 2;
                        break;
                    case 4:
                        CurrentChapterId = 3;
                        CurrentChapterChunk = CurrentChapterChunk2 = 3;
                        break;
                    case 5:
                        CurrentChapterId = 4;
                        CurrentChapterChunk = CurrentChapterChunk2 = 4;
                        break;
                    case 6:
                        CurrentChapterId = 5;
                        CurrentChapterChunk = CurrentChapterChunk2 = 5;
                        break;
                    case 7:
                        CurrentChapterId = 6;
                        CurrentChapterChunk = CurrentChapterChunk2 = 6;
                        break;
                    case 8:
                        CurrentChapterId = 8;
                        CurrentChapterChunk = CurrentChapterChunk2 = 8;
                        break;
                    case 9:
                        CurrentChapterId = 8;
                        CurrentChapterChunk = CurrentChapterChunk2 = 8;
                        break;
                    case 10:
                        CurrentChapterId = 9;
                        CurrentChapterChunk = CurrentChapterChunk2 = 9;
                        break;
                    case 11:
                        CurrentChapterId = 10;
                        CurrentChapterChunk = CurrentChapterChunk2 = 10;
                        break;
                    case 12:
                        CurrentChapterId = 11;
                        CurrentChapterChunk = CurrentChapterChunk2 = 2;
                        break;
                    case 13:
                        CurrentChapterId = 11;
                        CurrentChapterChunk = CurrentChapterChunk2 = 2;
                        break;
                    case 14:
                        CurrentChapterId = 12;
                        CurrentChapterChunk = CurrentChapterChunk2 = 8;
                        break;
                    case 15:
                        CurrentChapterId = 15;
                        CurrentChapterChunk = CurrentChapterChunk2 = 15;
                        break;
                    case 16:
                        CurrentChapterId = 16;
                        CurrentChapterChunk = CurrentChapterChunk2 = 16;
                        break;
                    case 17:
                        CurrentChapterId = 16;
                        CurrentChapterChunk = CurrentChapterChunk2 = 16;
                        break;
                    case 18:
                        CurrentChapterId = 16;
                        CurrentChapterChunk = CurrentChapterChunk2 = 16;
                        break;
                }

                OnPropertyChanged(nameof(CurrentChapterId));
                OnPropertyChanged(nameof(CurrentChapterChunk));
                OnPropertyChanged(nameof(CurrentChapterChunk2));
            }
        }
        public byte CurrentChapterId { get => _save.CurrentChapterId; set => _save.CurrentChapterId = value; }
        public byte CurrentChapterChunk { get => _save.CurrentChapterChunk; set => _save.CurrentChapterChunk = value; }
        public byte CurrentChapterChunk2 { get => _save.CurrentChapterChunk2; set => _save.CurrentChapterChunk2 = value; }

        public byte Unk01 { get => _save.ChunkCommon.Unk01; set => _save.ChunkCommon.Unk01 = value; }
        public byte Unk02 { get => _save.ChunkCommon.Unk02; set => _save.ChunkCommon.Unk02 = value; }
        public byte Unk03 { get => _save.ChunkCommon.Unk03; set => _save.ChunkCommon.Unk03 = value; }
        public byte Unk04 { get => _save.ChunkCommon.Unk04; set => _save.ChunkCommon.Unk04 = value; }
        public byte Unk05 { get => _save.ChunkCommon.Unk05; set => _save.ChunkCommon.Unk05 = value; }
        public int Unk288 { get => _save.ChunkCommon.Unk288; set => _save.ChunkCommon.Unk288 = value; }
        public int Unk28c { get => _save.ChunkCommon.Unk28c; set => _save.ChunkCommon.Unk28c = value; }
        public float Unk290 { get => _save.ChunkCommon.Unk290; set => _save.ChunkCommon.Unk290 = value; }
        public int Unk294 { get => _save.ChunkCommon.Unk294; set => _save.ChunkCommon.Unk294 = value; }
    }
}
