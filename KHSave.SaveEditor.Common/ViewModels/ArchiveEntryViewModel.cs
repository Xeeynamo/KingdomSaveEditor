using KHSave.Archives;
using KHSave.SaveEditor.Common.Models;
using Xe.Tools;

namespace KHSave.SaveEditor.Common.ViewModels
{
    public class ArchiveEntryViewModel : GenericEntryModel<string, ArchiveEntryViewModel>
    {
        public ArchiveEntryViewModel(IArchiveEntry archiveEntry)
        {
            ArchiveEntry = archiveEntry;
        }

        public IArchiveEntry ArchiveEntry { get; }

        public string Name
        {
            get => ArchiveEntry.Name;
            set => ArchiveEntry.Name = value;
        }

        public override string ToString() => Name;
    }
}
