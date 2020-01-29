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

namespace KHSave.Lib3.Types
{
    public enum StoryLabelTypeBt
    {
        BT_INIT = 0,
        BT_EVENT_bt901 = 100,
        BT_EVENT_bt902 = 200,
        BT_BATTLE_REPLICA = 210,
        BT_EVENT_bt903 = 220,
        BT_EVENT_bt904 = 230,
        BT_EVENT_RTEV_ms020s = 300,
        BT_BATTLE_ARMOR_01 = 310,
        BT_EVENT_RTEV_ms020e = 320,
        BT_EVENT_RTEV_ms030s = 400,
        BT_BATTLE_ARMOR_02 = 410,
        BT_EVENT_RTEV_ms030e = 420,
        BT_EVENT_RTEV_ms040s = 500,
        BT_BATTLE_ARMOR_03 = 510,
        BT_EVENT_bt905 = 600,
        BT_BATTLE_MASTER_01 = 610,
        BT_EVENT_RTEV_ms060 = 700,
        BT_BATTLE_MASTER_02 = 710,
        BT_EVENT_bt906 = 800,
        BT_EVENT_bt907 = 810,
        BT_EVENT_bt908 = 820,
        BT_END = 9999,
    }

    public enum StoryLabelTypeBx
	{
        BX_INIT = 0,
        BX_WORLD_VISIT1 = 10,
        BX_BRIDGE_MISSION1 = 20,
        BX_BRIDGE_RTEV1 = 30,
        BX_BRIDGE_MISSION2 = 40,
        BX_BRIDGE_RTEV2 = 50,
        BX_BRIDGE_MISSION3 = 60,
        BX_GARAGE_EVENT1 = 100,
        BX_CENTRAL_RTEV1 = 200,
        BX_CENTRAL_MISSON1 = 210,
        BX_CENTRAL_EVENT1 = 220,
        BX_GARAGE_EVENT2 = 300,
        BX_CENTRAL_RTEV2 = 400,
        BX_CENTRAL_MISSON2 = 410,
        BX_CENTRAL_RTEV2_2 = 412,
        BX_CENTRAL_MISSON2_2 = 415,
        BX_CENTRAL_RTEV3 = 420,
        BX_CENTRAL_BATTLE1 = 430,
        BX_CENTRAL_EVENT2 = 440,
        BX_BRIDGE_EVENT1 = 500,
        BX_CENTRAL_EVENT3 = 600,
        BX_CENTRAL_RTEV4 = 610,
        BX_CENTRAL_BATTLE2 = 620,
        BX_CENTRAL_EVENT4 = 630,
        BX_CENTRAL_MISSON3 = 640,
        BX_CENTRAL_EVENT5 = 650,
        BX_CENTRAL_BATTLE3 = 660,
        BX_CENTRAL_EVENT6 = 670,
        BX_GARAGE_EVENT3 = 700,
        BX_GARAGE_EVENT3b = 710,
        BX_CENTRAL_EVENT7 = 800,
        BX_CENTRAL_BATTLE4 = 810,
        BX_CENTRAL_EVENT7_2 = 811,
        BX_CENTRAL_BATTLE5 = 812,
        BX_CENTRAL_EVENT8 = 820,
        BX_GARAGE_EVENT4 = 900,
        BX_END = 9999,
        BX_END_DAY = 10000,
    }

    public enum StoryLabelTypeCa
    {
        CA_INIT = 0,
        CA_WORLD_VISIT1 = 100,
        CA_WORLD_VISIT2 = 200,
        CA_DAVY_JONES_ROCKER_MISSION_CHASE = 300,
        CA_DAVY_JONES_ROCKER_MISSION_CHASE_BOSS = 350,
        CA_WORLDEND_EVENT1 = 400,
        CA_WORLDEND_SHIP_TUTORIAL = 450,
        CA_WORLDEND_SHIPBATTLE = 500,
        CA_WORLDEND_EVENT2 = 1000,
        CA_WORLDEND_EVENT3 = 1100,
        CA_SEA_EVENT1 = 1200,
        CA_SEA_BATTLE_FLYING = 1300,
        CA_SEA_EVENT2A = 1400,
        CA_SEA_EVENT2B = 1500,
        CA_SEA_EVENT2C = 1600,
        CA_ISLAND_EVENT1 = 2000,
        CA_ISLAND_EVENT2 = 2100,
        CA_ISLAND_BATTLE_BIGFISH = 2200,
        CA_ISLAND_EVENT3 = 2300,
        CA_ISLAND_EVENT4 = 2400,
        CA_SEA_EVENT3 = 3000,
        CA_SEA_MISSION_SHIPRACE = 3100,
        CA_SEA_EVENT4 = 3200,
        CA_SEA_BATTLE_SHIP1 = 3300,
        CA_SEA_BATTLE_SHIPBOARD = 3400,
        CA_PORTROYAL_EVENT1 = 3600,
        CA_PORTROYAL_MISSION_CLEAR = 3700,
        CA_PORTROYAL_EVENT2 = 4000,
        CA_PORTROYAL_EVENT3 = 4100,
        CA_SEA_WATCH_DESTINATION = 4150,
        CA_SEA_EVENT6 = 4200,
        CA_SEA_BATTLE_SHIP2 = 4300,
        CA_SEA_EVENT7 = 4400,
        CA_MAELSTROM_EVENT1 = 5000,
        CA_MAELSTROM_BATTLE1 = 5100,
        CA_MAELSTROM_EVENT2 = 5200,
        CA_MAELSTROM_BATTLE2 = 5300,
        CA_MAELSTROM_EVENT3 = 5400,
        CA_END = 9999,
    }

