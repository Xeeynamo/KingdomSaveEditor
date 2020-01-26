using KHSave.Attributes;

namespace KHSave.Lib3.Types
{
    public enum PartyCharacter : byte
    {
        [Info("Default")] Sora,
        [Info("Sora (Caribbean)")] SoraCaribbean,
        [Info("Sora (Monstropolis)")] SoraMonstropolis,
        [Info("Sora (Toy Box)")] SoraToyBox,
        [Info("Sora (Baymax)")] SoraBaymax,
        Char05,
        [Info("Sora (KH2)")] SoraKh2,
        Char07,
        Char08,
        [Info("Riku (KH2)")] RikuKh2,
        [Info("Mickey")] Mickey,
        [Info("Donald")] Donald,
        [Info("Goofy")] Goofy,
        [Info("Jack")] Jack,
        [Info("Woody")] Woody,
        [Info("Buzz")] Buzz,
        [Info("Hercules")] Hercules,
        [Info("Rapunzel")] Rapunzel,
        [Info("Eugene")] Eugene,
        [Info("Sulley")] Sulley,
        [Info("Mike")] Mike,
        Char15,
        [Info("Marshmallow")] Marshmallow,
        [Info("Baymax")] Baymax,
    }
}
