using KHSave.Archives;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
    public class PcArchiveTests
    {
        [Fact]
        public void ReadKh2Archive() => File.OpenRead("Saves/KHIIFM.png").Using(stream =>
        {
            var actual = new MemoryStream();
            Assert.True(ArchiveFactories.TryGetFactory(stream, out var archiveFactory));

            var archive = archiveFactory.Read(stream);
            Assert.NotNull(archive);

            Assert.Equal("BISLPM-66675FM-98", archive.Entries[2].Name);
            Assert.Equal("BISLPM-66675FM-00", archive.Entries[1].Name);
            Assert.Equal("BISLPM-66675FM-SYS", archive.Entries[0].Name);
        });

        [Fact]
        public void WriteBackKh2Archive() => File.OpenRead("Saves/KHIIFM.png").Using(expected => Helpers.AssertStream(expected, stream =>
        {
            var actual = new MemoryStream();
            Assert.True(ArchiveFactories.TryGetFactory(stream, out var archiveFactory));

            archiveFactory.Read(stream).Write(actual);
            return actual;
        }));
    }
}
