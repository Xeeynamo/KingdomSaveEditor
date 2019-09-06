using System.Collections.Generic;

namespace KHSave.Lib3.Presets
{
    public static partial class Presets
    {
        public class Map
        {
            public string Name { get; set; }
        }

        public static readonly Dictionary<string, Map> MAPS = new Dictionary<string, Map>
        {
            ["he_01"] = new Map { Name = "Realm of the Gods" },
            ["he_02"] = new Map { Name = "Mount Olympus" },
            ["he_03"] = new Map { Name = "Thebes (in flames)" },
            ["he_04"] = new Map { Name = "Thebes" },
            ["he_05"] = new Map { Name = "Titans battle arena" },
            ["he_06"] = new Map { Name = "Titans battle tornado" },
            ["he_50"] = new Map { Name = "First cutscene map" },
            ["tt_01"] = new Map { Name = "The Neighborhood" },
            ["tt_40"] = new Map { Name = "Bistro" },
            ["tt_50"] = new Map { Name = "Computer Laboratory" },
            ["ts_01"] = new Map { Name = "Andy’s House" },
            ["ts_02"] = new Map { Name = "Galaxy Toys" },
            ["ts_03"] = new Map { Name = "Verux Rem Minigame" },
            ["ts_04"] = new Map { Name = "UFO battle arena" },
            ["ra_01"] = new Map { Name = "The Forest" },
            ["ra_02"] = new Map { Name = "The Kingdom" },
            ["mi_01"] = new Map { Name = "Monsters. Inc." },
            ["mi_02"] = new Map { Name = "The Factory" },
            ["mi_03"] = new Map { Name = "The Powerplant" },
            ["mi_04"] = new Map { Name = "The Door Vault" },
            ["mi_50"] = new Map { Name = "Outside the factory" },
            ["ca_01"] = new Map { Name = "Port Royal" },
            ["ca_02"] = new Map { Name = "The High Seas" },
            ["ca_03"] = new Map { Name = "" },
            ["ca_04"] = new Map { Name = "Davy Jones' Locker" },
            ["ca_05"] = new Map { Name = "Over the Edge" },
            ["ca_50"] = new Map { Name = "" },
            ["fz_01"] = new Map { Name = "The North Mountain" },
            ["fz_02"] = new Map { Name = "The Labyrinth of Ice" },
            ["fz_03"] = new Map { Name = "Trinity Sled Minigame" },
            ["fz_04"] = new Map { Name = "" },
            ["fz_05"] = new Map { Name = "Sköl fight arena" },
            ["fz_06"] = new Map { Name = "" },
            ["bx_01"] = new Map { Name = "The Bridge" },
            ["bx_02"] = new Map { Name = "The City" },
            ["bx_03"] = new Map { Name = "Hiro's Garage" },
            ["dp_01"] = new Map { Name = "Land of Departure" },
            ["kg_01"] = new Map { Name = "" },
            ["kg_02"] = new Map { Name = "" },
            ["kg_03"] = new Map { Name = "" },
            ["kg_50"] = new Map { Name = "" },
            ["kg_51"] = new Map { Name = "" },
            ["bt_01"] = new Map { Name = "" },
            ["bt_02"] = new Map { Name = "" },
            ["bt_03"] = new Map { Name = "" },
            ["bt_04"] = new Map { Name = "" },
            ["bt_50"] = new Map { Name = "Chess Room" },
            ["yt_50"] = new Map { Name = "" },
            ["ew_01"] = new Map { Name = "" },
            ["ew_02"] = new Map { Name = "" },
            ["ew_21"] = new Map { Name = "" },
            ["ew_22"] = new Map { Name = "" },
            ["ew_23"] = new Map { Name = "" },
            ["ew_24"] = new Map { Name = "" },
            ["ew_25"] = new Map { Name = "" },
            ["ew_26"] = new Map { Name = "" },
            ["ew_27"] = new Map { Name = "" },
            ["ew_28"] = new Map { Name = "" },
            ["rg_50"] = new Map { Name = "" },
            ["rg_51"] = new Map { Name = "" },
            ["dw_21"] = new Map { Name = "" },
            ["dw_71"] = new Map { Name = "" },
            ["wm_01"] = new Map { Name = "" },
            ["po_01"] = new Map { Name = "" },
            ["po_02"] = new Map { Name = "" },
            ["po_03"] = new Map { Name = "" },
            ["po_04"] = new Map { Name = "" },
            ["di_50"] = new Map { Name = "" },
            ["gm_01"] = new Map { Name = "" },
            ["gm_02"] = new Map { Name = "" },
            ["gm_03"] = new Map { Name = "" },
            ["gm_50"] = new Map { Name = "" },

            // The following maps are found in game data, but it is not known if those maps actually exists.
            ["sp_01"] = new Map { Name = "" },
            ["dc_50"] = new Map { Name = "Disney Castle" },
        };
    }
}
