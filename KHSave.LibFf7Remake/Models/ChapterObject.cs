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
    public class ChapterObject
    {
        [Data] public int Index { get; set; }
        [Data] public int Unknown04 { get; set; }
        [Data] public int Unknown08 { get; set; }
        [Data] public float Unknown0c { get; set; }
        [Data] public float PositionX { get; set; }
        [Data] public float PositionY { get; set; }
        [Data] public float PositionZ { get; set; }
        [Data] public float Rotation { get; set; }

        public override string ToString() =>
            $"{Index} {Unknown04:X08} {Unknown08:X08} {Unknown0c:N0} POS({PositionX:N0},{PositionY:N0},{PositionZ:N0} A({Rotation:N0})";
    }
}
