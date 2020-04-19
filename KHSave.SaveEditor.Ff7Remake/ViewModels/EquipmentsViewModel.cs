using KHSave.LibFf7Remake;
using KHSave.SaveEditor.Ff7Remake.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class EquipmentsViewModel : GenericListModel<EquipmentEntryModel>
    {
        private readonly SaveFf7Remake _save;

        public EquipmentsViewModel(SaveFf7Remake save, MateriaViewModel materiaVm) :
            this(save.Equipments.Select((x, i) => new EquipmentEntryModel(save, x, materiaVm)))
        {
            _save = save;
        }

        private EquipmentsViewModel(IEnumerable<EquipmentEntryModel> list) :
            base(list)
        { }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(EquipmentEntryModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }

        protected override EquipmentEntryModel OnNewItem() =>
            throw new System.NotImplementedException();
    }
}
