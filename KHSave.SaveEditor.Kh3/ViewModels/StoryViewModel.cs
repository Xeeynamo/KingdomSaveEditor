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
using KHSave.SaveEditor.Common;
using KHSave.Lib3.Types;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Models;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;
using KHSave.Lib3;
using KHSave.Lib3.Presets;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
	public class StoryViewModel
	{
		public StoryViewModel(ISaveKh3 save)
		{
			Advanced = new StoryAdvancedViewModel(save.Storyflags);
			Simple = new StorySimpleViewModel(save);
		}

		public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
		public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

		public StoryAdvancedViewModel Advanced { get; }

		public StorySimpleViewModel Simple { get; }
	}

	public class StorySimpleViewModel : BaseNotifyPropertyChanged
	{
		public StorySimpleViewModel(ISaveKh3 save)
		{
			Save = save;
			NewGamePlusCommand = new StoryCommand(save, "New Game+ (simulated)", "/Game/Levels/ew/ew_01/ew_01", new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.gameflow_EW] = 0,
				[StoryFlagType.gameflow_WM_WORLD_HE] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_TT] = 0,
				[StoryFlagType.gameflow_WM_WORLD_RA] = 0,
				[StoryFlagType.gameflow_WM_WORLD_TS] = 0,
				[StoryFlagType.gameflow_WM_WORLD_MI] = 0,
				[StoryFlagType.gameflow_WM_WORLD_FZ] = 0,
				[StoryFlagType.gameflow_WM_WORLD_CA] = 0,
				[StoryFlagType.gameflow_WM_WORLD_BX] = 0,
				[StoryFlagType.gameflow_WM_WORLD_KG] = 0,
				[StoryFlagType.global_GameBattleLV] = 0,
			}, true);
			NewGamePlusGlitchyCommand = new StoryCommand(save, "New Game+ (but with story complete)", "/Game/Levels/ew/ew_01/ew_01", CompleteSave(new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.gameflow_EW] = 0,
			}), false);
			CompleteGameCommand = new StoryCommand(save, "Complete game", "/Game/Levels/bt/bt_01/bt_01", CompleteSave(), false);
			LandOfDepartureCommand = new StoryCommand(save, "Back to Land of Departure (before Vanitas fight)", "/Game/Levels/dp/dp_01/dp_01", new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.gameflow_DP] = 0,
				[StoryFlagType.gameflow_WM_WORLD_HE] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_TT] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_RA] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_TS] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_MI] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_FZ] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_CA] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_BX] = 0,
				[StoryFlagType.gameflow_WM_WORLD_KG] = 0,
				[StoryFlagType.global_GameBattleLV] = 0,
			}, false);
			KgBattleGameCommand = new StoryCommand(save, "Keyblade Graveyard, before 1000 Heartless", "/Game/Levels/kg/kg_01/kg_01", CompleteSave(new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.gameflow_BT] = 0,
				[StoryFlagType.gameflow_CA_chart_last_access] = 900,
				[StoryFlagType.gameflow_CA_ship_ride_type] = 100,
				[StoryFlagType.gameflow_CA_Sub_Portroyal_Search] = 382,
				[StoryFlagType.gameflow_EW] = 2300,
				[StoryFlagType.gameflow_EW_MISSION] = 0,
				[StoryFlagType.gameflow_EW_MISSION_RA] = 0,
				[StoryFlagType.gameflow_EW_MISSION_MI] = 0,
				[StoryFlagType.gameflow_EW_MISSION_TS] = 0,
				[StoryFlagType.gameflow_EW_MISSION_CA] = 0,
				[StoryFlagType.gameflow_EW_MISSION_FZ] = 0,
				[StoryFlagType.gameflow_GM_03_SUB] = 10,
				[StoryFlagType.gameflow_HE_Sub_HeraculesBoy] = 0,
				[StoryFlagType.gameflow_KG] = 50,
				[StoryFlagType.gameflow_KG_13_A] = 0,
				[StoryFlagType.gameflow_KG_13_B] = 0,
				[StoryFlagType.gameflow_KG_13_C] = 0,
				[StoryFlagType.gameflow_KG_13_D] = 0,
				[StoryFlagType.gameflow_TT_PO] = 100,
				[StoryFlagType.gameflow_TT_Remy] = 0,
			}), false);
		}

		public ISaveKh3 Save { get; }

		public StoryCommand NewGamePlusCommand { get; }
		public StoryCommand NewGamePlusGlitchyCommand { get; }
		public StoryCommand CompleteGameCommand { get; }
		public StoryCommand LandOfDepartureCommand { get; }
		public StoryCommand KgBattleGameCommand { get; }

		private static Dictionary<StoryFlagType, int> CompleteSave(Dictionary<StoryFlagType, int> patches = null)
		{
			var complete = new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.gameflow_BT] = (int)StoryLabelTypeBt.BT_END,
				[StoryFlagType.gameflow_BX] = (int)StoryLabelTypeBx.BX_END,
				[StoryFlagType.gameflow_CA] = (int)StoryLabelTypeCa.CA_END,
				[StoryFlagType.gameflow_CA_chart_last_access] = (int)StoryLabelTypeCaChartLastAccess.CA_chart_last_access_13,
				[StoryFlagType.gameflow_CA_ship_ride_type] = (int)StoryLabelTypeCaShipRide.CA_ship_ride_type_02,
				[StoryFlagType.gameflow_CA_Sub_Portroyal_Search] = (int)StoryLabelTypeCaPortroyalSearch.CA_Sub_Portroyal_Search_STEP_05,
				[StoryFlagType.gameflow_CS] = (int)StoryLabelTypeCs.CS_END,
				[StoryFlagType.gameflow_DI] = (int)StoryLabelTypeDi.DI_END,
				[StoryFlagType.gameflow_DP] = (int)StoryLabelTypeDp.DP_END,
				[StoryFlagType.gameflow_DW] = (int)StoryLabelTypeDw.DW_END,
				[StoryFlagType.gameflow_DW_Sub_INT] = 0,
				[StoryFlagType.gameflow_EW] = (int)StoryLabelTypeEw.EW_END,
				[StoryFlagType.gameflow_EW_Sub_TESTB] = (int)StoryLabelTypeEwSub.EW_Sub_EVENT4,
				[StoryFlagType.gameflow_EW_MISSION] = (int)StoryLabelTypeEwMission.EW_MISSION_END,
				[StoryFlagType.gameflow_EW_MISSION_RA] = (int)StoryLabelTypeEwRa.EW_MISSION_RA_END,
				[StoryFlagType.gameflow_EW_MISSION_MI] = (int)StoryLabelTypeEwMi.EW_MISSION_MI_END,
				[StoryFlagType.gameflow_EW_MISSION_TS] = (int)StoryLabelTypeEwTs.EW_MISSION_TS_END,
				[StoryFlagType.gameflow_EW_MISSION_CA] = (int)StoryLabelTypeEwCa.EW_MISSION_CA_END,
				[StoryFlagType.gameflow_EW_MISSION_FZ] = (int)StoryLabelTypeEwFz.EW_MISSION_FZ_END,
				[StoryFlagType.gameflow_EX] = 0,
				[StoryFlagType.gameflow_FZ] = (int)StoryLabelTypeFz.FZ_END,
				[StoryFlagType.gameflow_FZ_Sub_SLIDEMISSION] = (int)StoryLabelTypeFzMinigame.FZ_Sub_SLIDEMISSION_END,
				[StoryFlagType.gameflow_GM] = (int)StoryLabelTypeGm.GM_END,
				[StoryFlagType.gameflow_GM_01] = (int)StoryLabelTypeGm1.GM_01_END,
				[StoryFlagType.gameflow_GM_02] = (int)StoryLabelTypeGm2.GM_02_END,
				[StoryFlagType.gameflow_GM_03] = (int)StoryLabelTypeGm3.GM_03_END,
				[StoryFlagType.gameflow_GM_03_SUB] = (int)StoryLabelTypeGm3sub.GM_03_SUB_END,
				[StoryFlagType.gameflow_GM_SYS] = (int)StoryLabelTypeGmSys.GM_SYS_END,
				[StoryFlagType.gameflow_GM_SYS_LEVELUP] = (int)StoryLabelTypeGmLevelUp.GM_SYS_LEVELUP_STEP_02,
				[StoryFlagType.gameflow_HE] = (int)StoryLabelTypeHe.HE_END,
				[StoryFlagType.gameflow_HE_Sub_HeraculesBoy] = (int)StoryLabelTypeHeSub.HE_Sub_HeraculesBoy_End,
				[StoryFlagType.gameflow_KG] = (int)StoryLabelTypeKg.KG_END2,
				[StoryFlagType.gameflow_KG_13_A] = (int)StoryLabelTypeKgA.KG_02_EVENT_A_END,
				[StoryFlagType.gameflow_KG_13_B] = (int)StoryLabelTypeKgB.KG_02_EVENT_B_END,
				[StoryFlagType.gameflow_KG_13_C] = (int)StoryLabelTypeKgC.KG_02_EVENT_C_END,
				[StoryFlagType.gameflow_KG_13_D] = (int)StoryLabelTypeKgD.KG_02_EVENT_D_END,
				[StoryFlagType.gameflow_MI] = 9999,
				[StoryFlagType.gameflow_MI_Sub_INT] = 0,
				[StoryFlagType.gameflow_PO] = 9999,
				[StoryFlagType.gameflow_RA] = 9999,
				[StoryFlagType.gameflow_RA_Dandelion] = 100,
				[StoryFlagType.gameflow_RA_Rabbit] = 0,
				[StoryFlagType.gameflow_RA_Rainbow] = 100,
				[StoryFlagType.gameflow_RA_Bird] = 100,
				[StoryFlagType.gameflow_RG] = 9999,
				[StoryFlagType.gameflow_SF] = 9999,
				[StoryFlagType.gameflow_TS] = 9999,
				[StoryFlagType.gameflow_TS_Sub_GAM1] = 0,
				[StoryFlagType.gameflow_TT] = 9999,
				[StoryFlagType.gameflow_TT_PO] = 9999,
				[StoryFlagType.gameflow_TT_Remy] = 100,
				[StoryFlagType.gameflow_WM_WORLD_HE] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_TT] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_RA] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_TS] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_MI] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_FZ] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_CA] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_BX] = 2000,
				[StoryFlagType.gameflow_WM_WORLD_KG] = 2000,
				[StoryFlagType.global_GameBattleLV] = 3000,
				[StoryFlagType.global_GameShopLV] = 6000,
				[StoryFlagType.gameflow_YT] = 9999,
				[StoryFlagType.gameflow_BT_DLC] = 0,
				[StoryFlagType.gameflow_BT_DLC_07_BT_01] = 0,
				[StoryFlagType.gim_BT_DLC_monument] = 0,
				[StoryFlagType.gameflow_KG_DLC] = 0,
				[StoryFlagType.gameflow_KG_DLC_13_A] = 0,
				[StoryFlagType.gameflow_KG_DLC_13_B] = 0,
				[StoryFlagType.gameflow_KG_DLC_13_C] = 0,
				[StoryFlagType.gameflow_KG_DLC_13_D] = 0,
				[StoryFlagType.gameflow_KG_DLC_05_AREA_A_CHARSEL] = 0,
				[StoryFlagType.gameflow_KG_DLC_05_AREA_B_CHARSEL] = 0,
				[StoryFlagType.gameflow_KG_DLC_05_AREA_C_CHARSEL] = 0,
				[StoryFlagType.gameflow_KG_DLC_05_AREA_D_CHARSEL] = 0,
				[StoryFlagType.gameflow_KG_DLC_06_LAST_CHARSEL] = 0,
				[StoryFlagType.gameflow_RG_DLC] = 0,
				[StoryFlagType.gameflow_SS_DLC] = 0,
				[StoryFlagType.gameflow_SS_DLC_Sub_BadEnd] = 0,
				[StoryFlagType.gameflow_SS_DLC_Sub_TrueEnd] = 0,
			};

			foreach (var patch in patches ?? new Dictionary<StoryFlagType, int>())
			{
				complete[patch.Key] = patch.Value;
			}

			return complete;
		}
	}

	public class StoryCommand : RelayCommand
	{
		public StoryCommand(
			ISaveKh3 save,
			string name,
			string map,
			Dictionary<StoryFlagType, int> flags,
			bool zeroEverything = false)
			: base(x =>
			{
				if (!ThrowConfirmationMessage(name))
					return;

				if (!string.IsNullOrEmpty(map))
				{
					save.MapPath = map;
					save.MapSpawn = "default";
				}

				if (zeroEverything)
				{
					for (var i = 0; i < save.Storyflags.Count; i++)
					{
						save.Storyflags[i] = 0;
					}
				}

				for (var i = 0; i < save.Storyflags.Count; i++)
				{
					if (flags.TryGetValue((StoryFlagType)i, out var newFlag))
					{
						save.Storyflags[i] = newFlag;
					}
				}
			})
		{
			Name = name;
		}

		public string Name { get; }

		public override string ToString() => Name;

		private static bool ThrowConfirmationMessage(string name)
		{
			var response = MessageBox.Show(
				"You are modifying the progress of the story.\n" +
				"This technique it is not 100% save and you could incur\n" +
				"in some glitches or infinite black screern during your run.\n" +
				$"Do you want to apply the change '{name}'?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Warning);

			return response == MessageBoxResult.Yes;
		}
	}

	public class StoryAdvancedViewModel : GenericListModel<StoryEntryModel>
	{
		public StoryAdvancedViewModel(List<int> storyflags) :
			base(storyflags.Select((_, index) => new StoryEntryModel(storyflags, index)))
		{

		}

		protected override StoryEntryModel OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}

	public class StoryEntryModel : BaseNotifyPropertyChanged
	{
		private readonly List<int> storyFlag;
		private readonly int index;

		public GenericListModel<EnumItemModel<int>> Preset { get; }

		public StoryEntryModel(List<int> storyFlag, int index)
		{
			this.storyFlag = storyFlag;
			this.index = index;

			if (Presets.STORY.TryGetValue((StoryFlagType)index, out var preset))
			{
				Preset = new StoryPresetModel(preset);
			}
		}

		public string Name => InfoAttribute.GetInfo((StoryFlagType)index) ?? $"{index:X02}";

		public int Value
		{
			get => storyFlag[index];
			set
			{
				storyFlag[index] = value;
				OnPropertyChanged(nameof(Value));
			}
		}
	}

	public class StoryPresetModel : GenericListModel<EnumItemModel<int>>
	{
		public StoryPresetModel(Dictionary<int, string> preset) :
			base(preset.Select(x => new EnumItemModel<int>
			{
				Value = (int)x.Key,
				Name = x.Value
			}))
		{ }

		protected override EnumItemModel<int> OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}
}
