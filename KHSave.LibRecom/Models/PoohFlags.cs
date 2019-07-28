using Xe.BinaryMapper;

namespace KHSave.LibRecom.Models
{
    public class PoohFlags
    {
        [Data] public int Data { get; set; }
        [Data(0)] public bool Piglet { get; set; }
        [Data] public bool Owl { get; set; }
        [Data] public bool Roo { get; set; }
        [Data] public bool Eeyore { get; set; }
        [Data] public bool Tigger { get; set; }
        [Data] public bool Rabbit { get; set; }
        [Data] public bool Goal1 { get; set; }
        [Data] public bool Goal2 { get; set; }
    }
}
