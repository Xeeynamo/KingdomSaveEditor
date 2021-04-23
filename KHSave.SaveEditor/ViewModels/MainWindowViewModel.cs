/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.Trssv;
using KHSave.Lib2;
using KHSave.LibRecom;
using KHSave.SaveEditor.Common.Exceptions;
using KHSave.Archives;
using KHSave.SaveEditor.Common.Views;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Interfaces;
using System;
using KHSave.SaveEditor.Services;
using System.Windows.Controls;
using KHSave.Lib3;
using KHSave.LibFf7Remake;
using KHSave.Lib1;
using KHSave.LibBbs;
using KHSave.LibDDD;
using KHSave.SaveEditor.Views;
using KHSave.LibPersona5;

namespace KHSave.SaveEditor.ViewModels
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private readonly IFileDialogManager fileDialogManager;
        private readonly IWindowManager windowManager;
        private readonly IAlertMessage alertMessage;
        private readonly IUpdater updater;
        private readonly IAppIdentity _appIdentity;
        private readonly ContentFactory contentFactory;
        private readonly ReporterService reporterService;
        private object dataContext;
        private ContentType _saveKind;

        private bool _isProcess;
        private string _processTitleName;
        private ProcessStream _processStream;

        private string OriginalTitle => "Kingdom Save Editor";
        public string CurrentVersion { get; } = new DesktopAppIdentity().Version;

        private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

        public string Title
        {
            get
            {
                if (_isProcess)
                    return $"[P] {_processTitleName} | {OriginalTitle}";

                return IsFileOpen ? $"{fileDialogManager.CurrentFileName} | {OriginalTitle}" : OriginalTitle;
            }
        }

        public Visibility UpdateVisibility => _appIdentity.IsMicrosoftStore ?
            Visibility.Collapsed : Visibility.Visible;

        public bool IsFileOpen => SaveKind != ContentType.Unload && fileDialogManager.IsFileOpen;

        public ContentType SaveKind
        {
            get => _saveKind;
            set
            {
                _saveKind = value;
                ChangeContent(_saveKind);
            }
        }

        public HomeViewModel HomeContext { get; }
        public RelayCommand OpenCommand { get; }
        public RelayCommand OpenPcsx2Command { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand SaveAsCommand { get; }
        public RelayCommand ImportCommand { get; }
        public RelayCommand ExitCommand { get; }
        public RelayCommand GetLatestVersionCommand { get; }
        public RelayCommand OpenLinkCommand { get; }

        public object DataContext
        {
            get => dataContext;
            set
            {
                dataContext = value;
                OnPropertyChanged();
            }
        }

        public Action<UserControl> OnControlChanged { get; set; }
        public IRefreshUi RefreshUi { get; set; }
        public IOpenStream OpenStream { get; set; }
        public IWriteToStream WriteToStream { get; set; }
        public IGetSave GetSave { get; private set; }

        public bool IsAdvancedMode
        {
            get => Global.IsAdvancedMode;
            set
            {
                Global.IsAdvancedMode = value;
                InvokeRefreshUi();
            }
        }

        public bool IsUpdateCheckingEnabled
        {
            get => updater.IsAutomaticUpdatesEnabled;
            set
            {
                updater.IsAutomaticUpdatesEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsAnonymousReporting
        {
            get => Global.AnonymousReporting;
            set
            {
                if (value == true)
                    reporterService.DeleteCookies();
                Global.AnonymousReporting = value;
            }
        }

        public MainWindowViewModel(
            IFileDialogManager fileDialogManager,
            IWindowManager windowManager,
            IAlertMessage alertMessage,
            IUpdater updater,
            IAppIdentity appIdentity,
            ContentFactory contentFactory,
            HomeViewModel homeContext)
        {
            this.fileDialogManager = fileDialogManager;
            this.windowManager = windowManager;
            this.alertMessage = alertMessage;
            this.updater = updater;
            _appIdentity = appIdentity;
            this.contentFactory = contentFactory;
            this.reporterService = ReporterService.Instance;
            HomeContext = homeContext;

            OpenCommand = new RelayCommand(o => fileDialogManager.Open(stream => Open(stream)));
            OpenPcsx2Command = new RelayCommand(o => OpenPcsx2(stream => Open(stream)));
            SaveCommand = new RelayCommand(o =>
            {
                CatchException(() =>
                {
                    if (_isProcess)
                        Save(_processStream);
                    else
                    {
                        // Create in-memory back-up to recover disastrous savings
                        var backupStream = new MemoryStream();
                        if (File.Exists(fileDialogManager.CurrentFileName))
                        {
                            using (var originalStream = File.OpenRead(fileDialogManager.CurrentFileName))
                                originalStream.CopyTo(backupStream);
                        }

                        try
                        {
                            fileDialogManager.Save(Save);
                        }
                        catch
                        {
                            // Restore back-up before throwing an error
                            fileDialogManager.Save(stream => backupStream.SetPosition(0).CopyTo(stream));
                            throw;
                        }
                    }
                });
            },
                x => IsFileOpen || _isProcess);
            SaveAsCommand = new RelayCommand(o => CatchException(() => fileDialogManager.SaveAs(Save)),
                x => IsFileOpen || _isProcess);
            ImportCommand = new RelayCommand(o => CatchException(() =>
            {
                MessageBox.Show(
                    "This functionality allows you to import a Kingdom Hearts II save of a region over another region.\n\n" +
                    "Note that this will not import the whole save but only the known values, therefore some content of " +
                    "your old save will still be present (eg. Gummiship, Journal, Minigames).");

                new FileDialogManager(windowManager)
                    .Open(stream =>
                    {
                        if (GetSave == null)
                            throw new Exception("The game you decided to operate with is not within the supported game list that supports import transfer.");

                        switch (TransferService.Transfer(GetSave.GetSave(), stream))
                        {
                            case TransferService.Result.Success:
                                RefreshUi.RefreshUi();
                                break;
                            case TransferService.Result.GameNotSupported:
                                throw new Exception("The game you decided to operate with is NOT within the supported game list that supports import transfer.");
                            case TransferService.Result.SourceNotCompatible:
                                throw new Exception("The game you selected is different than the save you have currently opened, therefore it is not possible to import it.");
                            case TransferService.Result.InternalError:
                                throw new Exception("Oh well, this was not supposed to happen... you might want to report this. Sorry 😅");
                        }
                    });
            }), x => (IsFileOpen || _isProcess) && IsTransferSupported());
            ExitCommand = new RelayCommand(x => Window.Close());

            GetLatestVersionCommand = new RelayCommand(x =>
            {
                Task.Run(async () =>
                {
                    var found = await updater.ForceCheckLastVersionAsync();
                    if (found == false)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                            alertMessage.Info("You are up to date :)", "Check update"));
                    }
                });
            });

            OpenLinkCommand = new RelayCommand(url => Process.Start(new ProcessStartInfo()
            {
                FileName = url as string,
                UseShellExecute = true
            }));
        }

        private bool IsTransferSupported()
        {
            switch (SaveKind)
            {
                case ContentType.KingdomHearts2:
                    return true;
                default:
                    return false;
            }
        }

        private void Buffered(Stream stream, Action<Stream> call) => Buffered(stream, bufferedStream =>
        {
            call(bufferedStream);
            return true;
        });

        private T Buffered<T>(Stream stream, Func<Stream, T> call)
        {
            const int DefaultBufferLength = 1024 * 1024;
            var bufferLength = DefaultBufferLength;
            if (stream.Length > 0 && stream.Length < DefaultBufferLength)
                bufferLength = (int)stream.Length;

            var bufferedStream = stream is BufferedStream ? (BufferedStream)stream :
                new BufferedStream(stream, bufferLength);

            var result = call(bufferedStream);
            if (bufferedStream.CanWrite)
                bufferedStream.Flush();

            return result;
        }

        public void Open(string fileName) => CatchException(() =>
        {
            fileDialogManager.InjectFileName(fileName, stream => Open(stream));
        });

        public void OpenPcsx2(Func<Stream, bool> openStream) => CatchException(() =>
        {
            var process = new AttachToProcessWindow("pcsx2").WaitForProcess();
            if (process != null)
            {
                var stream = new AttachToPcsx2GameWindow().WaitForGame(process);
                if (stream != null)
                    OpenProcessStream(stream, openStream);
            }
        });

        public bool Open(Stream stream) => CatchException(() =>
        {
            CloseProcessStream();

            try
            {
                if (!Buffered(stream, TryOpen))
                    throw CreateUnsupportedSaveExceptiom();

                InvokeRefreshUi();
                OnPropertyChanged(nameof(Title));
                return true;
            }
            catch (SaveNotSupportedException ex)
            {
                alertMessage.Error(ex);
            }

            return false;
        });

        private void Save(Stream stream)
        {
            Buffered(stream, WriteToStream.WriteToStream);
            OnPropertyChanged(nameof(Title));
        }

        public bool TryOpen(Stream stream) =>
            TryOpenKh1(stream) ||
            TryOpenKh2(stream) ||
            TryOpenKhBbs(stream) ||
            TryOpenKhDDD(stream) ||
            TryOpenKhRecom(stream) ||
            TryOpenKh02(stream) ||
            TryOpenKh3(stream) ||
            TryOpenFF7Remake(stream) ||
            TryOpenPersona5(stream) ||
            TryOpenArchive(stream);

        private bool Open(IArchiveFactory archiveFactory, Stream stream)
        {
            var archive = archiveFactory.Read(stream);
            stream.Close();
            return Open(archive);
        }

        private bool Open(IArchive archive)
        {
            var result = windowManager.Push<ArchiveManagerView>(
                onSetup: window => window.SetArchive(archive, fileDialogManager.CurrentFileName),
                onSuccess: window => Open(archive, window.SelectedEntry));

            if (result == false)
            {
                ChangeContent(ContentType.Unload);
            }

            return true;
        }

        private bool Open(IArchive archive, IArchiveEntry archiveEntry)
        {
            bool result;

            using (var stream = new MemoryStream(archiveEntry.Data))
                result = TryOpen(stream);

            if (!result)
                throw CreateUnsupportedSaveExceptiom();

            // archiveEntry.Name
            // archiveEntry.DateCreated
            // archiveEntry.DateModified

            WriteToStream = new ArchiveWriteToStream(WriteToStream, archive, archiveEntry);

            return result;
        }

        public bool TryOpenArchive(Stream stream)
        {
            if (!ArchiveFactories.TryGetFactory(stream, out var archiveFactory))
                return false;

            stream.Position = 0;
            return Open(archiveFactory, stream);
        }

        public bool TryOpenKh1(Stream stream) => TryOpen(SaveKh1.IsValid, stream, ContentType.KingdomHearts);
        public bool TryOpenKh2(Stream stream) => TryOpen(SaveKh2.IsValid, stream, ContentType.KingdomHearts2);
        public bool TryOpenKhBbs(Stream stream) => TryOpen(SaveKhBbs.IsValid, stream, ContentType.KingdomHeartsBbs);
        public bool TryOpenKhDDD(Stream stream) => TryOpen(SaveKhDDD.IsValid, stream, ContentType.KingdomHeartsDDD);
        public bool TryOpenKhRecom(Stream stream) => TryOpen(SaveKhRecom.IsValid, stream, ContentType.KingdomHeartsRecom);
        public bool TryOpenKh02(Stream stream) => TryOpen(SaveKh02.IsValid, stream, ContentType.KingdomHearts02);
        public bool TryOpenKh3(Stream stream) => TryOpen(SaveKh3.IsValid, stream, ContentType.KingdomHearts3);
        public bool TryOpenFF7Remake(Stream stream) => TryOpen(SaveFf7Remake.IsValid, stream, ContentType.FinalFantasy7Remake);
        public bool TryOpenPersona5(Stream stream) => TryOpen(SavePersona5.IsValid, stream, ContentType.Persona5);

        public bool TryOpen(Func<Stream, bool> prediate, Stream stream, ContentType contentType)
        {
            if (!prediate(stream))
                return false;

            _saveKind = contentType;
            ChangeContent(contentType, stream);
            return true;
        }

        private void OpenProcessStream(ProcessStream processStream, Func<Stream, bool> openStream)
        {
            if (openStream(processStream))
            {
                _isProcess = true;
                _processStream = processStream;
                _processTitleName = $"PCSX2@{processStream.BaseAddress:X08}";

                OnPropertyChanged(nameof(Title));
            }
        }

        private void CloseProcessStream()
        {
            if (!_isProcess)
                return;

            _isProcess = false;
            _processTitleName = string.Empty;
            _processStream?.Dispose();
            _processStream = null;

            OnPropertyChanged(nameof(Title));
        }

        public static void CatchException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static T CatchException<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return default(T);
            }
        }

        private static Exception CreateUnsupportedSaveExceptiom() =>
            new SaveNotSupportedException("The specified save game is not recognized.\nBe sure to have the last version or that the save is decrypted or supported.");

        public void InvokeRefreshUi() => RefreshUi?.RefreshUi();

        private void ChangeContent(ContentType contentType, Stream stream = null)
        {
            try
            {
                reporterService.SendGameName(contentType.ToString());
                contentFactory.LoadIconPack(contentType);
                var contentResponse = contentFactory.Factory(contentType);

                RefreshUi = contentResponse.RefreshUi;
                WriteToStream = contentResponse.WriteToStream;
                GetSave = contentResponse.GetSave;

                if (stream != null)
                    contentResponse.OpenStream.OpenStream(stream);

                OnPropertyChanged(nameof(SaveCommand));
                OnPropertyChanged(nameof(SaveAsCommand));
                OnPropertyChanged(nameof(ImportCommand));
                OnControlChanged?.Invoke(contentResponse.Control);
            }
            catch (Exception ex)
            {
                ReporterService.Instance.SendCrashReport(ex);
                MessageBox.Show(
                    $"An unhandled error has occurred:\n{ex.Message}\n\n{ex.StackTrace}",
                    "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
