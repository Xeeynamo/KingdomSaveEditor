using KHSave.LibPersona5;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Persona5.Interfaces
{
    public interface IConsumableList
    {
        IEnumerable<Presets.Consumable> ConsumableItems { get; }
    }
}
