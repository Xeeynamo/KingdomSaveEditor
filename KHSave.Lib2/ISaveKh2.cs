using KHSave.Lib2.Models;
using KHSave.Lib2.Types;
using System.IO;

namespace KHSave.Lib2
{
    public interface ISaveKh2
    {
        uint MagicCode { get; set; }
        int Version { get; set; }
        uint Checksum { get; set; }
        WorldType WorldId { get; set; }
        byte RoomId { get; set; }
        byte SpawnId { get; set; }
        byte Unused0f { get; set; }

        Progress[] StoryProgress { get; set; }
        
        byte[] RoomVisitedFlag { get; set; } // There might be a chance that it starts from 0x2300
        int MunnyAmount { get; set; }
        int Timer { get; set; }
        Difficulty Difficulty { get; set; }
        byte[] PuzzlePieceFlags { get; set; }
        ICharacter[] Characters { get; }

        short SoraValorKeyblade { get; set; }
        short SoraTrinityKeyblade { get; set; }
        short SoraFinalKeyblade { get; set; }

        PlayableCharacterType PlayableCharacter { get; set; }
        PlayableCharacterType CompanionCharacter1 { get; set; }
        PlayableCharacterType CompanionCharacter2 { get; set; }
        PlayableCharacterType CompanionCharacter3 { get; set; }
        byte[] InventoryCount { get; set; }

        int Experience { get; set; }
        CommandType ShortcutCircle { get; set; }
        CommandType ShortcutTriangle { get; set; }
        CommandType ShortcutSquare { get; set; }
        CommandType ShortcutCross { get; set; }
        int BonusLevel { get; set; }

        bool Vibration { get; set; }
        bool Unknown41a4_1 { get; set; }
        bool Unknown41a4_2 { get; set; }
        bool NavigationalMap { get; set; }
        bool FieldCameraManual { get; set; }
        bool RightAnalogStickCommand { get; set; }
        bool CommandMenuClassic { get; set; }
        bool CameraLeftRightReversed { get; set; }
        bool CameraUpDownReversed { get; set; }
        bool Unknown41a5_1 { get; set; }
        bool Unknown41a5_2 { get; set; }

        short ProgressTutorialMenu { get; set; }
        bool NewStatusValor { get; set; }
        bool NewStatusWisdom { get; set; }
        bool NewStatusLimit { get; set; }
        bool NewStatusMaster { get; set; }
        bool NewStatusFinal { get; set; }
        bool NewStatusSummonStitch { get; set; }
        bool NewStatusSummonGenie { get; set; }
        bool NewStatusSummonPeterPan { get; set; }
        bool NewStatusSummonChickenLittle { get; set; }

        void Write(Stream stream);
    }
}