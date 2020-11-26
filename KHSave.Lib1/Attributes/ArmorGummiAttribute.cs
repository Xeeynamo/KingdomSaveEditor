using KHSave.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class ArmorGummiAttribute : GummiBlockAttribute
    {
        public ArmorGummiAttribute(string info, int sizeX, int sizeY, int sizeZ, int armor, int max,
            int price = 0, int sell = 0, string description = null) : base(info, sizeX, sizeY, sizeZ,
                armor, max, price, sell, description)
        {

        }
    }
}
