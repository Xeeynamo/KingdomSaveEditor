using KHSave.SaveEditor.Persona5.ViewModels;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Persona5.Interfaces
{
    public interface ISkillList
    {
        IEnumerable<SkillViewModel> SkillList { get; }
    }
}
