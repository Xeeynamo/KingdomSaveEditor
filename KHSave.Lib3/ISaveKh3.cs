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

namespace KHSave.Lib3
{
    public interface ISaveKh3
    {

        int MagicCode { get; set; } // Identify the save
        int FileSize { get; set; }
        short MajorVersion { get; set; }
        short MinorVersion { get; set; }
        int Unknown0000C { get; set; } // Changes every time
        DifficultyType Difficulty { get; set; }
        WorldType WorldLogo { get; set; }

        TimeSpan GameTime { get; set; }
        int TotalExp { get; set; }
        int Munny { get; set; }
        byte Level { get; set; }
        DesireChoice DesireChoice { get; set; }
        PowerChoice PowerChoice { get; set; }
        List<PartyCharacter> Party { get; set; }
        bool SaveClear { get; set; }
        LocationType LocationName { get; set; }
        int Unknown00058 { get; set; } // Changes every time
        int Unknown0005C { get; set; } // Changes every time
        CharacterIconType BaseSaveIcon { get; set; }
        CharacterIconType DlcSaveIcon { get; set; }

        int EnemiesDefeated { get; set; }
        short SavesCount { get; set; }
        List<short> RecordAttractionsUseCount { get; set; }
        List<short> RecordShotlocksUseCount { get; set; }
        List<InventoryEntry> Inventory { get; set; }
        List<short> MaterialsCount { get; set; }
        int CrabsCollected { get; set; }
        List<PlayableCharacter> Pc { get; set; }
        List<int> Storyflags { get; set; }
        string MapPath { get; set; }
        string MapSpawn { get; set; }
        string PlayerScript { get; set; }
        string PlayerCharacter { get; set; }

        List<ShortcutGroup> Shortcuts { get; set; }

        List<CommandType> Magics { get; set; }
        List<CommandType> Links { get; set; }

        Records Records { get; set; }

        int PhotoMaxCount { get; set; }
        List<PhotoEntry> Photos { get; set; }

        string DlcMapPath { get; set; }
        string DlcSpawnPoint { get; set; }

        void Write(Stream stream);
    }
}
