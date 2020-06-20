using KHSave.LibDDD;
using KHSave.LibDDD.Model;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Exceptions;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class KhDDDViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        private ISaveKhDDD save;

        public SystemViewModel System { get; set; }
        //public CharacterViewModel Character { get; set; }
        public DreamEaterViewModel DreamEater { get; set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(save);
            //Character = new CharacterViewModel(save.Character);
            DreamEater = new DreamEaterViewModel(save.DreamEaters);

            OnPropertyChanged(nameof(System));
            //OnPropertyChanged(nameof(Character));
            OnPropertyChanged(nameof(DreamEater));
        }

        public void OpenStream(Stream stream)
        {
            
            save = SaveKhDDD.Read<SaveKhDDD.SaveKhDDD3DS>(stream);
            
            RefreshUi();
        }

        public void WriteToStream(Stream stream) => SaveKhDDD.Write(stream, save);
    }
}
