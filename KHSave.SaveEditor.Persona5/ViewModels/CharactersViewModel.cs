using KHSave.LibPersona5;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class CharactersViewModel
    {
        private ISavePersona5 save;

        public CharactersViewModel(ISavePersona5 save)
        {
            this.save = save;
        }
    }
}
