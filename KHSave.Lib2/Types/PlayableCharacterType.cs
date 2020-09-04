using KHSave.Attributes;

namespace KHSave.Lib2.Types
{
    public enum PlayableCharacterType : byte
    {
        [Info] Sora,
        [Info] Donald,
        [Info] Goofy,
        [Info("World character")] WorldCharacter,
        [Info] Valor,
        [Info] Wisdom,
        [Info] Limit,
        [Info] Trinity,
        [Info] Final,
        [Info] Antiform,
        [Info] Mickey,
        [Info] None = 18,
    }
}
