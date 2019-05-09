using KHSave.Lib3.Models;

namespace KHSave.SaveEditor.Kh3.Models
{
    public class FlantasticModel
    {
        private readonly FlantasticRecord flantasticRecord;

        public FlantasticModel(string name, FlantasticRecord flantasticRecord)
        {
            Name = name;
            this.flantasticRecord = flantasticRecord;
        }

        public string Name { get; }

        public int HighScore
        {
            get => flantasticRecord.HighScore;
            set => flantasticRecord.HighScore = flantasticRecord.HighScore2 = value;
        }

        public int AttemptCount
        {
            get => flantasticRecord.AttemptCount;
            set => flantasticRecord.AttemptCount = value;
        }
    }
}
