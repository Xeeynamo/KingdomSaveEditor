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
        private static readonly string FilePathKh1 = "Saves/Archives/kh1fm_ps4.dat";
        private static readonly string FilePathKh2 = "Saves/Archives/kh2fm_ps4.dat";

        private static readonly string ExpectedStrForFile1 = "Kingdom Hearts Save Editor, first file";
        private static readonly string ExpectedStrForFile2 = "Second file";
        private static readonly string ExpectedStrForFile3 = "Third one";

        [Fact]
        public void ReadKh1Archive() => OpenKh1File().Using(stream =>
        {
            var archive = ArchiveFactory.ReadKh1Ps4(stream);

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
            var archive = ArchiveFactory.ReadKh2Ps4(stream);

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
            ArchiveFactory.ReadKh2Ps4(stream).Write(actual);
            return actual;
        }));

        private Stream OpenKh1File()
        {
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            stream.Position = 0;
            WriteString(stream, ExpectedStrForFile1);
            stream.Position = 0x40;
            writer.Write(new DateTime(2002, 03, 28).ToBinary());
            writer.Write(new DateTime(2013, 03, 14).ToBinary());
            writer.Write(0x111);
            stream.Position = 0x44c0;
            writer.Write(11);

            stream.Position = 0x58;
            WriteString(stream, ExpectedStrForFile2);
            stream.Position = 0x98;
            writer.Write(new DateTime(2005, 12, 22).ToBinary());
            writer.Write(new DateTime(2014, 10, 2).ToBinary());
            writer.Write(0x222);
            stream.Position = 0x1b100;
            writer.Write(22);

            stream.Position = 0xb0;
            WriteString(stream, ExpectedStrForFile3);
            stream.Position = 0xf0;
            writer.Write(new DateTime(2019, 01, 25).ToBinary());
            writer.Write(new DateTime(2019, 01, 25).ToBinary());
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
            writer.Write(new DateTime(2002, 03, 28).ToBinary());
            writer.Write(new DateTime(2013, 03, 14).ToBinary());
            writer.Write(0x111);
            stream.Position = 0x2260;
            writer.Write(11);

            stream.Position = 0x58;
            WriteString(stream, ExpectedStrForFile2);
            stream.Position = 0x98;
            writer.Write(new DateTime(2005, 12, 22).ToBinary());
            writer.Write(new DateTime(2014, 10, 2).ToBinary());
            writer.Write(0x222);
            stream.Position = 0x13220;
            writer.Write(22);

            stream.Position = 0xb0;
            WriteString(stream, ExpectedStrForFile3);
            stream.Position = 0xf0;
            writer.Write(new DateTime(2019, 01, 25).ToBinary());
            writer.Write(new DateTime(2019, 01, 25).ToBinary());
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
