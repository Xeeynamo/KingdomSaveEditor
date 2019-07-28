using Xe.BinaryMapper;

namespace KHSave.LibRecom.Models
{
    public class Kh2CardFlags
    {
        [Data] public int Data { get; set; }
        [Data(0)] public bool Xemnas { get; set; }
        [Data] public bool Xigbar { get; set; }
        [Data] public bool Xaldin { get; set; }
        [Data] public bool Saix { get; set; }
        [Data] public bool Demyx { get; set; }
        [Data] public bool Luxord { get; set; }
        [Data] public bool Roxas { get; set; }
        [Data] public bool StarSeeker { get; set; }
        [Data] public bool Monochrome { get; set; }
        [Data] public bool FollowTheWind { get; set; }
        [Data] public bool HiddenDragon { get; set; }
        [Data] public bool PhotonDebugger { get; set; }
        [Data] public bool BondOfFlame { get; set; }
    }
}
