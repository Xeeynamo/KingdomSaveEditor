using KHSave.Attributes;
using KHSave.LibPersona5.Types;
using System;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class PersonaEntryViewModel
    {
        public string Name => ToString();
        public Demon Value { get; }

        public string SimpleName { get; }
        public string Arcana { get; }


        public PersonaEntryViewModel(Demon demon)
        {
            Value = demon;
            SimpleName = InfoAttribute.GetInfo(demon);
            Arcana = DemonAttribute.GetArcana(demon);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Arcana))
                return SimpleName;
            return $"{Arcana} | {SimpleName}";
        }

        public static IEnumerable<PersonaEntryViewModel> GetAll()
        {
            var array = Enum.GetValues(typeof(Demon));
            foreach (var item in array)
                yield return new PersonaEntryViewModel((Demon)item);
        }
    }
}
