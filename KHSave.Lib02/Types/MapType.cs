using KHSave.Attributes;

namespace KHSave.Trssv.Types
{
    public enum MapType
    {
        [MapInfo("dw_01", "Main Road")] Dw01,
        [MapInfo("dw_02", "Castle Town")] Dw02,
        [MapInfo("dw_03", "The World Within")] Dw03,
        [MapInfo("dw_04", "Inside the mirror (Road)")] Dw04,
        [MapInfo("dw_05", "Inside the mirror (Colums)")] Dw05,
        [MapInfo("dw_06", "Inside the mirror (Dwarf)")] Dw06,
        [MapInfo("dw_07", "Inside the mirror (Battle)")] Dw07,
        [MapInfo("dw_08", "Forest of Thorns")] Dw08,
        [MapInfo("dw_09", "Depths of Darkness")] Dw09,
        [MapInfo("dw_10", "Destiny Island")] Dw10,
        [MapInfo("dw_11", "Boss Rush (vs. Darkside)")] Dw11,
        [MapInfo("dw_12", "Boss Rush (Columns room)")] Dw12,
        [MapInfo("dw_58", "Opening")] Dw58,
        [MapInfo("dw_59", "dw59 (infinite loading screen)")] Dw59,
        [MapInfo("dw_60", "Ending")] Dw60,
    }
}
