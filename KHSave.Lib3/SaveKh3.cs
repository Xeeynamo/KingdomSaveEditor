/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using KHSave.Lib3.Models;
using KHSave.Lib3.Types;
using Xe.BinaryMapper;

namespace KHSave.Lib3
{
    public class SaveKh3 : ISaveKh3
    {
        internal static IBinaryMapping Mapper;

        static SaveKh3()
        {
            Mapper = MappingConfiguration
                .DefaultConfiguration()
                .ForType<TimeSpan>(
                    x => new TimeSpan(0, 0, 0, x.Reader.ReadInt32(), 0),
                    x => x.Writer.Write((int)((TimeSpan)x.Item).TotalSeconds)
                )
                .Build();
        }

        [Data(0, 0x94E8F0)] public byte[] Data { get; set; }

        [Data(0x0)] public int MagicCode { get; set; }
        [Data] public int FileSize { get; set; }
        [Data] public short MajorVersion { get; set; }
        [Data] public short MinorVersion { get; set; }
        [Data(0xC)] public int Unknown0000C { get; set; }
        [Data(0x14)] public DifficultyType Difficulty { get; set; }
        [Data(0x18)] public WorldType WorldLogo { get; set; }

        [Data(0x20)] public TimeSpan GameTime { get; set; }
        [Data(0x24)] public int TotalExp { get; set; }
        [Data(0x28)] public int Munny { get; set; }
        [Data(0x2C)] public byte Level { get; set; }
        [Data(0x30)] public DesireChoice DesireChoice { get; set; }
        [Data(0x31)] public PowerChoice PowerChoice { get; set; }
        [Data(0x32, Count = 5)] public List<PartyCharacter> Party { get; set; }
        [Data(0x39)] public bool SaveClear { get; set; }
        [Data(0x54)] public LocationType LocationName { get; set; }
        [Data(0x58)] public int Unknown00058 { get; set; }
        [Data(0x5C)] public int Unknown0005C { get; set; }
        [Data(0x60)] public CharacterIconType BaseSaveIcon { get; set; }
        public CharacterIconType DlcSaveIcon { get => default(CharacterIconType); set { } }

        [Data(0x68)] public int EnemiesDefeated { get; set; }
        [Data(0x5B0)] public short SavesCount { get; set; }
        [Data(0x68e, 5)] public List<short> RecordAttractionsUseCount { get; set; }
        [Data(0x6C8, 0x1e, 2)] public List<short> RecordShotlocksUseCount { get; set; }
        [Data(0x86c, 0x400, 2)] public List<InventoryEntry> Inventory { get; set; }
        [Data(0x15d6, 100)] public List<short> MaterialsCount { get; set; }
        [Data(0x1764)] public int CrabsCollected { get; set; }
        [Data(0x17F8, 16, 0x9C0)] public List<PlayableCharacter> Pc { get; set; }
        [Data(0xB414)] public int BonusHp { get; set; }
        [Data(0xB418)] public int BonusMp { get; set; }
        [Data(0xB41C)] public int BonusStrength { get; set; }
        [Data(0xB420)] public int BonusMagic { get; set; }
        [Data(0xB424)] public int BonusDefense { get; set; }
        [Data(0xB43C, 0x40, 4)] public List<int> Storyflags { get; set; }
        [Data(0xBB18, 0x100)] public string MapPath { get; set; }
        [Data(0xBC18, 0x40)] public string MapSpawn { get; set; }
        [Data(0xBC58, 0x100)] public string PlayerScript { get; set; }
        [Data(0xBD58, 0x100)] public string PlayerCharacter { get; set; }

        [Data(0xBE98, 3)] public List<ShortcutGroup> Shortcuts { get; set; }

        [Data(0xBEC8, 6, 4)] public List<CommandType> Magics { get; set; }
        [Data(0xBEE0, 5, 4)] public List<CommandType> Links { get; set; }

        [Data(0x83a70)] public Records Records { get; set; }

        [Data(0x84770)] public int PhotoMaxCount { get; set; }
        [Data(0x84784, 90, 0x19004)] public List<PhotoEntry> Photos { get; set; }
        public string DlcMapPath { get => string.Empty; set { } }
        public string DlcSpawnPoint { get => string.Empty; set { } }

        internal static bool IsValidInternal(Stream stream)
        {
            var prevPosition = stream.Position;
            var reader = new BinaryReader(stream.SetPosition(0));
            var magicCode = reader.ReadInt32();
            var length = reader.ReadInt32();
            stream.Position = prevPosition;

            return magicCode == 0x45764053 && length == 0x94E8E0;
        }

        public void Write(Stream stream) =>
            Mapper.WriteObject(stream.SetPosition(0), this);

        internal static SaveKh3 ReadInternal(Stream stream) =>
            Mapper.ReadObject(stream, new SaveKh3()) as SaveKh3;

        public static bool IsValid(Stream stream) =>
            SaveKh3.IsValidInternal(stream) ||
            SaveKh3u109.IsValidInternal(stream);

        public static ISaveKh3 Read(Stream stream)
        {
            if (SaveKh3.IsValidInternal(stream))
                return ReadInternal(stream);
            if (SaveKh3u109.IsValidInternal(stream))
                return SaveKh3u109.ReadInternal(stream);

            throw new InvalidDataException("Input not recognized as a valid or supported Kingdom Hearts III save game.");
        }
    }
}
