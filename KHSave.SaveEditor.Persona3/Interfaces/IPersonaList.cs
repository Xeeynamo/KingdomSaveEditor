using KHSave.LibPersona3.Types;
using KHSave.SaveEditor.Persona3.Models;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Persona3.Interfaces
{
    public interface IPersonaList
    {
        IEnumerable<PersonaModel> PersonaList { get; }
        PersonaModel GetPersona(Demons id);
    }
}
