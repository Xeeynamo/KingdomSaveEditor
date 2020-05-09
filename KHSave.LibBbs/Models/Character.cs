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
        [Data] public ushort Unk0 { get; set; }
        [Data] public ushort Unk1 { get; set; }
        [Data] public ushort Unk2 { get; set; }
        [Data] public ushort Unk3 { get; set; }
        [Data] public ushort Magic { get; set; }
        [Data] public ushort Defense { get; set; }
        [Data] public ushort ArenaLevel { get; set; }
        [Data] public ushort Strength { get; set; }
        [Data] public ushort Unk4 { get; set; }
        [Data] public ushort Unk5 { get; set; }
        [Data] public ushort Unk6 { get; set; }
        [Data] public ushort Unk7 { get; set; }
        [Data] public ushort Unk8 { get; set; }
        [Data] public WeaponType Weapon { get; set; }
        [Data] public ushort Unk9 { get; set; }
        [Data] public ushort UnkA { get; set; }
    }
}
