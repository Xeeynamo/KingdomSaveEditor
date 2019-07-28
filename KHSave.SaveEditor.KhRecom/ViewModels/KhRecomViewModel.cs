using KHSave.LibRecom;
using KHSave.SaveEditor.Common.Contracts;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class KhRecomViewModel : BaseNotifyPropertyChanged, IRefreshUi, IWriteToStream
    {
        public SaveKhRecom Save { get; }

        public CardInventoryViewModel Inventory { get; private set; }

        public KhRecomViewModel(Stream stream)
        {
            Save = SaveKhRecom.Read(stream);
            RefreshUi();
        }

        public void RefreshUi()
        {
            Inventory = new CardInventoryViewModel();

            OnPropertyChanged(nameof(CardInventoryViewModel));
        }

        public void WriteToStream(Stream stream) => Save.Write(stream);
    }
}
