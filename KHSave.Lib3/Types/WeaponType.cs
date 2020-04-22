﻿/*
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
	public enum WeaponType : byte
	{
		[Info] Empty,
		[Keyblade("Kingdom Key")] KingdomKey,
		[Keyblade("Hero's Origin")] HeroOrigin,
		[Keyblade("Shooting Star")] ShootingStar,
		[Keyblade("Favorite Deputy")] FavoriteDeputy,
		[Keyblade("Ever After")] EvenAfter,
		[Keyblade("Happy Gear")] HappyGear,
		[Keyblade("Crystal Snow")] CrystalSnow,
		[Keyblade("Hunny Spout")] HunnySpout,
		[Keyblade("Nano Gear")] NanoGear,
		[Keyblade("Wheel of Fate")] WheelOfFate,
		[Keyblade("Grand Chef")] GrandChef,
		[Keyblade("Classic Tone")] ClassicTone,
		[Keyblade("Oathkeeper")] Oathkeeper,
		[Keyblade("Oblivion")] Oblivion,
		[Keyblade("Ultima Weapon")] UltimaWeapon,
		[Keyblade("Midnight Blue")] MidnightBlue,
		[Keyblade("Phantom Green")] PhantomGreen,
		[Keyblade("Starlight")] Starlight,
		[Keyblade("Dawn Till Dusk")] DawnTillDusk,
		[Unused] UnusedKeyblade2b,
		[Staff("Mage's Staff")] Weapon15,
		[Staff("Mage's Staff+")] Weapon16,
		[Staff("Warhammer")] Weapon17,
		[Staff("Warhammer+")] Weapon18,
		[Staff("Magician's Wand")] Weapon19,
		[Staff("Magician's Wand+")] Weapon1a,
		[Staff("Nirvana")] Weapon1b,
		[Staff("Nirvana+")] Weapon1c,
		[Staff("Astrolabe")] Weapon1d,
		[Staff("Astrolabe+")] Weapon1e,
		[Staff("Heartless Maul")] Weapon1f,
		[Staff("Heartless Maul+")] Weapon20,
		[Staff("Save the Queen")] Weapon21,
		[Staff("Save the Queen+")] SaveTheQueenPlus,
		[Unused] UnusedStaff3c,
		[Unused] UnusedStaff3d,
		[Unused] UnusedStaff3e,
		[Unused] UnusedStaff3f,
		[Unused] UnusedStaff40,
		[Unused] UnusedStaff41,
		[Shield("Knight's Shield")] Weapon29,
		[Shield("Knight's Shield+")] Weapon2a,
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
		[Weapon("Kingdom Key W")] KingdomKeyDPlus,
		Weapon44,
		[Weapon("Heart of a Hero")] HeartOfHero,
		[Weapon("Cowboy's Pride")] CowboyPride,
		[Weapon("Space Ranger Suit")] SpaceRangerSuit,
		[Weapon("Golden Hair")] GoldenHair,
		[Weapon("Frying Pan")] FryingPan,
		[Weapon("Skill & Crossbones")] SkillAndCrossbones,
		[Weapon("Ice Claws")] IceClaws,
		[Weapon("Powered Suit")] PoweredSuit,
		[Weapon("Claws")] Claws,
		[Weapon("Knockout Body")] KnockoutBody,
		[Keyblade("Way to the Dawn")] WayToDawn,
		[Keyblade("Braveheart")] Braveheart,
		Weapon51,
		Weapon52,
		Weapon53,
		Weapon54,
		Weapon55,
		Weapon56,
		Weapon57,
		[Weapon("Kingdom Key (FAKE)")] FakeKingdomKey,
		[Weapon("Kingdom Key (FAKE)")] FakeKingdomKey2,
		Weapon5a,
		Weapon5b,
		Weapon5c,
		Weapon5d,
		Weapon5e,
		Weapon5f,
		Item60,
		Item61,
		Item62,
		Item63,
		Item64,
		Item65,
		Item66,
		Item67,
		Item68,
		Item69,
		Item6a,
		Item6b,
		Item6c,
		Item6d,
		Item6e,
		Item6f,
		Item70,
		Item71,
		Item72,
		Item73,
		Item74,
		Item75,
		Item76,
		Item77,
		Item78,
		Item79,
		Item7a,
		Item7b,
		Item7c,
		Item7d,
		Item7e,
		Item7f,
		Item80,
		Item81,
		Item82,
		Item83,
		Item84,
		Item85,
		Item86,
		Item87,
		Item88,
		Item89,
		Item8a,
		Item8b,
		Item8c,
		Item8d,
		Item8e,
		Item8f,
		Item90,
		Item91,
		Item92,
		Item93,
		Item94,
		Item95,
		Item96,
		Item97,
		Item98,
		Item99,
		Item9a,
		Item9b,
		Item9c,
		Item9d,
		Item9e,
		Item9f,
		Itema0,
		Itema1,
		Itema2,
		Itema3,
		Itema4,
		Itema5,
		Itema6,
		Itema7,
		Itema8,
		Itema9,
		Itemaa,
		Itemab,
		Itemac,
		Itemad,
		Itemae,
		Itemaf,
		Itemb0,
		Itemb1,
		Itemb2,
		Itemb3,
		Itemb4,
		Itemb5,
		Itemb6,
		Itemb7,
		Itemb8,
		Itemb9,
		Itemba,
		Itembb,
		Itembc,
		Itembd,
		Itembe,
		Itembf,
		Itemc0,
		Itemc1,
		Itemc2,
		Itemc3,
		Itemc4,
		Itemc5,
		Itemc6,
		Itemc7,
		Itemc8,
		Itemc9,
		Itemca,
		Itemcb,
		Itemcc,
		Itemcd,
		Itemce,
		Itemcf,
		Itemd0,
		Itemd1,
		Itemd2,
		Itemd3,
		Itemd4,
		Itemd5,
		Itemd6,
		Itemd7,
		Itemd8,
		Itemd9,
		Itemda,
		Itemdb,
		Itemdc,
		Itemdd,
		Itemde,
		Itemdf,
		Iteme0,
		Iteme1,
		Iteme2,
		Iteme3,
		Iteme4,
		Iteme5,
		Iteme6,
		Iteme7,
		Iteme8,
		Iteme9,
		Itemea,
		Itemeb,
		Itemec,
		Itemed,
		Itemee,
		Itemef,
		Itemf0,
		Itemf1,
		Itemf2,
		Itemf3,
		Itemf4,
		Itemf5,
		Itemf6,
		Itemf7,
		Itemf8,
		Itemf9,
		Itemfa,
		Itemfb,
		Itemfc,
		Itemfd,
		Itemfe,
		Itemff,
	}
}
