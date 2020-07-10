using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.Persona5.Interfaces
{
    public interface ISkillList
    {
        KhEnumListModel<EnumIconTypeModel<Skill>, Skill> SkillList { get; }
    }
}
