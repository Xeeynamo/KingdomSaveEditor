using KHSave.Attributes;

namespace KHSave.LibBbs.Types
{
    public enum WorldType : byte
    {
        [World("dp", "Land of Departure")] LandofDeparture = 1,
        [World("sw", "Dwarf Woodlands")] DwarfWoodlands = 2,
        [World("cd", "Castle of Dreams")] CastleofDreams = 3,
        [World("sb", "Enchanted Dominion")] EnchantedDominion = 4,
        [World("yt", "The Mysterious Tower")] MysteriousTower = 5,
        [World("rg", "Radiant Garden")] RadiantGarden = 6,
        [World("jb", "Realm of Darkness / Miscellaneous")] RealmOfDarkness = 7,
        [World("he", "Olympus Coliseum")] Olympus = 8,
        [World("ls", "Deep Space")] DeepSpace = 9,
        [World("di", "Destiny Islands")] DestinyIslands = 0xA, // 0x0A
        [World("pp", "Neverland")] Neverland = 0xB, // 0x0B
        [World("dc", "Disney Town")] DisneyTown = 0xC, // 0x0C
        [World("kg", "Keyblade Graveyard")] KeybladeGraveyard = 0xD, // 0x0D
        [World("vs", "Mirage Arena")] MirageArena = 0xF, // 0x0F
        [World("wm", "World Map")] WorldMap = 0x11, // 0x11
    }
}