    public enum StoryLabelTypeCaChartLastAccess
    {
        CA_chart_last_access_01 = 100,
        CA_chart_last_access_02 = 200,
        CA_chart_last_access_03 = 300,
        CA_chart_last_access_04 = 400,
        CA_chart_last_access_05 = 500,
        CA_chart_last_access_06 = 600,
        CA_chart_last_access_07 = 700,
        CA_chart_last_access_08 = 800,
        CA_chart_last_access_09 = 900,
        CA_chart_last_access_10 = 1000,
        CA_chart_last_access_11 = 1100,
        CA_chart_last_access_12 = 1200,
        CA_chart_last_access_13 = 1300,
    }

    public enum StoryLabelTypeCaShipRide
    {
        CA_ship_ride_type_01 = 100,
        CA_ship_ride_type_02 = 200,
    }

    public enum StoryLabelTypeCaPortroyalSearch
    {
        CA_Sub_Portroyal_Search_STEP_01 = 1000,
        CA_Sub_Portroyal_Search_STEP_02 = 2000,
        CA_Sub_Portroyal_Search_STEP_03 = 3000,
        CA_Sub_Portroyal_Search_STEP_04 = 4000,
        CA_Sub_Portroyal_Search_STEP_05 = 5000,
    }

    public enum StoryLabelTypeCs
    {
        CS_INIT = 0,
        CS_EVENT_10 = 1000,
        CS_MISSION_10 = 1010,
        CS_EVENT_20 = 1020,
        CS_MISSION_20 = 1030,
        CS_EVENT_30 = 1040,
        CS_EVENT_40 = 2000,
        CS_MISSION_30 = 2010,
        CS_EVENT_50 = 2020,
        CS_EVENT_60 = 3000,
        CS_MISSION_40 = 3010,
        CS_EVENT_70 = 3020,
        CS_END = 9999,
    }

    public enum StoryLabelTypeDi
    {
        DI_INIT = 0,
        DI_EVENT1 = 10,
        DI_EVENT2 = 100,
        DI_EVENT3 = 200,
        DI_EVENT4 = 300,
        DI_END = 9999,
    }

    public enum StoryLabelTypeDp
    {
        DP_INIT = 0,
        DP_EVENT1 = 10,
        DP_EVENT2 = 100,
        DP_EVENT3 = 200,
        DP_BATTLE_1 = 300,
        DP_EVENT4 = 400,
        DP_EVENT5 = 500,
        DP_EVENT6 = 600,
        DP_END = 9999,
    }

    public enum StoryLabelTypeDw
    {
        DW_INIT = 0,
        DW_EVENT1 = 10,
        DW_EVENT2 = 20,
        DW_BATTLE_TOWER = 30,
        DW_EVENT3 = 100,
        DW_EVENT4 = 200,
        DW_EVENT5 = 300,
        DW_EVENT6 = 400,
        DW_BATTLE_AntiAQUA_RIKU = 500,
        DW_EVENT7 = 600,
        DW_BATTLE_AntiAQUA_SORA = 700,
        DW_EVENT8 = 800,
        DW_END = 9999,
    }

    public enum StoryLabelTypeEw
    {
        EW_INIT = 0,
        EW_BASE_TUTORIAL = 1000,
        EW_FIRST_CHOICE1 = 1100,
        EW_FIRST_EVENT1 = 1200,
        EW_FIRST_QUESTION1 = 1300,
        EW_FIRST_EVENT2 = 1400,
        EW_FIRST_QUESTION2 = 1500,
        EW_FIRST_EVENT3 = 1600,
        EW_FIRST_EVENT4 = 2000,
        EW_ACTION_TUTORIAL = 2100,
        EW_FIRST_EVENT5 = 2300,
        EW_SECOND_EVENT1 = 5000,
        EW_SECOND_MISSION1 = 5100,
        EW_END = 9999,
    }

    public enum StoryLabelTypeEx
    { }

    public enum StoryLabelTypeEwSub
    {
        EW_Sub_INT = 0,
        EW_Sub_EVENT1 = 10,
        EW_Sub_EVENT2 = 20,
        EW_Sub_EVENT3 = 30,
        EW_Sub_EVENT4 = 40,
    }

    public enum StoryLabelTypeEwMission
    {
        EW_MISSION_INIT = 0,
        EW_MISSION_EVENT_01 = 100,
        EW_MISSION_EVENT_02 = 110,
        EW_MISSION_EVENT_02_2 = 115,
        EW_MISSION_EVENT_03 = 120,
        EW_MISSION_BATTLE_HE = 130,
        EW_MISSION_EVENT_04 = 140,
        EW_MISSION_EVENT_05 = 200,
        EW_MISSION_EVENT_06 = 300,
        EW_MISSION_EVENT_07 = 310,
        EW_MISSION_BATTLE_BX = 320,
        EW_MISSION_EVENT_08 = 330,
        EW_MISSION_EVENT_09 = 340,
        EW_MISSION_END = 9999,
    }

    public enum StoryLabelTypeEwRa
    {
        EW_MISSION_RA_START = 0,
        EW_MISSION_RA_EVENT_01 = 100,
        EW_MISSION_RA_BATTLE_01 = 200,
        EW_MISSION_RA_EVENT_02 = 300,
        EW_MISSION_RA_END = 9999,
    }

