using Xe.BinaryMapper;

namespace KHSave.Lib2.Models
{
    public class PlaceScriptFinalMix : IPlaceScript
    {
        [Data] public byte Map { get; set; }
        [Data] public byte MapSecondary { get; set; }
        [Data] public byte Battle { get; set; }
        [Data] public byte BattleSecondary { get; set; }
        [Data] public byte Event { get; set; }
        [Data] public byte EventSecondary { get; set; }
    }
}
