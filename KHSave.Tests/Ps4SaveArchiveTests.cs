using KHSave.Archives;
using System;
using System.IO;
using System.Text;
using Xe.BinaryMapper;
using Xunit;

namespace KHSave.Tests.Saves.Archives
{
    public class Ps4SaveArchiveTests
    {
        private static readonly string ExpectedStrForFile1 = "Kingdom Save Editor, first file";
        private static readonly string ExpectedStrForFile2 = "Second file";
        private static readonly string ExpectedStrForFile3 = "Third one";

        [Fact]
        public void ReadKh1Archive() => OpenKh1File().Using(stream =>
        {
            var archive = ArchiveFactories.Ps4Kh1.Read(stream);

            Assert.Equal(200, archive.Entries.Count);

            var entry1 = archive.Entries[0];
            Assert.Equal(ExpectedStrForFile1, entry1.Name);
            Assert.Equal(2002, entry1.DateCreated.Year);
            Assert.Equal(2013, entry1.DateModified.Year);
            Assert.Equal(0x111, entry1.Data.Length);
            Assert.Equal(11, entry1.Data[0]);

            var entry2 = archive.Entries[1];
            Assert.Equal(ExpectedStrForFile2, entry2.Name);
            Assert.Equal(2005, entry2.DateCreated.Year);
            Assert.Equal(2014, entry2.DateModified.Year);
            Assert.Equal(0x222, entry2.Data.Length);
            Assert.Equal(22, entry2.Data[0]);

            var entry3 = archive.Entries[2];
            Assert.Equal(ExpectedStrForFile3, entry3.Name);
            Assert.Equal(2019, entry3.DateCreated.Year);
            Assert.Equal(2019, entry3.DateModified.Year);
            Assert.Equal(0x333, entry3.Data.Length);
            Assert.Equal(33, entry3.Data[0]);
        });

        [Fact]
        public void ReadKh2Archive() => OpenKh2File().Using(stream =>
        {
            var archive = ArchiveFactories.Ps4Kh2.Read(stream);

            Assert.Equal(100, archive.Entries.Count);

            var entry1 = archive.Entries[0];
            Assert.Equal(ExpectedStrForFile1, entry1.Name);
            Assert.Equal(2002, entry1.DateCreated.Year);
            Assert.Equal(2013, entry1.DateModified.Year);
            Assert.Equal(0x111, entry1.Data.Length);
            Assert.Equal(11, entry1.Data[0]);

            var entry2 = archive.Entries[1];
            Assert.Equal(ExpectedStrForFile2, entry2.Name);
            Assert.Equal(2005, entry2.DateCreated.Year);
            Assert.Equal(2014, entry2.DateModified.Year);
            Assert.Equal(0x222, entry2.Data.Length);
            Assert.Equal(22, entry2.Data[0]);

            var entry3 = archive.Entries[2];
            Assert.Equal(ExpectedStrForFile3, entry3.Name);
            Assert.Equal(2019, entry3.DateCreated.Year);
            Assert.Equal(2019, entry3.DateModified.Year);
            Assert.Equal(0x333, entry3.Data.Length);
            Assert.Equal(33, entry3.Data[0]);
        });

        [Fact]
        public void WriteBackKh1Archive() => OpenKh2File().Using(expected => Helpers.AssertStream(expected, stream =>
        {
            var actual = new MemoryStream();
            ArchiveFactories.Ps4Kh2.Read(stream).Write(actual);
            return actual;
        }));

        [Fact]
        public void CreateKh1Archive()
        {
            var archive = ArchiveFactories.Ps4Kh1.Create();

            var entry = ArchiveFactories.Ps4Kh1.CreateEntry();
            entry.Name = "my test";
            entry.DateCreated = new DateTime(2019, 01, 01);
            entry.DateModified = new DateTime(2020, 01, 01);
            entry.Data = new byte[] { 9, 0 };

            archive.Entries.Add(entry);

            var stream = new MemoryStream();
            archive.Write(stream);

            stream.Position = 0;
            archive = ArchiveFactories.Ps4Kh1.Read(stream);

            Assert.Equal(0x11cd800, stream.Length);
            Assert.Equal(200, archive.Entries.Count);

            var actual = archive.Entries[0];
            Assert.Equal("my test", actual.Name);
            Assert.Equal(2019, actual.DateCreated.Year);
            Assert.Equal(2020, actual.DateModified.Year);
            Assert.Equal(2, actual.Data.Length);
            Assert.Equal(9, actual.Data[0]);
        }

        [Fact]
        public void CreateKh2Archive()
        {
            var archive = ArchiveFactories.Ps4Kh2.Create();
            var stream = new MemoryStream();
            archive.Write(stream);

            Assert.Equal(0x6a4c00, stream.Length);
        }

        private Stream OpenKh1File()
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            stream.Position = 0;
            WriteString(stream, ExpectedStrForFile1);
            stream.Position = 0x40;
            writer.Write((long)1017273600);
            writer.Write((long)1363219200);
            writer.Write(0x111);
            stream.Position = 0x44c0;
            writer.Write(11);

            stream.Position = 0x58;
            WriteString(stream, ExpectedStrForFile2);
            stream.Position = 0x98;
            writer.Write((long)1135209600);
            writer.Write((long)1412208000);
            writer.Write(0x222);
            stream.Position = 0x1b100;
            writer.Write(22);

            stream.Position = 0xb0;
            WriteString(stream, ExpectedStrForFile3);
            stream.Position = 0xf0;
            writer.Write((long)1548374400);
            writer.Write((long)1548374400);
            writer.Write(0x333);
            stream.Position = 0x31D40;
            writer.Write(33);

            writer.Flush();
            stream.SetLength(0x11cd800);
            stream.Position = 0;

            return stream;
        }

        private Stream OpenKh2File()
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            stream.Position = 0;
            WriteString(stream, ExpectedStrForFile1);
            stream.Position = 0x40;
            writer.Write((long)1017273600);
            writer.Write((long)1363219200);
            writer.Write(0x111);
            stream.Position = 0x2260;
            writer.Write(11);

            stream.Position = 0x58;
            WriteString(stream, ExpectedStrForFile2);
            stream.Position = 0x98;
            writer.Write((long)1135209600);
            writer.Write((long)1412208000);
            writer.Write(0x222);
            stream.Position = 0x13220;
            writer.Write(22);

            stream.Position = 0xb0;
            WriteString(stream, ExpectedStrForFile3);
            stream.Position = 0xf0;
            writer.Write((long)1548374400);
            writer.Write((long)1548374400);
            writer.Write(0x333);
            stream.Position = 0x241e0;
            writer.Write(33);

            writer.Flush();
            stream.SetLength(0x6a4c00);
            stream.Position = 0;

            return stream;
        }

        private void WriteString(Stream stream, string text)
        {
            var data = Encoding.UTF8.GetBytes(text);
            stream.Write(data, 0, data.Length);
        }
    }
}
