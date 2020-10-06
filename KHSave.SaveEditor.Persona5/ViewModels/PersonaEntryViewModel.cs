using KHSave.LibPersona5;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class PersonaEntryViewModel
    {
        public string Name => ToString();

        public Presets.Persona Properties { get; }
        public int Value { get; }

        public string SimpleName { get; }
        public string Arcana { get; }

        public PersonaEntryViewModel(Presets.Persona persona)
        {
            Properties = persona;
            Value = persona.Id;
            SimpleName = persona.Name;
            Arcana = persona.Arcana.ToString();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Arcana))
                return SimpleName;
            return $"{Arcana} | {SimpleName}";
        }
    }
}
