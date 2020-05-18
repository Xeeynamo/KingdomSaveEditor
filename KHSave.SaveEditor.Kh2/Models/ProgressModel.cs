using KHSave.Lib2;
using KHSave.Lib2.Models;
using KHSave.SaveEditor.Common.Services;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh2.Models
{
    public class ProgressModel : BaseNotifyPropertyChanged, SearchEngine.IName
    {
        private readonly int _worldId;
        private readonly Progress _progress;

        public ProgressModel(int worldId, Progress progress, int flag)
        {
            _worldId = worldId;
            _progress = progress;
            Flag = flag;
        }

        public int Flag { get; }

        public string World => Constants.WorldNames[_worldId];

        public string Label => Name.Substring(3);

        public string Name => Constants.Progress[Flag];

        public bool Done
        {
            get => _progress.GetFlag(Flag % 1024);
            set
            {
                _progress.SetFlag(Flag % 1024, value);
                OnPropertyChanged();
            }
        }
    }
}
