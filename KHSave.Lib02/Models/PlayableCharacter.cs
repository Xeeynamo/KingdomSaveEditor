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

namespace KHSave.Trssv.Models
{
    public class PlayableCharacter
    {
        [Data(0, 0x200)] public byte[] Data { get; set; }
        [Data(0x08C)] public int Hp { get; set; }
        [Data(0x090)] public int Mp { get; set; }
        [Data(0x094)] public int Focus { get; set; }
    }
}
