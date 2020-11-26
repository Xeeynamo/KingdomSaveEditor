using Xe.BinaryMapper;

namespace KHSave.LibRecom.Models
{
    public class SkillFlags
    {
        [Data] public int Data { get; set; }
        [Data(0)] public bool HighJump { get; set; }
        [Data] public bool Glide { get; set; }
        [Data] public bool SuperGlide { get; set; }
        [Data] public bool DodgeRoll { get; set; }
        [Data] public bool RapidBreak { get; set; }
        [Data] public bool Duel { get; set; }
    }
}
