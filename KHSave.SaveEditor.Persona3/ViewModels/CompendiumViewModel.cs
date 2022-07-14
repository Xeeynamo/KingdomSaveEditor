using KHSave.LibPersona3;
using KHSave.SaveEditor.Persona3.Interfaces;
using KHSave.SaveEditor.Persona3.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Persona3.ViewModels
{
    public class CompendiumViewModel : GenericListModel<PersonaViewModel>
    {
        private const string UnlockCompendiumMessage =
            "This will unlock the compendium by filling the Persona with their default parameters.\n" +
            "Do you wish to also overwrite the existing customized Persona too?\n\n" +
            "Yes: Unlock compenium, reset your customized Persona.\n" +
            "No: Only unlock missing Persona, do not touch the existing Persona.\n" +
            "Cancel: Do not perform any operation.";

        private readonly SavePersona3 _save;

        public CompendiumViewModel(
            SavePersona3 save,
            IPersonaList personaList,
            ISkillList skillList) :
            this(save.Compendium.Select((x, i) => new PersonaViewModel(i, x, personaList, skillList)))
        {
            _save = save;
            UnlockAllCompendiumCommand = new RelayCommand(_ =>
            {
                var result = MessageBox.Show(UnlockCompendiumMessage,
                    "Reset Persona to default", MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Warning);

                System.Func<PersonaViewModel, bool> predicate;
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        predicate = x => true;
                        break;
                    case MessageBoxResult.No:
                        predicate = x => !x.IsEnabled;
                        break;
                    default:
                        return;
                }

                foreach (var persona in Items.Where(predicate))
                    persona.ResetPersonaToDefault();
            });
        }

        private CompendiumViewModel(IEnumerable<PersonaViewModel> list) :
            base(list)
        { }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        public RelayCommand UnlockAllCompendiumCommand { get; }

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
