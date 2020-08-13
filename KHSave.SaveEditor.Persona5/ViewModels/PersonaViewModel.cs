using KHSave.Attributes;
using KHSave.LibPersona5.Models;
using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Persona5.Interfaces;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class PersonaViewModel
    {
        private readonly Persona _persona;
        private readonly IPersonaList _personaList;
        private readonly ISkillList _skillList;

        public PersonaViewModel(Persona persona, IPersonaList personaList, ISkillList skillList)
        {
            _persona = persona;
            _personaList = personaList;
            _skillList = skillList;
        }

        public KhEnumListModel<Demon> PersonaList => _personaList.PersonaList;
        public KhEnumListModel<EnumIconTypeModel<Skill>, Skill> SkillList => _skillList.SkillList;

        public string Name => InfoAttribute.GetInfo(PersonaId);
        public string Arcana => DemonAttribute.GetInfo(PersonaId);

        public bool IsEnabled
        {
            get => _persona.Flags != 0;
            set => _persona.Flags = (short)(value ? 1 : 0);
        }

        public Demon PersonaId
        {
            get => (Demon)_persona.Id;
            set => _persona.Id = (short)value;
        }

        public short Level
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
            set => _persona.Skills[0] = value;
        }

        public Skill Skill1
        {
            get => _persona.Skills[1];
            set => _persona.Skills[1] = value;
        }

        public Skill Skill2
        {
            get => _persona.Skills[2];
            set => _persona.Skills[2] = value;
        }

        public Skill Skill3
        {
            get => _persona.Skills[3];
            set => _persona.Skills[3] = value;
        }

        public Skill Skill4
        {
            get => _persona.Skills[4];
            set => _persona.Skills[4] = value;
        }

        public Skill Skill5
        {
            get => _persona.Skills[5];
            set => _persona.Skills[5] = value;
        }

        public Skill Skill6
        {
            get => _persona.Skills[6];
            set => _persona.Skills[6] = value;
        }

        public Skill Skill7
        {
            get => _persona.Skills[7];
            set => _persona.Skills[7] = value;
        }
    }
}
