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

using KHSave.Lib3.Models;
using KHSave.Lib3.Types;
using System;
using System.Collections.Generic;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib3
{
    public class SaveKh3u109 : ISaveKh3
    {
        static SaveKh3u109()
        {
            BinaryMapping.SetMapping<TimeSpan>(new BinaryMapping.Mapping
            {
                Reader = x => new TimeSpan(0, 0, 0, x.Reader.ReadInt32(), 0),
                Writer = x => x.Writer.Write((int)((TimeSpan)x.Item).TotalSeconds)
            });
        }

        [Data(0, 0x94F308)] public byte[] Data { get; set; }

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
        [Data(0x68)] public CharacterIconType DlcSaveIcon { get; set; }

        [Data(0x70)] public int EnemiesDefeated { get; set; }
        [Data(0x5B8)] public short SavesCount { get; set; }
        [Data(0x696, 5)] public List<short> RecordAttractionsUseCount { get; set; }
        [Data(0x6D0, 0x1e, 2)] public List<short> RecordShotlocksUseCount { get; set; }
        [Data(0x8F4, 0x400, 2)] public List<InventoryEntry> Inventory { get; set; }
        [Data(0x165E, 100)] public List<short> MaterialsCount { get; set; }
        [Data(0x17EC)] public int CrabsCollected { get; set; }
        [Data(0x1880, 16, 0x9C0)] public List<PlayableCharacter> Pc { get; set; }
        [Data(0xB49C)] public int BonusHp { get; set; }
        [Data(0xB4A0)] public int BonusMp { get; set; }
        [Data(0xB4A4)] public int BonusStrength { get; set; }
        [Data(0xB4A8)] public int BonusMagic { get; set; }
        [Data(0xB4AC)] public int BonusDefense { get; set; }
        [Data(0xB4C4, 0x50, 4)] public List<int> Storyflags { get; set; }
        [Data(0xBBA0, 0x100)] public string MapPath { get; set; }
        [Data(0xBCA0, 0x40)] public string MapSpawn { get; set; }
        [Data(0xBCE0, 0x100)] public string PlayerScript { get; set; }
        [Data(0xBDE0, 0x100)] public string PlayerCharacter { get; set; }

        [Data(0xBF20, 3)] public List<ShortcutGroup> Shortcuts { get; set; }
        
        [Data(0xBF50, 6, 4)] public List<CommandType> Magics { get; set; }
        [Data(0xBF68, 5, 4)] public List<CommandType> Links { get; set; }

        [Data(0x83AF8)] public Records Records { get; set; }

        [Data(0x84E48)] public int PhotoMaxCount { get; set; }
        [Data(0x84E5C, 90, 0x19004)] public List<PhotoEntry> Photos { get; set; }
        [Data(0x94EFC4, Count = 0x100)] public string DlcMapPath { get; set; }
        [Data(0x94F0C4, Count = 0x40)] public string DlcSpawnPoint { get; set; }

        internal static bool IsValidInternal(Stream stream)
        {
            var prevPosition = stream.Position;
            var reader = new BinaryReader(stream.SetPosition(0));
            var magicCode = reader.ReadInt32();
            var length = reader.ReadInt32();
            stream.Position = prevPosition;

            return magicCode == 0x45764053 && length == 0x94F2F8;
        }

        public void Write(Stream stream) =>
            BinaryMapping.WriteObject(new BinaryWriter(stream.SetPosition(0)), this);

        internal static SaveKh3u109 ReadInternal(Stream stream) =>
            BinaryMapping.ReadObject(new BinaryReader(stream.SetPosition(0)), new SaveKh3u109()) as SaveKh3u109;
    }
}
