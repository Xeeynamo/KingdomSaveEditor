using KHSave.Lib1;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Kh1.Models;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class InventoryViewModel : GenericListModel<InventoryItemModel>
    {
        private string _searchTerm;

        public InventoryViewModel(ISaveKh1 save) :
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
