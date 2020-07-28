using KHSave.LibPersona5;
using Xe.Tools;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class RoomViewModel : BaseNotifyPropertyChanged
    {
        private readonly Presets.Field _field;

        public string Id => $"{_field.Category:D03}_{_field.Map:D03}";
        public string Description => $"{Id} {_field.Description}";
        public bool IsVanilla => _field.Vanilla;
        public bool IsRoyal => _field.Royal;

        public RoomViewModel(Presets.Field field)
        {
            _field = field;
        }
    }
}
