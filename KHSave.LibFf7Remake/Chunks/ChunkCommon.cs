using KHSave.LibFf7Remake.Models;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkCommon
    {
        [Data(Count = 0x00050008)] public byte[] Data { get; set; }

        [Data(0, Count = 5, Stride = 0x40)] public Character[] Characters { get; set; }
        [Data(0x34DA0, Count = 0x800, Stride = 0x18)] public Inventory[] Inventory { get; set; }
        [Data(0x42F54)] public byte PlayableCharacter { get; set; }
        [Data(0x42F55)] public byte CurrentChapter { get; set; }
    }
}
