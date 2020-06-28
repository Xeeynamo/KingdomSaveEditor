using KHSave.LibDDD.Model;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class DreamEatersViewModel : GenericListModel<DreamEaterViewModel>
    {
        public DreamEatersViewModel(DreamEater[] dreamEaters):
            base(dreamEaters.Select(x => new DreamEaterViewModel(x)))
        {

        }
    }
}
