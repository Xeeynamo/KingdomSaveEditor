using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Models
{
    public class Equipment
    {
        [Data] public byte Unknown00 { get; set; }
        [Data] public byte Unknown01 { get; set; }
        [Data] public byte Unknown02 { get; set; }
        [Data] public byte Unknown03 { get; set; }
        [Data] public int ItemId { get; set; }
        [Data] public int Unknown08 { get; set; }
        [Data] public int Unknown0c { get; set; }
        [Data(0x10, Count = 8)] public int[] MateriaIndex { get; set; }
    }
}
