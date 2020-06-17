using KHSave.Lib1;
using KHSave.Lib1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class GummiShipViewModel
    {
        private readonly Gummiship gummiship;
        private readonly int index;

        public GummiShipViewModel(Gummiship gummiship, int index)
        {
            this.gummiship = gummiship;
            this.index = index;
        }


        public byte[] Name { get => gummiship.ShipName; }
        public byte BlocksUsed { get => gummiship.BlocksUsed; }

    }
}
