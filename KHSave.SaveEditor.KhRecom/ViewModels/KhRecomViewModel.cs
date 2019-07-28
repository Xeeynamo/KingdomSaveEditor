using KHSave.LibRecom;
using KHSave.SaveEditor.Common.Contracts;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class KhRecomViewModel : BaseNotifyPropertyChanged, IRefreshUi, IWriteToStream
    {
        private readonly SaveKhRecom _save;
        private DataRecom SaveData => _save.Data;

        public SystemViewModel KhSystem { get; private set; }
        public CardInventoryViewModel Inventory { get; private set; }

        public KhRecomViewModel(Stream stream)
        {
            _save = SaveKhRecom.Read(stream);
            RefreshUi();
        }

        public void RefreshUi()
        {
            KhSystem = new SystemViewModel(_save.Data);
            Inventory = new CardInventoryViewModel();

            OnPropertyChanged(nameof(SystemViewModel));
            OnPropertyChanged(nameof(CardInventoryViewModel));
        }

        public void WriteToStream(Stream stream) => _save.Write(stream);
    }
}
