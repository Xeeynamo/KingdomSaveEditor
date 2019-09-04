using System.IO;

namespace KHSave.Archives
{
    public static class ArchiveFactory
    {
        private const int Kh1Ps4EntryCount = 200;
        private const int Kh1Ps4Stride = 0x16C40;
        private const int Kh2Ps4EntryCount = 100;
        private const int Kh2Ps4Stride = 0x10FC0;

        public static IArchive CreateKh1Ps4() =>
            new Ps4SaveArchive(Kh1Ps4EntryCount, Kh1Ps4Stride);

        public static IArchive ReadKh1Ps4(Stream stream) =>
            Ps4SaveArchive.Read(stream, Kh1Ps4EntryCount, Kh1Ps4Stride);

        public static IArchive CreateKh2Ps4() =>
            new Ps4SaveArchive(Kh2Ps4EntryCount, Kh2Ps4Stride);

        public static IArchive ReadKh2Ps4(Stream stream) =>
            Ps4SaveArchive.Read(stream, Kh2Ps4EntryCount, Kh2Ps4Stride);

        public static IArchiveEntry CreateEntry() =>
            new GenericEntry();
    }
}
