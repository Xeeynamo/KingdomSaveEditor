using KHSave.LibRecom;
using KHSave.LibRecom.Types;
using KHSave.SaveEditor.Common.Models;
using Xe.Tools.Models;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class SystemViewModel
    {
        private readonly DataRecom _save;

        public SystemViewModel(DataRecom save)
        {
            _save = save;
            PlayModeItems = new EnumModel<PlayMode>();
            DifficultyItems = new EnumModel<Difficulty>();
        }

        public EnumModel<PlayMode> PlayModeItems { get; }
        public EnumModel<Difficulty> DifficultyItems { get; }

        public PlayMode PlayMode
        {
            get => _save.PlayMode;
            set => _save.PlayMode = value;
        }

        public Difficulty Difficulty
        {
            get => _save.Difficulty;
            set => _save.Difficulty = value;
        }
    }
}
