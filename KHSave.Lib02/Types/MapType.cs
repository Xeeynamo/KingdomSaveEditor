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

using KHSave.Attributes;

namespace KHSave.Trssv.Types
{
    public enum MapType
    {
        [MapInfo("dw_01", "Main Road")] Dw01,
        [MapInfo("dw_02", "Castle Town")] Dw02,
        [MapInfo("dw_03", "The World Within")] Dw03,
        [MapInfo("dw_04", "Inside the mirror (Road)")] Dw04,
        [MapInfo("dw_05", "Inside the mirror (Colums)")] Dw05,
        [MapInfo("dw_06", "Inside the mirror (Dwarf)")] Dw06,
        [MapInfo("dw_07", "Inside the mirror (Battle)")] Dw07,
        [MapInfo("dw_08", "Forest of Thorns")] Dw08,
        [MapInfo("dw_09", "Depths of Darkness")] Dw09,
        [MapInfo("dw_10", "Destiny Island")] Dw10,
        [MapInfo("dw_11", "Boss Rush (vs. Darkside)")] Dw11,
        [MapInfo("dw_12", "Boss Rush (Columns room)")] Dw12,
        [MapInfo("dw_58", "Opening")] Dw58,
        [MapInfo("dw_59", "dw59 (infinite loading screen)")] Dw59,
        [MapInfo("dw_60", "Ending")] Dw60,
    }
}
