using KHSave.Archives;
using KHSave.SaveEditor.Common.Models;
using System;
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
        private ArchiveEntryViewModel _selectedValue;

        private Window Window => Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);

        public ArchiveManagerViewModel(IArchive archive)
        {
            Archive = archive;
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

                var fileDialog = FileDialog.Factory(
                    Window,
                    FileDialog.Behavior.Open,
                    ("RAW save data", "bin"));
                fileDialog.DefaultFileName = $"{selectedEntry.Name}.bin";

                if (fileDialog.ShowDialog() == true)
                {
                    using (var stream = File.OpenRead(fileDialog.FileName))
                    {
                        var data = new byte[stream.Length];
                        stream.Read(data, 0, data.Length);
                        selectedEntry.ImportData(data);
                    }

                    ShowInfoMessageBox("Save imported with success!");
                }
            }, o => IsSelected);

            ExportCommand = new RelayCommand(o =>
            {
                var selectedEntry = SelectedEntry;
                if (selectedEntry == null)
                    return;

                var fileDialog = FileDialog.Factory(
                    Window,
                    FileDialog.Behavior.Save,
                    ("RAW save data", "bin"));
                fileDialog.DefaultFileName = $"{SelectedEntry?.Name ?? "empty save"}.bin";

                if (fileDialog.ShowDialog() == true)
                {
                    using (var stream = File.Create(fileDialog.FileName))
                    {
                        stream.Write(selectedEntry.Data, 0, selectedEntry.Data.Length);
                    }
                }
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
