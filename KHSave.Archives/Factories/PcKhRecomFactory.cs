using System.IO;

namespace KHSave.Archives.Factories
{
    internal class PcKhRecomFactory : IArchiveFactory
    {
        private const int EntryCount = 100;
        private const int Stride = 0x3a30;
        private const int Size = 0x188F5F;

        public string Name => "PC RECOM";

        public string Description => "Kingdom Hearts Re: Chain of Memories (PC)";

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
