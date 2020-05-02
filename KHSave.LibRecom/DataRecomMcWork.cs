using Xe.BinaryMapper;

namespace KHSave.LibRecom.Types
{
    public class DataRecomMcWork
    {
        [Data(0, 0x3110)] public byte[] Data { get; set; }

        [Data(0x1aa4, Count = 0x49C)] public byte[] CardInventoryCount { get; set; }

        [Data(0x2830)] public int Experience { get; set; }
    }
}
