using Xe.BinaryMapper;

namespace KHSave.Lib2.Models
{
    public class PlaceScriptVanilla : IPlaceScript
    {
        [Data] public byte Map { get; set; }
        [Data] public byte Battle { get; set; }
        [Data] public byte Event { get; set; }
    }
}
