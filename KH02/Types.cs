/*
    Kingdom Hearts 0.2 and 3 Save Editor
    Copyright (C) 2019  Luciano Ciccariello

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

namespace KHSave
{
	public enum DifficultyType
	{
		Easy,
		Normal,
		Proud,
		Critical
	}

	public enum WorldType
	{
		[WorldInfo("bt", "Scala Ad Caelum")]
		ScalaAdCaelum = 1,

		[WorldInfo("dw", "Dark World")]
		DarkWorld = 3,

		[WorldInfo("he", "Olympus")]
		Olympus = 4,

		[WorldInfo("ts", "Toy Box")]
		ToyBox = 5,

		[WorldInfo("ra", "Kindom of Corona")]
		KingdomOfCorona = 7,

		[WorldInfo("fz", "Arendelle")]
		Arendelle = 8,

		[WorldInfo("ca", "Caribbean")]
		Caribbean = 9,

		[WorldInfo("po", "100 Acre Wood")]
		AcreWood = 10,

		[WorldInfo("mi", "Monstropolis")]
		Monstropolis,

		[WorldInfo("tt", "Twilight Town")]
		TwilightTown,

		[WorldInfo("??", "The Mysterious Tower")]
		MysteriousTower,

		[WorldInfo("kg", "Keyblade Graveyard")]
		KeybladeGraveyard,

		[WorldInfo("bx", "San Fransokyo")]
		SanFransokyo = 19,

		[WorldInfo("dw", "The Final World")]
		FinalWorld = 22,

		[WorldInfo("dp", "Land of Departure")]
		LandOfDeparture = 25
	}

	public enum CharacterIconType
	{
		Sora = 1,
		Riku = 2,
		Kairi = 3,
		Terra = 4,
		Ventus = 5,
		Aqua = 6,
		Roxas = 7,
		Axel = 8,
		Xion = 9,
		Mickey = 10,
		Donald = 11,
		Goofy = 12,
		Hercules = 13,
		Woody = 14,
		Buzz = 15
	}

	public enum CommandType
	{
		Fire = 0x1d,
		Fira,
		Firaga,
		Firaza,
		Blizzard,
		Blizzara,
		Blizzaga,
		Blizzaza,
		Thunder,
		Thundara,
		Thundaga,
		Thundaza,
		Water,
		Watera,
		Waterga,
		Waterza,
		Aero,
		Aerora,
		Aeroga,
		Aeroza,
		Cure,
		Cura,
		Curaga,
		Curaza,
		SeaFire,
		SeaBlizzard,
		SeaThunder,
		SeaAero,

		Potion = 0x3a,
		HiPotion,
		MegaPotion,
		Ether,
		HiEther,
		MegaEther,
		Refocuser,
		HiRefocuser,
		Panacea,
		Unused45,
		MeowWowBaloon,
		EightBitBlast,
		KingFlare,
		PlasmaEncounter,
		SeaSpectacle,
		Finish,
		Save = 0x4c,
		Talk,
		Open,
		Examine,
		Shop,
		Help,
		Board,
		TakeTheHelm,

		[Info("Infinite jump")] Jump = 0xc6,
		ArsArcanum = 0xad,
		AncientLight = 0xae
	}
}
