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

namespace KHSave.Lib3.Types
{
    public enum WorldType : byte
    {
        [World("bt", "Scala Ad Caelum")]
        ScalaAdCaelum = 1,

        [World("dw", "Dark World")]
        DarkWorld = 3,

        [World("he", "Olympus")]
        Olympus = 4,

        [World("ts", "Toy Box")]
        ToyBox = 5,

        [World("ra", "Kingdom of Corona")]
        KingdomOfCorona = 7,

        [World("fz", "Arendelle")]
        Arendelle = 8,

        [World("ca", "Caribbean")]
        Caribbean = 9,

        [World("po", "100 Acre Wood")]
        AcreWood = 10,

        [World("mi", "Monstropolis")]
        Monstropolis = 11,

        [World("tt", "Twilight Town")]
        TwilightTown = 12,

        [World("yt", "The Mysterious Tower")]
        MysteriousTower = 13,

        [World("kg", "Keyblade Graveyard")]
        KeybladeGraveyard = 14,

        [World("bx", "San Fransokyo")]
        SanFransokyo = 19,

        [World("ew", "The Final World")]
        FinalWorld = 22,

        [World("rg", "Radiant Garden")]
        RadiantGarden = 24,

        [World("dp", "Land of Departure")]
        LandOfDeparture = 25,

        [World("wm", "World Map")]
        WorldMap = 28,

        [World("di", "Destiny Island")]
        DestinyIsland = 0xF0,

        [World("rg", "Radiant Garden")]
        RadiantGarden2 = 0xF1,

        [World("gm", "Gummiship")]
        Gummiship = 0xF2,

        [World("dc", "Disney Castle")]
        DisneyCastle = 0xF3,

        [World("sp", "SP world")]
        Sp = 0xF4,
    }
}
