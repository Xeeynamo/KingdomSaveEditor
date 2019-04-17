using KHSave.Attributes;

namespace KHSave.Lib3.Types
{
    public enum DesireChoice : byte
    {
        [Info] Vitality,
        [Info] Wisdom,
        [Info] Balance,
    }

    public enum PowerChoice : byte
    {
        [Info] Warrior,
        [Info] Mystic,
        [Info] Guardian,
    }
}
