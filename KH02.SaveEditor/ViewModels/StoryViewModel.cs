using KHSave.Attributes;
using KHSave.Presets;
using KHSave.Types;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools;
using Xe.Tools.Models;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class StoryViewModel : GenericListModel<StoryEntryModel>
	{
		public StoryViewModel(List<int> storyflags) :
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
