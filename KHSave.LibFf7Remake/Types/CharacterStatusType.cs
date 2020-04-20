using KHSave.Attributes;

namespace KHSave.LibFf7Remake.Types
{
    public enum CharacterStatusType : byte
    {
        [Info("Un-discovered")] Undiscovered,
        [Info("In party")] InParty,
        [Info("Out party")] OutParty,
        [Info("3")] Unk3,
        [Info("4")] Unk4,
    }
}
