using System.Collections.Generic;
using System.Linq;
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

	public class StoryEntryModel
	{
		private readonly List<int> storyFlag;
		private readonly int index;

		public StoryEntryModel(List<int> storyFlag, int index)
		{
			this.storyFlag = storyFlag;
			this.index = index;
		}

		public string Name => $"{index}";

		public int Value { get => storyFlag[index]; set => storyFlag[index] = value; }
	}
}
