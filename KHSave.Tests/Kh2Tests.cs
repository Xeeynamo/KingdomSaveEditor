using KHSave.Lib2;
using System.IO;
using System.Linq;
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

        [Fact]
        public void TestChecksum()
        {
            var rand = new System.Random(0);
            var data = Enumerable.Range(0, 0x10000)
                .Select(x => (byte)rand.Next())
                .ToArray();
            Assert.Equal(1527299405U, SaveKh2.CalculateChecksum(data, data.Length));
        }
    }
}
