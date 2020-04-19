using KHSave.LibFf7Remake.Models;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkChapter
    {
        [Data(Count = 0x660E8)] public byte[] Data { get; set; }

        [Data(0, Count = 8)] public byte[] Characters { get; set; }
        [Data(0xC, Count = 0x10)] public Position[] Positions { get; set; }

        public ChunkChapter()
        {
            Data = new byte[0x660E8];
            Characters = new byte[8];
            Positions = Enumerable.Range(0, 0x10).Select(x => new Position()).ToArray();
        }
    }
}
