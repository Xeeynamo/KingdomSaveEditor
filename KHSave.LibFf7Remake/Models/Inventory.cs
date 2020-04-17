using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Models
{
    public class Inventory
    {
        [Data] public uint Id { get; set; }
        [Data] public int Unknown04 { get; set; }
        [Data] public int Type { get; set; }
        [Data] public int Count { get; set; }
        [Data] public int Unknown10 { get; set; }
        [Data] public int Unknown14 { get; set; }
    }
}
