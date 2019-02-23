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
		[Keyblade("Kingdom Key")] KingdomKey = 0x01,
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
		[Unused] [Keyblade("Unknown0D")] Unknown0D,
		[Unused] [Keyblade("Unknown0E")] Unknown0E,
		[Keyblade("Ultima Weapon")] UltimaWeapon,
		[Keyblade("Midnight Blue")] MidnightBlue,
		[Unused] [Keyblade("Unknown11")] Unknown11,
		[Keyblade("Starlight")] Starlight,
		[Keyblade("Dawn Till Dusk")] DawnTillDusk,

		[Weapon("Kingdom Key D")] KingdomKeyD = 0x42,
		[Weapon("Kingdom Key D+")] KingdomKeyDPlus = 0x43,
		[Weapon("Heart of Hero")] HeartOfHero = 0x45,
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
		[Weapon("Kingdom Key (FAKE)")] FakeKingdomKey,
	}
}
