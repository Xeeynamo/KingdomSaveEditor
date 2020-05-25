using KHSave.Attributes;

namespace KHSave.LibBbs.Types
{
    public enum CharacterType : byte
    {
        [Unused] Crash00,
        [Info] Ventus,
        [Info] Aqua,
        [Info] Terra,
        [Unused] Crash04,
        [Info("Ventus (full armor)")] ArmoredVentus,
        [Info("Aqua (full armor)")] ArmoredAqua,
        [Info("Terra (full armor)")] ArmoredTerra,
    }
}
