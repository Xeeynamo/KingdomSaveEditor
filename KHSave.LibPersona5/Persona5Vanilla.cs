using KHSave.LibPersona5.Models;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5
{
    internal class Persona5Vanilla : ISavePersona5
    {
        public bool IsRoyal => false;

        [Data(Count = 192 * 1024)] public byte[] Data { get; set; }

        [Data(0x14, Count = 12)] public string ProtagonistLastName { get; set; }
        [Data(Count = 12)] public string ProtagonistFirstName { get; set; }
        [Data(0x48, Count = 9, Stride = 0x2a8)] public Character[] Characters { get; set; }
        [Data(0x2252, Count = 0x500)] public byte[] InventoryCount { get; set; }
        [Data(0x2d5a)] public int Money { get; set; }
        [Data(0x318b)] public bool PartyModifierRyuji { get; set; }
        [Data] public bool PartyModifierMorgana { get; set; }
        [Data] public bool PartyModifierAnn { get; set; }
        [Data] public bool PartyModifierYusuke { get; set; }
        [Data] public bool PartyModifierMakoto { get; set; }
        [Data] public bool PartyModifierHaru { get; set; }
        [Data] public bool PartyModifierFutaba { get; set; }
        [Data] public bool PartyModifierAkechi { get; set; }
        [Data(0x92be)] public short CalendarDay { get; set; }
        [Data(0x12512)] public short SocialStatKnowledge { get; set; }
        [Data] public short SocialStatCharm { get; set; }
        [Data] public short SocialStatProficency { get; set; }
        [Data] public short SocialStatGuts { get; set; }
        [Data] public short SocialStatKindness { get; set; }
        [Data(0x12524)] public short RoomCategory { get; set; }
        [Data(0x12526)] public short RoomMap { get; set; }
        [Data(0x1252c)] public float PositionX { get; set; }
        [Data(0x12530)] public float PositionY { get; set; }
        [Data(0x12534)] public float PositionZ { get; set; }
    }
}
