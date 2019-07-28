using KHSave.LibRecom.Models;
using Xe.BinaryMapper;

namespace KHSave.LibRecom
{
    public class DataRecom
    {
        [Data(0, 0x3620)] public byte[] Data { get; set; }
        [Data(0x314)] public StoryFlag SoraStoryFlag { get; set; }
        [Data] public StoryFlag RikuStoryFlag { get; set; }
        [Data] public TutorialFlags Tutorial { get; set; }
        [Data] public CardFlags UnlockedCards { get; set; }
        [Data] public Kh2CardFlags UnlockedKh2Cards { get; set; }
        [Data] public FriendsFlags UnlockedFriends { get; set; }
        [Data] public PoohFlags PoohFlags { get; set; }
    }
}
