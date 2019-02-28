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
	public enum ArmorType : byte
	{
		Empty,
        [Armor("Hero's Belt")] HerosBelt,
        [Armor("Hero's Glove")] HerosGlove,
        [Armor("Shield Belt")] ShieldBelt,
        [Armor("DefenseBelt")] DefenseBelt,
        [Armor("Guardian Belt")] GuardianBelt,
        [Armor("Power Band")] PowerBand,
		[Armor("Buster Band")] BusterBand,
		[Armor("Buster Band+")] BusterBandPlus,
		[Armor("Cosmic Belt")] CosmicBelt,
		[Armor("Cosmic Belt+")] CosmicBeltPlus,
		[Armor("Fire Bangle")] FireBangle,
        [Armor("Firaga Bangle")] FiragaBangle,
        [Armor("Firaza Bangle")] FirazaBangle,
        [Armor("Fire Chain")] FireChain,
        [Armor("Blizzard Choker")] BlizzardChoker,
        [Armor("Blizzara Choker")] BlizzaraChoker,
        [Armor("Blizzaga Choker")] BlizzagaChoker,
        [Armor("Blizzard Chain")] BlizzardChain,
        [Armor("Thunder Trinket")] ThunderTrinket,
        [Armor("Thundaga Trinket")] ThundagaTrinket,
        [Armor("Thundaza Trinket")] ThundazaTrinket,
        [Armor("Thunder Chain")] ThunderChain,
        [Armor("Dark Anklet")] DarkAnklet,
        [Armor("Midnight Anklet")] MidnightAnklet,
        [Armor("Chaos Anklet")] ChaosAnklet,
        [Armor("Dark Chain")] DarkChain,
        [Armor("Divine Bandanna")] DivineBandanna,
        [Armor("Elven Bandanna")] ElvenBandanna,
        [Armor("Aqua Chaplet")] AquaChaplet,
        [Armor("Wind Fan")] WindFan,
        [Armor("Storm Fan")] StormFan,
        [Armor("Aero Armlet")] AeroArmlet,
        [Armor("Aegis Chain")] AegisChain,
		[Armor("Acrisius")] Acrisius,
		[Armor("Cosmic Chain")] CosmicChain,
		[Armor("Petite Ribbon")] PetiteRibbon,
		[Armor("Ribbon")] Ribbon,
        [Armor("Fira Bangle")] FiraBangle,
        [Armor("Blizzaza Choker")] BlizzazaChoker,
        [Armor("Thundara Trinket")] ThundaraTrinket,
        [Armor("Shadow Anklet")] ShadowAnklet,
        [Armor("Abas Chain")] AbasChain,
        [Armor("Acrisius+")] AcrisiusPlus,
		[Armor("Royal Ribbon")] RoyalRibbon,
        [Armor("Firefighter Rosette")] FirefighterRosette,
        [Armor("Umbrella Rosette")] UmbrellaRosette,
        [Armor("Snowman Rosette")] SnowmanRosette,
        [Armor("Insulator Rosette")] InsulatorRosette

    }
}
