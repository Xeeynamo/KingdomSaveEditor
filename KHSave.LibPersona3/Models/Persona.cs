using KHSave.LibPersona3.Types;
using Xe.BinaryMapper;

namespace KHSave.LibPersona3.Models
{
    public record Persona
    {
        [Data(Count = 0x34)] public byte[] Data { get; set; }

        [Data(0)] public short Flags { get; set; }
        [Data] public Demons Id { get; set; }
        [Data] public byte Level { get; set; }
        [Data] public byte Break { get; set; }
        [Data] public short Unk { get; set; }
        [Data] public int Experience { get; set; }
        [Data(Count = 8)] public Skill[] Skills { get; set; }
        [Data] public byte Strength { get; set; }
        [Data] public byte Magic { get; set; }
        [Data] public byte Endurance { get; set; }
        [Data] public byte Agility { get; set; }
        [Data] public byte Luck { get; set; }
        [Data] public byte Unk21 { get; set; }
        [Data] public short Unk22 { get; set; }
        [Data] public short Unk24 { get; set; }
        [Data] public short Unk26 { get; set; }
        [Data] public int Unk28 { get; set; }
        [Data] public int OverThanatos { get; set; }
        [Data] public int Unk30 { get; set; }

        public override string ToString() =>
            $"{Id}: LV {Level}, St {Strength}, Ma {Magic}, En {Endurance}, Ag {Agility}, Lu {Luck}\nSkills: {string.Join(", ", Skills)}";
    }
}
