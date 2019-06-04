using KHSave.Lib2;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
    public class Kh2Tests
    {
        [Theory]
        [InlineData(0x4B48324A, true)]
        [InlineData(0x4B483255, true)]
        [InlineData(0x4B483245, true)]
        [InlineData(0xcccccccc, false)]
        public void TestIsValid(uint header, bool expected)
        {
            var stream = new MemoryStream(4);
            new BinaryWriter(stream).Write(header);
            stream.Position = 0;

            Assert.Equal(expected, SaveKh2.IsValid(stream));
        }
    }
}