    public enum StoryLabelTypeEwMi
    {
        EW_MISSION_MI_START = 0,
        EW_MISSION_MI_EVENT_01 = 100,
        EW_MISSION_MI_BATTLE_01 = 200,
        EW_MISSION_MI_EVENT_02 = 300,
        EW_MISSION_MI_END = 9999,
    }

    public enum StoryLabelTypeEwTs
    {
        EW_MISSION_TS_START = 0,
        EW_MISSION_TS_EVENT_01 = 100,
        EW_MISSION_TS_BATTLE_01 = 200,
        EW_MISSION_TS_EVENT_02 = 300,
        EW_MISSION_TS_END = 9999,
    }

    public enum StoryLabelTypeEwCa
    {
        EW_MISSION_CA_START = 0,
        EW_MISSION_CA_EVENT_01 = 100,
        EW_MISSION_CA_BATTLE_01 = 200,
        EW_MISSION_CA_EVENT_02 = 300,
        EW_MISSION_CA_END = 9999,
    }

    public enum StoryLabelTypeEwFz
    {
        EW_MISSION_FZ_START = 0,
        EW_MISSION_FZ_EVENT_01 = 100,
        EW_MISSION_FZ_BATTLE_01 = 200,
        EW_MISSION_FZ_EVENT_02 = 300,
        EW_MISSION_FZ_END = 9999,
    }

    public enum StoryLabelTypeFz
    {
        FZ_INIT = 0,
        FZ_WORLD_VISIT1 = 10,
        FZ_MOUNTAIN_RTEV1 = 1100,
        FZ_MOUNTAIN_EVENT1 = 1110,
        FZ_MOUNTAIN_BATTLE1 = 1120,
        FZ_MOUNTAIN_EVENT2 = 1130,
        FZ_LABYRINTH_EVENT1 = 2000,
        FZ_ICICLE_AREA_C_EVENT1 = 2010,
        FZ_ICICLE_AREA_C_BATTLE1 = 2020,
        FZ_ICICLE_AREA_C_EVENT2 = 2030,
        FZ_ICICLE_AREA_E_EVENT1 = 2110,
        FZ_ICICLE_AREA_E_BATTLE1 = 2120,
        FZ_ICICLE_AREA_E_EVENT2 = 2130,
        FZ_ICICLE_AREA_F_EVENT1 = 2210,
        FZ_ICICLE_AREA_F_BATTLE1 = 2220,
        FZ_ICICLE_AREA_F_EVENT2 = 2230,
        FZ_ICICLE_AREA_H_EVENT1 = 2310,
        FZ_ICICLE_AREA_H_BATTLE1 = 2320,
        FZ_ICICLE_AREA_H_EVENT2 = 2330,
        FZ_LABYRINTH_WORMHOLE = 2500,
        FZ_LABYRINTH_EVENT2 = 3300,
        FZ_CASTLE_EVENT1 = 3310,
        FZ_MOUNTAIN_EVENT3 = 4400,
        FZ_MOUNTAIN_MISSION1 = 4410,
        FZ_STEEP_RTEV1 = 4420,
        FZ_MOUNTAIN_BATTLE2 = 4430,
        FZ_MOUNTAIN_EVENT4 = 4440,
        FZ_MOUNTAIN_EVENT5 = 5500,
        FZ_MOUNTAIN_EVENT6 = 5510,
        FZ_MOUNTAIN_EVENT7 = 5520,
        FZ_MOUNTAIN_EVENT8 = 5530,
        FZ_MOUNTAIN_MISSION2 = 5540,
        FZ_MOUNTAIN_EVENT9 = 5550,
        FZ_MOUNTAIN_BATTLE3 = 5560,
        FZ_MOUNTAIN_EVENT10 = 5570,
        FZ_CASTLE_EVENT2 = 5580,
        FZ_MOUNTAIN_BATTLE4 = 6600,
        FZ_MOUNTAIN_EVENT11 = 6610,
        FZ_MOUNTAIN_EVENT12 = 7700,
        FZ_MOUNTAIN_EVENT13 = 7710,
        FZ_MOUNTAIN_EVENT14 = 7720,
        FZ_MOUNTAIN_MISSION3 = 7730,
        FZ_MOUNTAIN_RTEV2 = 7750,
        FZ_SEA_EVENT1 = 8800,
        FZ_SEA_BATTLE1 = 8810,
        FZ_SEA_EVENT2 = 8820,
        FZ_END = 9999,
    }

    public enum StoryLabelTypeFzMinigame
    {
        FZ_Sub_SLIDEMISSION_INIT = 0,
        FZ_Sub_SLIDEMISSION_CHASE = 2000,
        FZ_Sub_SLIDEMISSION_SLIDE1 = 2100,
        FZ_Sub_SLIDEMISSION_SLIDE2 = 2110,
        FZ_Sub_SLIDEMISSION_SLIDE3 = 2120,
        FZ_Sub_SLIDEMISSION_END = 2999,
    }

    public enum StoryLabelTypeGm
    {
        GM_INIT = 0,
        GM_EVENT1 = 10,
        GM_EVENT2 = 100,
        GM_EVENT3 = 200,
        GM_EVENT4 = 300,
        GM_EVENT5 = 400,
        GM_EVENT6 = 500,
        GM_EVENT7 = 600,
        GM_END = 9999,
    }

    public enum StoryLabelTypeGm1
    {
        GM_01_INIT = 0,
        GM_01_END = 9999,
    }

