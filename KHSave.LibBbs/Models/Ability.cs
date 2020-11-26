using Xe.BinaryMapper;

namespace KHSave.LibBbs.Models
{
    public class Ability
    {
        [Data] public byte NumberActivated { get; set; }
        [Data] public byte Slots { get; set; }
        [Data] public byte Unk2 { get; set; }
        [Data] public byte Unk3 { get; set; }
    }
}
