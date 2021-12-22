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
            this(save.Chapters.Select((x, i) => new ChapterEntryModel(x, i, x.Positions[0])))
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
            return chapterNumber switch
            {
                1 => 0,
                2 => 1,
                3 => 2,
                4 => 3,
                5 => 4,
                6 => 5,
                7 => 6,
                8 => 8,
                9 => 8,
                10 => 9,
                11 => 10,
                12 => 2,
                13 => 8,
                14 => 8,
                15 => 15,
                16 => 16,
                17 => 16,
                18 => 16,
                22 => 18,
                23 => 19,
                _ => -1,
            };
        }
    }
}
