using Xe.BinaryMapper;

namespace KHSave.LibRecom.Models
{
    public class FriendsFlags
    {
        [Data] public int Data { get; set; }
        [Data(0)] public bool Donald { get; set; }
        [Data] public bool Goofy { get; set; }
        [Data] public bool Alladin { get; set; }
        [Data] public bool Ariel { get; set; }
        [Data] public bool Jack { get; set; }
        [Data] public bool PeterPan { get; set; }
        [Data] public bool Beast { get; set; }
        [Data] public bool KingMickey { get; set; }
        [Data] public bool Pluto { get; set; }
    }
}