    public enum StoryLabelTypeGm2
    {
        GM_02_INIT = 0,
        GM_02_END = 9999,
    }

    public enum StoryLabelTypeGm3
    {
        GM_03_INIT = 0,
        GM_03_VISIT1 = 10,
        GM_03_BOSS_01_START = 100,
        GM_03_BOSS_01_END = 200,
        GM_03_END = 999,
        GM_03_VISIT10 = 1010,
    }

    public enum StoryLabelTypeGm3sub
    {
        GM_03_SUB_INIT = 0,
        GM_03_SUB_START = 10,
        GM_03_SUB_CAMERA_01 = 100,
        GM_03_SUB_ARENA_02 = 110,
        GM_03_SUB_ARENA_03 = 120,
        GM_03_SUB_CAMERA_10 = 200,
        GM_03_SUB_BOSS = 500,
        GM_03_SUB_END = 9999,
    }

    public enum StoryLabelTypeGmSys
    {
        GM_SYS_INIT = 0,
        GM_SYS_EVENT1 = 10,
        GM_SYS_EVENT2 = 100,
        GM_SYS_EVENT3 = 200,
        GM_SYS_EVENT4 = 300,
        GM_SYS_EVENT5 = 400,
        GM_SYS_EVENT6 = 500,
        GM_SYS_END = 9999,
    }

    public enum StoryLabelTypeGmLevelUp
    {
        GM_SYS_LEVELUP_STEP_01 = 100,
        GM_SYS_LEVELUP_STEP_02 = 200,
    }

    public enum StoryLabelTypeHe
    {
        HE_INIT = 0,
        HE_OLYMPUS_OPENING_EVENT = 2,
        HE_OLYMPUS_VISIT1_1 = 5,
        HE_OLYMPUS_RTEV1_1 = 10,
        HE_TUTO_MAGIC_PLAY = 11,
        HE_OLYMPUS_BATTLE1_1 = 15,
        HE_OLYMPUS_RTEV1_2 = 20,
        HE_TUTO_FREERUN_PLAY = 21,
        HE_OLYMPUS_EVENT1_1 = 25,
        HE_THEBES_VISIT1 = 30,
        HE_THEBES_EVENT1 = 40,
        HE_TUTO_FREEFLOW_PLAY = 41,
        HE_THEBES_BATTLE1 = 50,
        HE_THEBES_EVENT2 = 60,
        HE_THEBES_RTEV1 = 100,
        HE_THEBES_BATTLE1_5 = 110,
        HE_THEBES_EVENT2_5 = 120,
        HE_THEBES_RTEV3 = 300,
        HE_THEBES_EVENT4 = 400,
        HE_THEBES_BATTLE2 = 410,
        HE_THEBES_EVENT5 = 420,
        HE_THEBES_EVENT6 = 500,
        HE_TUTO_FORMCHANGE_PLAY = 501,
        HE_THEBES_BATTLE3 = 510,
        HE_THEBES_EVENT7 = 520,
        HE_THEBES_RTEV4 = 530,
        HE_TUTO_ATTRACTION_PLAY = 531,
        HE_THEBES_BATTLE4 = 540,
        HE_THEBES_EVENT8 = 600,
        HE_OLYMPUS_EVENT1_2 = 910,
        HE_OLYMPUS_EVENT1 = 1000,
        HE_OLYMPUS_RTEV1 = 1010,
        HE_OLYMPUS_RTEV1_5 = 1015,
        HE_OLYMPUS_RTEV2 = 1100,
        HE_OLYMPUS_BATTLE1 = 1110,
        HE_OLYMPUS_EVENT2 = 1120,
        HE_OLYMPUS_EVENT3 = 1200,
        HE_HEAVENLY_RTEV1 = 2000,
        HE_HEAVENLY_BATTLE1 = 2010,
        HE_TUTO_SHOOTFLOW_PLAY = 2011,
        HE_HEAVENLY_RTEV2 = 2100,
        HE_TUTO_ATHLETICFLOW_PLAY = 2101,
        HE_HEAVENLY_EVENT1 = 2200,
        HE_BOSS_BATTLE_01 = 2210,
        HE_HEAVENLY_RTEV3 = 2215,
        HE_BOSS_BATTLE_02 = 2216,
        HE_HEAVENLY_EVENT2 = 2220,
        HE_OLYMPUS_EVENT4 = 2230,
        HE_THEBES_EVENT9 = 2240,
        HE_END = 9999,
    }

    public enum StoryLabelTypeHeSub
    {
        HE_Sub_HeraculesBoy_Init = 0,
        HE_Sub_HeraculesBoy_Start = 100,
        HE_Sub_HeraculesBoy_Item_01 = 200,
        HE_Sub_HeraculesBoy_Item_02 = 300,
        HE_Sub_HeraculesBoy_Item_03 = 400,
        HE_Sub_HeraculesBoy_Item_04 = 500,
        HE_Sub_HeraculesBoy_Item_05 = 600,
        HE_Sub_HeraculesBoy_End = 9999,
    }

