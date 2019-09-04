using System.IO;

namespace KHSave.Archives.Factories
{
    internal class Ps4Kh2Factory : IArchiveFactory
    {
        private const int EntryCount = 100;
        private const int Stride = 0x10FC0;
        private const int Size = 0x6a4c00;

        public string Name => "PS4 KH2";

        public string Description => "Kingdom Hearts II Final Mix (PS4)";

        public IArchive Create() =>
            new Ps4SaveArchive(EntryCount, Stride);

        public IArchive Read(Stream stream) =>
            Ps4SaveArchive.Read(stream, EntryCount, Stride);

        public bool IsValid(Stream stream) => stream.Length == Size;

        public IArchiveEntry CreateEntry() => new GenericEntry();
    }
}
