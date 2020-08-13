using KHSave.LibPersona5;
using KHSave.SaveEditor.Persona5.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class CompendiumViewModel : GenericListModel<PersonaViewModel>
    {
        private readonly ISavePersona5 _save;

        public CompendiumViewModel(
            ISavePersona5 save,
            IPersonaList personaList,
            ISkillList skillList) :
            this(save.Compendium.Select(x => new PersonaViewModel(x, personaList, skillList)))
        {
            _save = save;
        }

        private CompendiumViewModel(IEnumerable<PersonaViewModel> list) :
            base(list)
        { }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(PersonaViewModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }

        protected override PersonaViewModel OnNewItem() =>
            throw new System.NotImplementedException();
    }
}
