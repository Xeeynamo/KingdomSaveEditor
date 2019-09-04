using System.IO;

namespace KHSave.Archives
{
    public static class ArchiveFactory
    {
        public static IArchive ReadKh1Ps4(Stream stream) =>
            Ps4SaveArchive.Read(stream, 200, 0x16C40);

        public static IArchive ReadKh2Ps4(Stream stream) =>
            Ps4SaveArchive.Read(stream, 100, 0x10FC0);
    }
}
