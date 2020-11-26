using KHSave.LibBbs.Models;
using KHSave.LibBbs.Types;
using Xe.BinaryMapper;

namespace KHSave.LibBbs
{
    public partial class SaveKhBbs
    {
        public class SaveEuropean : ISaveKhBbs
        {
            [Data(0, 0x11B40)] public byte[] Data { get; set; }

            [Data(0)] public uint MagicCode { get; set; }
            [Data] public int Version { get; set; }
            [Data] public uint Size { get; set; }
            [Data] public uint Checksum { get; set; }

            [Data] public byte Report { get; set; }
            [Data] public byte Dummy1 { get; set; }
            [Data] public byte Dummy2 { get; set; }
            [Data] public byte Dummy3 { get; set; }
            [Data] public WorldType World { get; set; }
            [Data] public byte Room { get; set; }
            [Data] public byte Location { get; set; }
            [Data] public CharacterType PlayableCharacter { get; set; }
            [Data] public int Timer { get; set; }

            [Data(0x3488, Count = 0x200)] public Command[] CommandList { get; set; }
            [Data(0x59A8)] public Character Character { get; set; }
            [Data(0x5A04, Count = 0x3)] public Deck[] Decks { get; set; }

            [Data(0x5C84)] public DifficultyType Difficulty { get; set; }
        }
    }
}
