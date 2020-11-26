using System.IO;
using KHSave.Archives;
using KHSave.SaveEditor.Common.Contracts;

namespace KHSave.SaveEditor.Common.Services
{
    public class ArchiveWriteToStream : IWriteToStream
    {
        private readonly IWriteToStream realWriteToStream;

        public ArchiveWriteToStream(IWriteToStream realWriteToStream, IArchive archive, IArchiveEntry entry)
        {
            this.realWriteToStream = realWriteToStream;
            Archive = archive;
            Entry = entry;
        }

        public IArchive Archive { get; }
        public IArchiveEntry Entry { get; }

        public void WriteToStream(Stream stream)
        {
            using (var entryStream = new MemoryStream())
            {
                realWriteToStream.WriteToStream(entryStream);
                Entry.Data = entryStream.GetBuffer();
            }

            bool found = false;
            for (var i = 0; i < Archive.Entries.Count; i++)
            {
                var entry = Archive.Entries[i];
                if (entry.Name == Entry.Name)
                {
                    Archive.Entries[i] = Entry;
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                Archive.Entries.Add(Entry);
            }

            Archive.Write(stream);
        }
    }
}
