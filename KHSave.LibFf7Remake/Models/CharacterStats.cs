using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Models
{
    public class CharacterStats
    {
        [Data] public int Strength { get; set; }
        [Data] public int Magic { get; set; }
        [Data] public int Vitality { get; set; }
        [Data] public int Spirit { get; set; }
    }
}
