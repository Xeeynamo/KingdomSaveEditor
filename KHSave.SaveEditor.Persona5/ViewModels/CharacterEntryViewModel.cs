using KHSave.Attributes;
using KHSave.LibPersona5.Models;
using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Persona5.Interfaces;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class CharacterEntryViewModel : GenericListModel<PersonaViewModel>
    {
        private readonly Characters _id;
        private readonly Character _character;

        public CharacterEntryViewModel(Character character, int index, IPersonaList personaList) :
            base(character.Persona.Select(x => new PersonaViewModel(x, personaList)))
        {
            _id = (Characters)index;
            _character = character;
        }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        public string Name => InfoAttribute.GetInfo(_id);

        public int Experience
        {
            get => _character.Experience;
            set => _character.Experience = value;
        }

        public int CurrentHp
        {
            get => _character.CurrentHp;
            set => _character.CurrentHp = value;
        }

        public int CurrentMp
        {
            get => _character.CurrentMp;
            set => _character.CurrentMp = value;
        }

        protected override void OnSelectedItem(PersonaViewModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }
    }
}
