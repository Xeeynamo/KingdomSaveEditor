using KHSave.LibDDD;
using KHSave.LibDDD.Model;
using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.KhDDD.Interfaces;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class KhDDDViewModel : BaseNotifyPropertyChanged,
        IRefreshUi, IOpenStream, IWriteToStream, IResourceGetter
    {
        private ISaveKhDDD save;

        public KhEnumListModel<EnumIconTypeModel<EquipmentType>, EquipmentType> Equipments { get; private set; }

        public SystemViewModel System { get; set; }
        public CharacterViewModel Character { get; set; }
        public CommandsViewModel Commands { get; set; }
        public DreamEatersViewModel DreamEaters { get; set; }
        public DecksViewModel SoraDecks { get; set; }
        public DecksViewModel RikuDecks { get; set; }

        public void RefreshUi()
        {
            Equipments = new KhEnumListModel<EnumIconTypeModel<EquipmentType>, EquipmentType>();

            System = new SystemViewModel(save);
            Character = new CharacterViewModel(save, this);
            Commands = new CommandsViewModel(save.CommandInventory, this);
            DreamEaters = new DreamEatersViewModel(save.DreamEaters);
            SoraDecks = new DecksViewModel(save.SoraDecks);
            RikuDecks = new DecksViewModel(save.RikuDecks);

            OnPropertyChanged(nameof(System));
            OnPropertyChanged(nameof(Character));
            OnPropertyChanged(nameof(Commands));
            OnPropertyChanged(nameof(DreamEater));
            OnPropertyChanged(nameof(Deck));
        }

        public void OpenStream(Stream stream)
        {

            save = SaveKhDDD.Read<SaveKhDDD.SaveKhDDD3DS>(stream);

            RefreshUi();
        }

        public void WriteToStream(Stream stream) => SaveKhDDD.Write(stream, save);
    }
}
