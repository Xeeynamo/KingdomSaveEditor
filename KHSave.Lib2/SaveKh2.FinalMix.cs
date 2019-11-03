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

            [Data(0x36f8)] public CommandType ShortcutCircle { get; set; }
            [Data(0x36fa)] public CommandType ShortcutTriangle { get; set; }
            [Data(0x36fc)] public CommandType ShortcutSquare { get; set; }
            [Data(0x36fe)] public CommandType ShortcutCross { get; set; }

            [Data(0x41a4, BitIndex = 0)] public bool Vibration { get; set; }
            [Data(0x41a4, BitIndex = 3)] public bool NavigationalMap { get; set; }
            [Data(0x41a4, BitIndex = 4)] public bool FieldCameraManual { get; set; }
            [Data(0x41a4, BitIndex = 5)] public bool RightAnalogStickCommand { get; set; }
            [Data(0x41a4, BitIndex = 6)] public bool CommandMenuClassic { get; set; }
            [Data(0x41a4, BitIndex = 7)] public bool CameraLeftRightReversed { get; set; }
            [Data(0x41a5, BitIndex = 0)] public bool CameraUpDownReversed { get; set; }

            [Data(0x41aa)] public bool NewMagicUnk1_0 { get; set; }
            [Data(0x41aa)] public bool NewMagicUnk1_1 { get; set; }
            [Data(0x41aa)] public bool NewMagicUnk1_2 { get; set; }
            [Data(0x41aa)] public bool NewMagicUnk1_4 { get; set; }
            [Data(0x41aa)] public bool NewMagicUnk1_8 { get; set; }
            [Data(0x41aa)] public bool NewMagicFiraga { get; set; }
            [Data(0x41aa)] public bool NewMagicBlizzaga { get; set; }
            [Data(0x41aa)] public bool NewMagicThundaga { get; set; }
            [Data(0x41ab)] public bool NewMagicCuraga { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_0 { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_1 { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_2 { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_4 { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_8 { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_10 { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_20 { get; set; }
            [Data(0x41b2)] public bool NewMagicUnk2_40 { get; set; }
            [Data(0x41b2)] public bool NewMagicMagnega { get; set; }
            [Data(0x41b3)] public bool NewMagicReflega { get; set; }

            [Data(0x4270)] public short ProgressTutorialMenu { get; set; }
            [Data(0x4274)] public bool NewStatusValor { get; set; }
            [Data(0x4274)] public bool NewStatusWisdom { get; set; }
            [Data(0x4274)] public bool NewStatusLimit { get; set; }
            [Data(0x4274)] public bool NewStatusMaster { get; set; }
            [Data(0x4274)] public bool NewStatusFinal { get; set; }
            [Data(0x4274)] public bool NewStatusSummonStitch { get; set; }
            [Data(0x4274)] public bool NewStatusSummonGenie { get; set; }
            [Data(0x4274)] public bool NewStatusSummonPeterPan { get; set; }
            [Data(0x4275)] public bool NewStatusSummonChickenLittle { get; set; }
        }
    }
}
