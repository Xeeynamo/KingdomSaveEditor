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

using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Models
{
    public class Character
    {
        [Data] public byte Level { get; set; }
        [Data] public bool IsUnlocked { get; set; }
        [Data] public byte AtbBarCount { get; set; }
        [Data] public byte Unknown03 { get; set; }
        [Data] public int Unknown04 { get; set; }
        [Data] public int Unknown08 { get; set; }
        [Data] public int Unknown0c { get; set; }
        [Data] public int CurrentHp { get; set; }
        [Data] public int MaxHp { get; set; }
        [Data] public int CurrentMp { get; set; }
        [Data] public int MaxMp { get; set; }
        [Data] public int Experience { get; set; }
        [Data] public int Unknown14 { get; set; }
        [Data] public int Attack { get; set; }
        [Data] public int MagicAttack { get; set; }
        [Data] public int Defense { get; set; }
        [Data] public int MagicDefense { get; set; }
        [Data] public int Luck { get; set; }
        [Data] public int Unknown3c { get; set; }
    }
}
