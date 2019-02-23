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
	public enum InventoryType
	{
		[Consumable("")] KupoCoin,
		[Consumable("Potion")] Potion,
		[Consumable("Hi-potion")] HiPotion,
		[Consumable("Mega-potion")] MegaPotion,
		[Consumable("Ether")] Ether,
		[Consumable("Mega-ether")] MegaEther,
		[Consumable("Elixir")] Elixir,
		[Consumable("Megalixir")] Megalixir,
		[Consumable("Refocuser")] Refocuser,
		[Consumable("Hi-refocuser")] HiRefocuser,
		[Consumable("Panacea")] Panacea,
		[Consumable("Hi-ether")] HiEther,
		[Unused] UnusedItem0d,
		[Unused] UnusedItem0e,
		[Unused] UnusedItem0f,
		[Unused] UnusedItem10,
		[Unused] UnusedItem11,
		[Consumable("Tent")] Tent,
		[Consumable("Strength boost")] StrengthBoost,
		[Consumable("Magic boost")] MagicBoost,
		[Consumable("Defense boost")] DefenseBoost,
		[Consumable("AP boost")] ApBoost,
		[Unused] UnusedBoost17,
		[Unused] UnusedBoost18,
		[Unused] UnusedBoost19,
		[Keyblade("Kingdom Key")] KingdomKey,
		[Keyblade("Hero's Origin")] HeroOrigin,
		[Keyblade("Shooting Star")] ShootingStar,
		FavoriteDeputy,
		EvenAfter,
		HappyGear,
		CrystalSnow,
		HunnySpout,
		NanoGear,
		WheelOfFate,
		GrandChef,
		ClassicTone,
		[Unused] UnusedKeyblade26,
		[Unused] UnusedKeyblade27,
		UltimaWeapon,
		[Unused] UnusedKeyblade29,
		[Unused] UnusedKeyblade2a,
		Starlight,
		[Unused] UnusedKeyblade2c,
		[Unused] UnusedKeyblade2b,
		MageStaff,
		MageStaffPlus,
		Warhammer,
		WarhammerPlus,
		MagicianWand,
		MagicianWandPlus,
		Nirvana,
		NirvanaPlus,
		Astrolabe,
		AstrolabePlus,
		HeartlessMaul,
		HeartlessMaulPlus,
		SaveTheQueen,
		SaveTheQueenPlus,
		[Unused] UnusedStaff3c,
		[Unused] UnusedStaff3d,
		[Unused] UnusedStaff3e,
		[Unused] UnusedStaff3f,
		[Unused] UnusedStaff40,
		[Unused] UnusedStaff41,
		KnightShield,
		KnightShieldPlus,
		ClockworkShield,
		ClockworkShieldPlus,
		StarShield,
		StarShieldPlus,
		AegisShield,
		AegisShieldPlus,
		StormAnchor,
		StormAnchorPlus,
		NobodyGuard,
		NobodyGuardPlus,
		SaveTheKing,
		SaveTheKingPlus,
		[Unused] Unused50,
		[Unused] Unused51,
		[Unused] Unused52,
		[Unused] Unused53,
		[Unused] Unused54,
		[Unused] Unused55,
		[Unused] Unused56,
		[Unused] Unused57,
		[Unused] Unused58,
		[Unused] Unused59,
		[Unused] Unused5a,
		[Unused] Unused5b,
		[Unused] Unused5c,
		[Unused] Unused5d,
		HeartOfHero,
		CowboyPride,
		SpaceRangerSuit,
		GoldenHair,
		FryingPan,
		SkillAndCrossbones,
		IceClaws,
		PoweredSuit,
		Claws,
		KnockoutBody
	}
}
