using KHSave.LibPersona5;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class InventoryViewModel
    {
        private ISavePersona5 save;

        public InventoryViewModel(ISavePersona5 save)
        {
            this.save = save;
        }
    }
}