    public enum StoryLabelTypeKg
    {
        KG_INTERVAL_00 = 0,
        KG_INTERVAL_01 = 10,
        KG_INTERVAL_02 = 20,
        KG_INIT = 50,
        KG_WORLD_VISIT = 100,
        KG_01_BATTLE1 = 200,
        KG_01_CS_KG702 = 500,
        KG_END = 9999,
        KG_01_CS_KG801 = 10000,
        KG_01_CS_KG802 = 10100,
        KG_01_CS_KG851 = 10500,
        KG_01_CS_KG851b = 11000,
        KG_01_CS_KG852 = 11100,
        KG_01_BATTLE2 = 11300,
        KG_01_CS_KG852b = 11400,
        KG_01_BATTLE3 = 11410,
        KG_01_CS_KG853 = 11420,
        KG_50_CS_KG854 = 11500,
        KG_02_CS_KG855 = 11600,
        KG_02_BATTLE_AB = 13000,
        KG_02_LABYRINTH_END = 13050,
        KG_02_RTEV_CD = 13100,
        KG_02_BATTLE_CD = 13500,
        KG_02_EVENT_E_START = 14000,
        KG_02_BATTLE_E_PHASE_01 = 14100,
        KG_02_EVENT_E_PHASE_01_END = 14200,
        KG_02_BATTLE_E_PHASE_02 = 14300,
        KG_02_EVENT_E_PHASE_02_END = 14400,
        KG_02_BATTLE_E_PHASE_03 = 14500,
        KG_02_EVENT_E_PHASE_03_END = 14600,
        KG_02_EVENT_E_END = 14700,
        KG_END2 = 99999,
    }

    public enum StoryLabelTypeKgA
    {
        KG_02_EVENT_A_INIT = 0,
        KG_02_EVENT_A_START = 1000,
        KG_02_BATTLE_A_PHASE_01 = 1100,
        KG_02_EVNET_A_PHASE_01_END = 1200,
        KG_02_BATTLE_A_PHASE_02 = 1300,
        KG_02_EVNET_A_PHASE_02_END = 1400,
        KG_02_BATTLE_A_PHASE_03 = 1500,
        KG_02_EVNET_A_PHASE_03_END = 1600,
        KG_02_EVENT_A_END = 9999,
    }

    public enum StoryLabelTypeKgB
    {
        KG_02_EVENT_B_INIT = 0,
        KG_02_EVENT_B_START = 1000,
        KG_02_BATTLE_B_PHASE_01 = 1100,
        KG_02_EVENT_B_PHASE_01_END = 1200,
        KG_02_BATTLE_B_PHASE_02 = 1300,
        KG_02_EVENT_B_PHASE_02_END = 1400,
        KG_02_BATTLE_B_PHASE_03 = 1500,
        KG_02_EVENT_B_PHASE_03_END = 1600,
        KG_02_BATTLE_B_PHASE_04 = 1700,
        KG_02_EVENT_B_PHASE_04_END = 1800,
        KG_02_EVENT_B_END = 9999,
    }

    public enum StoryLabelTypeKgC
    {
        KG_02_EVENT_C_INIT = 0,
        KG_02_EVENT_C_START = 1000,
        KG_02_BATTLE_C_PHASE_01 = 1100,
        KG_02_EVENT_C_PHASE_01_END = 1200,
        KG_02_BATTLE_C_PHASE_02 = 1300,
        KG_02_EVENT_C_PHASE_02_END = 1400,
        KG_02_EVENT_C_END = 9999,
    }

    public enum StoryLabelTypeKgD
    {
        KG_02_EVENT_D_INIT = 0,
        KG_02_EVENT_D_START = 1000,
        KG_02_BATTLE_D_PHASE1_01 = 1100,
        KG_02_EVENT_D_PHASE_01_END = 1200,
        KG_02_BATTLE_D_PHASE1_02 = 1300,
        KG_02_EVENT_D_PHASE_02_END = 1400,
        KG_02_EVENT_D_END = 9999,
    }

    public enum StoryLabelTypeMi
    {
        MI_INIT = 0,
        MI_WORLD_VISIT1 = 10,
        MI_ENTRANCE_EVENT1 = 1010,
        MI_ENTRANCE_BATTLE1 = 1020,
        MI_ENTRANCE_EVENT2 = 1030,
        MI_SCARE_EVENT1 = 1110,
        MI_SCARE_BATTLE1 = 1120,
        MI_SCARE_EVENT2 = 1130,
        MI_SCARE_EVENT3 = 1140,
        MI_DOOR_REAL1 = 1210,
        MI_DOOR_MISSION1 = 1220,
        MI_DOOR_EVENT1 = 1230,
        MI_DOOR_MISSION2 = 1240,
        MI_DOOR_EVENT2 = 1250,
        MI_DOOR_REAL2 = 1251,
        MI_DOOR_MISSION3 = 1260,
        MI_DOOR_EVENT3 = 1270,
        MI_FACTORY_EVENT1 = 3010,
        MI_FACTORY_EVENT2 = 3020,
        MI_FACTORY_MISSION1 = 3030,
        MI_FACTORY_REAL1 = 3040,
        MI_FACTORY_EVENT3 = 3050,
        MI_FACTORY_LIFT = 3060,
        MI_FACTORY_REAL2 = 3110,
        MI_FACTORY_BATTLE1 = 3120,
        MI_FACTORY_REAL3 = 3130,
        MI_FACTORY_BATTLE2 = 3140,
        MI_FACTORY_REAL4 = 3150,
        MI_FACTORY_REAL5 = 3160,
        MI_FACTORY_MISSION2 = 3170,
        MI_FACTORY_REAL6 = 3180,
        MI_FACTORY_EVENT4 = 3190,
        MI_FACTORY_MISSION3 = 3200,
        MI_FACTORY_EVENT5 = 3210,
        MI_PLANT_EVENT1 = 5010,
        MI_PLANT_EVENT2 = 5020,
        MI_PLANT_BATTLE1 = 5030,
        MI_PLANT_EVENT3 = 5040,
        MI_PLANT_REAL1 = 5050,
        MI_PLANT_BATTLE2 = 5060,
        MI_PLANT_EVENT4 = 5070,
        MI_PLANT_REAL2 = 5080,
        MI_PLANT_BATTLE3 = 5090,
        MI_PLANT_EVENT5 = 5100,
        MI_DOORBOSS_EVENT1 = 7010,
        MI_DOORBOSS_BATTLE1 = 7020,
        MI_DOORBOSS_EVENT2 = 7030,
        MI_SCARE_EVENT4 = 7040,
        MI_ENTRANCE_EVENT3 = 7050,
        MI_END = 9999,
    }

