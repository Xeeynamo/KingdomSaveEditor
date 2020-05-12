using KHSave.LibBbs.Models;
using KHSave.LibBbs.Types;
using Xe.BinaryMapper;

namespace KHSave.LibBbs
{
    public partial class SaveKhBbs
    {
        public class SaveFinalMix : ISaveKhBbs
        {
            [Data(0, 0x11E50)] public byte[] Data { get; set; }

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
            [Data] public byte CharacterIndex { get; set; }
            [Data] public int Timer { get; set; }

            [Data(0x3498, Count = 0x200)] public Command[] CommandList { get; set; }
            [Data(0x4D64, Count = 0x1E)] public Ability[] Abilities { get; set; }
            [Data(0x5644, Count = 0xF)] public Finisher[] Finishers { get; set; }
            [Data(0x5746, Count = 0xC)] public Dlink[] Dlinks { get; set; }
            [Data(0x59D0)] public Character Character { get; set; }
            [Data(0x5A2C, Count = 0x3)] public Deck[] Decks { get; set; }

            [Data(0x5CAC)] public DifficultyType Difficulty { get; set; }

        }
    }
}
