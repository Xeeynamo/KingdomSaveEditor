using System.IO;

namespace KHSave.Archives.Factories
{
    internal class PcKh1Factory : IArchiveFactory
    {
        private const int EntryCount = 200;
        private const int Stride = 0x16C40;
        private const int Size = 0x11EB09D;

        public string Name => "PC KH1FM";

        public string Description => "Kingdom Hearts Final Mix (PC)";

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
