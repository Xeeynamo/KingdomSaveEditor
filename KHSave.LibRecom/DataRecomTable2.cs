using Xe.BinaryMapper;

namespace KHSave.LibRecom
{
    public class DataRecomTable2
    {
        [Data(Count = 0x80)] public byte[] Data { get; set; }

        [Data(0)] public byte Unknown490 { get; set; }
        [Data] public bool Unknown491_0 { get; set; }
        [Data] public bool SoraCleared { get; set; }
        [Data] public bool Unknown492_0 { get; set; }
        [Data] public bool Kh2Cleared { get; set; }
        [Data] public bool RikuCleared { get; set; }

        [Data(0x10)] public bool Unknown4a0_0 { get; set; }
        [Data] public bool Unknown4a0_1 { get; set; }
        [Data] public bool MarluxiaKilled { get; set; }
        [Data] public bool GameCleared { get; set; }
    }
}
