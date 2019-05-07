using System.Collections.Generic;
using Xe.BinaryMapper;

namespace KHSave.Lib3.Models
{
    public class Records
    {
        [Data] public int VerumRexHighScore { get; set; }
        [Data] public int VerumRexTimer { get; set; }
        [Data] public int FlashTracer1HighScore { get; set; }
        [Data] public int FlashTracer2HighScore { get; set; }
        [Data] public int FlashTracer1Timer { get; set; }
        [Data] public int FlashTracer2Timer { get; set; }
        [Data] public int FrozenSliderHighScore { get; set; }
        [Data] public int FrozenSliderTimer { get; set; }
        [Data] public int FrozenSliderMedals { get; set; }
        [Data] public int FestivalDanceHighScore { get; set; }
        [Data] public int FestivalDanceLongestChain { get; set; }
        [Data] public FlantasticRecord CherryFlan { get; set; }
        [Data] public FlantasticRecord StrawberryFlan { get; set; }
        [Data] public FlantasticRecord BananaFlan { get; set; }
        [Data] public FlantasticRecord HoneydewFlan { get; set; }
        [Data] public FlantasticRecord GrapeFlan { get; set; }
        [Data] public FlantasticRecord WatermelonFlan { get; set; }
        [Data] public FlantasticRecord OrangeFlan { get; set; }
        [Data(Count = 0x1e)] public List<short> ShotlocksHighScore { get; set; }
    }
}
