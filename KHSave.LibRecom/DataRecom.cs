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
    }
}
