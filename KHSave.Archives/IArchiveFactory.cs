using System.IO;

namespace KHSave.Archives
{
    public interface IArchiveFactory
    {
        string Name { get; }

        string Description { get; }

        IArchive Create();

        IArchive Read(Stream stream);

        bool IsValid(Stream stream);

        IArchiveEntry CreateEntry();
    }
}
