using Xe.BinaryMapper;

namespace KHSave.LibDDD.Model
{
    public class Deck
    {
        [Data(Count = 220)] public byte[] Unk01 { get; set; }
        [Data(Count = 16)] public byte[] Name { get; set; }
        [Data(Count = 24)] public byte[] Unk02 { get; set; }
    }
}
