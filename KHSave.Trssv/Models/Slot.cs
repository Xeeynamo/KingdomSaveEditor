using Xe.BinaryMapper;

namespace KHSave.Trssv.Models
{
    public class Slot
    {
        [Data(0x2410)] public int Hp { get; set; }

        [Data(0x2414)] public int Mp { get; set; }

        [Data(0x3324, 0x100)] public string MapName { get; set; }
    }
}
