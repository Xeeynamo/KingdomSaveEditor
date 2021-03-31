using System.IO;

namespace KHSave.Archives.Factories
{
    internal class PcKh2Factory : IArchiveFactory
    {
        private const int EntryCount = 100;
        private const int Stride = 0x10FC0;
        private const int Size = 0x6BED08;

        public string Name => "PC KH2FM";

        public string Description => "Kingdom Hearts II Final Mix (PC)";

        public IArchive Create() => new PcSaveArchive(EntryCount, Stride);

        public IArchiveEntry CreateEntry() => new PcSaveArchive.Entry();

        public bool IsValid(Stream stream) => stream.Length == Size;

        public IArchive Read(Stream stream)
        {
            var archive = PcSaveArchive.Read(stream, EntryCount, Stride);
            archive.Name = Description;

            return archive;
        }
    }
}
