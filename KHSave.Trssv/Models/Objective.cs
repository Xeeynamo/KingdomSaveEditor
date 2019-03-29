using Xe.BinaryMapper;

namespace KHSave.Trssv.Models
{
    public class Objective
    {
        // bit 0: unlocked
        // bit 4: unread
        [Data] public short Flags { get; set; }
        [Data] public short Progress { get; set; }
    }
}
