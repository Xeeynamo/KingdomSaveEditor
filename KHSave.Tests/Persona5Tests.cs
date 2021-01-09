using KHSave.LibPersona5;
using KHSave.LibPersona5.Types;
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
            //Assert.Equal("Pandan", save.ProtagonistLastName);
            //Assert.Equal("Xeeynamo", save.ProtagonistFirstName);
            Assert.Equal(10, save.CalendarDay1);
            Assert.Equal(10, save.CalendarDay2);
            Assert.Equal(10, save.CalendarDay3);

            Assert.Equal(1002943, save.Money);
            Assert.Equal(9, save.Characters.Length);
            Assert.Equal(103, save.Characters[0].CurrentHp);
            Assert.Equal(38, save.Characters[0].CurrentMp);
            Assert.Equal(77, save.Characters[0].Experience);
            Assert.Equal(0x0002, (ushort)save.Characters[0].MeleeWeapon);
            Assert.Equal(0x1002, (ushort)save.Characters[0].Protector);
            Assert.False(save.PartyModifierRyuji);
            Assert.False(save.PartyModifierMorgana);
            Assert.False(save.PartyModifierAnn);
            Assert.False(save.PartyModifierYusuke);
            Assert.False(save.PartyModifierMakoto);
            Assert.False(save.PartyModifierHaru);
            Assert.False(save.PartyModifierFutaba);
            Assert.False(save.PartyModifierAkechi);
            Assert.Equal(-1525, save.PositionX, 0);
            Assert.Equal(360, save.PositionY, 0);
            Assert.Equal(-2922, save.PositionZ, 0);
            Assert.Equal(123, save.RoomCategory);
            Assert.Equal(101, save.RoomMap);
        }

        [Fact]
        public void ReadPersona5FromPs4()
        {
            var save = File.OpenRead("Saves/p5_ps4.DAT").Using(SavePersona5.Read);
            //Assert.Equal("Luciano", save.ProtagonistLastName);
            //Assert.Equal("Xeeynamo", save.ProtagonistFirstName);
            Assert.Equal(256, save.CalendarDay1);
            Assert.Equal(256, save.CalendarDay2);
            Assert.Equal(256, save.CalendarDay3);

            Assert.Equal(505184, save.Money);
            Assert.Equal(9, save.Characters.Length);
            Assert.Equal(0x0016, (ushort)save.Characters[0].MeleeWeapon);
            Assert.Equal(0x108c, (ushort)save.Characters[0].Protector);
            Assert.True(save.PartyModifierRyuji);
            Assert.True(save.PartyModifierMorgana);
            Assert.True(save.PartyModifierAnn);
            Assert.True(save.PartyModifierYusuke);
            Assert.True(save.PartyModifierMakoto);
            Assert.True(save.PartyModifierHaru);
            Assert.True(save.PartyModifierFutaba);
            Assert.False(save.PartyModifierAkechi);
            Assert.Equal(-78, save.PositionX, 0);
            Assert.Equal(0, save.PositionY, 0);
            Assert.Equal(575, save.PositionZ, 0);
            Assert.Equal(3, save.RoomCategory);
            Assert.Equal(2, save.RoomMap);
        }

        [Fact]
        public void ReadPersona5Royal()
        {
            var save = File.OpenRead("Saves/p5r.DAT").Using(SavePersona5.Read);
            //Assert.Equal("Retsu", save.ProtagonistLastName);
            //Assert.Equal("Xeeynamo", save.ProtagonistFirstName);
            Assert.Equal(20, save.CalendarDay1);
            Assert.Equal(20, save.CalendarDay2);
            Assert.Equal(20, save.CalendarDay3);

            Assert.Equal(49735, save.Money);
            Assert.Equal(10, save.Characters.Length);
            Assert.Equal(136, save.Characters[0].CurrentHp);
            Assert.Equal(2, save.Characters[0].CurrentMp);
            Assert.Equal(566, save.Characters[0].Experience);
            Assert.Equal(125, save.Characters[1].CurrentHp);
            Assert.Equal(21, save.Characters[1].CurrentMp);
            Assert.Equal(498, save.Characters[1].Persona[0].Experience);
            Assert.Equal(117, save.Characters[2].CurrentHp);
            Assert.Equal(18, save.Characters[2].CurrentMp);
            Assert.Equal(543, save.Characters[2].Persona[0].Experience);
            Assert.Equal(463, save.Characters[3].Persona[0].Experience);
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
