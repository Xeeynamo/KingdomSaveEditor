using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class SpecialGummiAttribute : GummiBlockAttribute
    {
        public float EnergyUse { get; set; }
        public SpecialGummiAttribute(string info, int sizeX, int sizeY, int sizeZ, int armor, int max, float energyUse,
            int price = 0, int sell = 0, string description = null) : base(info, sizeX, sizeY, sizeZ,
                armor, max, price, sell, description)
        {
            EnergyUse = energyUse;
        }
    }
}
