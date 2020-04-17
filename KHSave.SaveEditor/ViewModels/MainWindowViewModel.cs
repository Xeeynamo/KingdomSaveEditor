/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

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
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;
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

namespace KHSave.SaveEditor.ViewModels
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private readonly IFileDialogManager fileDialogManager;
        private readonly IWindowManager windowManager;
        private readonly IAlertMessage alertMessage;
        private readonly IUpdater updater;
        private readonly ContentFactory contentFactory;
        private object dataContext;
        private ContentType _saveKind;

        private string OriginalTitle => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;

        private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

        public string Title => IsFileOpen ?
            $"{fileDialogManager.CurrentFileName} | {OriginalTitle}" : OriginalTitle;

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
        public RelayCommand SaveCommand { get; }
        public RelayCommand SaveAsCommand { get; }
        public RelayCommand ExitCommand { get; }
        public RelayCommand GetLatestVersionCommand { get; }
        public RelayCommand AboutCommand { get; }

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

        public MainWindowViewModel(
            IFileDialogManager fileDialogManager,
            IWindowManager windowManager,
            IAlertMessage alertMessage,
            IUpdater updater,
            ContentFactory contentFactory,
            HomeViewModel homeContext)
        {
            this.fileDialogManager = fileDialogManager;
            this.windowManager = windowManager;
            this.alertMessage = alertMessage;
            this.updater = updater;
            this.contentFactory = contentFactory;
            HomeContext = homeContext;
            OpenCommand = new RelayCommand(o => fileDialogManager.Open(Open));

            SaveCommand = new RelayCommand(o => fileDialogManager.Save(Save),
                x => IsFileOpen);

            SaveAsCommand = new RelayCommand(o => fileDialogManager.SaveAs(Save),
                x => IsFileOpen);

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

            AboutCommand = new RelayCommand(x =>
			{
				var contributors = string.Join("\n", (new string[]
				{
					"Keytotruth, additional coding and offsets",
					"Troopah, for providing the icons",
					"Sonicshadowsilver2, for story flags and records offsets",
                    "13th Vessel for the complete story flag list",
                    "TALESIOFIFREAK, for the ability list and DLC inventory",
                    "SilverCam , for the gummiship inventory items",
				}).Select(name => $" - {name}")
				.ToList());

                Assembly assembly = Assembly.GetExecutingAssembly();
                var assemblyName = assembly.GetName();
                var aboutDialog = new AboutDialog(assembly)
                {
                    Version = $"{assemblyName.Version.Major}.{assemblyName.Version.Minor}.{assemblyName.Version.Build}"
                };
                aboutDialog.Author += "\n\nContributors and special thanks:\n" + contributors + "\n - Every other contributor on GitHub repo\n";

				aboutDialog.ShowDialog();
			}, x => true);
        }

        public void TestOpen(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
                Open(stream);
        }

        public void Open(Stream stream)
		{
            try
            {
                if (!TryOpen(stream))
                    throw CreateUnsupportedSaveExceptiom();

                InvokeRefreshUi();
                OnPropertyChanged(nameof(Title));
            }
            catch (SaveNotSupportedException ex)
            {
                alertMessage.Error(ex);
            }
        }

        private void Save(Stream stream)
        {
            WriteToStream.WriteToStream(stream);
            OnPropertyChanged(nameof(Title));
        }

        public bool TryOpen(Stream stream) =>
            TryOpenKh2(stream) ||
            TryOpenKhRecom(stream) ||
            TryOpenKh02(stream) ||
            TryOpenKh3(stream) ||
            TryOpenFF7Remake(stream) ||
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

        public bool TryOpenKh2(Stream stream) => TryOpen(SaveKh2.IsValid,  stream, ContentType.KingdomHearts2);
        public bool TryOpenKhRecom(Stream stream) => TryOpen(SaveKhRecom.IsValid, stream, ContentType.KingdomHeartsRecom);
        public bool TryOpenKh02(Stream stream) => TryOpen(SaveKh02.IsValid, stream, ContentType.KingdomHearts02);
        public bool TryOpenKh3(Stream stream) => TryOpen(SaveKh3.IsValid, stream, ContentType.KingdomHearts3);
        public bool TryOpenFF7Remake(Stream stream) => TryOpen(SaveFf7Remake.IsValid, stream, ContentType.FinalFantasy7Remake);

        public bool TryOpen(Func<Stream, bool> prediate, Stream stream, ContentType contentType)
        {
            if (!prediate(stream))
                return false;

            _saveKind = contentType;
            ChangeContent(contentType, stream);
            return true;
        }

        private static Exception CreateUnsupportedSaveExceptiom() =>
            new SaveNotSupportedException("The specified save game is not recognized.\nBe sure to have the last version or that the save is decrypted or supported.");

        public void InvokeRefreshUi() => RefreshUi?.RefreshUi();

        private void ChangeContent(ContentType contentType, Stream stream = null)
        {
            var contentResponse = contentFactory.Factory(contentType);

            RefreshUi = contentResponse.RefreshUi;
            WriteToStream = contentResponse.WriteToStream;

            if (stream != null)
                contentResponse.OpenStream.OpenStream(stream);

            OnPropertyChanged(nameof(SaveCommand));
            OnPropertyChanged(nameof(SaveAsCommand));
            OnControlChanged?.Invoke(contentResponse.Control);
        }
    }
}
