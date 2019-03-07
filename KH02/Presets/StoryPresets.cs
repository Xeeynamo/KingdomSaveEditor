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
				[218] = "Stairway to the Sky (Part 1)",
				[222] = "Confront Armored Xehanort once you are duly prepared!",
				[244] = "Stairway to the Sky (Part 2)",
                [300] = "Armored Xehanort (1st Phase)",
                [350] = "Armored Xehanort (2nd Phase) [Cutscene before fight]",
                [400] = "Armored Xehanort (2nd Phase)",
                [450] = "Armored Xehanort (3rd Phase) [Cutscene before fight]",
                [500] = "Armored Xehanort (3rd Phase)",
                [550] = "One Sky, One Destiny",
                [720] = "Checkmate (Part 1)",
                [800] = "Checkmate (Part 2)",
                [810] = "Checkmate (Part 3)",
            },
            [(int)StoryFlagType.SanFransokyo] = new Dictionary<int, string>
            {
                [0] = "City of Superheroes",
                [22] = "Bridge Heartless",
                [50] = "Rock Troll II",
                [75] = "The AR Device",
                [100] = "Before Flash Tracer",
                [256] = "Upgraded",
                [512] = "Microbots",
                [608] = "Before Darkubes I",
                [618] = "Darkubes I",
                [624] = "After Darkubes I",
                [646] = "Rescue Big Hero 6",
                [652] = "Darkubes II",
                [668] = "A Riku From the Past?",
                [676] = "The First Baymax",
                [692] = "Friend of Yours?",
                [718] = "Before Dark Baymax",
                [1024] = "Subdue Dark Baymax!",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.Caribbean] = new Dictionary<int, string>
            {
                [0] = "Start of the World",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.DestinyIsland] = new Dictionary<int, string>
			{
				[0] = "A Guiding Key (Part 2)",
				[10] = "Return to the Light (Part 2)",
				[100] = "A Replica's Resolve Pt. 1",
				[200] = "The Papou Fruit",
				[9999] = "Story Done",
			},
			[(int)StoryFlagType.LandOfDeparture] = new Dictionary<int, string>
			{
				[0] = "Castle Oblivion Is Unlocked (Part 1)",
				[50] = "Castle Oblivion Is Unlocked (Part 2)",
				[100] = "Before Vanitas fight",
				[200] = "Vanitas Boss Battle",
				[300] = "An End to Slumber (Part 1) (After Vanitas)",
				[490] = "An End to Slumber (Part 2)",
				[502] = "An End to Slumber (Part 3)",
				[9999] = "Story Done",
			},
            [(int)StoryFlagType.DarkWorld] = new Dictionary<int, string>
            {
                [0] = "A Dwindling Trail",
                [14] = "The Dark Margin",
                [22] = "Demon Tower I",
                [50] = "Reunion (After Demon Tower I)",
                [100] = "An Unexpected Encounter",
                [200] = "Riku and the King's Peril",
                [300] = "Too Late",
                [410] = "Demon Tower II",
                [520] = "Braving the Darkness",
                [608] = "Anti-Aqua",
                [718] = "Return to the Light (Part 1)",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.TheFinalWorld] = new Dictionary<int, string>
            {
                [2200] = "Darkside Boss Battle",
                [2300] = "End of tutorial",
            },
            [(int)StoryFlagType.Arendelle] = new Dictionary<int, string>
            {
                [0] = "Start of the World",
                [3300] = "After exiting Ice Tower",
                [8820] = "Story Done",
            },
            [(int)StoryFlagType.ArendelleAvalanche] = new Dictionary<int, string>
            {
                [0] = "Avalanche Minigame",
                [2120] = "Avalanche Done [Black screen]",
            },
            [(int)StoryFlagType.Gummi] = new Dictionary<int, string>
            {
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.Hercules] = new Dictionary<int, string>
            {
                [0] = "Start of Olympus",
                [50] = "After Agora heartless",
                [1280] = "Start of Realm of Gods",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.KeybladeGraveyard] = new Dictionary<int, string>
			{
				[0] = "Vexen's Return",
				[10] = "The Organization's Origins",
				[50] = "The Xehanorts Gather",
				[100] = "1 Million Heartless",
				[200] = "Before The Final World",
                [512] = "Light Expires",
                [9999] = "Go Toward the Light (Part 1)",
                [10000] = "Go Toward the Light (Part 2)",
                [10240] = "Light in the Darkness",
                [10752] = "Thanks, Kairi",
                [11100] = "Before Demon Tide II",
                [11104] = "Demon Tide II",
                [11300] = "The Light of the Past",
                [11400] = "Demon Tide II (Union Cross)",
                [11413] = "A Corridor of Light",
                [11424] = "The X-Blade",
                [11500] = "Start of The Skein of Severance",
				[11600] = "Before 1st Set of Organization XIII Fights",
				[13050] = "Before 2nd Set of Organization XIII Fights",
				[13500] = "Before Young Master Xehanort, Ansem, & Xemnas",
				[14000] = "Xehanort Trio (Black Screen)",
				[14696] = "After Xehanort Trio",
				[99999] = "Story Done",
			},
            [(int)StoryFlagType.KG_Riku_Xigbar] = new Dictionary<int, string>
            {
                [0] = "Before Fight",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.KG_Luxord_Marluxia_Larxene] = new Dictionary<int, string>
            {
                [0] = "Before Fight",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.KG_Vanitas_Terra] = new Dictionary<int, string>
            {
                [0] = "Before Fight",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.KG_Xion_Saix] = new Dictionary<int, string>
            {
                [0] = "Before Fight",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.Monstropolis] = new Dictionary<int, string>
            {
                [0] = "Start of the World",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.Pooh] = new Dictionary<int, string>
            {
                [0] = "Start of the world",
                [100] = "First minigame beaten",
                [200] = "Second minigame beaten",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.KingdomOfCorona] = new Dictionary<int, string>
            {
                [0] = "Start of the World",
                [3170] = "Going back to Rapunzel's Tower",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.RadiantGarden] = new Dictionary<int, string>
            {
                [0] = "Terra's Whereabouts",
                [50] = "The Missing Scientist",
                [100] = "The Benched Enact a Plan",
                [200] = "A Present from Vexen",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.SecretForest] = new Dictionary<int, string>
            {
                [0] = "Talking On Paper",
                [10] = "Nothing's As It Should Be",
                [9999] = "Story Done"
            },
            [(int)StoryFlagType.ToyBox] = new Dictionary<int, string>
            {
                [0] = "Start of the World",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.TwilightTown] = new Dictionary<int, string>
            {
                [0] = "Nostalgic Streets",
                [100] = "The Neighborhood Nobodies",
                [116] = "Hello, Good-bye",
                [124] = "Demon Tide I",
                [132] = "Defeat the Demon Tide!",
                [140] = "Before The Woods Powerwilds",
                [200] = "The Woods Powerwilds",
                [250] = "Before Entering the Mansion",
                [300] = "Datascapes (Part 2)",
                [350] = "Before The Old Mansion Fight",
                [400] = "After The Old Mansion Fight",
                [450] = "The Old Mansion Fight",
                [500] = "Collect Ingredients",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.WorldMap] = new Dictionary<int, string>
            {
                [0] = "Prelude to Adventure (Part 2)",
                [22] = "Heart Within a Heart",
                [100] = "A Replica for Roxas (Part 1)",
                [210] = "A Replica for Roxas (Part 2)",
                [320] = "A Message from Merlin",
                [500] = "A Guiding Key (Part 1)",
                [3000] = "Ienzo Checks In",
                [9999] = "Story Done",
            },
            [(int)StoryFlagType.MysteriousTower] = new Dictionary<int, string>
			{
				[0] = "Prelude to Adventure",
				[10] = "A Fresh Start",
				[100] = "A Quick Review",
				[200] = "The Guardians of Light Gather",
				[300] = "Beneath the Same Stars",
				[9999] = "Story Done",
			},
		};
	}
}
