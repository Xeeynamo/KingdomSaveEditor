using KHSave.Attributes;
using KHSave.LibPersona5.Models;
using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Persona5.Interfaces;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class PersonaViewModel : BaseNotifyPropertyChanged
    {
        private readonly Persona _persona;
        private readonly IPersonaList _personaList;
        private readonly ISkillList _skillList;
        private PersonaEntryViewModel _vm;

        public PersonaViewModel(Persona persona, IPersonaList personaList, ISkillList skillList)
        {
            _persona = persona;
            _personaList = personaList;
            _skillList = skillList;
            _vm = new PersonaEntryViewModel(PersonaId);
        }

        public IEnumerable<PersonaEntryViewModel> PersonaList => _personaList.PersonaList;
        public IEnumerable<SkillViewModel> SkillList => _skillList.SkillList;
        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public string Name => _vm.Name;
        public string DemonName => _vm.SimpleName;
        public string Arcana => _vm.Arcana;

        public bool IsEnabled
        {
            get => _persona.Flags != 0;
            set => _persona.Flags = (short)(value ? 1 : 0);
        }

        public Demon PersonaId
        {
            get => (Demon)_persona.Id;
            set
            {
                _persona.Id = (short)value;
                _vm = new PersonaEntryViewModel(PersonaId);
                OnPropertyChanged(nameof(DemonName));
                OnPropertyChanged(nameof(Arcana));
                OnPropertyChanged(nameof(Name));
            }
        }

        public byte Level
        {
            get => _persona.Level;
            set => _persona.Level = value;
        }

        public short Unknown06
        {
            get => _persona.Unknown06;
            set => _persona.Unknown06 = value;
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

        public Skill Skill0
        {
            get => _persona.Skills[0];
            set
            {
                _persona.Skills[0] = value;
                OnPropertyChanged(nameof(Skill0));
                OnPropertyChanged(nameof(SkillData0));
            }
        }

        public Skill Skill1
        {
            get => _persona.Skills[1];
            set
            {
                _persona.Skills[1] = value;
                OnPropertyChanged(nameof(Skill1));
                OnPropertyChanged(nameof(SkillData1));
            }
        }

        public Skill Skill2
        {
            get => _persona.Skills[2];
            set
            {
                _persona.Skills[2] = value;
                OnPropertyChanged(nameof(Skill2));
                OnPropertyChanged(nameof(SkillData2));
            }
        }

        public Skill Skill3
        {
            get => _persona.Skills[3];
            set
            {
                _persona.Skills[3] = value;
                OnPropertyChanged(nameof(Skill3));
                OnPropertyChanged(nameof(SkillData3));
            }
        }

        public Skill Skill4
        {
            get => _persona.Skills[4];
            set
            {
                _persona.Skills[4] = value;
                OnPropertyChanged(nameof(Skill4));
                OnPropertyChanged(nameof(SkillData4));
            }
        }

        public Skill Skill5
        {
            get => _persona.Skills[5];
            set
            {
                _persona.Skills[5] = value;
                OnPropertyChanged(nameof(Skill5));
                OnPropertyChanged(nameof(SkillData5));
            }
        }

        public Skill Skill6
        {
            get => _persona.Skills[6];
            set
            {
                _persona.Skills[6] = value;
                OnPropertyChanged(nameof(Skill6));
                OnPropertyChanged(nameof(SkillData6));
            }
        }

        public Skill Skill7
        {
            get => _persona.Skills[7];
            set
            {
                _persona.Skills[7] = value;
                OnPropertyChanged(nameof(Skill7));
                OnPropertyChanged(nameof(SkillData7));
            }
        }

        public int SkillData0
        {
            get => (int)_persona.Skills[0];
            set
            {
                _persona.Skills[0] = (Skill)value;
                OnPropertyChanged(nameof(Skill0));
                OnPropertyChanged(nameof(SkillData0));
            }
        }

        public int SkillData1
        {
            get => (int)_persona.Skills[1];
            set
            {
                _persona.Skills[1] = (Skill)value;
                OnPropertyChanged(nameof(Skill1));
                OnPropertyChanged(nameof(SkillData1));
            }
        }

        public int SkillData2
        {
            get => (int)_persona.Skills[2];
            set
            {
                _persona.Skills[2] = (Skill)value;
                OnPropertyChanged(nameof(Skill2));
                OnPropertyChanged(nameof(SkillData2));
            }
        }

        public int SkillData3
        {
            get => (int)_persona.Skills[3];
            set
            {
                _persona.Skills[3] = (Skill)value;
                OnPropertyChanged(nameof(Skill3));
                OnPropertyChanged(nameof(SkillData3));
            }
        }

        public int SkillData4
        {
            get => (int)_persona.Skills[4];
            set
            {
                _persona.Skills[4] = (Skill)value;
                OnPropertyChanged(nameof(Skill4));
                OnPropertyChanged(nameof(SkillData4));
            }
        }

        public int SkillData5
        {
            get => (int)_persona.Skills[5];
            set
            {
                _persona.Skills[5] = (Skill)value;
                OnPropertyChanged(nameof(Skill5));
                OnPropertyChanged(nameof(SkillData5));
            }
        }

        public int SkillData6
        {
            get => (int)_persona.Skills[6];
            set
            {
                _persona.Skills[6] = (Skill)value;
                OnPropertyChanged(nameof(Skill6));
                OnPropertyChanged(nameof(SkillData6));
            }
        }

        public int SkillData7
        {
            get => (int)_persona.Skills[7];
            set
            {
                _persona.Skills[7] = (Skill)value;
                OnPropertyChanged(nameof(Skill7));
                OnPropertyChanged(nameof(SkillData7));
            }
        }
    }
}
