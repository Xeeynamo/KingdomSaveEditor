using KHSave.Lib2.Models;
using KHSave.Lib2.Types;
using Xe.BinaryMapper;

namespace KHSave.Lib2
{
    public partial class SaveKh2
    {
        public class SaveFinalMix
        {
            [Data] public uint MagicCode { get; set; }
            [Data] public int Version { get; set; }

            [Data(0x2494)] public int Timer { get; set; }
            [Data(0x24f0, Count = 13, Stride = 0x114)] public Character[] Characters { get; set; }

            [Data(0x32f4)] public short SoraValorKeyblade { get; set; }
            [Data(0x339c)] public short SoraTrinityKeyblade { get; set; }
            [Data(0x33d4)] public short SoraFinalKeyblade { get; set; }

            [Data(0x357c)] public PlayableCharacterType PlayableCharacter { get; set; }
            [Data(0x357d)] public PlayableCharacterType CompanionCharacter1 { get; set; }
            [Data(0x357e)] public PlayableCharacterType CompanionCharacter2 { get; set; }
            [Data(0x357f)] public PlayableCharacterType CompanionCharacter3 { get; set; }
        }
    }
}
