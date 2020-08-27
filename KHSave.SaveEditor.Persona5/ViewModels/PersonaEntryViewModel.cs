namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class PersonaEntryViewModel
    {
        public string Name => ToString();
        public int Value { get; }

        public string SimpleName { get; }
        public string Arcana { get; }

        public PersonaEntryViewModel(int id, string name, string arcana)
        {
            Value = id;
            SimpleName = name;
            Arcana = arcana;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Arcana))
                return SimpleName;
            return $"{Arcana} | {SimpleName}";
        }
    }
}
