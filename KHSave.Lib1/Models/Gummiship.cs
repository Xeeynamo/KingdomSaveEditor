using KHSave.Lib1.Types;
using System.Threading;
using Xe.BinaryMapper;

namespace KHSave.Lib1.Models
{
    public class Gummiship
    {
        [Data] public byte BlocksUsed { get; set; }
        //probably the other statistics
        [Data(Count = 75)] public byte[] Unk01 { get; set; }
        [Data(Count = 10)] public byte[] ShipName { get; set; }
        [Data(Count = 22)] public byte[] Unk02 { get; set; }
        [Data(Count = 200)] public GummiBlock[] GummiBlocks { get; set; }
        [Data(Count = 1466)] public byte[] Unk03 { get; set; }
    }
}