    public enum StoryLabelTypeMiSub
    { }

    public enum StoryLabelTypePo
    {
        PO_INIT = 0,
        PO_EVENT_01 = 100,
        PO_VEGETABLE_MINIGAME_01 = 110,
        PO_EVENT_02 = 200,
        PO_ORCHARD_MINIGAME_01 = 210,
        PO_EVENT_03 = 300,
        PO_FLOWER_MINIGAME_01 = 310,
        PO_EVENT_04 = 400,
        PO_END = 9999,
    }

    public enum StoryLabelTypeRa
    {
        RA_INIT = 0,
        RA_WORLD_VISIT1 = 10,
        RA_FOREST_EVENT1 = 100,
        RA_FOREST_BATTLE1 = 110,
        RA_FOREST_EVENT2 = 120,
        RA_FOREST_EVENT3 = 200,
        RA_TOWER_EVENT1 = 210,
        RA_FOREST_EVENT4 = 220,
        RA_FOREST_EVENT5 = 300,
        RA_FOREST_EVENT6 = 400,
        RA_FOREST_BATTLE2 = 410,
        RA_TOWER_EVENT2 = 420,
        RA_FOREST_REAL10 = 500,
        RA_FOREST_EVENT20 = 1000,
        RA_FOREST_BATTLE10 = 1010,
        RA_FOREST_EVENT21 = 1020,
        RA_FOREST_EVENT22 = 1100,
        RA_FOREST_EVENT23 = 1200,
        RA_FOREST_REAL22 = 2020,
        RA_FOREST_REAL25 = 2025,
        RA_FOREST_BATTLE20 = 2030,
        RA_FOREST_BATTLE21 = 2031,
        RA_FOREST_REAL30 = 2500,
        RA_FOREST_REAL40 = 2900,
        RA_CASTLE_EVENT1 = 3000,
        RA_CASTLE_EVENT2 = 3100,
        RA_CASTLE_MISSION1 = 3110,
        RA_CASTLE_EVENT3 = 3120,
        RA_CASTLE_BATTLE1 = 3130,
        RA_FOREST_EVENT30 = 3140,
        RA_TOWER_EVENT3 = 3150,
        RA_FOREST_EVENT31 = 3160,
        RA_FOREST_EVENT32 = 3170,
        RA_FOREST_REAL50 = 4000,
        RA_FOREST_BATTLE30 = 4010,
        RA_TOWER_EVENT4 = 4020,
        RA_TOWER_EVENT5 = 4100,
        RA_FOREST_EVENT41 = 4110,
        RA_FOREST_BATTLEBOSS = 4120,
        RA_TOWER_EVENT6 = 4200,
        RA_FOREST_EVENT42 = 4210,
        RA_FOREST_EVENT50 = 4300,
        RA_END = 9999,
    }

    public enum StoryLabelTypeRaDandelion
    {
        RA_DANDELION_INIT = 0,
        RA_DANDELION_START = 10,
        RA_DANDELION_END = 100,
    }

    public enum StoryLabelTypeRaRabbit
    {
        RA_RABBIT_INIT = 0,
        RA_RABBIT_START = 10,
        RA_RABBIT_FINISH = 50,
        RA_RABBIT_END = 100,
    }

    public enum StoryLabelTypeRaRainbow
    {
        RA_RAINBOW_INIT = 0,
        RA_RAINBOW_START = 10,
        RA_RAINBOW_END = 100,
    }

    public enum StoryLabelTypeRaBird
    {
        RA_BIRD_INIT = 0,
        RA_BIRD_START = 10,
        RA_BIRD_END = 100,
    }

    public enum StoryLabelTypeRg
    {
        RG_INIT = 0,
        RG_EVENT1 = 10,
        RG_EVENT2 = 100,
        RG_EVENT3 = 200,
        RG_EVENT4 = 300,
        RG_END = 9999,
    }

    public enum StoryLabelTypeSf
    {
        SF_INIT = 0,
        SF_EVENT1 = 10,
        SF_EVENT2 = 100,
        SF_END = 9999,
    }

