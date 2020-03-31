using KHSave.Archives;
using KHSave.SaveEditor.Common.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Dialogs;

namespace KHSave.SaveEditor.Common.ViewModels
{
    public class ArchiveManagerViewModel : BaseNotifyPropertyChanged
    {
        private static readonly List<FileDialogFilter> Filters = FileDialogFilterComposer.Compose().AddAllFiles("RAW save data");
        private ArchiveEntryViewModel _selectedValue;

        private Window Window { get; }
        private readonly string _archiveFileName;

        public ArchiveManagerViewModel(Window window, IArchive archive, string archiveFileName)
        {
            Window = window;
            Archive = archive;
            _archiveFileName = archiveFileName;
            Entries = new GenericListModel<ArchiveEntryViewModel, ArchiveEntryViewModel>(
                archive.Entries.Select(x => new ArchiveEntryViewModel(x)),
                Getter, Setter);

            OpenCommand = new RelayCommand(o =>
            {
                Window.DialogResult = true;
                Window.Close();
            }, o => IsSelected);

            ImportCommand = new RelayCommand(o =>
            {
                var selectedEntry = SelectedValue;
                if (selectedEntry == null)
                    return;

                FileDialog.OnOpen(fileName =>
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        var data = new byte[stream.Length];
                        stream.Read(data, 0, data.Length);
                        selectedEntry.ImportData(data);
                    }

                    using (var stream = File.Create(_archiveFileName))
                        archive.Write(stream);

                    ShowInfoMessageBox("Save imported with success!");
                }, Filters, parent: Window);
            }, o => IsSelected);

            ExportCommand = new RelayCommand(o =>
            {
                var selectedEntry = SelectedEntry;
                if (selectedEntry == null)
                    return;

                FileDialog.OnSave(fileName =>
                {
                    using (var stream = File.Create(fileName))
                    {
                        stream.Write(selectedEntry.Data, 0, selectedEntry.Data.Length);
                    }
                }, Filters, $"{SelectedEntry?.Name ?? "empty save"}.bin",  Window);
            }, o => !IsSelectedEmpty);

            CopyCommand = new RelayCommand(o =>
            {

            }, o => IsSelected);

            PasteCommand = new RelayCommand(o =>
            {

            }, o => IsSelected);

            DeleteCommand = new RelayCommand(o =>
            {
                Entries.SelectedValue?.Erase();
            }, o => !IsSelectedEmpty);
        }

        public string Title => $"{Archive.Name} | Archive manager";

        public RelayCommand OpenCommand { get; }
        public RelayCommand ImportCommand { get; }
        public RelayCommand ExportCommand { get; }
        public RelayCommand CopyCommand { get; }
        public RelayCommand PasteCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public IArchive Archive { get; }

        public GenericListModel<ArchiveEntryViewModel, ArchiveEntryViewModel> Entries { get; }

        public ArchiveEntryViewModel SelectedValue
        {
            get => _selectedValue;
            set
            {
                _selectedValue = value;
                OnPropertyChanged(nameof(OpenCommand));
                OnPropertyChanged(nameof(ImportCommand));
                OnPropertyChanged(nameof(ExportCommand));
                OnPropertyChanged(nameof(CopyCommand));
                OnPropertyChanged(nameof(PasteCommand));
                OnPropertyChanged(nameof(DeleteCommand));
            }
        }
        public IArchiveEntry SelectedEntry => SelectedValue?.ArchiveEntry;
        private bool IsSelected => SelectedValue != null;
        private bool IsSelectedEmpty => SelectedValue?.IsEmpty ?? true;

        private ArchiveEntryViewModel Getter() => SelectedValue;

        private void Setter(ArchiveEntryViewModel obj) => SelectedValue = obj;

        private void ShowInfoMessageBox(string message) =>
            MessageBox.Show(message, "Archive manager", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
