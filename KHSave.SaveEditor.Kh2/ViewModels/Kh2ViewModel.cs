using KHSave.Lib2;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Exceptions;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class Kh2ViewModel : IRefreshUi, IWriteToStream
    {
        private readonly SaveKh2.SaveFinalMix save;

        public Kh2ViewModel(Stream stream)
        {
            switch (SaveKh2.GetGameVersion(stream))
            {
                case GameVersion.Japanese:
                    throw new SaveNotSupportedException("Japanese save file is not yet supported.");
                case GameVersion.American:
                    throw new SaveNotSupportedException("American or European save file is not yet supported.");
                case GameVersion.FinalMix:
                    save = BinaryMapping.ReadObject<SaveKh2.SaveFinalMix>(stream);
                    break;
                case null:
                    throw new SaveNotSupportedException("An invalid version has been specified.");
                default:
                    throw new SaveNotSupportedException("The version has been recognized but it is not supported.");
            }
        }

        public void RefreshUi()
        {
        }

        public void WriteToStream(Stream stream)
        {
            BinaryMapping.WriteObject(stream, save);
        }
    }
}
