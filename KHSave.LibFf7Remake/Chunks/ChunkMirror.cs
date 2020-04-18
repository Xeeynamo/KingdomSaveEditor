using KHSave.LibFf7Remake.Models;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkMirror
    {
        [Data(0x34DA0, Count = 0x800, Stride = 0x18)] public Inventory[] Inventory { get; set; }
    }
}
