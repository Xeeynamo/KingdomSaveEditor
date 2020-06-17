using KHSave.Attributes;

namespace KHSave.LibDDD.Types
{
    public enum WorldType : byte
    {
        [World("ex", "ex")] WorldEx,
        [World("de", "Destiny Island")] DestinyIsland,
        [World("tt", "Traverse Town")] TraverseTown,
        [World("cm", "Country of the Musketeers")] CountryOfTheMusketeers,
        [World("ss", "Symphony of Sorcery")] SymphonyOfSorcery,
        [World("pp", "Pranksters Paradise")] PrankstersParadise,
        [World("rg", "Radiant Garden")] RadiantGarden,
        [World("cc", "La Cite des Cloches")] LaCiteDesCloches,
        [World("tg", "The Grid")] TheGrid,
        [World("eh", "The World That Never Was")] TheWorldThatNeverWas,
        [World("sp", "Spirit Space")] SpiritSpace,
        [World("te", "For Testing Purpose")] WorldTesting,
        [World("ttr", "Traverse Town (Revisited)")] TraverseTownRevisited,
        [World("en", "Ending")] Ending,
    }
}
