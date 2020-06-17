using KHSave.Lib1;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Exceptions;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Kh1.Interfaces;
using System;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class Kh1ViewModel : BaseNotifyPropertyChanged,
        IRefreshUi,
        IOpenStream,
        IWriteToStream,
        IGetAbilities
    {
        public ISaveKh1 Save { get; private set; }

        public Kh1ViewModel()
        {
            Abilities = new KhEnumListModel<AbilityType>();
        }

        public SystemViewModel System { get; private set; }
        public InventoryViewModel Inventory { get; private set; }
        public PlayersViewModel Players { get; private set; }
        public KhEnumListModel<AbilityType> Abilities { get; }
        public GummiShipsViewModel GummiShips { get; private set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(Save, this);
            Inventory = new InventoryViewModel(Save);
            Players = new PlayersViewModel(Save, this);

            OnPropertyChanged(nameof(System));
            OnPropertyChanged(nameof(Inventory));
            OnPropertyChanged(nameof(Players));
        }

        public void OpenStream(Stream stream)
        {
            try
            {
                Save = SaveKh1.Read(stream);
            }
            catch (NotSupportedException ex)
            {
                throw new SaveNotSupportedException(ex.Message);
            }

            RefreshUi();
        }

        public void WriteToStream(Stream stream) => Save.Write(stream);
    }
}
