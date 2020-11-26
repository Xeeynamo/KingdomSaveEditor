using KHSave.LibPersona5;
using KHSave.SaveEditor.Persona5.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class CharactersViewModel : GenericListModel<CharacterEntryViewModel>
    {
        private readonly ISavePersona5 _save;

        public CharactersViewModel(
            ISavePersona5 save,
            IPersonaList personaList,
            ISkillList skillList,
            IEquipmentList equipmentList) :
            this(save.Characters.Select((_, i) => new CharacterEntryViewModel(save, save.Characters[i], i, personaList, skillList, equipmentList)))
        {
            _save = save;
        }

        private CharactersViewModel(IEnumerable<CharacterEntryViewModel> list) :
            base(list)
        { }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(CharacterEntryViewModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }

        protected override CharacterEntryViewModel OnNewItem() =>
            throw new System.NotImplementedException();
    }
}
