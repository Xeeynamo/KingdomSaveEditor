using KHSave.LibRecom.Models;
using KHSave.LibRecom.Types;
using Xe.BinaryMapper;

namespace KHSave.LibRecom
{
    public class DataRecom
    {
        [Data(Count = 0x10)] public byte[] RealData { get; set; }
        [Data] public DataRecomTable0 Table0 { get; set; } // 0x10
        [Data] public DataRecomTable1 Table1 { get; set; } // 0x410
        [Data] public DataRecomTable2 Table2 { get; set; } // 0x490
        [Data(0x510)] public DataRecomMcWork McWork { get; set; } // 0x510
    }
}
