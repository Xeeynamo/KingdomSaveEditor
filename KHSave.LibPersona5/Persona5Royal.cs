using KHSave.LibPersona5.Models;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5
{
    internal class Persona5Royal : ISavePersona5
    {
        public bool IsRoyal => true;

        [Data(Count = 256 * 1024)] public byte[] Data { get; set; }

        [Data(0x0006)] public short CalendarDay1 { get; set; }
        [Data(0x14, Count = 12)] public string ProtagonistLastName { get; set; }
        [Data(Count = 12)] public string ProtagonistFirstName { get; set; }

        [Data(0x48, Count = 10, Stride = 0x2a8)] public Character[] Characters { get; set; }
        [Data(0x2252, Count = 0x500)] public byte[] InventoryCount { get; set; }
        [Data(0x357c)] public int Money { get; set; }
        [Data(0x3b4c)] public bool PartyModifierKasumi { get; set; }
        [Data(0x3b4d)] public bool PartyModifierRyuji { get; set; }
        [Data] public bool PartyModifierMorgana { get; set; }
        [Data] public bool PartyModifierAnn { get; set; }
        [Data] public bool PartyModifierYusuke { get; set; }
        [Data] public bool PartyModifierMakoto { get; set; }
        [Data] public bool PartyModifierHaru { get; set; }
        [Data] public bool PartyModifierFutaba { get; set; }
        [Data] public bool PartyModifierAkechi { get; set; }
        [Data(0x41d8, Count = 0x1D0, Stride = 0x30)] public Persona[] Compendium { get; set; }
        [Data(0xA5F4)] public short CalendarDay2 { get; set; }
        [Data(0xA5F8)] public short CalendarDay3 { get; set; }
        [Data(0x13878)] public short RoomCategory { get; set; }
        [Data(0x1387a)] public short RoomMap { get; set; }
        [Data(0x13882)] public float PositionX { get; set; }
        [Data(0x13886)] public float PositionY { get; set; }
        [Data(0x1388a)] public float PositionZ { get; set; }
    }
}
