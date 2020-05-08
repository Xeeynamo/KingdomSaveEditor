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

namespace KHSave.Lib2.Types
{
    // https://openkh.dev/kh2/worlds.html
    public enum WorldType : byte
    {
        [World("zz", "World ZZ")] WorldZZ,
        [World("es", "End of Sea")] EndOfSea,
        [World("tt", "Twilight Town")] TwilightTown,
        [World("di", "Destiny Island")] DestinyIsland,
        [World("hb", "Hollow Bastion")] HollowBastion,
        [World("bb", "Beast's Castle")] BestCastle,
        [World("he", "Olympus Coliseum")] OlympusColiseum,
        [World("al", "Agrabah")] Agrabah,
        [World("mu", "The Land of Dragons")] LandOfDragons,
        [World("po", "100 Acre Wood")] HundredsAcreWood,
        [World("lk", "Pride Land")] PrideLand,
        [World("lm", "Atlantica")] Atlantica,
        [World("dc", "Disney Castle")] DisneyCastle,
        [World("wi", "Timeless River")] TimelessRiver,
        [World("nm", "Halloween Town")] HalloweenTown,
        [World("wm", "World Map")] WorldMap,
        [World("ca", "Port Royal")] PortRoyal,
        [World("tr", "Space Paranoids")] SpaceParanoids,
        [World("eh", "The World That Never Was")] TheWorldThatNeverWas,
    }
}
