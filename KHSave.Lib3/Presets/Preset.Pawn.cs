using System.Collections.Generic;

namespace KHSave.Lib3.Presets
{
    public static partial class Presets
    {
        public class Pawn
        {
            public string Name { get; set; }
        }

        public static readonly string PlayablePawnPath = "/Game/Blueprints/Player/{0}/{0}_Pawn.{0}_Pawn_C";
        public static readonly string NpcPawnPath = "/Game/Blueprints/Npc/{0}/{0}_Pawn.{0}_Pawn_C";
        public static readonly string EnemyPawnPath = "/Game/Blueprints/Enemy/{0}/{0}_Pawn.{0}_Pawn_C";

        public static readonly Dictionary<string, Pawn> PlayablePawns = new Dictionary<string, Pawn>
        {
            ["p_ex001"] = new Pawn { Name = "Sora (KH3)" },
            ["p_dl001"] = new Pawn { Name = "Sora (Shibuya)" },
            ["p_ex002"] = new Pawn { Name = "Aqua" },
            ["p_ex003"] = new Pawn { Name = "Riku (KH2)" },
            ["p_ex004"] = new Pawn { Name = "Riku (KH3)" },
            ["p_ex005"] = new Pawn { Name = "Sora (KH1)" },
            ["p_ex006"] = new Pawn { Name = "Kairi" },
            ["p_ex007"] = new Pawn { Name = "Roxas" },
            ["p_ex011"] = new Pawn { Name = "Sora (KH2)" },
            ["p_bx001"] = new Pawn { Name = "Sora (Baymax)" },
            ["p_ca001"] = new Pawn { Name = "Sora (Caribbean)" },
            ["p_ew001"] = new Pawn { Name = "Sora (Final World)" },
            ["p_mi001"] = new Pawn { Name = "Sora (Monstropolis)" },
            ["p_po001"] = new Pawn { Name = "Sora (100 Acre Wood)" },
            ["p_re001"] = new Pawn { Name = "Sora (Remy)" },
            ["p_ts001"] = new Pawn { Name = "Sora (Toy Story)" },
        };

        public static readonly Dictionary<string, Pawn> NpcPawns = new Dictionary<string, Pawn>
        {
            ["n_bt201"] = new Pawn { Name = "Young Xehanort (Chess)" },
            ["n_bt202"] = new Pawn { Name = "Young Eraqus (Chess)" },
            ["n_dw202"] = new Pawn { Name = "Riku (KH1)" },
            ["n_dw208"] = new Pawn { Name = "Ansem the Wise" },

            ["n_ex001"] = new Pawn { Name = "Donald" },
            ["n_ex002"] = new Pawn { Name = "Goofy" },
            ["n_ex003"] = new Pawn { Name = "Mickey" },
            ["n_ex004"] = new Pawn { Name = "Riku" },
            ["n_ex005"] = new Pawn { Name = "Kairi" },
            ["n_ex006"] = new Pawn { Name = "Ventus" },
            ["n_ex007"] = new Pawn { Name = "Terra" },
            ["n_ex008"] = new Pawn { Name = "Roxas" },
            ["n_ex009"] = new Pawn { Name = "Roxas (Coat)" },
            ["n_ex010"] = new Pawn { Name = "Lea" },
            ["n_ex011"] = new Pawn { Name = "Aquanort" },
            ["n_ex013"] = new Pawn { Name = "Naminé" },
            ["n_ex024"] = new Pawn { Name = "Eraqus" },
            ["n_ex029"] = new Pawn { Name = "Lingering Will" },
            ["n_ex033"] = new Pawn { Name = "Xion (Coat)" },
        };

        public static readonly Dictionary<string, Pawn> EnemyPawns = new Dictionary<string, Pawn>
        {
            ["e_dw401"] = new Pawn { Name = "Demon Tide" },
            ["e_ex301"] = new Pawn { Name = "Xehanort" },
            ["e_ex302"] = new Pawn { Name = "Young Xehanort" },
            ["e_ex303"] = new Pawn { Name = "Ansem" },
            ["e_ex304"] = new Pawn { Name = "Xemnas" },
        };
    }
}
