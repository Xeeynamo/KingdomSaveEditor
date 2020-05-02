using KHSave.LibRecom;
using KHSave.LibRecom.Types;
using KHSave.SaveEditor.Common.Models;
using Xe.Tools.Models;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class SystemViewModel
    {
        private readonly DataRecom _save;
        private readonly DataRecomTable1 _saveSets;
        private readonly DataRecomTable2 _saveFlags;

        public SystemViewModel(DataRecom save)
        {
            _save = save;
            _saveSets = save.Table1;
            _saveFlags = save.Table2;
            PlayModeItems = new EnumModel<PlayMode>();
            DifficultyItems = new EnumModel<Difficulty>();
        }

        public EnumModel<PlayMode> PlayModeItems { get; }
        public EnumModel<Difficulty> DifficultyItems { get; }

        public PlayMode PlayMode
        {
            get => _saveSets.PlayMode;
            set => _saveSets.PlayMode = value;
        }

        public Difficulty Difficulty
        {
            get => _saveSets.Difficulty;
            set => _saveSets.Difficulty = value;
        }

        public bool SoraCleared
        {
            get => _saveFlags.SoraCleared;
            set => _saveFlags.SoraCleared = value;
        }

        public bool RikuCleared
        {
            get => _saveFlags.RikuCleared;
            set => _saveFlags.RikuCleared = value;
        }

        public bool MarluxiaKilled
        {
            get => _saveFlags.MarluxiaKilled;
            set => _saveFlags.MarluxiaKilled = value;
        }

        public bool GameCleared
        {
            get => _saveFlags.GameCleared;
            set => _saveFlags.GameCleared = value;
        }

        public bool Kh2Cleared
        {
            get => _saveFlags.Kh2Cleared;
            set => _saveFlags.Kh2Cleared = value;
        }

        public int Experience
        {
            get => _save.McWork.Experience;
            set => _save.McWork.Experience = value;
        }
    }
}
