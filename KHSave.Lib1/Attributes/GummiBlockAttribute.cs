using KHSave.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class GummiBlockAttribute : InfoAttribute
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
        public int Armor { get; set; }
        public int Max { get; set; }
        public int Price { get; set; }
        public int Sell { get; set; }
        public string Description { get; set; }

        public GummiBlockAttribute(string info, int sizeX, int sizeY, int sizeZ, int armor, int max,
            int price = 0, int sell = 0, string description = null) : base(info)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
            Armor = armor;
            Max = max;
            Price = price;
            Sell = sell;
            Description = description;
        }
    }
}
