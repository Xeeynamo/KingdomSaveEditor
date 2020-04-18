using KHSave.Attributes;

namespace KHSave.LibFf7Remake.Types
{
    public enum CharacterType
    {
        [Info("Cloud")] Cloud = SaveFf7Remake.Cloud,
        [Info("Barret")] Barret = SaveFf7Remake.Barret,
        [Info("Tifa")] Tifa = SaveFf7Remake.Tifa,
        [Info("Aerith")] Aerith = SaveFf7Remake.Aerith,
        [Info("Red XIII")] Red13 = SaveFf7Remake.Red13,
        [Info("5")] Unused5, // Cait Sith
        [Info("6")] Unused6, // Cid
        [Info("7")] Unused7, // Yuffie
        [Info("8")] Unused8, // Vincent
        [Info("Unequip")] Unequip = SaveFf7Remake.Unequipped,
    }
}
