using KHSave.LibPersona5.Types;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5.Models
{
    public class Persona
    {
        [Data(Count = 0x30)] public byte[] Data { get; set; }

        [Data(0)] public short Flags { get; set; }
        [Data] public short Id { get; set; }
        [Data] public byte Level { get; set; }
        [Data] public byte Unknown05 { get; set; }
        [Data] public Trait Trait { get; set; }
        [Data] public int Experience { get; set; }
        [Data(Count = 8)] public Skill[] Skills { get; set; }
        [Data] public byte Strength { get; set; }
        [Data] public byte Magic { get; set; }
        [Data] public byte Endurance { get; set; }
        [Data] public byte Agility { get; set; }
        [Data] public byte Luck { get; set; }
    }
}
