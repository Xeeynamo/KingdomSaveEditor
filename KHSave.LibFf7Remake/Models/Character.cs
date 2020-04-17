using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Models
{
    public class Character
    {
        [Data] public byte Level { get; set; }
        [Data] public byte Unknown01 { get; set; }
        [Data] public byte Unknown02 { get; set; }
        [Data] public byte Unknown03 { get; set; }
        [Data] public int Unknown04 { get; set; }
        [Data] public int Unknown08 { get; set; }
        [Data] public int Unknown0c { get; set; }
        [Data] public int CurrentHp { get; set; }
        [Data] public int MaxHp { get; set; }
        [Data] public int CurrentMp { get; set; }
        [Data] public int MaxMp { get; set; }
        [Data] public int Experience { get; set; }
        [Data] public int Unknown14 { get; set; }
        [Data] public int Attack { get; set; }
        [Data] public int MagicAttack { get; set; }
        [Data] public int Defense { get; set; }
        [Data] public int MagicDefense { get; set; }
        [Data] public int Luck { get; set; }
        [Data] public int Unknown3c { get; set; }
    }
}
