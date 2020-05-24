using KHSave.Lib1;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Exceptions;
using System;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class Kh1ViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        public ISaveKh1 Save { get; private set; }

        public Kh1ViewModel()
        {
        }

        public SystemViewModel System { get; private set; }
        public InventoryViewModel Inventory { get; private set; }
        public PlayersViewModel Players { get; private set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(Save);
            Inventory = new InventoryViewModel(Save);
            Players = new PlayersViewModel(Save);

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
