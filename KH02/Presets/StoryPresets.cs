using KHSave.Types;
using System.Collections.Generic;

namespace KHSave.Presets
{
	public static class StoryPresets
	{
		public static Dictionary<int, Dictionary<int, string>> KnownStoryFlags { get; } = new Dictionary<int, Dictionary<int, string>>
		{
			[(int)StoryFlagType.ScalaAdCaelum] = new Dictionary<int, string>
			{
				[0] = "A Strange World",
				[100] = "Before Mysterious Adversaries",
				[200] = "Mysterious Adversaries",
				[218] = "Stairway to the Sky (Before Armored Xehanort)",
				[222] = "Confront Armored Xehanort once you are duly prepared!",
				[244] = "No Information Box",
			},
			[(int)StoryFlagType.DestinyIsland] = new Dictionary<int, string>
			{
				[0] = "Interval VIII: The Destiny Islands",
				[10] = "Return to Light",
				[100] = "A Replica's Resolve Pt. 1",
				[200] = "A Replica's Resolve Pt. 2",
				[9999] = "Story Done",
			},
			[(int)StoryFlagType.LandOfDeparture] = new Dictionary<int, string>
			{
				[0] = "Castle Oblivion Is Unlocked (Part 1)",
				[50] = "Castle Oblivion Is Unlocked (Part 2)",
				[100] = "Before Vanitas fight",
				[200] = "During Vanitas fight",
				[300] = "An End to Slumber (Part 1) (After Vanitas)",
				[490] = "An End to Slumber (Part 2)",
				[502] = "An End to Slumber (Part 3)",
			},
			[(int)StoryFlagType.WorldMap] = new Dictionary<int, string>
			{
				[0] = "Start of World Map",
				[100] = "A Replica for Roxas (Part 1)",
				[210] = "A Replica for Roxas (Part 2)",
				[320] = "A Message from Merlin",
				[500] = "A Guiding Key (Part 1)",
				[9999] = "Story Done",
			},
			[(int)StoryFlagType.KeybladeGraveyard] = new Dictionary<int, string>
			{
				[0] = "Vexen's Return",
				[18] = "The Organization's Origins",
				[50] = "The Xehanorts Gather",
				[100] = "1 Million Heartless",
				[200] = "Before The Final World",
				[11500] = "Start of The Skein of Severance",
				[11600] = "Before 1st Set of Organization XIII Fights",
				[13050] = "Before 2nd Set of Organization XIII Fights",
				[13500] = "Before Young Master Xehanort, Ansem, & Xemnas",
				[14000] = "Xehanort Trio (Black Screen)",
				[14696] = "After Xehanort Trio",
				[99999] = "Story Done",
			},
			[(int)StoryFlagType.MysteriousTower] = new Dictionary<int, string>
			{
				[0] = "Prelude to Adventure",
				[50] = "A Fresh Start",
				[100] = "A Quick Review",
				[200] = "The Guardians of Light Gather",
				[300] = "Beneath the Same Stars",
				[9999] = "Story Done",
			},
		};
	}
}
