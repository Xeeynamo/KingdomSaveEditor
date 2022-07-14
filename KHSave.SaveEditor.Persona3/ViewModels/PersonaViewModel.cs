using KHSave.LibPersona3.Models;
using KHSave.LibPersona3.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Persona3.Interfaces;
using KHSave.SaveEditor.Persona3.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Persona3.ViewModels
{
    public class PersonaViewModel : BaseNotifyPropertyChanged
    {
        private readonly int _compendiumIndex;
        private readonly Persona _persona;
        private readonly IPersonaList _personaList;
        private readonly ISkillList _skillList;

        public Demons Value
        {
            get => _persona.Id;
            set
            {
                _persona.Id = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DemonName));
                OnPropertyChanged(nameof(IsImplemented));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Arcana));
            }
        }

        private PersonaModel Persona => _personaList.GetPersona(_persona.Id);

        public Demons PersonaId
        {
            get => _persona.Id;
            set
            {
                _persona.Id = value;
                IsEnabled = value != Demons.Empty;

                OnPropertyChanged(nameof(DemonName));
                OnPropertyChanged(nameof(Arcana));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(IsEnabled));
                OnPropertyChanged(nameof(Flags));
            }
        }
        public string Name => ToString();
        public string DemonName => Persona?.Name ?? "-";
        public string Arcana => Persona?.Arcana ?? string.Empty;
        public bool IsImplemented => Persona?.IsImplemented ?? false;

        public byte Level
        {
            get => _persona.Level;
            set => _persona.Level = value;
        }

        public bool IsEnabled
        {
            get => (_persona.Flags & 1) == 1;
            set
            {
                if (value)
                    _persona.Flags |= 1;
                else
                    _persona.Flags &= ~1;
                OnPropertyChanged(nameof(Flags));
            }
        }

        internal void ResetPersonaToDefault()
        {
            var personaId = (Demons)_compendiumIndex;
            var persona = _personaList.GetPersona(personaId);
            if (persona == null || !persona.IsImplemented)
                return;
            PersonaId = (Demons)_compendiumIndex;
        }

        public short Flags
        {
            get => _persona.Flags;
            set => _persona.Flags = value;
        }

        public byte Break
        {
            get => _persona.Break;
            set => _persona.Break = value;
        }

        public short Unk
        {
            get => _persona.Unk;
            set => _persona.Unk = value;
        }

        public int Experience
        {
            get => _persona.Experience;
            set => _persona.Experience = value;
        }

        public byte Strength
        {
            get => _persona.Strength;
            set => _persona.Strength = value;
        }

        public byte Magic
        {
            get => _persona.Magic;
            set => _persona.Magic = value;
        }

        public byte Endurance
        {
            get => _persona.Endurance;
            set => _persona.Endurance = value;
        }

        public byte Agility
        {
            get => _persona.Agility;
            set => _persona.Agility = value;
        }

        public byte Luck
        {
            get => _persona.Luck;
            set => _persona.Luck = value;
        }

        public bool OverThanatos
        {
            get => _persona.OverThanatos != 0;
            set => _persona.OverThanatos = value ? 1 : 0;
        }

        public Skill Skill0
        {
            get => _persona.Skills[0];
            set
            {
                _persona.Skills[0] = value;
                OnPropertyChanged(nameof(Skill0));
            }
        }

        public Skill Skill1
        {
            get => _persona.Skills[1];
            set
            {
                _persona.Skills[1] = value;
                OnPropertyChanged(nameof(Skill1));
            }
        }

        public Skill Skill2
        {
            get => _persona.Skills[2];
            set
            {
                _persona.Skills[2] = value;
                OnPropertyChanged(nameof(Skill2));
            }
        }

        public Skill Skill3
        {
            get => _persona.Skills[3];
            set
            {
                _persona.Skills[3] = value;
                OnPropertyChanged(nameof(Skill3));
            }
        }

        public Skill Skill4
        {
            get => _persona.Skills[4];
            set
            {
                _persona.Skills[4] = value;
                OnPropertyChanged(nameof(Skill4));
            }
        }

        public Skill Skill5
        {
            get => _persona.Skills[5];
            set
            {
                _persona.Skills[5] = value;
                OnPropertyChanged(nameof(Skill5));
            }
        }

        public Skill Skill6
        {
            get => _persona.Skills[6];
            set
            {
                _persona.Skills[6] = value;
                OnPropertyChanged(nameof(Skill6));
            }
        }

        public Skill Skill7
        {
            get => _persona.Skills[7];
            set
            {
                _persona.Skills[7] = value;
                OnPropertyChanged(nameof(Skill7));
            }
        }

        public IEnumerable<PersonaModel> PersonaList => _personaList.PersonaList;
        public IEnumerable<SkillModel> SkillList => _skillList.SkillList;

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public PersonaViewModel(int compendiumIndex, Persona persona, IPersonaList personaList, ISkillList skillList)
        {
            _compendiumIndex = compendiumIndex;
            _persona = persona;
            _personaList = personaList;
            _skillList = skillList;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Arcana))
                return DemonName;
            return $"{Arcana} | {DemonName}";
        }
    }
}
