using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
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

            [Data(0x499, Count = 0x100)] public byte[] Inventory { get; set; }

            [Data(0x599)] public AbilityType SharedAbility1 { get; set; }
            [Data(0x59A)] public AbilityType SharedAbility2 { get; set; }
            [Data(0x59B)] public AbilityType SharedAbility3 { get; set; }
            [Data(0x59C)] public AbilityType SharedAbility4 { get; set; }

            [Data(0x844)] public CommandType ShortcutCircle { get; set; }
            [Data(0x845)] public CommandType ShortcutTriangle { get; set; }
            [Data(0x846)] public CommandType ShortcutSquare { get; set; }

            [Data(0x16400)] public int AutoLock { get; set; }
            [Data(0x16404)] public int TargetLock { get; set; }
            [Data(0x16408)] public int Camera { get; set; }
            [Data(0x16410)] public int Vibration { get; set; }
            [Data(0x16414)] public int Sound { get; set; }

            [Data(0x1641C)] public int Money { get; set; }
        }
    }
}
