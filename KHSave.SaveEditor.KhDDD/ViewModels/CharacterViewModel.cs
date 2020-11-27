using KHSave.LibDDD;
using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.KhDDD.Interfaces;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class CharacterViewModel : BaseNotifyPropertyChanged
    {
        public CharacterViewModel(ISaveKhDDD save, IResourceGetter resourceGetter)
        {
            _save = save;
            SoraKeyblade = new ItemComboBoxModel<EquipmentType>(
                () => save.SoraKeyblade, x => save.SoraKeyblade = x);
            RikuKeyblade = new ItemComboBoxModel<EquipmentType>(
                () => save.RikuKeyblade, x => save.RikuKeyblade = x);
        }

        private readonly ISaveKhDDD _save;

        public ItemComboBoxModel<EquipmentType> SoraKeyblade { get; set; }
        public ItemComboBoxModel<EquipmentType> RikuKeyblade { get; set; }
        public byte SoraLv { get => _save.SoraLv; set => _save.SoraLv = value; }
        public byte RikuLv { get => _save.RikuLv; set => _save.RikuLv = value; }
        public uint SoraXp { get => _save.SoraXp; set => _save.SoraXp = value; }
        public uint RikuXp { get => _save.RikuXp; set => _save.RikuXp = value; }
    }
}
