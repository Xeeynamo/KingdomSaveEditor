using KHSave;
using KHSave.Attributes;
using KHSave.Presets;
using KHSave.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Models;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.ViewModels
{
	public class StoryViewModel
	{
		public StoryViewModel(Kh3 save)
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
		public StorySimpleViewModel(Kh3 save)
		{
			Save = save;
			NewGamePlusCommand = new StoryCommand(save, "New Game+", "/Game/Levels/ew/ew_01/ew_01", new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.TheFinalWorld] = 0,
				[StoryFlagType.Story33] = 2000
			}, true);
			NewGamePlusGlitchyCommand = new StoryCommand(save, "New Game+ (every world is completed anyway)", "/Game/Levels/ew/ew_01/ew_01", new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.TheFinalWorld] = 0,
				[StoryFlagType.Story33] = 2000
			}, false);
			CompleteGameCommand = new StoryCommand(save, "Complete game", "/Game/Levels/bt/bt_01/bt_01", CompleteSave(), false);
			LandOfDepartureCommand = new StoryCommand(save, "Back to Land of Departure (before Vanitas fight)", "/Game/Levels/dp/dp_01/dp_01", new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.LandOfDeparture] = 0,
			}, false);
			KgBattleGameCommand = new StoryCommand(save, "Keyblade Graveyard, before 1000 Heartless", "/Game/Levels/kg/kg_01/kg_01", CompleteSave(new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.ScalaAdCaelum] = 0,
				[StoryFlagType.Story03] = 900,
				[StoryFlagType.Story04] = 100,
				[StoryFlagType.Story05] = 382,
				[StoryFlagType.TheFinalWorld] = 2300,
				[StoryFlagType.Story0D] = 0,
				[StoryFlagType.Story0E] = 0,
				[StoryFlagType.Story0F] = 0,
				[StoryFlagType.Story10] = 0,
				[StoryFlagType.Story11] = 0,
				[StoryFlagType.Story12] = 0,
				[StoryFlagType.Story1A] = 10,
				[StoryFlagType.Story1E] = 0,
				[StoryFlagType.KeybladeGraveyard] = 50,
				[StoryFlagType.KG_Riku_Xigbar] = 0,
				[StoryFlagType.KG_Luxord_Marluxia_Larxene] = 0,
				[StoryFlagType.KG_Vanitas_Terra] = 0,
				[StoryFlagType.KG_Xion_Saix] = 0,
				[StoryFlagType.Story31] = 100,
				[StoryFlagType.Story32] = 0,
				[StoryFlagType.Story3B] = 1000,
				[StoryFlagType.Story3C] = 2000,
			}), false);
		}

		public Kh3 Save { get; }

		public StoryCommand NewGamePlusCommand { get; }
		public StoryCommand NewGamePlusGlitchyCommand { get; }
		public StoryCommand CompleteGameCommand { get; }
		public StoryCommand LandOfDepartureCommand { get; }
		public StoryCommand KgBattleGameCommand { get; }

		private static Dictionary<StoryFlagType, int> CompleteSave(Dictionary<StoryFlagType, int> patches = null)
		{
			var complete = new Dictionary<StoryFlagType, int>()
			{
				[StoryFlagType.ScalaAdCaelum] = 100,
				[StoryFlagType.SanFransokyo] = 9999,
				[StoryFlagType.Caribbean] = 9999,
				[StoryFlagType.Story03] = 100,
				[StoryFlagType.Story04] = 100,
				[StoryFlagType.Story05] = 472,
				[StoryFlagType.Story06] = 0,
				[StoryFlagType.DestinyIsland] = 9999,
				[StoryFlagType.LandOfDeparture] = 9999,
				[StoryFlagType.DarkWorld] = 9999,
				[StoryFlagType.Story0A] = 0,
				[StoryFlagType.TheFinalWorld] = 9999,
				[StoryFlagType.Story0C] = 0,
				[StoryFlagType.Story0D] = 9999,
				[StoryFlagType.Story0E] = 9999,
				[StoryFlagType.Story0F] = 9999,
				[StoryFlagType.Story10] = 9999,
				[StoryFlagType.Story11] = 9999,
				[StoryFlagType.Story12] = 9999,
				[StoryFlagType.Story13] = 0,
				[StoryFlagType.Arendelle] = 8820,
				[StoryFlagType.ArendelleAvalanche] = 2120,
				[StoryFlagType.Gummi] = 9999,
				[StoryFlagType.Story17] = 0,
				[StoryFlagType.Story18] = 0,
				[StoryFlagType.Story19] = 200,
				[StoryFlagType.Story1A] = 9999,
				[StoryFlagType.Story1B] = 0,
				[StoryFlagType.Story1C] = 0,
				[StoryFlagType.Hercules] = 9999,
				[StoryFlagType.Story1E] = 600,
				[StoryFlagType.KeybladeGraveyard] = 99999,
				[StoryFlagType.KG_Riku_Xigbar] = 9999,
				[StoryFlagType.KG_Luxord_Marluxia_Larxene] = 9999,
				[StoryFlagType.KG_Vanitas_Terra] = 9999,
				[StoryFlagType.KG_Xion_Saix] = 9999,
				[StoryFlagType.Monstropolis] = 9999,
				[StoryFlagType.Story25] = 0,
				[StoryFlagType.Pooh] = 9999,
				[StoryFlagType.KingdomOfCorona] = 9999,
				[StoryFlagType.Story28] = 100,
				[StoryFlagType.Story29] = 0,
				[StoryFlagType.Story2A] = 100,
				[StoryFlagType.Story2B] = 100,
				[StoryFlagType.RadiantGarden] = 9999,
				[StoryFlagType.SecretForest] = 9999,
				[StoryFlagType.ToyBox] = 9999,
				[StoryFlagType.Story2F] = 0,
				[StoryFlagType.TwilightTown] = 9999,
				[StoryFlagType.Story31] = 9999,
				[StoryFlagType.Story32] = 100,
				[StoryFlagType.Story33] = 2000,
				[StoryFlagType.Story34] = 2000,
				[StoryFlagType.Story35] = 2000,
				[StoryFlagType.Story36] = 2000,
				[StoryFlagType.Story37] = 2000,
				[StoryFlagType.Story38] = 2000,
				[StoryFlagType.Story39] = 2000,
				[StoryFlagType.Story3A] = 2000,
				[StoryFlagType.Story3B] = 2000,
				[StoryFlagType.Story3C] = 3000,
				[StoryFlagType.WorldMap] = 6000,
				[StoryFlagType.MysteriousTower] = 9999,
				[StoryFlagType.Story3F] = 0,
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
			Kh3 save,
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

			if (StoryPresets.KnownStoryFlags.TryGetValue(index, out var preset))
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
					Value = x.Key,
					Name = x.Value
				}))
		{ }

		protected override EnumItemModel<int> OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}
}
