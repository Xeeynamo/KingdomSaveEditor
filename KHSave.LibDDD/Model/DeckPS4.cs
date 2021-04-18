using Xe.BinaryMapper;

namespace KHSave.LibDDD.Model
{
    public class DeckPS4 : IDeck
    {
        [Data(Count = 220)] public byte[] Unk01 { get; set; }
        [Data(Count = 43)] public byte[] Name { get; set; }
        [Data(Count = 55)] public byte[] Unk02 { get; set; }
    }
}
