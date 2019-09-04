using System.IO;

namespace KHSave.Archives.Factories
{
    internal class Ps4Kh1Factory : IArchiveFactory
    {
        private const int EntryCount = 200;
        private const int Stride = 0x16C40;
        private const int Size = 0x11cd800;

        public string Name => "PS4 KH1";

        public string Description => "Kingdom Hearts Final Mix (PS4)";

        public IArchive Create() =>
            new Ps4SaveArchive(EntryCount, Stride);

        public IArchive Read(Stream stream)
        {
            var archive = Ps4SaveArchive.Read(stream, EntryCount, Stride);
            archive.Name = Description;

            return archive;
        }

        public bool IsValid(Stream stream) => stream.Length == Size;

        public IArchiveEntry CreateEntry() => new GenericEntry();
    }
}