    public enum StoryLabelTypeTs
    {
        TS_INIT = 0,
        TS_GAME_CM1 = 500,
        TS_WORLD_VISIT1 = 1000,
        TS_ANDY_BATTLE1 = 1010,
        TS_ANDY_EVENT1 = 1020,
        TS_ANDY_EVENT2 = 1030,
        TS_ANDY_TO_TOYSHOP = 1040,
        TS_HOLE_EVENT1 = 1500,
        TS_HOLE_BATTLE1 = 1520,
        TS_HOLE_EVENT2 = 1530,
        TS_KAIJU_EVENT1 = 1600,
        TS_KAIJU_BATTLE1 = 1610,
        TS_KAIJU_EVENT2 = 1620,
        TS_NUIGURUMI_EVENT1 = 1700,
        TS_NUIGURUMI_EVENT2 = 1710,
        TS_NUIGURUMI_EVENT3 = 1720,
        TS_NUIGURUMI_EVENT4 = 1730,
        TS_NUIGURUMI_BATTLE1 = 1740,
        TS_NUIGURUMI_EVENT5 = 1750,
        TS_BABYTOY_EVENT1 = 1800,
        TS_BABYTOY_MISSION1 = 1810,
        TS_BABYTOY_EVENT2 = 1820,
        TS_HOLE_EVENT3 = 1900,
        TS_GAME_EVENT1 = 3000,
        TS_GAME_EVENT2 = 3010,
        TS_GAME_MISSION1 = 3020,
        TS_GAME_EVENT3 = 3030,
        TS_ATHLETIC_EVENT1 = 3100,
        TS_ATHLETIC_EVENT2 = 3200,
        TS_ATHLETIC_EVENT3 = 3300,
        TS_BOSS_EVENT1 = 3500,
        TS_BOSS_BATTLE1 = 3510,
        TS_HOLE_EVENT4 = 4000,
        TS_END = 9999,
    }

    public enum StoryLabelTypeTsSub
    {
        TS_Sub_GAM1_EVENT1 = 1000,
        TS_Sub_GAM1_EVENT2 = 1100,
        TS_Sub_GAM1_EVENT3 = 1200,
        TS_Sub_GAM1_EVENT4 = 1300,
        TS_Sub_GAM1_EVENT5 = 1400,
        TS_Sub_GAM1_EVENT6 = 1500,
        TS_Sub_GAM1_EVENT7 = 1600,
        TS_Sub_GAM1_EVENT8 = 1700,
        TS_Sub_GAM1_EVENT9 = 1800,
    }

    public enum StoryLabelTypeTt
    {
        TT_INIT = 0,
        TT_TRM_EVENT01 = 100,
        TT_TRM_MISSION01 = 110,
        TT_TRM_EVENT02 = 120,
        TT_TRM_MISSION02 = 130,
        TT_TRM_EVENT03 = 140,
        TT_WODS_EVENT01 = 200,
        TT_WODS_MISSION01 = 210,
        TT_WODS_EVENT02 = 220,
        TT_COMP_EVENT01 = 300,
        TT_COMP_EVENT02 = 310,
        TT_MANS_EVENT01 = 400,
        TT_MANS_MISSION01 = 410,
        TT_MANS_EVENT02 = 420,
        TT_TRM2_EVENT01 = 500,
        TT_TRM2_MISSION01 = 510,
        TT_TRM2_EVENT02 = 520,
        TT_END = 9999,
    }

    public enum StoryLabelTypeTtPo
    {
        TT_PO_INIT = 0,
        TT_PO_TRM_EVENT01 = 100,
        TT_PO_TRM_EVENT02 = 110,
        TT_PO_END = 9999,
    }

    public enum StoryLabelTypeTtRemy
    {
        TT_Remy_EVENT01 = 100,
    }

