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

using KHSave.Attributes;

namespace KHSave.Trssv.Types
{
    public enum MapType
    {
        [MapInfo("dw_01", "Main Road")] dw_01,
        [MapInfo("dw_02", "Castle Town")] dw_02,
        [MapInfo("dw_03", "The World Within")] dw_03,
        [MapInfo("dw_04", "Inside the mirror (Road)")] dw_04,
        [MapInfo("dw_05", "Inside the mirror (Colums)")] dw_05,
        [MapInfo("dw_06", "Inside the mirror (Dwarf)")] dw_06,
        [MapInfo("dw_07", "Inside the mirror (Battle)")] dw_07,
        [MapInfo("dw_08", "Forest of Thorns")] dw_08,
        [MapInfo("dw_09", "Depths of Darkness")] dw_09,
        [MapInfo("dw_10", "Destiny Island")] dw_10,
        [MapInfo("dw_11", "Boss Rush (vs. Darkside)")] dw_11,
        [MapInfo("dw_12", "Boss Rush (Columns room)")] dw_12,
        [MapInfo("dw_58", "Opening")] dw_58,
        [MapInfo("dw_59", "dw59 (infinite loading screen)")] dw_59,
        [MapInfo("dw_60", "Ending")] dw_60,
    }
}
