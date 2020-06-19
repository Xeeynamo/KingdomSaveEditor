using KHSave.Attributes;

namespace KHSave.LibDDD.Types
{
    public enum WorldType : byte
    {
        [World("ex", "ex")] WorldEx,
        [World("de", "Destiny Island")] DestinyIsland,
        [World("yt", "Mysterious Tower")]MysteriousTower,
        [World("tw", "Traverse Town")] TraverseTown,
        [World("tm", "Country of the Musketeers")] CountryOfTheMusketeers,
        [World("fa", "Symphony of Sorcery")] SymphonyOfSorcery,
        [World("pi", "Pranksters Paradise")] PrankstersParadise,
        [World("rg", "Radiant Garden")] RadiantGarden,
        [World("nd", "La Cite des Cloches")] LaCiteDesCloches,
        [World("tl", "The Grid")] TheGrid,
        [World("eh", "The World That Never Was")] TheWorldThatNeverWas,
        [World("wm", "World Map")] WorldMap,
        [World("di", "Spirit Space")] SpiritSpace,
        [World("zz", "World ZZ")] WorldZz,
        [World("unk1", "Traverse Town (Revisited)")] TraverseTownRevisited,
        [World("unk2", "Ending")] Ending,
    }
}
