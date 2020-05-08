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
        public PlayersViewModel Players { get; private set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(Save);
            Players = new PlayersViewModel(Save);

            OnPropertyChanged(nameof(System));
            OnPropertyChanged(nameof(Players));
        }

        public void OpenStream(Stream stream)
        {
            switch(SaveKh1.GetGameVersion(stream))
            {
                case Constants.MagicCodeFm:
                    Save = SaveKh1.Read<SaveKh1.SaveFinalMix>(stream);
                    break;
                case Constants.MagicCodeEverythingElse:
                    Save = SaveKh1.Read<SaveKh1.SaveEU>(stream);
                    break;
                default:
                    throw new SaveNotSupportedException("The version is not supported.");
            }
            RefreshUi();
        }

        public void WriteToStream(Stream stream) => Save.Write(stream);
    }
}
