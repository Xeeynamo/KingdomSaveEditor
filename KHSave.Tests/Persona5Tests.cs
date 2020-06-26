using KHSave.LibPersona5;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
    public class Persona5Tests
    {
        [Theory]
        [InlineData(0x0e000000, 192 * 1024, true)]
        [InlineData(0x0e000000, 191 * 1024, false)]
        [InlineData(0x0f000000, 192 * 1024, false)]
        [InlineData(0x2d000000, 256 * 1024, true)]
        [InlineData(0x2d000000, 257 * 1024, false)]
        [InlineData(0x2c000000, 256 * 1024, false)]
        public void TestIsValid(uint header, int fileSize, bool expected)
        {
            var stream = new MemoryStream(4);
            new BinaryWriter(stream).Write(header);
            stream.SetLength(fileSize);
            stream.Position = 0;

            Assert.Equal(expected, SavePersona5.IsValid(stream));
        }

        [Fact]
        public void ReadPersona5FromPs3()
        {
            var save = File.OpenRead("Saves/p5_ps3.DAT").Using(SavePersona5.Read);
        }

        [Fact]
        public void ReadPersona5FromPs4()
        {
            var save = File.OpenRead("Saves/p5_ps4.DAT").Using(SavePersona5.Read);
        }

        [Fact]
        public void ReadPersona5Royal()
        {
            var save = File.OpenRead("Saves/p5r.DAT").Using(SavePersona5.Read);
        }

        [Theory]
        [InlineData("Saves/p5_ps3.DAT")]
        [InlineData("Saves/p5_ps4.DAT")]
        [InlineData("Saves/p5r.DAT")]
        public void WriteBackTheSameExactFile(string fileName) =>
            File.OpenRead(fileName).Using(stream => Helpers.AssertStream(stream, inStream =>
            {
                var save = SavePersona5.Read(inStream);

                var outStream = new MemoryStream();
                SavePersona5.Write(outStream, save);

                return outStream;
            }));
    }
}
