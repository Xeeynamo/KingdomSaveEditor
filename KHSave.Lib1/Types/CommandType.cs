using KHSave.Attributes;

namespace KHSave.Lib1.Types
{
    public enum CommandType : byte
    {
        [Magic] Fire,
        [Magic] Blizzard,
        [Magic] Thunder,
        [Magic] Cure,
        [Magic] Gravity,
        [Magic] Stop,
        [Magic] Aero,
        Empty = 0xFF
    }
}
