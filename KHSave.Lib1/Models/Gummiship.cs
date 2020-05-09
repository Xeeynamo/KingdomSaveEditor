using KHSave.Lib1.Types;
using Xe.BinaryMapper;

namespace KHSave.Lib1.Models
{
    public class Gummiship
    {
        [Data] public byte BlocksUsed { get; set; }
        //probably the other statistics
        [Data(Count = 75)] public byte[] Unk01 { get; set; }
        [Data(Count = 10)] public byte[] ShipName { get; set; }
        //contains block ID, rotations, color?
        [Data(Count = 3866)] public byte[] Unk02 { get; set; }
    }
}
