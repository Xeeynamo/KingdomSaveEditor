using KHSave.LibPersona3;
using KHSave.LibPersona3.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Persona3.Interfaces;
using KHSave.SaveEditor.Persona3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Persona3.ViewModels
{
    public class Persona3MainViewModel : BaseNotifyPropertyChanged,
        IRefreshUi, IOpenStream, IWriteToStream,
        IPersonaList, ISkillList
    {
        private const string DefaultTab = "Characters";
        private static readonly List<PersonaModel> PersonaListAll;
        private static readonly Dictionary<Demons, PersonaModel> PersonaDictionary;
        private static readonly IList<SkillModel> SkillListAll;

        static Persona3MainViewModel()
        {
            PersonaListAll = Enum
                .GetValues<Demons>()
                .Select(x => new PersonaModel(x))
                .ToList();
            PersonaDictionary = PersonaListAll
                .ToDictionary(x => x.Value, x => x);
            SkillListAll = Enum
                .GetValues<Skill>()
                .Select(x => new SkillModel(x))
                .ToList();
        }

        public SavePersona3 Save { get; private set; }

        public CompendiumViewModel Compendium { get; set; }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public string CurrentTabId
        {
            get => Global.LastPersona3Tab ?? DefaultTab;
            set => Global.LastPersona3Tab = value;
        }

        public IEnumerable<PersonaModel> PersonaList => PersonaListAll
            .Where(x => x.IsImplemented || Global.IsAdvancedMode);
        public IEnumerable<SkillModel> SkillList => SkillListAll
            .Where(x => x.IsImplemented || Global.IsAdvancedMode);

        public void RefreshUi()
        {
            Compendium = new CompendiumViewModel(Save, this, this);

            OnPropertyChanged(nameof(SimpleVisibility));
            OnPropertyChanged(nameof(AdvancedVisibility));
            OnPropertyChanged(nameof(Compendium));
        }

        public void OpenStream(Stream stream)
        {
            Save = SavePersona3.Read(stream);
            RefreshUi();
        }

        public void WriteToStream(Stream stream) => Save.Write(stream);

        public PersonaModel GetPersona(Demons id)
        {
            if (PersonaDictionary.TryGetValue(id, out var persona))
                return persona;
            return new PersonaModel(id);
        }
    }
}
