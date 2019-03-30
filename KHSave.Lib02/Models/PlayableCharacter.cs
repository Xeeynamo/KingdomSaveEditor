using Xe.BinaryMapper;

namespace KHSave.Trssv.Models
{
    public class PlayableCharacter
    {
        [Data(0, 0x200)] public byte[] Data { get; set; }
        [Data(0x08C)] public int Hp { get; set; }
        [Data(0x090)] public int Mp { get; set; }
        [Data(0x094)] public int Focus { get; set; }
    }
}
