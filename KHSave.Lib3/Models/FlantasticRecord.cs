using Xe.BinaryMapper;

namespace KHSave.Lib3.Models
{
    public class FlantasticRecord
    {
        [Data] public int HighScore { get; set; }
        [Data] public int HighScore2 { get; set; }
        [Data] public int AttemptCount { get; set; }
    }
}
