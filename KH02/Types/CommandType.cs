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

namespace KHSave.Types
{
	public enum CommandType : int
	{
		Empty_Dash = 0x0,
		Empty_1 = 0x1,
		PaybackStrike = 0x2,
		CounterSlash = 0x3,
		CounterImpact = 0x4,
		CounterKick = 0x5,
		CounterBlast = 0x6,
		RisingHook = 0x7,
		RiskRaid = 0x8,
		Backslash = 0x9,
		TeleportSlash = 0xa,
		DivingStrike = 0xb,
		FinalBlow = 0xc,
		Raid = 0xd,
		NanoCounter = 0xe,
		CounterBlade = 0xf,
		WrathfulFist = 0x10,
		WrathfulFlurry = 0x11,
		FlameTorrent = 0x12,
		FlameBarrage = 0x13,
		Lightning = 0x14,
		Sneeze = 0x15,
		UnisonFire = 0x16,
		UnisonBlizzard = 0x17,
		UnisonThunder = 0x18,
		FusionSpin = 0x19,
		FusionRocket = 0x1a,
		Attack = 0x1b,
		Empty_2 = 0x1c,
		[Magic] Fire = 0x1d,
		[Magic] Fira = 0x1e,
		[Magic] Firaga = 0x1f,
		[Magic] Firaza = 0x20,
		[Magic] Blizzard,
		[Magic] Blizzara,
		[Magic] Blizzaga,
		[Magic] Blizzaza,
		[Magic] Thunder,
		[Magic] Thundara,
		[Magic] Thundaga,
		[Magic] Thundaza,
		[Magic] Water,
		[Magic] Watera,
		[Magic] Waterga,
		[Magic] Waterza,
		[Magic] Aero,
		[Magic] Aerora,
		[Magic] Aeroga = 0x2f,
		[Magic] Aeroza,
		[Magic] Cure,
		[Magic] Cura,
		[Magic] Curaga,
		[Magic] Curaza,
		[Magic] SeaFire,
		[Magic] SeaBlizzard,
		[Magic] SeaThunder,
		[Magic] SeaAero,
		[Consumable("Potion")] Potion = 0x3a,
		[Consumable("Hi-Potion")] HiPotion,
		[Consumable("Mega-Potion")] MegaPotion,
		[Consumable("Ether")] Ether,
		[Consumable] HiEther,
		[Consumable("Mega-Ether")] MegaEther,
		[Consumable("Refocuser")] Refocuser,
		[Consumable("Hi-Refocuser")] HiRefocuser,
		[Consumable("Panacea")] Panacea,
		Unused45,
		Unused46,
		Unused47,
		[Link("Meow Wow Balloon")] MeowWowBaloon,
		[Link("8-Bit Blast")] EightBitBlast,
		[Link("King's Flare")] KingFlare,
		[Link("Plasma Encounter")] PlasmaEncounter,
		[Link("Sea Spectacle")] SeaSpectacle,
		Finish,
		Save,
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