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
    public class ChaptersViewModel : GenericListModel<ChapterEntryModel>
    {
        public ChaptersViewModel(SaveFf7Remake save) :
            this(save.Chapters.Select((x, i) => new ChapterEntryModel(x, i)))
        {
            CurrentChapterId = GetChapterIdFromChapterNumber(save.CurrentChapter);
        }

        private ChaptersViewModel(IEnumerable<ChapterEntryModel> list) :
            base(list)
        { }

        public int CurrentChapterId { get; }
        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(ChapterEntryModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }

        protected override ChapterEntryModel OnNewItem() =>
            throw new System.NotImplementedException();

        private static int GetChapterIdFromChapterNumber(int chapterNumber)
        {
            switch (chapterNumber)
            {
                case 1: return 0;
                case 2: return 1;
                case 3: return 2;
                case 4: return 3;
                case 5: return 4;
                case 6: return 5;
                case 7: return 6;
                case 8: return 8;
                case 9: return 8;
                case 10: return 9;
                case 11: return 10;
                case 12: return 2;
                case 13: return 8;
                case 14: return 8;
                case 15: return 15;
                case 16: return 16;
                case 17: return 16;
                case 18: return 16;
                default: return -1;
            }
        }
    }
}
