using KHSave.Trssv.Types;
using System;
using System.Collections.Generic;
using Xe.BinaryMapper;

namespace KHSave.Trssv.Models
{
    public class Slot
    {
        [Data(0, 0x3B40)] public byte[] Data { get; set; }

        [Data(0x04)] public DifficultyType Difficulty { get; set; }

        [Data(0x18)] public int Experience { get; set; }
        [Data(0x20)] public byte Level { get; set; }

        [Data(0x30)] public int EnemiesDefeated { get; set; }
        [Data(0x34)] public int StyleChangesPerformed { get; set; }
        [Data(0x3C)] public int MagicFiragaUses { get; set; }
        [Data(0x44)] public int MagicBlizzardUses { get; set; }
        [Data(0x4C)] public int MagicThundagaUses { get; set; }
        [Data(0x64)] public int MagicCuragaUses { get; set; }


        [Data(0x24)] public byte Location { get; set; }

        [Data(0x2384, 5, 0x200)] public List<PlayableCharacter> Pc { get; set; }

        [Data(0x3324, 0x100)] public string MapPath { get; set; }
        [Data(0x3424, 0x40)] public string MapSpawn { get; set; }
        [Data(0x3464, 0x100)] public string PlayerScript { get; set; }
        [Data(0x3564, 0x100)] public string PlayerCharacter { get; set; }
        [Data(0x3664, 0x100)] public string SupportCharacter { get; set; }
    }
}
