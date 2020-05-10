using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib1
{
    public partial class SaveKh1
    {
        public class SaveEU : ISaveKh1
        {
            [Data(0, 0x16C00)] public byte[] Data { get; set; }
            [Data(0)] public uint MagicCode { get; set; }
            [Data(Count = 10, Stride = 0x74)] public Character[] Characters { get; set; }

            [Data(0x48E)] public PlayableCharacterType PlayableCharacter { get; set; }
            [Data(0x48F)] public PlayableCharacterType CompanionCharacter1 { get; set; }
            [Data(0x490)] public PlayableCharacterType CompanionCharacter2 { get; set; }
            [Data(0x491)] public PlayableCharacterType CompanionCharacter3 { get; set; }

            [Data(0x499, Count = 0x100)] public byte[] InventoryCount { get; set; }

            [Data(0x599)] public AbilityType SharedAbility1 { get; set; }
            [Data(0x59A)] public AbilityType SharedAbility2 { get; set; }
            [Data(0x59B)] public AbilityType SharedAbility3 { get; set; }
            [Data(0x59C)] public AbilityType SharedAbility4 { get; set; }

            [Data(0x82C)] public CommandType ShortcutTriangle { get; set; }
            [Data(0x82D)] public CommandType ShortcutCircle { get; set; }
            [Data(0x82E)] public CommandType ShortcutSquare { get; set; }

            
            //Gummiships
            [Data(Count = 10, Stride = 0x241C)] public Gummiship[] Gummiships { get; set; }
            
            //Needs testing
            [Data(0x16A30)] public int AutoLock { get; set; }
            [Data(0x16A34)] public int TargetLock { get; set; }
            [Data(0x16A38)] public int Camera { get; set; }
            [Data(0x16A40)] public int Vibration { get; set; }
            [Data(0x16A44)] public int Sound { get; set; }

            
            [Data(0x16418)] public DifficultyFm Difficulty { get; set; }

            [Data(0x1641C)] public uint Munny { get; set; }


            public void Write(Stream stream) =>
                Mapper.WriteObject(stream.SetPosition(0), this);

            internal static SaveEU ReadInternal(Stream stream) =>
                Mapper.ReadObject(stream, new SaveEU()) as SaveEU;
        }
    }
}

