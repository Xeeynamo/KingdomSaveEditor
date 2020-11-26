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

using KHSave.Lib3.Types;
using System.Collections.Generic;
using System.Linq;
using static KHSave.Lib3.Types.StoryLabelTypeBt;
using static KHSave.Lib3.Types.StoryLabelTypeBx;
using static KHSave.Lib3.Types.StoryLabelTypeCa;
using static KHSave.Lib3.Types.StoryLabelTypeCaChartLastAccess;
using static KHSave.Lib3.Types.StoryLabelTypeCaShipRide;
using static KHSave.Lib3.Types.StoryLabelTypeCaPortroyalSearch;
using static KHSave.Lib3.Types.StoryLabelTypeCs;
using static KHSave.Lib3.Types.StoryLabelTypeDi;
using static KHSave.Lib3.Types.StoryLabelTypeDp;
using static KHSave.Lib3.Types.StoryLabelTypeDw;
using static KHSave.Lib3.Types.StoryLabelTypeEw;
using static KHSave.Lib3.Types.StoryLabelTypeEwSub;
using static KHSave.Lib3.Types.StoryLabelTypeEwMission;
using static KHSave.Lib3.Types.StoryLabelTypeEwRa;
using static KHSave.Lib3.Types.StoryLabelTypeEwMi;
using static KHSave.Lib3.Types.StoryLabelTypeEwTs;
using static KHSave.Lib3.Types.StoryLabelTypeEwCa;
using static KHSave.Lib3.Types.StoryLabelTypeEwFz;
using static KHSave.Lib3.Types.StoryLabelTypeFz;
using static KHSave.Lib3.Types.StoryLabelTypeFzMinigame;
using static KHSave.Lib3.Types.StoryLabelTypeGm;
using static KHSave.Lib3.Types.StoryLabelTypeGm1;
using static KHSave.Lib3.Types.StoryLabelTypeGm2;
using static KHSave.Lib3.Types.StoryLabelTypeGm3;
using static KHSave.Lib3.Types.StoryLabelTypeGm3sub;
using static KHSave.Lib3.Types.StoryLabelTypeGmSys;
using static KHSave.Lib3.Types.StoryLabelTypeGmLevelUp;
using static KHSave.Lib3.Types.StoryLabelTypeHe;
using static KHSave.Lib3.Types.StoryLabelTypeHeSub;
using static KHSave.Lib3.Types.StoryLabelTypeKg;
using static KHSave.Lib3.Types.StoryLabelTypeKgA;
using static KHSave.Lib3.Types.StoryLabelTypeKgB;
using static KHSave.Lib3.Types.StoryLabelTypeKgC;
using static KHSave.Lib3.Types.StoryLabelTypeKgD;
using static KHSave.Lib3.Types.StoryLabelTypeMi;
using static KHSave.Lib3.Types.StoryLabelTypePo;
using static KHSave.Lib3.Types.StoryLabelTypeRa;
using static KHSave.Lib3.Types.StoryLabelTypeRaDandelion;
using static KHSave.Lib3.Types.StoryLabelTypeRaRabbit;
using static KHSave.Lib3.Types.StoryLabelTypeRaRainbow;
using static KHSave.Lib3.Types.StoryLabelTypeRaBird;
using static KHSave.Lib3.Types.StoryLabelTypeRg;
using static KHSave.Lib3.Types.StoryLabelTypeSf;
using static KHSave.Lib3.Types.StoryLabelTypeTs;
using static KHSave.Lib3.Types.StoryLabelTypeTsSub;
using static KHSave.Lib3.Types.StoryLabelTypeTt;
using static KHSave.Lib3.Types.StoryLabelTypeTtPo;
using static KHSave.Lib3.Types.StoryLabelTypeTtRemy;
using static KHSave.Lib3.Types.StoryLabelTypeWmHe;
using static KHSave.Lib3.Types.StoryLabelTypeWmTt;
using static KHSave.Lib3.Types.StoryLabelTypeWmRa;
using static KHSave.Lib3.Types.StoryLabelTypeWmTs;
using static KHSave.Lib3.Types.StoryLabelTypeWmMi;
using static KHSave.Lib3.Types.StoryLabelTypeWmFz;
using static KHSave.Lib3.Types.StoryLabelTypeWmCa;
using static KHSave.Lib3.Types.StoryLabelTypeWmBx;
using static KHSave.Lib3.Types.StoryLabelTypeWmKg;
using static KHSave.Lib3.Types.StoryLabelTypeGameBattle;
using static KHSave.Lib3.Types.StoryLabelTypeGameShop;
using static KHSave.Lib3.Types.StoryLabelTypeYt;
using static KHSave.Lib3.Types.StoryLabelTypeBtDlc8;
using static KHSave.Lib3.Types.StoryLabelTypeBtDlc7;
using static KHSave.Lib3.Types.StoryLabelTypeBtDlc7Monument;
using static KHSave.Lib3.Types.StoryLabelTypeKgDlc;
using static KHSave.Lib3.Types.StoryLabelTypeKgDlc5c;
using static KHSave.Lib3.Types.StoryLabelTypeKgDlc5d;
using static KHSave.Lib3.Types.StoryLabelTypeKgDlcCharSelect;
using static KHSave.Lib3.Types.StoryLabelTypeRgDlc;
using static KHSave.Lib3.Types.StoryLabelTypeSsDlc;
using static KHSave.Lib3.Types.StoryLabelTypeSsDlcSub;

namespace KHSave.Lib3.Presets
{
    public static partial class Presets
    {
        private static Dictionary<int, string> ToStoryLabel<T>(this Dictionary<T, string> dictionary)
            where T : struct =>
            dictionary.ToDictionary(
                x => (int)(object)x.Key,
                x => string.IsNullOrEmpty(x.Value) ? x.Key.ToString() : x.Value
            );

