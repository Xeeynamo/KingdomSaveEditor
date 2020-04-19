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

using KHSave.LibFf7Remake.Models;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkCommon
    {
        [Data(Count = 0x00050008)] public byte[] Data { get; set; }

        [Data(8, Count = 5, Stride = 0x40)] public Character[] Characters { get; set; }
        [Data(0x1818, Count = 1000, Stride = 0x20)] public Materia[] Materia { get; set; }
        [Data(0x34DA8, Count = 0x800, Stride = 0x18)] public Inventory[] Inventory { get; set; }
        [Data(0x40DA8, Count = 0x80, Stride = 0x30)] public Equipment[] Equipments { get; set; }
        [Data(0x42F5C)] public byte PlayableCharacter { get; set; }
        [Data(0x42F5D)] public byte CurrentChapter { get; set; }
    }
}
