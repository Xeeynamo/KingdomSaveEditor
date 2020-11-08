using KHSave.SaveEditor.Persona5.ViewModels;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Persona5.Interfaces
{
    public interface IPersonaList
    {
        IEnumerable<PersonaEntryViewModel> PersonaList { get; }
    }
}
