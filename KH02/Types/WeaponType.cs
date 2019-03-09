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
	public enum WeaponType : byte
	{
		[Info] Empty,
		[Keyblade("Kingdom Key")] KingdomKey,
		[Keyblade("Hero's Origin")] HeroOrigin,
		[Keyblade("Shooting Star")] ShootingStar,
		[Keyblade("Favorite Deputy")] FavoriteDeputy,
		[Keyblade("Even After")] EvenAfter,
		[Keyblade("Happy Gear")] HappyGear,
		[Keyblade("Crystal Snow")] CrystalSnow,
		[Keyblade("Hunny Spout")] HunnySpout,
		[Keyblade("Nano Gear")] NanoGear,
		[Keyblade("Wheel of Fate")] WheelOfFate,
		[Keyblade("Grand Chef")] GrandChef,
		[Keyblade("Classic Tone")] ClassicTone,
		[Unused] Unknown0D,
		[Unused] Unknown0E,
		[Keyblade("Ultima Weapon")] UltimaWeapon,
		[Keyblade("Midnight Blue")] MidnightBlue,
		[Unused] [Keyblade("Unknown11")] Unknown11,
		[Keyblade("Starlight")] Starlight,
		[Keyblade("Dawn Till Dusk")] DawnTillDusk,
		[Unused] Weapon14,
		[Staff("Mage's Staff")] Weapon15,
		[Staff("Mage's Staff+")] Weapon16,
		[Staff("Warhammer")] Weapon17,
		[Staff("Warhammer+")] Weapon18,
		[Staff("Magician's Wand")] Weapon19,
		[Staff("Magician's Wand+")] Weapon1a,
		[Staff("Nirvana")] Weapon1b,
		[Staff("Nirvana+")] Weapon1c,
		[Staff("Astroblade")] Weapon1d,
		[Staff("Astroblade+")] Weapon1e,
		[Staff("Heartless Maul")] Weapon1f,
		[Staff("Heartless Maul+")] Weapon20,
		[Staff("Save the Queen")] Weapon21,
		[Staff("Save the Queen+")] SaveTheQueenPlus,
		[Unused] Weapon23,
		[Unused] Weapon24,
		[Unused] Weapon25,
		[Unused] Weapon26,
		[Unused] Weapon27,
		[Unused] Weapon28,
		[Shield("Knight Shield")] Weapon29,
		[Shield("Knight Shield+")] Weapon2a,
		[Shield("Clockwork Shield")] Weapon2b,
		[Shield("Clockwork Shield+")] Weapon2c,
		[Shield("Star Shield")] Weapon2d,
		[Shield("Star Shield+")] Weapon2e,
		[Shield("Aegis Shield")] Weapon2f,
		[Shield("Aegis Shield+")] Weapon30,
		[Shield("Storm Anchor")] Weapon31,
		[Shield("Storm Anchor+")] Weapon32,
		[Shield("Nobody Guard")] Weapon33,
		[Shield("Nobody Guard+")] Weapon34,
		[Shield("Save the King")] Weapon35,
		[Shield("Save the King+")] SaveTheKingPlus,
		[Unused] Weapon37,
		[Unused] Weapon38,
		[Unused] Weapon39,
		[Unused] Weapon3a,
		[Unused] Weapon3b,
		[Unused] Weapon3c,
		[Weapon("Master's Defender")] EraqusKeyblade,
		Weapon3e,
		Weapon3f,
		Weapon40,
		Weapon41,
		[Weapon("Kingdom Key D")] KingdomKeyD,
		[Weapon("Kingdom Key D+")] KingdomKeyDPlus,
		Weapon44,
		[Weapon("Heart of Hero")] HeartOfHero,
		[Weapon("Cowboy's Pride")] CowboyPride,
		[Weapon("Space Ranger Suit")] SpaceRangerSuit,
		[Weapon("Golden Hair")] GoldenHair,
		[Weapon("Frying Pan")] FryingPan,
		[Weapon("Skill & Crossbones")] SkillAndCrossbones,
		[Weapon("Ice Claws")] IceClaws,
		[Weapon("Powered Suit")] PoweredSuit,
		[Weapon("Claws")] Claws,
		[Weapon("Knockout Body")] KnockoutBody,
		[Keyblade("Way to Dawn")] WayToDawn,
		[Keyblade("Braveheart")] Braveheart,
		Weapon51,
		Weapon52,
		Weapon53,
		Weapon54,
		Weapon55,
		Weapon56,
		Weapon57,
		[Weapon("Kingdom Key (FAKE)")] FakeKingdomKey,
		Weapon59,
		Weapon5a,
		Weapon5b,
		Weapon5c,
		Weapon5d,
		Weapon5e,
		Weapon5f,
	}
}
