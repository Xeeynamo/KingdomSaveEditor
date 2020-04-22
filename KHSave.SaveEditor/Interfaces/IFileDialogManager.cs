using System;
using System.IO;

namespace KHSave.SaveEditor.Interfaces
{
    public interface IFileDialogManager
    {
        bool IsFileOpen { get; }
        string CurrentFileName { get; }

        void InjectFileName(string fileName, Action<Stream> onSuccess);
        void Open(Action<Stream> onSuccess);
        void Save(Action<Stream> onSuccess);
        void SaveAs(Action<Stream> onSuccess);
    }
}
