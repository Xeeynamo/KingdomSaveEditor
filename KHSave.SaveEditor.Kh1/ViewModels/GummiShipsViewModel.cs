using KHSave.Lib1;
using KHSave.Lib1.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class GummiShipsViewModel : GenericListModel<GummiShipViewModel>
    {
        public readonly ISaveKh1 save;
        public RelayCommand ExportCommand { get; }
        public RelayCommand ImportCommand { get; }

        public GummiShipsViewModel(ISaveKh1 save) : this(save.Gummiships)
        {
            this.save = save;
        }*/
        
        public GummiShipsViewModel(Gummiship[] gummiships) :
            base(gummiships.Select(x => new GummiShipViewModel(x)))
        {
            
        }

        public GummiShipsViewModel(IEnumerable<Gummiship> list) :
            this(list.Select((gummi, index) => new GummiShipViewModel(gummi, index)))
        {

        }

        public GummiShipsViewModel(IEnumerable<GummiShipViewModel> list) : base(list)
        {
            ExportCommand = new RelayCommand(o => );
        }

        protected override void OnSelectedItem(GummiShipViewModel item)
        {
            base.OnSelectedItem(item);
        }
    }
}
