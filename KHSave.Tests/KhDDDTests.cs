using KHSave.LibDDD;
using KHSave.LibDDD.Types;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
    public class KhDDDTests
    {
        private static readonly string FilePath = "Saves/khddd3ds.bin";
        private SaveKhDDD.SaveKhDDD3DS save;

        public KhDDDTests()
        {
            using (var stream = File.OpenRead(FilePath))
            {
                save = Xe.BinaryMapper.BinaryMapping.ReadObject<SaveKhDDD.SaveKhDDD3DS>(stream);
            }
        }

        [Theory]
        [InlineData(0x444d4f53, true)]
        [InlineData(0x444d4f00, false)]
        public void TestIsValid(uint header, bool expected)
        {
            var stream = new MemoryStream(4);
            new BinaryWriter(stream).Write(header);
            stream.Position = 0;

            Assert.Equal(expected, SaveKhDDD.IsValid(stream));
        }

        [Fact]
        public void TestRead()
        {
            Assert.Equal((uint)3133, save.Munny);

            // World and room of current playable character
            Assert.Equal(WorldType.TheWorldThatNeverWas, save.WorldId);
            Assert.Equal(5, save.RoomId);
            Assert.Equal(99, save.SpawnId);

            // Sora equipment and stats
            Assert.Equal(EquipmentType.CounterpointS, save.SoraKeyblade);
            Assert.Equal((uint)68040, save.SoraXp);
            Assert.Equal(31, save.SoraLv);
            
            // Riku equipment and stats
            Assert.Equal(EquipmentType.SkullNoiseR, save.RikuKeyblade);
            Assert.Equal((uint)73953, save.RikuXp);
            Assert.Equal(32, save.RikuLv);

            // Dreameater tests
            var dreameater = save.DreamEaters[0];
            Assert.Equal("WundermMieze", dreameater.Name.ToString());
            Assert.Equal(35, dreameater.Attack);
            Assert.Equal(99, dreameater.Magic);
            Assert.Equal(28, dreameater.Defence);
            Assert.Equal(DreamEaterType.YoggyRam, dreameater.DreamEaterType);

            // Decks
            var deck = save.SoraDecks[0];
            Assert.Equal("Deck 1", deck.Name.ToString());
        }

        [Fact]
        public void TestWriteBackTheSameExactFile() =>
            File.OpenRead(FilePath).Using(stream => Helpers.AssertStream(stream, inStream =>
           {
               var outStream = new MemoryStream();
               SaveKhDDD.Read(inStream).Write(outStream);

               return outStream;
           }));
    }
}
