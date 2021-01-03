using KHSave.Lib1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class GummiBlocksViewModel : GenericListModel<GummiBlockViewModel>
    {
        public GummiBlocksViewModel(GummiBlock[] gummiBlocks) :
            base(gummiBlocks.Select(x => new GummiBlockViewModel(x)))
        {

        }
    }
}
