using KHSave.Attributes;
using KHSave.LibPersona3.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Services;
using System.Windows.Media;

namespace KHSave.SaveEditor.Persona3.Models
{
    public class SkillModel
    {
        public SkillModel(Skill value)
        {
            Value = value;
            Name = InfoAttribute.GetInfo(value);
            Icon = IconService.Icon(value);
            IsImplemented = Global.CanDisplayInBasicMode(value);
        }

        public string Name { get; }
        public Skill Value { get; }
        public ImageSource Icon { get; }
        public bool IsImplemented { get; }
    }
}
