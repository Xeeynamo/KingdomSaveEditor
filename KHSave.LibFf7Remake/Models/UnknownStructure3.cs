﻿/*
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
    public class UnknownStructure3
    {
        [Data] public byte Character { get; set; }
        [Data] public byte Unknown01 { get; set; }
        [Data] public byte Unknown02 { get; set; }
        [Data] public byte Unused03 { get; set; }
        [Data] public int Unknown04 { get; set; }
        [Data] public int Unknown08 { get; set; }
        [Data] public int Unknown0c { get; set; }
        [Data] public int Unknown10 { get; set; }
        [Data(Count = 12)] public byte[] Characters { get; set; }
        [Data] public int Unused20 { get; set; }
        [Data] public int Unused24 { get; set; }
        [Data] public int Unused28 { get; set; }
        [Data] public int Unused2c { get; set; }
    }
}
