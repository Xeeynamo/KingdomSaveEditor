using KHSave.SaveEditor.Persona3.Models;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Persona3.Interfaces
{
    public interface ISkillList
    {
        IEnumerable<SkillModel> SkillList { get; }
    }
}
