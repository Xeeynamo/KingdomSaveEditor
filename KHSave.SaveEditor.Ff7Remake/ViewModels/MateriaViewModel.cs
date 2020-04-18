using KHSave.LibFf7Remake;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Ff7Remake.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class MateriaViewModel : GenericListModel<MateriaEntryModel>
    {
        private readonly SaveFf7Remake _save;
        private string searchTerm;

        public MateriaViewModel(SaveFf7Remake save) :
            this(save.Materia.Select((x, i) => new MateriaEntryModel(save, i, x)))
        {
            _save = save;
        }

        private MateriaViewModel(IEnumerable<MateriaEntryModel> list) :
            base(list.OrderBy(Order))
        { }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                Filter(items => SearchEngine.Filter(searchTerm, items).OrderBy(Order));
            }
        }

        private static int Order(MateriaEntryModel materia)
        {
            if (materia.Type <= 0)
                return int.MaxValue;
            return (int)materia.Type;
        }

        protected override void OnSelectedItem(MateriaEntryModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }

        protected override MateriaEntryModel OnNewItem() =>
            throw new System.NotImplementedException();
    }
}
