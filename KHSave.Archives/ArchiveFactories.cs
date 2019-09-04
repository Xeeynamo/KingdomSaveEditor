using KHSave.Archives.Factories;
using System.IO;

namespace KHSave.Archives
{
    public static class ArchiveFactories
    {
        public static IArchiveFactory Ps4Kh1 = new Ps4Kh1Factory();
        public static IArchiveFactory Ps4Kh2 = new Ps4Kh2Factory();

        public static bool TryGetFactory(Stream stream, out IArchiveFactory archiveFactory)
        {
            if (Ps4Kh1.IsValid(stream)) archiveFactory = Ps4Kh1;
            else if (Ps4Kh2.IsValid(stream)) archiveFactory = Ps4Kh2;
            else archiveFactory = null;

            return archiveFactory != null;
        }
    }
}
