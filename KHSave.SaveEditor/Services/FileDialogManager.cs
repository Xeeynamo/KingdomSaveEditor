using System;
using System.IO;
using KHSave.SaveEditor.Interfaces;
using Xe.Tools.Wpf.Dialogs;

namespace KHSave.SaveEditor.Services
{
    public class FileDialogManager : IFileDialogManager
    {
        (string, string) Filter = ("Kingdom Hearts 2/ReCom//0.2/III (PS2/PS4) Save", "bin;*.sav;*.dat;*");
        private readonly IWindowManager _windowManager;

        public bool IsFileOpen { get; private set; }

        public string CurrentFileName { get; private set; }

        public FileDialogManager(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void Open(Action<Stream> onSuccess)
        {
            var fd = FileDialog.Factory(_windowManager.CurrentWindow, FileDialog.Behavior.Open, Filter);

            if (fd.ShowDialog() == true)
            {
                using (var stream = File.OpenRead(fd.FileName))
                {
                    IsFileOpen = true;
                    CurrentFileName = fd.FileName;
                    try { onSuccess(stream); }
                    catch
                    {
                        IsFileOpen = false;
                        throw;
                    }
                }
            }
        }

        public void Save(Action<Stream> onSuccess)
        {
            if (IsFileOpen)
            {
                using (var stream = File.Open(CurrentFileName, FileMode.Create))
                {
                    onSuccess(stream);
                }
            }
            else
            {
                SaveAs(onSuccess);
            }
        }

        public void SaveAs(Action<Stream> onSuccess)
        {
            var fd = FileDialog.Factory(_windowManager.CurrentWindow, FileDialog.Behavior.Save, Filter);
            fd.DefaultFileName = CurrentFileName;

            if (fd.ShowDialog() == true)
            {
                using (var stream = File.Create(fd.FileName))
                {
                    CurrentFileName = fd.FileName;
                    onSuccess(stream);
                }
            }
        }
    }
}
