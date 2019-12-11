using System;
using System.Collections.Generic;
using System.IO;
using KHSave.SaveEditor.Interfaces;
using Xe.Tools.Wpf.Dialogs;

namespace KHSave.SaveEditor.Services
{
    public class FileDialogManager : IFileDialogManager
    {
        private readonly IEnumerable<FileDialogFilter> Filters = FileDialogFilterComposer
            .Compose()
            .AddExtensions("All supported games", "bin;*.sav;*.dat;*")
            .AddExtensions("Kingdom Hearts II: Final Mix (raw)", ";BISLPM*")
            .AddExtensions("Kingdom Hearts II (PS4)", "DAT")
            .AddExtensions("Kingdom Hearts Re: CoM (raw)", ";BISLPM*;BASLUS*")
            .AddExtensions("Kingdom Hearts Re: CoM (PS4)", "DAT")
            .AddExtensions("Kingdom Hearts 0.2", ";ue4savegame*.sav")
            .AddExtensions("Kingdom Hearts III", ";__data__slot*.bin")
            ;

        private readonly IWindowManager _windowManager;

        public bool IsFileOpen { get; private set; }

        public string CurrentFileName { get; private set; }

        public FileDialogManager(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void Open(Action<Stream> onSuccess) => FileDialog.OnOpen(fileName =>
            {
                using (var stream = File.OpenRead(fileName))
                {
                    IsFileOpen = true;
                    CurrentFileName = fileName;
                    try { onSuccess(stream); }
                    catch
                    {
                        IsFileOpen = false;
                        throw;
                    }
                }
            }, Filters, parent: _windowManager.CurrentWindow);

        public void Save(Action<Stream> onSuccess)
        {
            if (IsFileOpen)
            {
                using (var stream = File.Create(CurrentFileName))
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
            FileDialog.OnSave(fileName =>
            {
                using (var stream = File.Create(fileName))
                {
                    CurrentFileName = fileName;
                    onSuccess(stream);
                }
            }, Filters, defaultFileName: CurrentFileName, parent: _windowManager.CurrentWindow);
        }
    }
}
