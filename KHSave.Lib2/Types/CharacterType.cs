using KHSave.Attributes;

namespace KHSave.Lib2.Types
{
    public enum CharacterType
    {
        [Info] Sora,
        [Info] Donald,
        [Info] Goofy,
        [Info] Mickey,
        [Info] Auron,
        [Info] Mulan,
        [Info] Aladdin,
        [Info("Jack Sparrow")] JackSparrow,
        [Info] Beast,
        [Info] Jack,
        [Info] Simba,
        [Info] Tron,
        [Info] Riku,
    }
}
