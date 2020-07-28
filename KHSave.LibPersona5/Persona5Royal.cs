using KHSave.LibPersona5.Models;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5
{
    internal class Persona5Royal : ISavePersona5
    {
        public bool IsRoyal => true;

        [Data(Count = 256 * 1024)] public byte[] Data { get; set; }

        [Data(0x14, Count = 12)] public string ProtagonistLastName { get; set; }
        [Data(Count = 12)] public string ProtagonistFirstName { get; set; }

        [Data(0x48, Count = 10, Stride = 0x2a8)] public Character[] Characters { get; set; }
        [Data(0x357c)] public int Money { get; set; }
        public bool PartyModifierRyuji { get; set; }   // TODO maybe 3B4C
        public bool PartyModifierMorgana { get; set; } // TODO
        public bool PartyModifierAnn { get; set; }     // TODO
        public bool PartyModifierYusuke { get; set; }  // TODO
        public bool PartyModifierMakoto { get; set; }  // TODO
        public bool PartyModifierHaru { get; set; }    // TODO
        public bool PartyModifierFutaba { get; set; }  // TODO
        public bool PartyModifierAkechi { get; set; }  // TODO
        public short RoomCategory { get; set; } // TODO
        public short RoomMap { get; set; } // TODO
        public float PositionX { get; set; } // TODO
        public float PositionY { get; set; } // TODO
        public float PositionZ { get; set; } // TODO
    }
}
