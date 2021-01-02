using KHSave.Lib1;
using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class GummiShipViewModel : BaseNotifyPropertyChanged
    {
        private readonly Gummiship gummiship;

        public GummiShipViewModel(Gummiship gummiship)
        {
            this.gummiship = gummiship;
            new GummiBlocksViewModel(gummiship.GummiBlocks);
        }

        public byte[] Name { get => gummiship.ShipName; set => gummiship.ShipName = value; }
        public byte BlocksUsed { get => gummiship.BlocksUsed; set => gummiship.BlocksUsed = value; }

    }
}
