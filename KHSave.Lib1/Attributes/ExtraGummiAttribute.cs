using KHSave.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class ExtraGummiAttribute : InfoAttribute
    {
        public int Max { get; set; }
        public int Price { get; set; }
        public int Sell { get; set; }
        public string Description { get; set; }

        public ExtraGummiAttribute(string info, int max, int price = 0, int sell = 0, string description = null) : base(info)
        {
            Max = max;
            Price = price;
            Sell = sell;
            Description = description;
        }
    }
}
