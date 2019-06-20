using System.Collections.Generic;

namespace KHSave.Lib3.Presets
{
    public static partial class Presets
    {
        public class Pawn
        {
            public string Name { get; set; }
        }

        public static readonly Dictionary<string, Pawn> PAWNS = new Dictionary<string, Pawn>
        {
            ["p_ex001"] = new Pawn { Name = "Sora (KH3)" },
            ["p_ex002"] = new Pawn { Name = "Aqua" },
            ["p_ex003"] = new Pawn { Name = "Riku (KH2)" },
            ["p_ex004"] = new Pawn { Name = "Riku (KH3)" },
            ["p_ex005"] = new Pawn { Name = "Sora (KH1)" },
            ["p_ex011"] = new Pawn { Name = "Sora (KH2)" },
        };
    }
}
