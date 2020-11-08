using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib1
{
    public partial class SaveKh1
    {
        public class SaveFinalMix : ISaveKh1
        {

            [Data(0, 0x16C00)] public byte[] Data { get; set; }

            [Data(0)] public uint MagicCode { get; set; }
            [Data(Count = 10, Stride = 0x74)] public Character[] Characters { get; set; }

            [Data(0x48E)] public PlayableCharacterType PlayableCharacter { get; set; }
            [Data(0x48F)] public PlayableCharacterType CompanionCharacter1 { get; set; }
            [Data(0x490)] public PlayableCharacterType CompanionCharacter2 { get; set; }
            [Data(0x491)] public PlayableCharacterType CompanionCharacter3 { get; set; }

            [Data(0x499, Count = 0x100)] public byte[] InventoryCount { get; set; }

            [Data(0x599, Count = 4)] public byte[] SharedAbilities { get; set; }

            [Data(0x844)] public CommandType ShortcutCircle { get; set; }
            [Data(0x845)] public CommandType ShortcutTriangle { get; set; }
            [Data(0x846)] public CommandType ShortcutSquare { get; set; }

            [Data(0x2040)] public WorldType World { get; set; }
            [Data(0x2044)] public uint Room { get; set; }
            [Data(0x2048)] public uint SpawnLocation { get; set; }

            [Data(0x16400)] public int AutoLock { get; set; }
            [Data(0x16404)] public int TargetLock { get; set; }
            [Data(0x16408)] public int Camera { get; set; }
            [Data(0x16410)] public int Vibration { get; set; }
            [Data(0x16414)] public int Sound { get; set; }

            [Data(0x1641C)] public uint Munny { get; set; }
            [Data(0x1642C)] public DifficultyFm Difficulty { get; set; }

            public void Write(Stream stream) =>
                BinaryMapping.WriteObject(stream.FromBegin(), this);
        }
    }
}
