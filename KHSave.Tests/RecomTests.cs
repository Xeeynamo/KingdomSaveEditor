using Xunit;
using KHSave.LibRecom;
using System.IO;
using System;

namespace KHSave.Tests
{
    public class RecomTests
    {
        [Fact]
        public void IsValidTest()
        {
            var data = new byte[0x10];
            data[0] = 7;
            using (var stream = new MemoryStream(data))
                Assert.True(SaveKhRecom.IsValid(stream));
        }

        [Fact]
        public void IsNotValidIfMagicCodeIsNotRecognizedTest()
        {
            var data = new byte[0x10];
            data[0] = 6;
            using (var stream = new MemoryStream(data))
                Assert.False(SaveKhRecom.IsValid(stream));
        }

        [Fact]
        public void IsNotValidIfLengthIsNotEnoughTest()
        {
            var data = new byte[0xf];
            data[0] = 7;
            using (var stream = new MemoryStream(data))
                Assert.False(SaveKhRecom.IsValid(stream));
        }

        [Fact]
        public void SaveCorrectHeader() => OnSave(save =>
        {
            using (var memStream = new MemoryStream())
            {
                save.MagicCode = 999;
                save.Checksum = 888;
                save.Length = 777;
                save.Zeroed = 666;

                save.Write(memStream);
                memStream.Position = 0;
                var reader = new BinaryReader(memStream);

                Assert.Equal(7, reader.ReadInt32());
                Assert.Equal(180124905, reader.ReadInt32());
                Assert.Equal(13856, reader.ReadInt32());
                Assert.Equal(0, reader.ReadInt32());
            }
        });

        private static void OnSave(Action<SaveKhRecom> test)
        {
            const string FilePath = "Saves/BISLPM-66676COM-01";
            using (var stream = File.OpenRead(FilePath))
                test(SaveKhRecom.Read(stream));
        }
    }
}
