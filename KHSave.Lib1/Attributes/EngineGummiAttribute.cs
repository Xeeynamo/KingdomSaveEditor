using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class EngineGummiAttribute : GummiBlockAttribute
    {
        public int TopSpeed { get; set; }
        public int LowSpeed { get; set; }
        public int Horsepower { get; set; }

        public EngineGummiAttribute(string info, int sizeX, int sizeY, int sizeZ, int armor, int max, int topSpeed, int lowSpeed,
            int horsepower, int price = 0, int sell = 0, string description = null) : base(info, sizeX, sizeY, sizeZ,
                armor, max, price, sell, description)
        {
            TopSpeed = topSpeed;
            LowSpeed = lowSpeed;
            Horsepower = horsepower;
        }
    }
}
