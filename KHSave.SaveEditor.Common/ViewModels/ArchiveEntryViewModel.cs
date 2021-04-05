using KHSave.Archives;
using KHSave.SaveEditor.Common.Models;
using System;

namespace KHSave.SaveEditor.Common.ViewModels
{
    public class ArchiveEntryViewModel : GenericEntryModel<string, ArchiveEntryViewModel>
    {
        public ArchiveEntryViewModel(IArchiveEntry archiveEntry)
        {
            ArchiveEntry = archiveEntry;
        }

        public IArchiveEntry ArchiveEntry { get; }

        public string FileName
        {
            get => IsEmpty ? "<empty>" : ArchiveEntry.Name;
            set => ArchiveEntry.Name = value;
        }

        public string DisplayDate =>
            IsEmpty ? string.Empty : ArchiveEntry.DateModified.ToString();

        public bool IsEmpty => string.IsNullOrEmpty(ArchiveEntry.Name);

        public void ImportData(byte[] data)
        {
            if (IsEmpty)
            {
                ArchiveEntry.Name = "New save";
                ArchiveEntry.DateCreated = DateTime.Now;
                ArchiveEntry.DateModified = DateTime.Now;
            }
            ArchiveEntry.Data = data;

            OnPropertyChanged(nameof(Name));
        }

        public void Rename(string newname)
        {
            ArchiveEntry.Name = newname;

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(FileName));
        }

        public void Erase()
        {
            ArchiveEntry.Name = string.Empty;
            ArchiveEntry.DateCreated = DateTime.MinValue;
            ArchiveEntry.DateModified = DateTime.MinValue;
            ArchiveEntry.Data = new byte[0];

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(FileName));
        }

        public override string ToString() => Name;
    }
}
