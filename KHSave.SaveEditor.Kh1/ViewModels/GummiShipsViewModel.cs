using KHSave.Lib1;
using KHSave.Lib1.Models;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class GummiShipsViewModel : GenericListModel<GummiShipViewModel>
    {
        public GummiShipsViewModel(Gummiship[] gummiships) :
            base(gummiships.Select(x => new GummiShipViewModel(x)))
        {

        }
    }
}
