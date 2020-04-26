using KHSave.Lib1.Types;
using Xe.BinaryMapper;

namespace KHSave.Lib1.Models
{
    public class Character
    {
        [Data] public byte Level { get; set; }
        [Data] public byte HpCur { get; set; }
        [Data] public byte HpMax { get; set; }
        [Data] public byte MpCur { get; set; }
        [Data] public byte MpMax { get; set; }
        [Data] public byte ApMax { get; set; }
        [Data] public byte Unk06 { get; set; }
        [Data] public byte Unk07 { get; set; }
        [Data(Count = 16)] public byte[] Unk08 { get; set; }
        [Data] public byte AccessoryCount { get; set; }
        [Data(Count = 8)] public byte[] Accessories { get; set; }
        [Data] public byte ItemCount { get; set; }
        [Data(Count = 0xC)] public byte[] Items { get; set; }
        [Data] public int Unk2e { get; set; }
        [Data] public EquipmentType Weapon { get; set; }
        [Data] public byte Unk33 { get; set; }
        [Data] public byte Unk34 { get; set; }
        [Data] public byte Unk35 { get; set; }
        [Data] public byte Unk36 { get; set; }
        [Data] public byte Unk37 { get; set; }
        [Data] public int Unk38 { get; set; }
        [Data] public int Experience { get; set; }
        [Data(Count = 0x30)] public byte[] Abilities { get; set; }
        [Data(0x70, BitIndex = 0)] public bool FireAvailable { get; set; }
        [Data(0x70, BitIndex = 1)] public bool BlizzardAvailable { get; set; }
        [Data(0x70, BitIndex = 2)] public bool ThunderAvailable { get; set; }
        [Data(0x70, BitIndex = 3)] public bool CureAvailable { get; set; }
        [Data(0x70, BitIndex = 4)] public bool GravityAvailable { get; set; }
        [Data(0x70, BitIndex = 5)] public bool StopAvailable { get; set; }
        [Data(0x70, BitIndex = 6)] public bool AeroAvailable { get; set; }
        [Data(0x71)] public byte Unk71 { get; set; }
        [Data(0x72)] public byte Unk72 { get; set; }
        [Data(0x73)] public byte Unk73 { get; set; }

    }
}
