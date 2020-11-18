using KHSave.LibDDD.Types;
using Xe.BinaryMapper;

namespace KHSave.LibDDD.Model
{
    public class DreamEater
    {
        [Data] public DreamEaterType DreamEaterType { get; set; }
        [Data(Count = 5)] public byte[] Unk01 { get; set; }
        [Data(Count = 22)] public byte[] Name { get; set; }
        [Data(Count = 33)] public byte[] Unk02 { get; set; }
        [Data] public byte Attack { get; set; }
        [Data] public byte Magic { get; set; }
        [Data] public byte Defence { get; set; }
        [Data(Count = 192)] public byte[] Unk03 { get; set; }
    }
}
