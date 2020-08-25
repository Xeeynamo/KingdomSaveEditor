using KHSave.Lib2.Models;
using KHSave.Lib2.Types;
using System;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib2
{
    public partial class SaveKh2
    {
        public class SaveEuropean : ISaveKh2
        {
            public bool IsFinalMix => false;

            [Data(0, 0xb4e0)] public byte[] Data { get; set; }

            [Data(0)] public uint MagicCode { get; set; }
            [Data] public int Version { get; set; }
            [Data] public uint Checksum { get; set; }
            [Data] public WorldType WorldId { get; set; }
            [Data] public byte RoomId { get; set; }
            [Data] public byte SpawnId { get; set; }
            [Data] public byte Unused0f { get; set; }


            [Data(0xe50, Count = 20, Stride = 0x20)] public Progress[] StoryProgress { get; set; }
            [Data(0x14b8, Count = 8 * Constants.WorldCount)] public byte[] RoomVisitedFlag { get; set; }
            [Data(0x1600)] public int MunnyAmount { get; set; }
            [Data(0x1604, Count = Constants.WorldCount + 2)] public int Timer { get; set; }
            [Data(0x1658)] public Difficulty Difficulty { get; set; }
            [Data(Count = 0)] public byte[] PuzzlePieceFlags { get; set; }
            [Data(0x1660, Count = 13, Stride = 0xf4)] public CharacterVanilla[] Characters { get; set; }
            [Data(0x22c4, Count = 9, Stride = 0x28)] public DriveFormVanilla[] DriveForms { get; set; }


            [Data(0x244c)] public PlayableCharacterType PlayableCharacter { get; set; }
            [Data(0x244d)] public PlayableCharacterType CompanionCharacter1 { get; set; }
            [Data(0x244e)] public PlayableCharacterType CompanionCharacter2 { get; set; }
            [Data(0x244f)] public PlayableCharacterType CompanionCharacter3 { get; set; }
            [Data(0x2488, Count = 280)] public byte[] InventoryCount { get; set; }
            [Data(0x25E8)] public int Experience { get; set; }
            [Data(0x2600)] public CommandType ShortcutCircle { get; set; }
            [Data] public CommandType ShortcutTriangle { get; set; }
            [Data] public CommandType ShortcutSquare { get; set; }
            [Data] public CommandType ShortcutCross { get; set; }
            [Data] public int BonusLevel { get; set; }

            public bool Vibration { get; set; }
            public bool Unknown41a4_1 { get; set; }
            public bool Unknown41a4_2 { get; set; }
            public bool NavigationalMap { get; set; }
            public bool FieldCameraManual { get; set; }
            public bool RightAnalogStickCommand { get; set; }
            public bool CommandMenuClassic { get; set; }
            public bool CameraLeftRightReversed { get; set; }
            public bool CameraUpDownReversed { get; set; }
            public bool Unknown41a5_1 { get; set; }
            public bool Unknown41a5_2 { get; set; }
            public short ProgressTutorialMenu { get; set; }
            public bool NewStatusValor { get; set; }
            public bool NewStatusWisdom { get; set; }
            public bool NewStatusLimit { get; set; }
            public bool NewStatusMaster { get; set; }
            public bool NewStatusFinal { get; set; }
            public bool NewStatusSummonStitch { get; set; }
            public bool NewStatusSummonGenie { get; set; }
            public bool NewStatusSummonPeterPan { get; set; }
            public bool NewStatusSummonChickenLittle { get; set; }

            ICharacter[] ISaveKh2.Characters => Array.ConvertAll(Characters, x => (ICharacter)x);
            IDriveForm[] ISaveKh2.DriveForms => Array.ConvertAll(DriveForms, x => (IDriveForm)x);

            public void Write(Stream stream) =>
                BinaryMapping.WriteObject(stream.FromBegin(), this);
        }
    }
}
