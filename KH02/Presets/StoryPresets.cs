using KHSave.Types;
using System.Collections.Generic;

namespace KHSave.Presets
{
	public static class StoryPresets
	{
		public static Dictionary<int, Dictionary<int, string>> KnownStoryFlags { get; } = new Dictionary<int, Dictionary<int, string>>
		{
			[(int)StoryFlagType.DestinyIsland] = new Dictionary<int, string>
			{
				[0] = "Interval VIII: The Destiny Islands",
				[10] = "Return to Light",
				[100] = "A Replica's Resolve Pt. 1",
				[200] = "A Replica's Resolve Pt. 2",
				[9999] = "Complete",
			}
		};
	}
}
