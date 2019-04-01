using KHSave.SaveEditor.Kh02.ViewModels;
using KHSave.Trssv;
using KHSave.Trssv.Models;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh02.Models
{
    public class SlotListModel : GenericListModel<SlotViewModel>
    {
        public SlotListModel(SaveKh02 save) :
            this(save.Slots)
        { }

        public SlotListModel(IEnumerable<Slot> slots) :
            this(slots.Select((x, i) => new SlotViewModel(i, x)))
        { }

        public SlotListModel(IEnumerable<SlotViewModel> slots) :
            base(slots)
        { }

        protected override SlotViewModel OnNewItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
