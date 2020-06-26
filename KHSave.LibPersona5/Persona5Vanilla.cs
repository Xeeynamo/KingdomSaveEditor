using Xe.BinaryMapper;

namespace KHSave.LibPersona5
{
    internal class Persona5Vanilla : ISavePersona5
    {
        [Data(Count = 192 * 1024)] public byte[] Data { get; set; }

        [Data(0x2d5a)] public int Money { get; set; }
    }
}
