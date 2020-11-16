using KHSave.LibDDD;
using KHSave.LibDDD.Model;
using KHSave.SaveEditor.Common.Contracts;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class KhDDDViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        private ISaveKhDDD save;

        public SystemViewModel System { get; set; }
        public CharacterViewModel Character { get; set; }
        public DreamEatersViewModel DreamEaters { get; set; }
        public DecksViewModel SoraDecks { get; set; }
        public DecksViewModel RikuDecks { get; set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(save);
            Character = new CharacterViewModel(save.SoraKeyblade, save.RikuKeyblade, save.SoraLv, save.RikuLv, save.SoraXp, save.RikuXp);
            DreamEaters = new DreamEatersViewModel(save.DreamEaters);
            SoraDecks = new DecksViewModel(save.SoraDecks);
            RikuDecks = new DecksViewModel(save.RikuDecks);

            OnPropertyChanged(nameof(System));
            OnPropertyChanged(nameof(Character));
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
