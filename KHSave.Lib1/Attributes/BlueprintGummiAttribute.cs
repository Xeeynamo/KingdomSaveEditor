using KHSave.Attributes;
using KHSave.Lib1.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Lib1.Attributes
{
    public class BlueprintGummiAttribute : InfoAttribute
    {
        public GameTypes GameType { get; set; }
        public BlueprintGummiAttribute(string info, GameTypes gameType): base(info)
        {
            GameType = gameType;
        }
    }
}
