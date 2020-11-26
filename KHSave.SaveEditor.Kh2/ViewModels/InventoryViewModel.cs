using KHSave.Lib2;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Kh2.Models;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class InventoryViewModel : GenericListModel<InventoryItemModel>
    {
        private string _searchTerm;

        public InventoryViewModel(ISaveKh2 save) :
            base(save.InventoryCount.Select((_, i) => new InventoryItemModel(i, save.InventoryCount)))
        {

        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                Filter(items => SearchEngine.Filter(_searchTerm, items).OrderBy(x => (uint)x.Type));
            }
        }
    }
}