    public enum StoryLabelTypeWmHe
    {
        WM_WORLD_HE_CLOSED = 0,
        WM_WORLD_HE_STARTED = 1000,
        WM_WORLD_HE_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmTt
    {
        WM_WORLD_TT_CLOSED = 0,
        WM_WORLD_TT_STARTED = 1000,
        WM_WORLD_TT_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmRa
    {
        WM_WORLD_RA_CLOSED = 0,
        WM_WORLD_RA_STARTED = 1000,
        WM_WORLD_RA_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmTs
    {
        WM_WORLD_TS_CLOSED = 0,
        WM_WORLD_TS_STARTED = 1000,
        WM_WORLD_TS_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmMi
    {
        WM_WORLD_MI_CLOSED = 0,
        WM_WORLD_MI_STARTED = 1000,
        WM_WORLD_MI_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmFz
    {
        WM_WORLD_FZ_CLOSED = 0,
        WM_WORLD_FZ_STARTED = 1000,
        WM_WORLD_FZ_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmCa
    {
        WM_WORLD_CA_CLOSED = 0,
        WM_WORLD_CA_STARTED = 1000,
        WM_WORLD_CA_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmBx
    {
        WM_WORLD_BX_CLOSED = 0,
        WM_WORLD_BX_STARTED = 1000,
        WM_WORLD_BX_CLEARED = 2000,
    }

    public enum StoryLabelTypeWmKg
    {
        WM_WORLD_KG_CLOSED = 0,
        WM_WORLD_KG_STARTED = 1000,
        WM_WORLD_KG_CLEARED = 2000,
    }

    public enum StoryLabelTypeGameBattle
    {
        GLOBAL_GAMEBATTLELv_01 = 0,
        GLOBAL_GAMEBATTLELv_02 = 1000,
        GLOBAL_GAMEBATTLELv_03 = 2000,
        GLOBAL_GAMEBATTLELv_04 = 3000,
        GLOBAL_GAMEBATTLELv_05 = 4000,
        GLOBAL_GAMEBATTLELv_06 = 5000,
        GLOBAL_GAMEBATTLELv_07 = 6000,
        GLOBAL_GAMEBATTLELv_08 = 7000,
        GLOBAL_GAMEBATTLELv_09 = 8000,
    }

    public enum StoryLabelTypeGameShop
    {
        GLOBAL_GAMESHOPLv_01 = 0,
        GLOBAL_GAMESHOPLv_02 = 1000,
        GLOBAL_GAMESHOPLv_03 = 2000,
        GLOBAL_GAMESHOPLv_04 = 3000,
        GLOBAL_GAMESHOPLv_05 = 4000,
        GLOBAL_GAMESHOPLv_06 = 5000,
        GLOBAL_GAMESHOPLv_07 = 6000,
        GLOBAL_GAMESHOPLv_END = 7000,
    }

    public enum StoryLabelTypeYt
    {
        YT_INIT = 0,
        YT_EVENT1 = 10,
        YT_EVENT2 = 100,
        YT_EVENT3 = 200,
        YT_EVENT4 = 300,
        YT_EVENT5 = 400,
        YT_END = 9999,
    }

    public enum StoryLabelTypeBtDlc8
    {
        BT_DLC_INIT = 0,
        BT_DLC_08_EVENT_01 = 110,
        BT_DLC_08_EVENT_02 = 210,
        BT_DLC_08_BATTLE_01 = 220,
        BT_DLC_07_MISSION_01 = 310,
        BT_DLC_08_EVENT_03 = 410,
        BT_DLC_08_BATTLE_02 = 420,
        BT_DLC_08_EVENT_04 = 430,
        BT_DLC_END = 9999,
    }

    public enum StoryLabelTypeBtDlc7
    {
        BT_DLC_07_BT_01_INIT = 0,
        BT_DLC_07_BT_01_EVENT_01 = 110,
        BT_DLC_07_BT_01_EVENT_02 = 120,
        BT_DLC_07_BT_01_BATTLE_01 = 130,
        BT_DLC_07_BT_01_END = 9999,
    }

    public enum StoryLabelTypeBtDlc7Monument
    {
        BT_DLC_07_MONUMENT_START = 0,
        BT_DLC_07_MONUMENT_STEP01 = 110,
        BT_DLC_07_MONUMENT_STEP02 = 120,
        BT_DLC_07_MONUMENT_STEP03 = 130,
    }

    public enum StoryLabelTypeKgDlc
    {
        KG_DLC_INIT = 0,
        KG_DLC_WORLD_VISIT = 110,
        KG_DLC_04_EVENT_01 = 410,
        KG_DLC_04_BATTLE_01 = 420,
        KG_DLC_04_EVENT_02 = 430,
        KG_DLC_04_BATTLE_02 = 440,
        KG_DLC_04_EVENT_03 = 450,
        KG_DLC_04_EVENT_05 = 510,
        KG_DLC_04_EVENT_06 = 520,
        KG_DLC_04_BATTLE_03 = 530,
        KG_DLC_04_EVENT_07 = 540,
        KG_DLC_06_EVENT_01 = 20100,
        KG_DLC_06_BATTLE_01 = 21200,
        KG_DLC_06_BATTLE_02 = 21300,
        KG_DLC_07_BATTLE_01 = 21400,
        KG_DLC_06_2_EVENT_01 = 22100,
        KG_DLC_06_2_BATTLE_01 = 22200,
        KG_DLC_06_2_BATTLE_02 = 22250,
        KG_DLC_05_3_EVENT_01 = 22300,
        KG_DLC_END = 99999,
    }

    public enum StoryLabelTypeKgDlc5
    {
        KG_DLC_05_BATTLE_C_PHASE_0a = 1050,
        KG_DLC_05_EVENT_C_PHASE_0a_END = 1060,
        KG_DLC_05_EVENT_D_EVENT_01 = 1050,
        KG_DLC_05_EVENT_D_PHASE_01a_END = 1250,
        KG_DLC_05_BATTLE_D_PHASE_0a = 1260,
        KG_DLC_05_EVENT_D_PHASE_0a_END = 1270,
        KG_DLC_05_AREA_A_CHARSEL_01 = 0,
        KG_DLC_05_AREA_A_CHARSEL_02 = 1,
        KG_DLC_05_AREA_B_CHARSEL_01 = 0,
        KG_DLC_05_AREA_B_CHARSEL_02 = 1,
        KG_DLC_05_AREA_C_CHARSEL_01 = 0,
        KG_DLC_05_AREA_C_CHARSEL_02 = 1,
        KG_DLC_05_AREA_D_CHARSEL_01 = 0,
        KG_DLC_05_AREA_D_CHARSEL_02 = 1,
        KG_DLC_06_LAST_CHARSEL_01 = 0,
        KG_DLC_06_LAST_CHARSEL_02 = 1,
    }

    public enum StoryLabelTypeRgDlc
    {
        RG_DLC_INIT = 0,
        RG_DLC_EVENT_01 = 110,
        RG_DLC_EVENT_02 = 120,
        RG_DLC_MAR_EVENT_01 = 210,
        RG_DLC_SHU_EVENT_01 = 310,
        RG_DLC_SHU_EVENT_02 = 320,
        RG_DLC_SHU_BATTLE_01 = 330,
        RG_DLC_MAR2_EVENT_01 = 410,
        RG_DLC_END = 9999,
    }

    public enum StoryLabelTypeSsDlc
    {
        SS_DLC_INIT = 0,
        SS_DLC_EVENT_01 = 110,
        SS_DLC_BATTLE_01 = 120,
        SS_DLC_END = 9999,
    }

    public enum StoryLabelTypeSsDlcSub
    {
        SS_DLC_SUB_BADEND_END = 100,
        SS_DLC_SUB_TRUEEND_END = 100,
    }
}
