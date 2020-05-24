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
            .AddExtensions("All supported games", "bin", "sav", "dat;*")
            .AddPatterns("Kingdom Hearts I", ";BESCES*", ";BASLUS-20370*", ";BISLPM-66233-*")
            .AddPatterns("Kingdom Hearts II", ";BISLPM-66675FM-**")
            .AddExtensions("Kingdom Hearts Birth By Sleep", "DAT")
            .AddPatterns("Kingdom Hearts Re: CoM", ";BISLUS-21799COM-*", ";BASLUS-21799COM-*")
            .AddExtensions("Kingdom Hearts 1.5/2.5 ReMIX", "DAT")
            .AddPatterns("Kingdom Hearts 0.2", ";ue4savegame*.sav")
            .AddPatterns("Kingdom Hearts III", ";__data__slot*.bin")
            .AddPatterns("Final Fantasy VII REMAKE", ";ff7remake*")
            ;

        private readonly IWindowManager _windowManager;

        public bool IsFileOpen { get; private set; }

        public string CurrentFileName { get; private set; }

        public FileDialogManager(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void InjectFileName(string fileName, Action<Stream> onSuccess)
        {
            IsFileOpen = true;
            CurrentFileName = fileName;
            using (var stream = File.OpenRead(fileName))
            {
                try { onSuccess(stream); }
                catch
                {
                    IsFileOpen = false;
                    throw;
                }
            }
        }

        public void Open(Action<Stream> onSuccess) =>
            FileDialog.OnOpen(fileName => InjectFileName(fileName, onSuccess), Filters);

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
            }, Filters, defaultFileName: CurrentFileName);
        }
    }
}
