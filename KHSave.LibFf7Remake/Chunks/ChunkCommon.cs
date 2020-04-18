using KHSave.LibFf7Remake.Models;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkCommon
    {
        [Data(Count = 0x00050008)] public byte[] Data { get; set; }

        [Data(8, Count = 5, Stride = 0x40)] public Character[] Characters { get; set; }
        [Data(0x1818, Count = 1000, Stride = 0x20)] public Materia[] Materia { get; set; }
        [Data(0x34DA8, Count = 0x800, Stride = 0x18)] public Inventory[] Inventory { get; set; }
        [Data(0x42F5C)] public byte PlayableCharacter { get; set; }
        [Data(0x42F5D)] public byte CurrentChapter { get; set; }
    }
}
