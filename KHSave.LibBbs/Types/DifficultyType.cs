using KHSave.Attributes;

namespace KHSave.LibBbs.Types
{
    public enum DifficultyType : byte
    {
        [Info] Beginner = 0x8,
        [Info] Standard = 0x48,
        [Info] Proud = 0x88,
        [Info] Critical = 0xC8,
    }
}
