/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

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

using KHSave.Trssv.Types;
using System.Collections.Generic;
using Xe.BinaryMapper;

namespace KHSave.Trssv.Models
{
    public class Slot
    {
        [Data(0, 0x3B40)] public byte[] Data { get; set; }

        //[Data(0x00)] public bool IsDataExists { get; set; } // Bit 0
        //[Data(0x00)] public bool SaveClear { get; set; } // Bit 2
        [Data(0x04)] public DifficultyType Difficulty { get; set; }

        [Data(0x18)] public int Experience { get; set; }
        [Data(0x20)] public byte Level { get; set; }
        [Data(0x24)] public LocationType Location { get; set; }

        [Data(0x30)] public int EnemiesDefeated { get; set; }
        [Data(0x34)] public int StyleChangesPerformed { get; set; }
        [Data(0x3C)] public int MagicFiragaUses { get; set; }
        [Data(0x44)] public int MagicBlizzardUses { get; set; }
        [Data(0x4C)] public int MagicThundagaUses { get; set; }
        [Data(0x54)] public int MagicUnknown1Uses { get; set; }
        [Data(0x5C)] public int MagicUnknown2Uses { get; set; }
        [Data(0x64)] public int MagicCuragaUses { get; set; }

        [Data(0xA30, 52, 4)] public List<Objective> Objectives { get; set; }

        [Data(0x2384, 5, 0x200)] public List<PlayableCharacter> Pc { get; set; }

        [Data(0x2e10)] public int StoryProgression { get; set; }

        [Data(0x3324, 0x100)] public string MapPath { get; set; }
        [Data(0x3424, 0x40)] public string MapSpawn { get; set; }
        [Data(0x3464, 0x100)] public string PlayerScript { get; set; }
        [Data(0x3564, 0x100)] public string PlayerCharacter { get; set; }
        [Data(0x3664, 0x100)] public string SupportCharacter { get; set; }

        [Data(0x3a78)] public CommandType Shortcut1Circle { get; set; }
        [Data(0x3a7c)] public CommandType Shortcut1Triangle { get; set; }
        [Data(0x3a80)] public CommandType Shortcut1Square { get; set; }
        [Data(0x3a84)] public CommandType Shortcut1Cross { get; set; }
        [Data(0x3a88)] public CommandType Shortcut2Circle { get; set; }
        [Data(0x3a8c)] public CommandType Shortcut2Triangle { get; set; }
        [Data(0x3a90)] public CommandType Shortcut2Square { get; set; }
        [Data(0x3a94)] public CommandType Shortcut2Cross { get; set; }
    }
}
