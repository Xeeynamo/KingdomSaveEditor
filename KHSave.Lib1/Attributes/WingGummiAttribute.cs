using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class WingGummiAttribute : GummiBlockAttribute
    {
        public int Handling { get; set; }
        public WingGummiAttribute(string info, int sizeX, int sizeY, int sizeZ, int armor, int max, int handling,
            int price = 0, int sell = 0, string description = null) : base(info, sizeX, sizeY, sizeZ,
                armor, max, price, sell, description)
        {
            Handling = handling;
        }
    }
}
