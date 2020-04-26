using KHSave.Attributes;

namespace KHSave.Lib1.Types
{
    public enum DifficultyFm : byte
    {
        [Info("Final Mix: Beginner Mode")] Beginner,
        [Info("Final Mix Mode")] Standard,
        [Info("Final Mix: Proud Mode")] Proud
    }
}
