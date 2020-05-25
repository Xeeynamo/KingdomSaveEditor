using KHSave.LibBbs.Types;
using Xe.BinaryMapper;

namespace KHSave.LibBbs.Models
{
    public class Character
    {
        [Data] public uint Experience { get; set; }
        [Data] public uint Money { get; set; }
        [Data] public uint Medals { get; set; }
        [Data] public ushort Level { get; set; }
        [Data] public ushort Hp1 { get; set; }
        [Data] public ushort Hp2 { get; set; }
        [Data] public ushort Unk12 { get; set; }
        [Data] public ushort Unk14 { get; set; }
        [Data] public ushort Unk16 { get; set; }
        [Data] public ushort Magic { get; set; }
        [Data] public ushort Defense { get; set; }
        [Data] public ushort ArenaLevel { get; set; }
        [Data] public ushort Strength { get; set; }
        [Data] public ushort Unk20 { get; set; }
        [Data] public ushort Unk22 { get; set; }
        [Data] public ushort Unk24 { get; set; }
        [Data] public ushort Unk26 { get; set; }
        [Data] public ushort Unk28 { get; set; }
        [Data] public WeaponType Weapon { get; set; }
        [Data] public ushort Unk2C { get; set; }
        [Data] public ushort Unk2E { get; set; }
    }
}
