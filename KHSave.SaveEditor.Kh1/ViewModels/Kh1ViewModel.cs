using KHSave.Lib1;
using KHSave.SaveEditor.Common.Contracts;
using System;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class Kh1ViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        private SaveKh1.SaveFinalMix save;

        public Kh1ViewModel()
        {
        }

        public SystemViewModel System { get; private set; }
        public PlayersViewModel Players { get; private set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(save);
            Players = new PlayersViewModel(save);

            OnPropertyChanged(nameof(System));
            OnPropertyChanged(nameof(Players));
        }

        public void OpenStream(Stream stream)
        {
            save = SaveKh1.Read<SaveKh1.SaveFinalMix>(stream);

            RefreshUi();
        }

        public void WriteToStream(Stream stream) => SaveKh1.Write(stream, save);
    }
}
