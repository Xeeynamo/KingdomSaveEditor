using KHSave.LibPersona5.Types;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5.Models
{
    public class Persona
    {
        [Data(Count = 0x30)] public byte[] Data { get; set; }

        [Data(0)] public short IsEnabled { get; set; }
        [Data] public short Id { get; set; }
        [Data] public short Level { get; set; }
        [Data] public short Unknown06 { get; set; }
        [Data] public int Experience { get; set; }
        [Data(Count = 8)] public Skill[] Skills{ get; set; }
        [Data] public byte Strength { get; set; }
        [Data] public byte Magic { get; set; }
        [Data] public byte Endurance { get; set; }
        [Data] public byte Agility { get; set; }
        [Data] public byte Luck { get; set; }
    }

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
    }
}
