using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class WeaponGummiAttribute : GummiBlockAttribute
    {
        public int Power { get; set; }
        public float PowerUse { get; set; }
        public WeaponGummiAttribute(string info, int sizeX, int sizeY, int sizeZ, int armor, int max, int power, float powerUse,
            int price = 0, int sell = 0, string description = null) : base(info, sizeX, sizeY, sizeZ,
                armor, max, price, sell, description)
        {
            Power = power;
            PowerUse = powerUse;
        }
    }
}
