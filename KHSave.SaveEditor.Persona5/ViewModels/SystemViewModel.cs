using KHSave.LibPersona5;
using System.Collections.Generic;
using System.Linq;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class SystemViewModel
    {
        private readonly ISavePersona5 _save;

        public List<RoomViewModel> Rooms { get; set; }

        public string Room
        {
            get => $"{_save.RoomCategory:D03}_{_save.RoomMap:D03}";
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                var room = value.Split('_');
                _save.RoomCategory = short.Parse(room[0]);
                _save.RoomMap = short.Parse(room[1]);
            }
        }

        public SystemViewModel(ISavePersona5 save)
        {
            _save = save;

            Rooms = Presets.Fields.Select(x => new RoomViewModel(x)).ToList();
        }
    }
}
