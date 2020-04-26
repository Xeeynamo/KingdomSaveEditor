using KHSave.Attributes;

namespace KHSave.Lib1.Types
{
    public enum PlayableCharacterType : byte
    {
        [Info] Sora,
        [Info] Donald,
        [Info] Goofy,
        [Info] Tarzan,
        [Info("Pooh (not playable)")] Pooh,
        [Info] Aladdin,
        [Info] Ariel,
        [Info] Jack,
        [Info("Peter Pan")] PeterPan,
        [Info] Biest,
        [Info] Empty = 0xFF
    }
}
