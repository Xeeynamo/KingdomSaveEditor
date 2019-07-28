using KHSave.LibRecom;
using KHSave.LibRecom.Types;
using Xe.Tools.Models;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class SettingsViewModel
    {
        private readonly DataRecom _save;

        public SettingsViewModel(DataRecom save)
        {
            _save = save;
            SoundModeItems = new EnumModel<SoundMode>();
        }

        public EnumModel<SoundMode> SoundModeItems { get; }

        public SoundMode SoundMode
        {
            get => _save.SoundMode;
            set => _save.SoundMode = value;
        }

        public bool Vibration
        {
            get => !_save.NoVibration;
            set => _save.NoVibration = !value;
        }
    }
}
