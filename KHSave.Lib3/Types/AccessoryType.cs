﻿/*
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

namespace KHSave.Lib3.Types
{
	public enum AccessoryType : byte
	{
		[Info] Empty,
        [Accessory("Laughter Pin")] LaughterPin,
        [Accessory("Forest Clasp")] ForestClasp,
        [Accessory("Ability Ring")] AbilityRing,
        [Accessory("Ability Ring+")] AbilityRingPlus,
        [Accessory("Technician's Ring")] TechnicianRing,
        [Accessory("Technician's Ring+")] TechnicianRingPlus,
        [Accessory("Skill Ring")] SkillRing,
        [Accessory("Skill Ring+")] SkillRingPlus,
        [Accessory("Expert's Ring")] ExpertRing,
        [Accessory("Master's Ring")] MasterRing,
        [Accessory("Cosmic Ring")] CosmicRing,
        [Accessory("Power Ring")] PowerRing,
        [Accessory("Buster Ring")] BusterRing,
        [Accessory("Valor Ring")] ValorRing,
		[Accessory("Phantom Ring")] PhantomRing,
        [Accessory("Orichalcum Ring")] OrichalcumRing,
        [Accessory("Magic Ring")] MagicRing,
		[Accessory("Rune Ring")] RuneRing,
		[Accessory("Force Ring")] ForceRing,
        [Accessory("Sorcerer's Ring")] SorcererRing,
        [Accessory("Wisdom Ring")] WisdomRing,
        [Accessory("Bronze Necklace")] BronzeNecklace,
        [Accessory("Silver Necklace")] SilverNecklace,
		[Accessory("Master's Necklace")] MasterNecklace,
        [Accessory("Bronze Amulet")] BronzeAmulet,
        [Accessory("Silver Amulet")] SilverAmulet,
        [Accessory("Gold Amulet")] GoldAmulet,
        [Accessory("Junior Medal")] JuniorMedal,
        [Accessory("Master Medal")] MasterMedal,
        [Accessory("Star Medal")] StarMedal,
		[Accessory("Mickey Clasp")] MickeyClasp,
        [Accessory("Soldier's Earring")] SoldierEarring,
        [Accessory("Fencer's Earring")] FencerEarring,
        [Accessory("Mage's Earring")] MageEarring,
        [Accessory("Slayer's Earring")] SlayerEarring,
        [Accessory("Moon Amulet")] MoonAmulet,
        [Accessory("Star Charm")] StarCharm,
        [Accessory("Cosmic Arts")] CosmicArts,
        [Accessory("Crystal Regalia")] CrystalRegalia,
        [Accessory("Water Cufflink")] WaterCufflink,
        [Accessory("Thunder Cufflink")] ThunderCufflink,
        [Accessory("Fire Cufflink")] FireCufflink,
        [Accessory("Aero Cufflink")] AeroCufflink,
        [Accessory("Blizzard Cufflink")] BlizzardCufflink,
		[Accessory("Celestriad")] Celestriad,
        [Accessory("Yin-Yang Cufflink")] YinYangCufflink,
        [Accessory("Gourmand's Ring")] GourmandRing,
        [Accessory("Draw Ring")] DrawRing,
        [Accessory("Lucky Ring")] LuckyRing,
		[Accessory("Flanniversary Badge")] FlanniversaryBadge,
        [Accessory("Bronze Necklace")] BronzeNecklace_33,
        [Accessory("Bronze Necklace")] BronzeNecklace_34,
        [Accessory("Bronze Necklace")] BronzeNecklace_35,
        [Accessory("Bronze Necklace")] BronzeNecklace_36,
        [Accessory("Bronze Necklace")] BronzeNecklace_37,
        [Accessory("Bronze Necklace")] BronzeNecklace_38,
        [Accessory("Bronze Necklace")] BronzeNecklace_39,
        [Accessory("Bronze Necklace")] BronzeNecklace_3A,
        [Accessory("Bronze Necklace")] BronzeNecklace_3B,
        [Accessory("Bronze Necklace")] BronzeNecklace_3C,
        [Accessory("Bronze Necklace")] BronzeNecklace_3D,
        [Accessory("Bronze Necklace")] BronzeNecklace_3E,
        [Accessory("Silver Necklace")] SilverNecklace_3F,
        [Accessory("Silver Necklace")] SilverNecklace_40,
        [Accessory("Silver Necklace")] SilverNecklace_41,
        [Accessory("Silver Necklace")] SilverNecklace_42,
        [Accessory("Silver Necklace")] SilverNecklace_43,
        [Accessory("Silver Necklace")] SilverNecklace_44,
        [Accessory("Silver Necklace")] SilverNecklace_45,
        [Accessory("Silver Necklace")] SilverNecklace_46,
        [Accessory("Silver Necklace")] SilverNecklace_47,
        [Accessory("Silver Necklace")] SilverNecklace_48,
        [Accessory("Silver Necklace")] SilverNecklace_49,
        [Accessory("Master's Necklace")] MasterNecklace_4A,
        [Accessory("Master's Necklace")] MasterNecklace_4B,
        [Accessory("Master's Necklace")] MasterNecklace_4C,
        [Accessory("Master's Necklace")] MasterNecklace_4D,
        [Accessory("Master's Necklace")] MasterNecklace_4E,
        [Accessory("Master's Necklace")] MasterNecklace_4F,
        [Accessory("Master's Necklace")] MasterNecklace_50,
        [Accessory("Master Medal")] MasterMedal_51,
        [Accessory("Master Medal")] MasterMedal_52,
        [Accessory("Junior Medal")] JuniorMedal_53,
        [Accessory("Master Medal")] MasterMedal_54,
        [Accessory("Junior Medal")] JuniorMedal_55,
        [Accessory("Junior Medal")] JuniorMedal_56,
        [Accessory("Junior Medal")] JuniorMedal_57,
        [Accessory("Junior Medal")] JuniorMedal_58,
        [Accessory("Junior Medal")] JuniorMedal_59,
        [Accessory("Junior Medal")] JuniorMedal_5A,
        [Accessory("Junior Medal")] JuniorMedal_5B,
        [Accessory("Junior Medal")] JuniorMedal_5C,
        [Accessory("Star Medal")] StarMedal_5D,
        [Accessory("Master Medal")] MasterMedal_5E,
        [Accessory("Master Medal")] MasterMedal_5F,
        [Accessory("Star Medal")] StarMedal_60,
        [Accessory("Master Medal")] MasterMedal_61,
        [Accessory("Star Medal")] StarMedal_62,
        [Accessory("Master Medal")] MasterMedal_63,
        [Accessory("Master Medal")] MasterMedal_64,
        [Accessory("Master Medal")] MasterMedal_65,
        [Accessory("Master Medal")] MasterMedal_66,
        [Accessory("Master Medal")] MasterMedal_67,
        [Accessory("Master Medal")] MasterMedal_68,
        [Accessory("Star Medal")] StarMedal_69,
        [Accessory("Star Medal")] StarMedal_6A,
        [Accessory("Star Medal")] StarMedal_6B,
        [Accessory("Star Medal")] StarMedal_6C,
        [Accessory("Star Medal")] StarMedal_6D,
        [Accessory("Star Medal")] StarMedal_6E,
	[Accessory("Breakthrough")] Item6f,
	[Accessory("Crystal Regalia+")] Item70,
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
