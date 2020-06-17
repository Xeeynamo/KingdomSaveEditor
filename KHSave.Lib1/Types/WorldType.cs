using KHSave.Attributes;

namespace KHSave.Lib1.Types
{
    public enum WorldType : uint
    {
        [Info("Dive into the Heart")] DiveIntoHeart = 0x00,
        [Info("Destiny Island")] DestinyIsland = 0x01,
        [Info("Disney Castle")] DisneyCastle = 0x02,
        [Info("Traverse Town")] TraverseTown = 0x03,
        [Info("Wonderland")] Wonderland = 0x04,
        [Info("Deep Jungle")] DeepJungle = 0x05,
        [Info("100 Acre Wood")] HundredAcreWood = 0x06,
        [Unused] Crash07 = 0x07,
        [Info("Agrabah")] Agrahbah = 0x08,
        [Info("Atlantica")] Atlantica = 0x09,
        [Info("Halloween Town")] HalloweenTown = 0x0a,
        [Info("Olympus Coliseum")] OlympusColiseum = 0x0b,
        [Info("Monstro")] Monstro = 0x0c,
        [Info("Neverland")] Neverland = 0x0d,
        [Unused] Crash0e = 0x0e,
        [Info("Hollow Bastion")] HollowBastion = 0x0f,
        [Info("End of the world")] Endoftheworld = 0x10,
    }
}
