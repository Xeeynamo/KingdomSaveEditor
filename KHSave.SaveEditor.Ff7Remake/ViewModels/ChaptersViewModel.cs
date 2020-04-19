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
        }

        private ChaptersViewModel(IEnumerable<ChapterEntryModel> list) :
            base(list)
        { }

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
    }
}
