using Xe.BinaryMapper;

namespace KHSave.LibPersona5
{
    public class Character
    {
        [Data(Count = 0x2a8)] public byte[] Data { get; set; }

        [Data(0x14)] public int CurrentHp { get; set; }
        [Data] public int CurrentMp { get; set; }
        [Data(0x24)] public int Experience { get; set; }
        [Data(0x54)] public int Experience2 { get; set; }
    }
}