        public static Dictionary<StoryFlagType, Dictionary<int, string>> STORY { get; } = new Dictionary<StoryFlagType, Dictionary<int, string>>
        {
            [StoryFlagType.gameflow_BT] = new Dictionary<StoryLabelTypeBt, string>
            {
                [BT_INIT] = "Beginning",
                [BT_EVENT_bt901] = "Before Mysterious Adversaries",
                [BT_EVENT_bt902] = "Mysterious Adversaries",
                [BT_BATTLE_REPLICA] = "Stairway to the Sky (Part 1)",
                [BT_EVENT_bt903] = "Confront Armored Xehanort once you are duly prepared!",
                [BT_EVENT_bt904] = "Stairway to the Sky (Part 2)",
                [BT_EVENT_RTEV_ms020s] = "Cutscene before Armored Xehanort (1st Phase)",
                [BT_EVENT_RTEV_ms020s] = "Armored Xehanort (1st Phase)",
                [BT_EVENT_RTEV_ms020e] = "Armored Xehanort (2nd Phase) [Cutscene before fight]",
                [BT_EVENT_RTEV_ms030s] = "Cutscene before Armored Xehanort (2nd Phase)",
                [BT_BATTLE_ARMOR_02] = "Armored Xehanort (2nd Phase)",
                [BT_EVENT_RTEV_ms030e] = "Armored Xehanort (3rd Phase) [Cutscene before fight]",
                [BT_EVENT_RTEV_ms040s] = "Armored Xehanort (3rd Phase)",
                [BT_EVENT_bt905] = "One Sky, One Destiny cutscene",
                [BT_BATTLE_MASTER_01] = "Final battle pt. 1",
                [BT_EVENT_RTEV_ms060] = "Final battle middle cutscene",
                [BT_BATTLE_MASTER_02] = "Final battle pt. 2",
                [BT_EVENT_bt906] = "End of battle",
                [BT_EVENT_bt907] = "Checkmate (Part 2)",
                [BT_EVENT_bt908] = "Checkmate (Part 3)",
                [BT_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_BX] = new Dictionary<StoryLabelTypeBx, string>
            {
                [BX_INIT] = "Beginning",
                [BX_WORLD_VISIT1] = "First visit",
                [BX_BRIDGE_MISSION1] = "Mission 1",
                [BX_BRIDGE_RTEV1] = "Bridge Heartless",
                [BX_BRIDGE_MISSION2] = "Mission 2",
                [BX_BRIDGE_RTEV2] = "Rock Troll II",
                [BX_BRIDGE_MISSION3] = "The AR Device",
                [BX_GARAGE_EVENT1] = "Before Flash Tracer",

                [BX_CENTRAL_RTEV1] = "",
                [BX_CENTRAL_MISSON1] = "",
                [BX_CENTRAL_MISSON1] = "",

                [BX_CENTRAL_EVENT1] = "",

                [BX_GARAGE_EVENT2] = "",
                [BX_CENTRAL_RTEV2] = "",
                [BX_CENTRAL_MISSON2] = "",
                [BX_CENTRAL_RTEV2_2] = "",
                [BX_CENTRAL_MISSON2_2] = "",
                [BX_CENTRAL_RTEV3] = "",
                [BX_CENTRAL_BATTLE1] = "",
                [BX_CENTRAL_EVENT2] = "",

                [BX_BRIDGE_EVENT1] = "Microbots",
                [BX_CENTRAL_EVENT3] = "Before Darkubes I",
                [BX_CENTRAL_RTEV4] = "Darkubes I",
                [BX_CENTRAL_BATTLE2] = "After Darkubes I",

                [BX_CENTRAL_EVENT4] = "",

                [BX_CENTRAL_MISSON3] = "Rescue Big Hero 6",
                [BX_CENTRAL_EVENT5] = "Darkubes II",
                [BX_CENTRAL_BATTLE3] = "A Riku From the Past?",
                [BX_CENTRAL_EVENT6] = "The First Baymax",
                [BX_GARAGE_EVENT3] = "Friend of Yours?",
                [BX_GARAGE_EVENT3b] = "Before Dark Baymax",

                [BX_CENTRAL_EVENT7] = "",
                [BX_CENTRAL_BATTLE4] = "",
                [BX_CENTRAL_EVENT7_2] = "",
                [BX_CENTRAL_EVENT7] = "",

                [BX_GARAGE_EVENT4] = "Subdue Dark Baymax!",

                [BX_END] = "Story Done (night)",
                [BX_END_DAY] = "Story Done (day)",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_CA] = new Dictionary<StoryLabelTypeCa, string>
            {
                [CA_INIT] = "Beginning",
                [CA_WORLD_VISIT1] = "Start of the World",
                [CA_WORLD_VISIT2] = "Don't let the black pearl escape",
                [CA_DAVY_JONES_ROCKER_MISSION_CHASE] = "",
                [CA_DAVY_JONES_ROCKER_MISSION_CHASE_BOSS] = "",
                [CA_WORLDEND_EVENT1] = "Sail to the island with the two peaks!",
                [CA_WORLDEND_SHIP_TUTORIAL] = "Ship tutorial",
                [CA_WORLDEND_SHIPBATTLE] = "Ship first battle",
                [CA_WORLDEND_EVENT2] = "",
                [CA_WORLDEND_EVENT3] = "",
                [CA_WORLDEND_EVENT3] = "",
                [CA_SEA_EVENT1] = "",
                [CA_SEA_BATTLE_FLYING] = "",
                [CA_SEA_EVENT2A] = "",
                [CA_SEA_EVENT2B] = "",
                [CA_SEA_EVENT2C] = "",
                [CA_ISLAND_EVENT1] = "",
                [CA_ISLAND_EVENT2] = "",
                [CA_ISLAND_BATTLE_BIGFISH] = "",
                [CA_ISLAND_EVENT3] = "",
                [CA_ISLAND_EVENT4] = "",
                [CA_SEA_EVENT3] = "",
                [CA_SEA_MISSION_SHIPRACE] = "Ship race",
                [CA_SEA_EVENT4] = "",
                [CA_SEA_BATTLE_SHIP1] = "",
                [CA_SEA_BATTLE_SHIPBOARD] = "",
                [CA_PORTROYAL_EVENT1] = "",
                [CA_PORTROYAL_MISSION_CLEAR] = "",
                [CA_PORTROYAL_EVENT2] = "",
                [CA_PORTROYAL_EVENT3] = "",
                [CA_SEA_WATCH_DESTINATION] = "",
                [CA_SEA_EVENT6] = "",
                [CA_SEA_BATTLE_SHIP2] = "",
                [CA_SEA_EVENT7] = "",
                [CA_MAELSTROM_EVENT1] = "",
                [CA_MAELSTROM_BATTLE1] = "",
                [CA_MAELSTROM_EVENT2] = "",
                [CA_MAELSTROM_BATTLE2] = "",
                [CA_MAELSTROM_EVENT3] = "",
                [CA_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_CA_chart_last_access] = new Dictionary<StoryLabelTypeCaChartLastAccess, string>
            {
                [CA_chart_last_access_01] = "",
                [CA_chart_last_access_02] = "",
                [CA_chart_last_access_03] = "",
                [CA_chart_last_access_04] = "",
                [CA_chart_last_access_05] = "",
                [CA_chart_last_access_06] = "",
                [CA_chart_last_access_07] = "",
                [CA_chart_last_access_08] = "",
                [CA_chart_last_access_09] = "",
                [CA_chart_last_access_10] = "",
                [CA_chart_last_access_11] = "",
                [CA_chart_last_access_12] = "",
                [CA_chart_last_access_13] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_CA_ship_ride_type] = new Dictionary<StoryLabelTypeCaShipRide, string>
            {
                [CA_ship_ride_type_01] = "",
                [CA_ship_ride_type_02] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_CA_Sub_Portroyal_Search] = new Dictionary<StoryLabelTypeCaPortroyalSearch, string>
            {
                [CA_Sub_Portroyal_Search_STEP_01] = "",
                [CA_Sub_Portroyal_Search_STEP_02] = "",
                [CA_Sub_Portroyal_Search_STEP_03] = "",
                [CA_Sub_Portroyal_Search_STEP_04] = "",
                [CA_Sub_Portroyal_Search_STEP_05] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_CS] = new Dictionary<StoryLabelTypeCs, string>
            {
                [CS_INIT] = "",
                [CS_EVENT_10] = "",
                [CS_MISSION_10] = "",
                [CS_EVENT_20] = "",
                [CS_MISSION_20] = "",
                [CS_EVENT_30] = "",
                [CS_EVENT_40] = "",
                [CS_MISSION_30] = "",
                [CS_EVENT_50] = "",
                [CS_EVENT_60] = "",
                [CS_MISSION_40] = "",
                [CS_EVENT_70] = "",
                [CS_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_DI] = new Dictionary<StoryLabelTypeDi, string>
            {
                [DI_INIT] = "A Guiding Key (Part 2)",
                [DI_EVENT1] = "Return to the Light (Part 2)",
                [DI_EVENT2] = "A Replica's Resolve Pt. 1",
                [DI_EVENT3] = "The Papou Fruit",
                [DI_EVENT4] = "Last cutscene",
                [DI_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_DP] = new Dictionary<StoryLabelTypeDp, string>
            {
                [DP_INIT] = "Beginning",
                [DP_EVENT1] = "Castle Oblivion Is Unlocked",
                [DP_EVENT2] = "Before Vanitas fight",
                [DP_EVENT3] = "Cutscene before Vanitas fight",
                [DP_BATTLE_1] = "Vanitas fight",
                [DP_EVENT4] = "An End to Slumber (Part 1) (After Vanitas)",
                [DP_EVENT5] = "An End to Slumber (Part 2)",
                [DP_EVENT6] = "An End to Slumber (Part 3)",
                [DP_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_DW] = new Dictionary<StoryLabelTypeDw, string>
            {
                [DW_INIT] = "A Dwindling Trail",
                [DW_EVENT1] = "The Dark Margin",
                [DW_EVENT2] = "Demon Tower cutscene",
                [DW_BATTLE_TOWER] = "Demon Tower battle I",
                [DW_EVENT3] = "An Unexpected Encounter",
                [DW_EVENT4] = "Riku and the King's Peril",
                [DW_EVENT5] = "Too Late",
                [DW_EVENT6] = "Demon Tower cutscene II",
                [DW_BATTLE_AntiAQUA_RIKU] = "Demon Tower battle II",
                [DW_EVENT7] = "Sora arrives",
                [DW_BATTLE_AntiAQUA_SORA] = "Anti-Aqua fight (Sora)",
                [DW_EVENT8] = "Return to the Light (Part 1)",
                [DW_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW] = new Dictionary<StoryLabelTypeEw, string>
            {
                [EW_INIT] = "Beginning",
                [EW_BASE_TUTORIAL] = "Base tutorial",
                [EW_FIRST_CHOICE1] = "Choice",
                [EW_FIRST_EVENT1] = "Cutscene before question 1",
                [EW_FIRST_QUESTION1] = "Question 1",
                [EW_FIRST_EVENT2] = "Cutscene before question 2",
                [EW_FIRST_QUESTION2] = "Question 2",
                [EW_FIRST_EVENT3] = "",
                [EW_FIRST_EVENT4] = "",
                [EW_ACTION_TUTORIAL] = "Darkside Boss Battle",
                [EW_FIRST_EVENT5] = "End of tutorial",
                [EW_SECOND_EVENT1] = "",
                [EW_SECOND_MISSION1] = "",
                [EW_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW_Sub_TESTB] = new Dictionary<StoryLabelTypeEwSub, string>
            {
                [EW_Sub_INT] = "Beginning",
                [EW_Sub_EVENT1] = "",
                [EW_Sub_EVENT2] = "",
                [EW_Sub_EVENT3] = "",
                [EW_Sub_EVENT4] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW_MISSION] = new Dictionary<StoryLabelTypeEwMission, string>
            {
                [EW_MISSION_INIT] = "",
                [EW_MISSION_EVENT_01] = "",
                [EW_MISSION_EVENT_02] = "",
                [EW_MISSION_EVENT_02_2] = "",
                [EW_MISSION_EVENT_03] = "",
                [EW_MISSION_BATTLE_HE] = "",
                [EW_MISSION_EVENT_04] = "",
                [EW_MISSION_EVENT_05] = "",
                [EW_MISSION_EVENT_06] = "",
                [EW_MISSION_EVENT_07] = "",
                [EW_MISSION_BATTLE_BX] = "",
                [EW_MISSION_EVENT_08] = "",
                [EW_MISSION_EVENT_09] = "",
                [EW_MISSION_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW_MISSION_RA] = new Dictionary<StoryLabelTypeEwRa, string>
            {
                [EW_MISSION_RA_START] = "",
                [EW_MISSION_RA_EVENT_01] = "",
                [EW_MISSION_RA_BATTLE_01] = "",
                [EW_MISSION_RA_EVENT_02] = "",
                [EW_MISSION_RA_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW_MISSION_MI] = new Dictionary<StoryLabelTypeEwMi, string>
            {
                [EW_MISSION_MI_START] = "",
                [EW_MISSION_MI_EVENT_01] = "",
                [EW_MISSION_MI_BATTLE_01] = "",
                [EW_MISSION_MI_EVENT_02] = "",
                [EW_MISSION_MI_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW_MISSION_TS] = new Dictionary<StoryLabelTypeEwTs, string>
            {
                [EW_MISSION_TS_START] = "",
                [EW_MISSION_TS_EVENT_01] = "",
                [EW_MISSION_TS_BATTLE_01] = "",
                [EW_MISSION_TS_EVENT_02] = "",
                [EW_MISSION_TS_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW_MISSION_CA] = new Dictionary<StoryLabelTypeEwCa, string>
            {
                [EW_MISSION_CA_START] = "",
                [EW_MISSION_CA_EVENT_01] = "",
                [EW_MISSION_CA_BATTLE_01] = "",
                [EW_MISSION_CA_EVENT_02] = "",
                [EW_MISSION_CA_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EW_MISSION_FZ] = new Dictionary<StoryLabelTypeEwFz, string>
            {
                [EW_MISSION_FZ_START] = "",
                [EW_MISSION_FZ_EVENT_01] = "",
                [EW_MISSION_FZ_BATTLE_01] = "",
                [EW_MISSION_FZ_EVENT_02] = "",
                [EW_MISSION_FZ_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_EX] = new Dictionary<StoryLabelTypeEx, string>
            {
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_FZ] = new Dictionary<StoryLabelTypeFz, string>
            {
                [FZ_INIT] = "Beginning",
                [FZ_WORLD_VISIT1] = "",
                [FZ_MOUNTAIN_RTEV1] = "",
                [FZ_MOUNTAIN_EVENT1] = "",
                [FZ_MOUNTAIN_BATTLE1] = "",
                [FZ_MOUNTAIN_EVENT2] = "",
                [FZ_LABYRINTH_EVENT1] = "",
                [FZ_ICICLE_AREA_C_EVENT1] = "",
                [FZ_ICICLE_AREA_C_BATTLE1] = "",
                [FZ_ICICLE_AREA_C_EVENT2] = "",
                [FZ_ICICLE_AREA_E_EVENT1] = "",
                [FZ_ICICLE_AREA_E_BATTLE1] = "",
                [FZ_ICICLE_AREA_E_EVENT2] = "",
                [FZ_ICICLE_AREA_F_EVENT1] = "",
                [FZ_ICICLE_AREA_F_BATTLE1] = "",
                [FZ_ICICLE_AREA_F_EVENT2] = "",
                [FZ_ICICLE_AREA_H_EVENT1] = "",
                [FZ_ICICLE_AREA_H_BATTLE1] = "",
                [FZ_ICICLE_AREA_H_EVENT2] = "",
                [FZ_LABYRINTH_WORMHOLE] = "",
                [FZ_LABYRINTH_EVENT2] = "",
                [FZ_CASTLE_EVENT1] = "",
                [FZ_MOUNTAIN_EVENT3] = "",
                [FZ_MOUNTAIN_MISSION1] = "",
                [FZ_STEEP_RTEV1] = "",
                [FZ_MOUNTAIN_BATTLE2] = "",
                [FZ_MOUNTAIN_EVENT4] = "",
                [FZ_MOUNTAIN_EVENT5] = "",
                [FZ_MOUNTAIN_EVENT6] = "",
                [FZ_MOUNTAIN_EVENT7] = "",
                [FZ_MOUNTAIN_EVENT8] = "",
                [FZ_MOUNTAIN_MISSION2] = "",
                [FZ_MOUNTAIN_EVENT9] = "",
                [FZ_MOUNTAIN_BATTLE3] = "",
                [FZ_MOUNTAIN_EVENT10] = "",
                [FZ_CASTLE_EVENT2] = "",
                [FZ_MOUNTAIN_BATTLE4] = "",
                [FZ_MOUNTAIN_EVENT11] = "",
                [FZ_MOUNTAIN_EVENT12] = "",
                [FZ_MOUNTAIN_EVENT13] = "",
                [FZ_MOUNTAIN_EVENT14] = "",
                [FZ_MOUNTAIN_MISSION3] = "",
                [FZ_MOUNTAIN_RTEV2] = "",
                [FZ_SEA_EVENT1] = "",
                [FZ_SEA_BATTLE1] = "",
                [FZ_SEA_EVENT2] = "After last cutscene",
                [FZ_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_FZ_Sub_SLIDEMISSION] = new Dictionary<StoryLabelTypeFzMinigame, string>
            {
                [FZ_Sub_SLIDEMISSION_INIT] = "Beginning",
                [FZ_Sub_SLIDEMISSION_CHASE] = "",
                [FZ_Sub_SLIDEMISSION_SLIDE1] = "",
                [FZ_Sub_SLIDEMISSION_SLIDE2] = "",
                [FZ_Sub_SLIDEMISSION_SLIDE3] = "",
                [FZ_Sub_SLIDEMISSION_END] = "Complete"

            }.ToStoryLabel(),
            [StoryFlagType.gameflow_GM] = new Dictionary<StoryLabelTypeGm, string>
            {
                [GM_INIT] = "Beginning",
                [GM_EVENT1] = "",
                [GM_EVENT2] = "",
                [GM_EVENT3] = "",
                [GM_EVENT4] = "",
                [GM_EVENT5] = "",
                [GM_EVENT6] = "",
                [GM_EVENT7] = "",
                [GM_END] = "Story Done"

            }.ToStoryLabel(),
            [StoryFlagType.gameflow_GM_01] = new Dictionary<StoryLabelTypeGm1, string>
            {
                [GM_01_INIT] = "",
                [GM_01_END] = ""

            }.ToStoryLabel(),
            [StoryFlagType.gameflow_GM_02] = new Dictionary<StoryLabelTypeGm2, string>
            {
                [GM_02_INIT] = "",
                [GM_02_END] = ""

            }.ToStoryLabel(),
            [StoryFlagType.gameflow_GM_03] = new Dictionary<StoryLabelTypeGm3, string>
            {
                [GM_03_INIT] = "",
                [GM_03_VISIT1] = "",
                [GM_03_BOSS_01_START] = "",
                [GM_03_BOSS_01_END] = "",
                [GM_03_END] = "",
                [GM_03_VISIT10] = ""

            }.ToStoryLabel(),
            [StoryFlagType.gameflow_GM_03_SUB] = new Dictionary<StoryLabelTypeGm3sub, string>
            {
                [GM_03_SUB_INIT] = "",
                [GM_03_SUB_START] = "",
                [GM_03_SUB_CAMERA_01] = "",
                [GM_03_SUB_ARENA_02] = "",
                [GM_03_SUB_ARENA_03] = "",
                [GM_03_SUB_CAMERA_10] = "",
                [GM_03_SUB_BOSS] = "",
                [GM_03_SUB_END] = "",

            }.ToStoryLabel(),
            [StoryFlagType.gameflow_GM_SYS] = new Dictionary<StoryLabelTypeGmSys, string>
            {
                [GM_SYS_INIT] = "",
                [GM_SYS_EVENT1] = "",
                [GM_SYS_EVENT2] = "",
                [GM_SYS_EVENT3] = "",
                [GM_SYS_EVENT4] = "",
                [GM_SYS_EVENT5] = "",
                [GM_SYS_EVENT6] = "",
                [GM_SYS_END] = "",

            }.ToStoryLabel(),
            [StoryFlagType.gameflow_GM_SYS_LEVELUP] = new Dictionary<StoryLabelTypeGmLevelUp, string>
            {
                [0] = "Beginning",
                [GM_SYS_LEVELUP_STEP_01] = "",
                [GM_SYS_LEVELUP_STEP_02] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_HE] = new Dictionary<StoryLabelTypeHe, string>
            {
                [HE_INIT] = "Beginning",
                [HE_OLYMPUS_OPENING_EVENT] = "",
                [HE_OLYMPUS_VISIT1_1] = "",
                [HE_OLYMPUS_RTEV1_1] = "",
                [HE_TUTO_MAGIC_PLAY] = "",
                [HE_OLYMPUS_BATTLE1_1] = "",
                [HE_OLYMPUS_RTEV1_2] = "",
                [HE_TUTO_FREERUN_PLAY] = "",
                [HE_OLYMPUS_EVENT1_1] = "",
                [HE_THEBES_VISIT1] = "",
                [HE_THEBES_EVENT1] = "",
                [HE_TUTO_FREEFLOW_PLAY] = "",
                [HE_THEBES_BATTLE1] = "After Agora heartless",
                [HE_THEBES_EVENT2] = "",
                [HE_THEBES_RTEV1] = "",
                [HE_THEBES_BATTLE1_5] = "",
                [HE_THEBES_EVENT2_5] = "",
                [HE_THEBES_RTEV3] = "",
                [HE_THEBES_EVENT4] = "",
                [HE_THEBES_BATTLE2] = "",
                [HE_THEBES_EVENT5] = "",
                [HE_THEBES_EVENT6] = "",
                [HE_TUTO_FORMCHANGE_PLAY] = "",
                [HE_THEBES_BATTLE3] = "",
                [HE_THEBES_EVENT7] = "",
                [HE_THEBES_RTEV4] = "",
                [HE_TUTO_ATTRACTION_PLAY] = "",
                [HE_THEBES_BATTLE4] = "",
                [HE_THEBES_EVENT8] = "",
                [HE_OLYMPUS_EVENT1_2] = "",
                [HE_OLYMPUS_EVENT1] = "",
                [HE_OLYMPUS_RTEV1] = "",
                [HE_OLYMPUS_RTEV1_5] = "",
                [HE_OLYMPUS_RTEV2] = "",
                [HE_OLYMPUS_BATTLE1] = "",
                [HE_OLYMPUS_EVENT2] = "",
                [HE_OLYMPUS_EVENT3] = "Start of Realm of Gods",
                [HE_HEAVENLY_RTEV1] = "",
                [HE_HEAVENLY_BATTLE1] = "",
                [HE_TUTO_SHOOTFLOW_PLAY] = "",
                [HE_HEAVENLY_RTEV2] = "",
                [HE_TUTO_ATHLETICFLOW_PLAY] = "",
                [HE_HEAVENLY_EVENT1] = "",
                [HE_BOSS_BATTLE_01] = "",
                [HE_HEAVENLY_RTEV3] = "",
                [HE_BOSS_BATTLE_02] = "",
                [HE_HEAVENLY_EVENT2] = "",
                [HE_OLYMPUS_EVENT4] = "",
                [HE_THEBES_EVENT9] = "",
                [HE_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_HE_Sub_HeraculesBoy] = new Dictionary<StoryLabelTypeHeSub, string>
            {
                [HE_Sub_HeraculesBoy_Init] = "",
                [HE_Sub_HeraculesBoy_Start] = "",
                [HE_Sub_HeraculesBoy_Item_01] = "",
                [HE_Sub_HeraculesBoy_Item_02] = "",
                [HE_Sub_HeraculesBoy_Item_03] = "",
                [HE_Sub_HeraculesBoy_Item_04] = "",
                [HE_Sub_HeraculesBoy_Item_05] = "",
                [HE_Sub_HeraculesBoy_End] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG] = new Dictionary<StoryLabelTypeKg, string>
            {
                [StoryLabelTypeKg.KG_INTERVAL_00] = "Interval - Vexen's Return",
                [StoryLabelTypeKg.KG_INTERVAL_01] = "Interval - The Organization's Origins",
                [StoryLabelTypeKg.KG_INTERVAL_02] = "Interval - cutscene",
                [StoryLabelTypeKg.KG_INIT] = "Beginning",
                [StoryLabelTypeKg.KG_WORLD_VISIT] = "1 Million Heartless",
                [StoryLabelTypeKg.KG_01_BATTLE1] = "KG01 Before The Final World",
                [StoryLabelTypeKg.KG_01_CS_KG702] = "KG01 Light Expires",
                [StoryLabelTypeKg.KG_END] = "Go Toward the Light (Part 1)",
                [StoryLabelTypeKg.KG_01_CS_KG801] = "Go Toward the Light (Part 2)",
                [StoryLabelTypeKg.KG_01_CS_KG802] = "Light in the Darkness",
                [StoryLabelTypeKg.KG_01_CS_KG851] = "Thanks, Kairi",
                [StoryLabelTypeKg.KG_01_CS_KG851b] = "Before Demon Tide II",
                [StoryLabelTypeKg.KG_01_CS_KG852] = "Demon Tide II",
                [StoryLabelTypeKg.KG_01_BATTLE2] = "The Light of the Past",
                [StoryLabelTypeKg.KG_01_CS_KG852b] = "Demon Tide II (Union Cross)",
                [StoryLabelTypeKg.KG_01_BATTLE3] = "A Corridor of Light",
                [StoryLabelTypeKg.KG_01_CS_KG853] = "The X-Blade",
                [StoryLabelTypeKg.KG_50_CS_KG854] = "Start of The Skein of Severance",
                [StoryLabelTypeKg.KG_02_CS_KG855] = "Before 1st Set of Organization XIII Fights",
                [StoryLabelTypeKg.KG_02_BATTLE_AB] = "Towards the end of the labyrinth",
                [StoryLabelTypeKg.KG_02_LABYRINTH_END] = "Before 2nd Set of Organization XIII Fights",
                [StoryLabelTypeKg.KG_02_RTEV_CD] = "",
                [StoryLabelTypeKg.KG_02_BATTLE_CD] = "Before Young Master Xehanort, Ansem, & Xemnas",
                [StoryLabelTypeKg.KG_02_EVENT_E_START] = "Xehanort Trio start battle",
                [StoryLabelTypeKg.KG_02_BATTLE_E_PHASE_01] = "Xehanort Trio phase 1",
                [StoryLabelTypeKg.KG_02_EVENT_E_PHASE_01_END] = "Xehanort Trio end phase 1",
                [StoryLabelTypeKg.KG_02_BATTLE_E_PHASE_02] = "Xehanort Trio phase 2",
                [StoryLabelTypeKg.KG_02_EVENT_E_PHASE_02_END] = "Xehanort Trio end phase 2",
                [StoryLabelTypeKg.KG_02_BATTLE_E_PHASE_03] = "Xehanort Trio phase 3",
                [StoryLabelTypeKg.KG_02_EVENT_E_PHASE_03_END] = "Xehanort Trio end phase 3",
                [StoryLabelTypeKg.KG_02_EVENT_E_END] = "Xehanort Trio end battle",
                [StoryLabelTypeKg.KG_END2] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_13_A] = new Dictionary<StoryLabelTypeKgA, string>
            {
                [KG_02_EVENT_A_INIT] = "Beginning",
                [KG_02_EVENT_A_START] = "",
                [KG_02_BATTLE_A_PHASE_01] = "",
                [KG_02_EVNET_A_PHASE_01_END] = "",
                [KG_02_BATTLE_A_PHASE_02] = "",
                [KG_02_EVNET_A_PHASE_02_END] = "",
                [KG_02_BATTLE_A_PHASE_03] = "",
                [KG_02_EVNET_A_PHASE_03_END] = "",
                [KG_02_EVENT_A_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_13_B] = new Dictionary<StoryLabelTypeKgB, string>
            {
                [KG_02_EVENT_B_INIT] = "Beginning",
                [KG_02_EVENT_B_START] = "",
                [KG_02_BATTLE_B_PHASE_01] = "",
                [KG_02_EVENT_B_PHASE_01_END] = "",
                [KG_02_BATTLE_B_PHASE_02] = "",
                [KG_02_EVENT_B_PHASE_02_END] = "",
                [KG_02_BATTLE_B_PHASE_03] = "",
                [KG_02_EVENT_B_PHASE_03_END] = "",
                [KG_02_BATTLE_B_PHASE_04] = "",
                [KG_02_EVENT_B_PHASE_04_END] = "",
                [KG_02_EVENT_B_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_13_C] = new Dictionary<StoryLabelTypeKgC, string>
            {
                [StoryLabelTypeKgC.KG_02_EVENT_C_INIT] = "Beginning",
                [StoryLabelTypeKgC.KG_02_EVENT_C_START] = "",
                [StoryLabelTypeKgC.KG_02_BATTLE_C_PHASE_01] = "",
                [StoryLabelTypeKgC.KG_02_EVENT_C_PHASE_01_END] = "",
                [StoryLabelTypeKgC.KG_02_BATTLE_C_PHASE_02] = "",
                [StoryLabelTypeKgC.KG_02_EVENT_C_PHASE_02_END] = "",
                [StoryLabelTypeKgC.KG_02_EVENT_C_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_13_D] = new Dictionary<StoryLabelTypeKgD, string>
            {
                [StoryLabelTypeKgD.KG_02_EVENT_D_INIT] = "Beginning",
                [StoryLabelTypeKgD.KG_02_EVENT_D_START] = "",
                [StoryLabelTypeKgD.KG_02_BATTLE_D_PHASE1_01] = "",
                [StoryLabelTypeKgD.KG_02_EVENT_D_PHASE_01_END] = "",
                [StoryLabelTypeKgD.KG_02_BATTLE_D_PHASE1_02] = "",
                [StoryLabelTypeKgD.KG_02_EVENT_D_PHASE_02_END] = "",
                [StoryLabelTypeKgD.KG_02_EVENT_D_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_MI] = new Dictionary<StoryLabelTypeMi, string>
            {
                [MI_INIT] = "Beginning",
                [MI_WORLD_VISIT1] = "",
                [MI_ENTRANCE_EVENT1] = "",
                [MI_ENTRANCE_BATTLE1] = "",
                [MI_ENTRANCE_EVENT2] = "",
                [MI_SCARE_EVENT1] = "",
                [MI_SCARE_BATTLE1] = "",
                [MI_SCARE_EVENT2] = "",
                [MI_SCARE_EVENT3] = "",
                [MI_DOOR_REAL1] = "",
                [MI_DOOR_MISSION1] = "",
                [MI_DOOR_EVENT1] = "",
                [MI_DOOR_MISSION2] = "",
                [MI_DOOR_EVENT2] = "",
                [MI_DOOR_REAL2] = "",
                [MI_DOOR_MISSION3] = "",
                [MI_DOOR_EVENT3] = "",
                [MI_FACTORY_EVENT1] = "",
                [MI_FACTORY_EVENT2] = "",
                [MI_FACTORY_MISSION1] = "",
                [MI_FACTORY_REAL1] = "",
                [MI_FACTORY_EVENT3] = "",
                [MI_FACTORY_LIFT] = "",
                [MI_FACTORY_REAL2] = "",
                [MI_FACTORY_BATTLE1] = "",
                [MI_FACTORY_REAL3] = "",
                [MI_FACTORY_BATTLE2] = "",
                [MI_FACTORY_REAL4] = "",
                [MI_FACTORY_REAL5] = "",
                [MI_FACTORY_MISSION2] = "",
                [MI_FACTORY_REAL6] = "",
                [MI_FACTORY_EVENT4] = "",
                [MI_FACTORY_MISSION3] = "",
                [MI_FACTORY_EVENT5] = "",
                [MI_PLANT_EVENT1] = "",
                [MI_PLANT_EVENT2] = "",
                [MI_PLANT_BATTLE1] = "",
                [MI_PLANT_EVENT3] = "",
                [MI_PLANT_REAL1] = "",
                [MI_PLANT_BATTLE2] = "",
                [MI_PLANT_EVENT4] = "",
                [MI_PLANT_REAL2] = "",
                [MI_PLANT_BATTLE3] = "",
                [MI_PLANT_EVENT5] = "",
                [MI_DOORBOSS_EVENT1] = "",
                [MI_DOORBOSS_BATTLE1] = "",
                [MI_DOORBOSS_EVENT2] = "",
                [MI_SCARE_EVENT4] = "",
                [MI_ENTRANCE_EVENT3] = "",
                [MI_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_MI_Sub_INT] = new Dictionary<StoryLabelTypeMiSub, string>
            {
                [0] = "Beginning",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_PO] = new Dictionary<StoryLabelTypePo, string>
            {
                [PO_INIT] = "Beginning",
                [PO_EVENT_01] = "First minigame beaten",
                [PO_VEGETABLE_MINIGAME_01] = "Before second minigame",
                [PO_EVENT_02] = "Second minigame beaten",
                [PO_ORCHARD_MINIGAME_01] = "Before third minigame",
                [PO_EVENT_03] = "Third minigame beaten",
                [PO_FLOWER_MINIGAME_01] = "Before fourth minigame",
                [PO_EVENT_04] = "Fourth minigame beaten",
                [PO_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_RA] = new Dictionary<StoryLabelTypeRa, string>
            {
                [RA_INIT] = "Beginning",
                [RA_WORLD_VISIT1] = "",
                [RA_FOREST_EVENT1] = "",
                [RA_FOREST_BATTLE1] = "",
                [RA_FOREST_EVENT2] = "",
                [RA_FOREST_EVENT3] = "",
                [RA_TOWER_EVENT1] = "",
                [RA_FOREST_EVENT4] = "",
                [RA_FOREST_EVENT5] = "",
                [RA_FOREST_EVENT6] = "",
                [RA_FOREST_BATTLE2] = "",
                [RA_TOWER_EVENT2] = "",
                [RA_FOREST_REAL10] = "",
                [RA_FOREST_EVENT20] = "",
                [RA_FOREST_BATTLE10] = "",
                [RA_FOREST_EVENT21] = "",
                [RA_FOREST_EVENT22] = "",
                [RA_FOREST_EVENT23] = "",
                [RA_FOREST_REAL22] = "",
                [RA_FOREST_REAL25] = "",
                [RA_FOREST_BATTLE20] = "",
                [RA_FOREST_BATTLE21] = "",
                [RA_FOREST_REAL30] = "",
                [RA_FOREST_REAL40] = "",
                [RA_CASTLE_EVENT1] = "",
                [RA_CASTLE_EVENT2] = "",
                [RA_CASTLE_MISSION1] = "",
                [RA_CASTLE_EVENT3] = "",
                [RA_CASTLE_BATTLE1] = "",
                [RA_FOREST_EVENT30] = "",
                [RA_TOWER_EVENT3] = "",
                [RA_FOREST_EVENT31] = "",
                [RA_FOREST_EVENT32] = "Going back to Rapunzel's Tower",
                [RA_FOREST_REAL50] = "",
                [RA_FOREST_BATTLE30] = "",
                [RA_TOWER_EVENT4] = "",
                [RA_TOWER_EVENT5] = "",
                [RA_FOREST_EVENT41] = "",
                [RA_FOREST_BATTLEBOSS] = "",
                [RA_TOWER_EVENT6] = "",
                [RA_FOREST_EVENT42] = "",
                [RA_FOREST_EVENT50] = "",
                [RA_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_RA_Dandelion] = new Dictionary<StoryLabelTypeRaDandelion, string>
            {
                [RA_DANDELION_INIT] = "",
                [RA_DANDELION_START] = "",
                [RA_DANDELION_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_RA_Rabbit] = new Dictionary<StoryLabelTypeRaRabbit, string>
            {
                [RA_RABBIT_INIT] = "",
                [RA_RABBIT_START] = "",
                [RA_RABBIT_FINISH] = "",
                [RA_RABBIT_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_RA_Rainbow] = new Dictionary<StoryLabelTypeRaRainbow, string>
            {
                [RA_RAINBOW_INIT] = "",
                [RA_RAINBOW_START] = "",
                [RA_RAINBOW_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_RA_Bird] = new Dictionary<StoryLabelTypeRaBird, string>
            {
                [RA_BIRD_INIT] = "",
                [RA_BIRD_START] = "",
                [RA_BIRD_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_RG] = new Dictionary<StoryLabelTypeRg, string>
            {
                [RG_INIT] = "Terra's Whereabouts",
                [RG_EVENT1] = "The Missing Scientist",
                [RG_EVENT2] = "The Benched Enact a Plan",
                [RG_EVENT3] = "A Present from Vexen",
                [RG_EVENT4] = "Last cutscene",
                [RG_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_SF] = new Dictionary<StoryLabelTypeSf, string>
            {
                [SF_INIT] = "Beginning",
                [SF_EVENT1] = "Nothing's As It Should Be",
                [SF_EVENT2] = "Second cutscene",
                [SF_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_TS] = new Dictionary<StoryLabelTypeTs, string>
            {
                [TS_INIT] = "Beginning",
                [TS_GAME_CM1] = "",
                [TS_WORLD_VISIT1] = "",
                [TS_ANDY_BATTLE1] = "",
                [TS_ANDY_EVENT1] = "",
                [TS_ANDY_EVENT2] = "",
                [TS_ANDY_TO_TOYSHOP] = "",
                [TS_HOLE_EVENT1] = "",
                [TS_HOLE_BATTLE1] = "",
                [TS_HOLE_EVENT2] = "",
                [TS_KAIJU_EVENT1] = "",
                [TS_KAIJU_BATTLE1] = "",
                [TS_KAIJU_EVENT2] = "",
                [TS_NUIGURUMI_EVENT1] = "",
                [TS_NUIGURUMI_EVENT2] = "",
                [TS_NUIGURUMI_EVENT3] = "",
                [TS_NUIGURUMI_EVENT4] = "",
                [TS_NUIGURUMI_BATTLE1] = "",
                [TS_NUIGURUMI_EVENT5] = "",
                [TS_BABYTOY_EVENT1] = "",
                [TS_BABYTOY_MISSION1] = "",
                [TS_BABYTOY_EVENT2] = "",
                [TS_HOLE_EVENT3] = "",
                [TS_GAME_EVENT1] = "",
                [TS_GAME_EVENT2] = "",
                [TS_GAME_MISSION1] = "",
                [TS_GAME_EVENT3] = "",
                [TS_ATHLETIC_EVENT1] = "",
                [TS_ATHLETIC_EVENT2] = "",
                [TS_ATHLETIC_EVENT3] = "",
                [TS_BOSS_EVENT1] = "",
                [TS_BOSS_BATTLE1] = "",
                [TS_HOLE_EVENT4] = "",
                [TS_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_TS_Sub_GAM1] = new Dictionary<StoryLabelTypeTsSub, string>
            {
                [0] = "Beginning",
                [TS_Sub_GAM1_EVENT1] = "",
                [TS_Sub_GAM1_EVENT2] = "",
                [TS_Sub_GAM1_EVENT3] = "",
                [TS_Sub_GAM1_EVENT4] = "",
                [TS_Sub_GAM1_EVENT5] = "",
                [TS_Sub_GAM1_EVENT6] = "",
                [TS_Sub_GAM1_EVENT7] = "",
                [TS_Sub_GAM1_EVENT8] = "",
                [TS_Sub_GAM1_EVENT9] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_TT] = new Dictionary<StoryLabelTypeTt, string>
            {
                [TT_INIT] = "Beginning",
                [TT_TRM_EVENT01] = "The Neighborhood Nobodies",
                [TT_TRM_MISSION01] = "Hello, Good-bye",
                [TT_TRM_EVENT02] = "Demon Tide I",
                [TT_TRM_MISSION02] = "Defeat the Demon Tide!",
                [TT_TRM_EVENT03] = "Before The Woods Powerwilds",
                [TT_WODS_EVENT01] = "The Woods Powerwilds",
                [TT_WODS_MISSION01] = "",
                [TT_WODS_EVENT02] = "Before Entering the Mansion",
                [TT_COMP_EVENT01] = "Datascapes (Part 2)",
                [TT_COMP_EVENT02] = "Before The Old Mansion Fight",
                [TT_MANS_EVENT01] = "After The Old Mansion Fight",
                [TT_MANS_MISSION01] = "",
                [TT_MANS_EVENT02] = "The Old Mansion Fight",
                [TT_TRM2_EVENT01] = "Collect Ingredients",
                [TT_TRM2_MISSION01] = "End ingredients collection mission",
                [TT_TRM2_EVENT02] = "",
                [TT_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_TT_PO] = new Dictionary<StoryLabelTypeTtPo, string>
            {
                [TT_PO_INIT] = "",
                [TT_PO_TRM_EVENT01] = "",
                [TT_PO_TRM_EVENT02] = "",
                [TT_PO_END] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_TT_Remy] = new Dictionary<StoryLabelTypeTtRemy, string>
            {
                [0] = "Beginning",
                [TT_Remy_EVENT01] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_HE] = new Dictionary<StoryLabelTypeWmHe, string>
            {
                [WM_WORLD_HE_CLOSED] = "",
                [WM_WORLD_HE_STARTED] = "",
                [WM_WORLD_HE_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_TT] = new Dictionary<StoryLabelTypeWmTt, string>
            {
                [WM_WORLD_TT_CLOSED] = "",
                [WM_WORLD_TT_STARTED] = "",
                [WM_WORLD_TT_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_RA] = new Dictionary<StoryLabelTypeWmRa, string>
            {
                [WM_WORLD_RA_CLOSED] = "",
                [WM_WORLD_RA_STARTED] = "",
                [WM_WORLD_RA_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_TS] = new Dictionary<StoryLabelTypeWmTs, string>
            {
                [WM_WORLD_TS_CLOSED] = "",
                [WM_WORLD_TS_STARTED] = "",
                [WM_WORLD_TS_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_MI] = new Dictionary<StoryLabelTypeWmMi, string>
            {
                [WM_WORLD_MI_CLOSED] = "",
                [WM_WORLD_MI_STARTED] = "",
                [WM_WORLD_MI_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_FZ] = new Dictionary<StoryLabelTypeWmFz, string>
            {
                [WM_WORLD_FZ_CLOSED] = "",
                [WM_WORLD_FZ_STARTED] = "",
                [WM_WORLD_FZ_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_CA] = new Dictionary<StoryLabelTypeWmCa, string>
            {
                [WM_WORLD_CA_CLOSED] = "",
                [WM_WORLD_CA_STARTED] = "",
                [WM_WORLD_CA_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_BX] = new Dictionary<StoryLabelTypeWmBx, string>
            {
                [WM_WORLD_BX_CLOSED] = "",
                [WM_WORLD_BX_STARTED] = "",
                [WM_WORLD_BX_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_WM_WORLD_KG] = new Dictionary<StoryLabelTypeWmKg, string>
            {
                [WM_WORLD_KG_CLOSED] = "",
                [WM_WORLD_KG_STARTED] = "",
                [WM_WORLD_KG_CLEARED] = "",
            }.ToStoryLabel(),
            [StoryFlagType.global_GameBattleLV] = new Dictionary<StoryLabelTypeGameBattle, string>
            {
                [GLOBAL_GAMEBATTLELv_01] = "Lv. 1 (beginning)",
                [GLOBAL_GAMEBATTLELv_02] = "Lv. 2",
                [GLOBAL_GAMEBATTLELv_03] = "Lv. 3",
                [GLOBAL_GAMEBATTLELv_04] = "Lv. 4",
                [GLOBAL_GAMEBATTLELv_05] = "Lv. 5 (endgame)",
                [GLOBAL_GAMEBATTLELv_06] = "Lv. 6 (DLC beginning",
                [GLOBAL_GAMEBATTLELv_07] = "Lv. 7",
                [GLOBAL_GAMEBATTLELv_08] = "Lv. 8 (endgame)",
                [GLOBAL_GAMEBATTLELv_09] = "Lv. 9 (DLC endgame)",
            }.ToStoryLabel(),
            [StoryFlagType.global_GameShopLV] = new Dictionary<StoryLabelTypeGameShop, string>
            {
                [GLOBAL_GAMESHOPLv_01] = "Lv. 1 (beginning)",
                [GLOBAL_GAMESHOPLv_02] = "Lv. 2",
                [GLOBAL_GAMESHOPLv_03] = "Lv. 3",
                [GLOBAL_GAMESHOPLv_04] = "Lv. 4",
                [GLOBAL_GAMESHOPLv_05] = "Lv. 5",
                [GLOBAL_GAMESHOPLv_06] = "Lv. 6",
                [GLOBAL_GAMESHOPLv_07] = "Lv. 7",
                [GLOBAL_GAMESHOPLv_END] = "Lv. 8 (endgame)",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_YT] = new Dictionary<StoryLabelTypeYt, string>
            {
                [YT_INIT] = "Prelude to Adventure",
                [YT_EVENT1] = "A Fresh Start",
                [YT_EVENT2] = "A Quick Review",
                [YT_EVENT3] = "The Guardians of Light Gather",
                [YT_EVENT4] = "Beneath the Same Stars",
                [YT_EVENT5] = "Last cutscene",
                [YT_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_BT_DLC] = new Dictionary<StoryLabelTypeBtDlc8, string>
            {
                [BT_DLC_INIT] = "Beginning",
                [BT_DLC_08_EVENT_01] = "",
                [BT_DLC_08_EVENT_02] = "",
                [BT_DLC_08_BATTLE_01] = "",
                [BT_DLC_07_MISSION_01] = "",
                [BT_DLC_08_EVENT_03] = "",
                [BT_DLC_08_BATTLE_02] = "",
                [BT_DLC_08_EVENT_04] = "",
                [BT_DLC_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_BT_DLC_07_BT_01] = new Dictionary<StoryLabelTypeBtDlc7, string>
            {
                [BT_DLC_07_BT_01_INIT] = "Beginning",
                [BT_DLC_07_BT_01_EVENT_01] = "",
                [BT_DLC_07_BT_01_EVENT_02] = "",
                [BT_DLC_07_BT_01_BATTLE_01] = "",
                [BT_DLC_07_BT_01_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gim_BT_DLC_monument] = new Dictionary<StoryLabelTypeBtDlc7Monument, string>
            {
                [BT_DLC_07_MONUMENT_START] = "Beginning",
                [BT_DLC_07_MONUMENT_STEP01] = "Step 1",
                [BT_DLC_07_MONUMENT_STEP02] = "Step 2",
                [BT_DLC_07_MONUMENT_STEP03] = "Step 3",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC] = new Dictionary<StoryLabelTypeKgDlc, string>
            {
                [StoryLabelTypeKgDlc.KG_DLC_INIT] = "Beginning",
                [StoryLabelTypeKgDlc.KG_DLC_WORLD_VISIT] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_EVENT_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_BATTLE_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_EVENT_02] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_BATTLE_02] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_EVENT_03] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_EVENT_05] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_EVENT_06] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_BATTLE_03] = "",
                [StoryLabelTypeKgDlc.KG_DLC_04_EVENT_07] = "",
                [StoryLabelTypeKgDlc.KG_02_EVENT_E_END] = "Between Main story and DLC",
                [StoryLabelTypeKgDlc.KG_DLC_06_EVENT_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_06_BATTLE_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_06_BATTLE_02] = "",
                [StoryLabelTypeKgDlc.KG_DLC_07_BATTLE_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_06_2_EVENT_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_06_2_BATTLE_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_06_2_BATTLE_02] = "",
                [StoryLabelTypeKgDlc.KG_DLC_05_3_EVENT_01] = "",
                [StoryLabelTypeKgDlc.KG_DLC_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_13_A] = new Dictionary<StoryLabelTypeKgA, string>
            {
                [KG_02_EVENT_A_INIT] = "Beginning",
                [KG_02_EVENT_A_START] = "",
                [KG_02_BATTLE_A_PHASE_01] = "",
                [KG_02_EVNET_A_PHASE_01_END] = "",
                [KG_02_BATTLE_A_PHASE_02] = "",
                [KG_02_EVNET_A_PHASE_02_END] = "",
                [KG_02_BATTLE_A_PHASE_03] = "",
                [KG_02_EVNET_A_PHASE_03_END] = "",
                [KG_02_EVENT_A_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_13_B] = new Dictionary<StoryLabelTypeKgB, string>
            {
                [KG_02_EVENT_B_INIT] = "Beginning",
                [KG_02_EVENT_B_START] = "",
                [KG_02_BATTLE_B_PHASE_01] = "",
                [KG_02_EVENT_B_PHASE_01_END] = "",
                [KG_02_BATTLE_B_PHASE_02] = "",
                [KG_02_EVENT_B_PHASE_02_END] = "",
                [KG_02_BATTLE_B_PHASE_03] = "",
                [KG_02_EVENT_B_PHASE_03_END] = "",
                [KG_02_BATTLE_B_PHASE_04] = "",
                [KG_02_EVENT_B_PHASE_04_END] = "",
                [KG_02_EVENT_B_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_13_C] = new Dictionary<StoryLabelTypeKgDlc5c, string>
            {
                [StoryLabelTypeKgDlc5c.KG_02_EVENT_C_INIT] = "Beginning",
                [StoryLabelTypeKgDlc5c.KG_02_EVENT_C_START] = "",
                [StoryLabelTypeKgDlc5c.KG_DLC_05_BATTLE_C_PHASE_0a] = "",
                [StoryLabelTypeKgDlc5c.KG_DLC_05_EVENT_C_PHASE_0a_END] = "",
                [StoryLabelTypeKgDlc5c.KG_02_BATTLE_C_PHASE_01] = "",
                [StoryLabelTypeKgDlc5c.KG_02_EVENT_C_PHASE_01_END] = "",
                [StoryLabelTypeKgDlc5c.KG_02_BATTLE_C_PHASE_02] = "",
                [StoryLabelTypeKgDlc5c.KG_02_EVENT_C_PHASE_02_END] = "",
                [StoryLabelTypeKgDlc5c.KG_02_EVENT_C_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_13_D] = new Dictionary<StoryLabelTypeKgDlc5d, string>
            {
                [StoryLabelTypeKgDlc5d.KG_02_EVENT_D_INIT] = "Beginning",
                [StoryLabelTypeKgDlc5d.KG_02_EVENT_D_START] = "",
                [StoryLabelTypeKgDlc5d.KG_DLC_05_EVENT_D_EVENT_01] = "",
                [StoryLabelTypeKgDlc5d.KG_02_BATTLE_D_PHASE1_01] = "",
                [StoryLabelTypeKgDlc5d.KG_02_EVENT_D_PHASE_01_END] = "",
                [StoryLabelTypeKgDlc5d.KG_DLC_05_EVENT_D_PHASE_01a_END] = "",
                [StoryLabelTypeKgDlc5d.KG_DLC_05_BATTLE_D_PHASE_0a] = "",
                [StoryLabelTypeKgDlc5d.KG_DLC_05_EVENT_D_PHASE_0a_END] = "",
                [StoryLabelTypeKgDlc5d.KG_02_BATTLE_D_PHASE1_02] = "",
                [StoryLabelTypeKgDlc5d.KG_02_EVENT_D_PHASE_02_END] = "",
                [StoryLabelTypeKgDlc5d.KG_02_EVENT_D_END] = "Fight Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_05_AREA_A_CHARSEL] = new Dictionary<StoryLabelTypeKgDlcCharSelect, string>
            {
                [KG_DLC_05_AREA_A_CHARSEL_01] = "Sora",
                [KG_DLC_05_AREA_A_CHARSEL_02] = "Riku",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_05_AREA_B_CHARSEL] = new Dictionary<StoryLabelTypeKgDlcCharSelect, string>
            {
                [KG_DLC_05_AREA_B_CHARSEL_01] = "Sora",
                [KG_DLC_05_AREA_B_CHARSEL_02] = "???",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_05_AREA_C_CHARSEL] = new Dictionary<StoryLabelTypeKgDlcCharSelect, string>
            {
                [KG_DLC_05_AREA_C_CHARSEL_01] = "Sora",
                [KG_DLC_05_AREA_C_CHARSEL_02] = "Aqua",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_05_AREA_D_CHARSEL] = new Dictionary<StoryLabelTypeKgDlcCharSelect, string>
            {
                [KG_DLC_05_AREA_D_CHARSEL_01] = "Sora",
                [KG_DLC_05_AREA_D_CHARSEL_02] = "Roxas",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_KG_DLC_06_LAST_CHARSEL] = new Dictionary<StoryLabelTypeKgDlcCharSelect, string>
            {
                [KG_DLC_06_LAST_CHARSEL_01] = "Sora",
                [KG_DLC_06_LAST_CHARSEL_02] = "Kairi",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_RG_DLC] = new Dictionary<StoryLabelTypeRgDlc, string>
            {
                [RG_DLC_INIT] = "Beginning",
                [RG_DLC_EVENT_01] = "",
                [RG_DLC_EVENT_02] = "",
                [RG_DLC_MAR_EVENT_01] = "",
                [RG_DLC_SHU_EVENT_01] = "",
                [RG_DLC_SHU_EVENT_02] = "",
                [RG_DLC_SHU_BATTLE_01] = "",
                [RG_DLC_MAR2_EVENT_01] = "",
                [RG_DLC_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_SS_DLC] = new Dictionary<StoryLabelTypeSsDlc, string>
            {
                [SS_DLC_INIT] = "Beginning",
                [SS_DLC_EVENT_01] = "",
                [SS_DLC_BATTLE_01] = "",
                [SS_DLC_END] = "Story Done",
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_SS_DLC_Sub_BadEnd] = new Dictionary<StoryLabelTypeSsDlcSub, string>
            {
                [0] = "Not seen",
                [SS_DLC_SUB_BADEND_END] = "Seen"
            }.ToStoryLabel(),
            [StoryFlagType.gameflow_SS_DLC_Sub_TrueEnd] = new Dictionary<StoryLabelTypeSsDlcSub, string>
            {
                [0] = "Not seen",
                [SS_DLC_SUB_BADEND_END] = "Seen"
            }.ToStoryLabel(),
        };
    }
}
