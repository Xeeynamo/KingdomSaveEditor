using KHSave.Attributes;
using KHSave.LibPersona3.Types;
using KHSave.SaveEditor.Common;

namespace KHSave.SaveEditor.Persona3.Models
{
    public class PersonaModel
    {
        public Demons Value { get; }
        public string Name { get; }
        public bool IsImplemented { get; }
        public string Arcana { get; }

        public PersonaModel(Demons demon)
        {
            Value = demon;
            Name = InfoAttribute.GetInfo(demon);
            IsImplemented = Global.CanDisplayInBasicMode(demon);
            Arcana = DemonAttribute.GetArcana(demon);
        }
    }
}
