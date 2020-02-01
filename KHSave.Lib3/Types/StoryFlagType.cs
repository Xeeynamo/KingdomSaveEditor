/*
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
	public enum StoryFlagType
	{
		[Info("Scala ad Caelum")] gameflow_BT,
		[Info("San Fransokyo")] gameflow_BX,
		[Info("Caribbean")] gameflow_CA,
		[Info("Caribbean - Chart last access")] gameflow_CA_chart_last_access,
		[Info("Caribbean - Ship ride type")] gameflow_CA_ship_ride_type,
		[Info("Caribbean - Port Royal search")] gameflow_CA_Sub_Portroyal_Search,
		[Info("World CS (unused)")] gameflow_CS,
		[Info("Destiny Island")] gameflow_DI,
		[Info("Land of Departure")] gameflow_DP,
		[Info("Dark World")] gameflow_DW,
		[Info("Dark World (unused)")] gameflow_DW_Sub_INT,
		[Info("Final World")] gameflow_EW,
		[Info("Final World - Test")] gameflow_EW_Sub_TESTB,
		[Info("Final World - Dive")] gameflow_EW_MISSION,
		[Info("Final World - Kingdom of Corona")] gameflow_EW_MISSION_RA,
		[Info("Final World - Monstropolis")] gameflow_EW_MISSION_MI,
		[Info("Final World - Toy Box")] gameflow_EW_MISSION_TS,
		[Info("Final World - Caribbean")] gameflow_EW_MISSION_CA,
		[Info("Final World - Frozen")] gameflow_EW_MISSION_FZ,
		[Info("System (unused)")] gameflow_EX,
		[Info("Arendelle")] gameflow_FZ,
		[Info("Arendelle - Minigame")] gameflow_FZ_Sub_SLIDEMISSION,
		[Info("Gummiship")] gameflow_GM,
		[Info("Gummiship - Area 1")] gameflow_GM_01,
		[Info("Gummiship - Area 2")] gameflow_GM_02,
		[Info("Gummiship - Area 3A")] gameflow_GM_03,
		[Info("Gummiship - Area 3B")] gameflow_GM_03_SUB,
		[Info("Gummiship - System")] gameflow_GM_SYS,
		[Info("Gummiship - Level up")] gameflow_GM_SYS_LEVELUP,
		[Info("Olympus")] gameflow_HE,
		[Info("Olympus  #2")] gameflow_HE_Sub_HeraculesBoy,
		[Info("Keyblade Graveyard")] gameflow_KG,
		[Info("KG - Dark Riku, Xigbar")] gameflow_KG_13_A,
		[Info("KG - Luxord, Marluxia, Larxene")] gameflow_KG_13_B,
		[Info("KG - Vanitas, Terra-Xehanort")] gameflow_KG_13_C,
		[Info("KG - Xion, Saix")] gameflow_KG_13_D,
		[Info("Monstropolis")] gameflow_MI,
		[Info("Monstropolis (unused)")] gameflow_MI_Sub_INT,
		[Info("100 Acre Wood")] gameflow_PO,
		[Info("Kingdom of Corona")] gameflow_RA,
		[Info("Kingdom of Corona - Dandelion")] gameflow_RA_Dandelion,
		[Info("Kingdom of Corona - Rabbit")] gameflow_RA_Rabbit,
		[Info("Kingdom of Corona - Rainbow")] gameflow_RA_Rainbow,
		[Info("Kingdom of Corona - Bird")] gameflow_RA_Bird,
		[Info("Radiant Garden")] gameflow_RG,
		[Info("Secret Forest")] gameflow_SF,
		[Info("Toy Box")] gameflow_TS,
		[Info("Toy Box - Minigame")] gameflow_TS_Sub_GAM1,
		[Info("Twilight Town")] gameflow_TT,
		[Info("Twilight Town - Winnie the Pooh")] gameflow_TT_PO,
		[Info("Twilight Town - Remy")] gameflow_TT_Remy,
		[Info("World map - Olympus")] gameflow_WM_WORLD_HE,
		[Info("World map - Twilight Town")] gameflow_WM_WORLD_TT,
		[Info("World map - Kingdom of Corona")] gameflow_WM_WORLD_RA,
		[Info("World map - Toy Story")] gameflow_WM_WORLD_TS,
		[Info("World map - Monstropolis")] gameflow_WM_WORLD_MI,
		[Info("World map - Arendelle")] gameflow_WM_WORLD_FZ,
		[Info("World map - Caribbean")] gameflow_WM_WORLD_CA,
		[Info("World map - San Fransokyo")] gameflow_WM_WORLD_BX,
		[Info("World map - Keyblade Graveyard")] gameflow_WM_WORLD_KG,
		[Info("Game battle level")] global_GameBattleLV,
		[Info("Game shop level")] global_GameShopLV,
		[Info("The Mysterious Tower")] gameflow_YT,
		[Info("Scala ad Caelum (DLC) main map")] gameflow_BT_DLC,
		[Info("Scala ad Caelum (DLC) second map")] gameflow_BT_DLC_07_BT_01,
		[Info("Scala ad Caelum (DLC) Monument")] gim_BT_DLC_monument,
		[Info("Keyblade Graveyard (DLC)")] gameflow_KG_DLC,
		[Info("KG (DLC) - Dark Riku, Xigbar")] gameflow_KG_DLC_13_A,
		[Info("KG (DLC) - Luxord, Marluxia, Larxene")] gameflow_KG_DLC_13_B,
		[Info("KG (DLC) - Vanitas, Terra-Xehanort")] gameflow_KG_DLC_13_C,
		[Info("KG (DLC) - Xion, Saix")] gameflow_KG_DLC_13_D,
		[Info("KG (DLC) Character Select 1")] gameflow_KG_DLC_05_AREA_A_CHARSEL,
		[Info("KG (DLC) Character Select 2")] gameflow_KG_DLC_05_AREA_B_CHARSEL,
		[Info("KG (DLC) Character Select 3")] gameflow_KG_DLC_05_AREA_C_CHARSEL,
		[Info("KG (DLC) Character Select 4")] gameflow_KG_DLC_05_AREA_D_CHARSEL,
		[Info("Keyblade Graveyard (DLC) Last fight")] gameflow_KG_DLC_06_LAST_CHARSEL,
		[Info("Radiant Garden (DLC)")] gameflow_RG_DLC,
		[Info("Yozora Fight")] gameflow_SS_DLC,
		[Info("Yozora Fight - Bad ending")] gameflow_SS_DLC_Sub_BadEnd,
		[Info("Yozora Fight - True ending")] gameflow_SS_DLC_Sub_TrueEnd,
	}
}
