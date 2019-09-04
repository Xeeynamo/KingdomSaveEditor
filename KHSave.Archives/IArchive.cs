using System.Collections.Generic;
using System.IO;

namespace KHSave.Archives
{
    public interface IArchive
    {
        string Name { get; }

        int MaxEntryCount { get; }

        IList<IArchiveEntry> Entries { get; }

        void Write(Stream stream);
    }
}
