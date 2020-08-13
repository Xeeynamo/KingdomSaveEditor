using KHSave.LibPersona5.Types;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5.Models
{
    public class Character
    {
        [Data(Count = 0x2a8)] public byte[] Data { get; set; }

        [Data(0)] public short Unknown00 { get; set; }
        [Data] public short Unknown02 { get; set; }
        [Data] public int Unknown04 { get; set; }
        [Data] public int Unknown08 { get; set; }
        [Data] public int Unknown0c { get; set; }
        [Data] public int Unknown10 { get; set; }
        [Data] public int CurrentHp { get; set; }
        [Data] public int CurrentMp { get; set; }
        [Data] public int Unknown1c { get; set; }
        [Data(0x24)] public int Experience { get; set; }
        [Data(0x4c, Count = 12, Stride = 0x30)] public Persona[] Persona { get; set; }
        [Data] public Equipment MeleeWeapon { get; set; }
        [Data] public Equipment Protector { get; set; }
        [Data] public Equipment Accessory { get; set; }
        [Data] public Equipment Outfit { get; set; }
        [Data] public Equipment RangeWeapon { get; set; }
    }
}
