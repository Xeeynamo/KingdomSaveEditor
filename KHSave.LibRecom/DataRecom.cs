using KHSave.LibRecom.Models;
using KHSave.LibRecom.Types;
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
        [Data(0x470)] public PlayMode PlayMode { get; set; }
        [Data] public Difficulty Difficulty { get; set; }
        [Data] public SoundMode SoundMode { get; set; }
        [Data] public bool NoVibration { get; set; }

        [Data(0x490)] public byte Unknown490 { get; set; }
        [Data(0x491)] public bool Unknown491_0 { get; set; }
        [Data(0x491)] public bool SoraCleared { get; set; }
        [Data(0x492)] public bool Unknown492_0 { get; set; }
        [Data] public bool Kh2Cleared { get; set; }
        [Data] public bool RikuCleared { get; set; }
        [Data(0x4a0)] public bool Unknown4a0_0 { get; set; }
        [Data] public bool Unknown4a0_1 { get; set; }
        [Data] public bool MarluxiaKilled { get; set; }
        [Data] public bool GameCleared { get; set; }
    }
}
