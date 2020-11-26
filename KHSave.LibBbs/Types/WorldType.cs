using KHSave.Attributes;

namespace KHSave.LibBbs.Types
{
    // https://openkh.dev/bbs/worlds.html
    public enum WorldType : byte
    {
        [World("ex", "Generic")] Generic = 0x0,
        [World("dp", "Land of Departure")] LandofDeparture = 0x1,
        [World("sw", "Dwarf Woodlands")] DwarfWoodlands = 0x2,
        [World("cd", "Castle of Dreams")] CastleofDreams = 0x3,
        [World("sb", "Enchanted Dominion")] EnchantedDominion = 0x4,
        [World("yt", "The Mysterious Tower")] MysteriousTower = 0x5,
        [World("rg", "Radiant Garden")] RadiantGarden = 0x6,
        [World("jb", "Jungle Book (JP) / Miscellaneous / Realm of Darkness (FM)")] RealmOfDarkness = 0x7,
        [World("he", "Olympus Coliseum")] Olympus = 0x8,
        [World("ls", "Deep Space")] DeepSpace = 0x9,
        [World("di", "Destiny Island")] DestinyIsland = 0xA,
        [World("pp", "Neverland")] Neverland = 0xB,
        [World("dc", "Disney Town")] DisneyTown = 0xC,
        [World("kg", "Keyblade Graveyard")] KeybladeGraveyard = 0xD,
        [World("vs", "Mirage Arena")] MirageArena = 0xF,
        [World("bd", "Command Board")] CommandBoard = 0x10,
        [World("wm", "World Map")] WorldMap = 0x11,
    }
}
