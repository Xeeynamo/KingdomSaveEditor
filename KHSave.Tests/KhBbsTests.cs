using KHSave.LibBbs;
using KHSave.LibBbs.Types;
using System.IO;
using Xe.BinaryMapper;
using Xunit;

namespace KHSave.Tests
{
    public class KhBbsTests
    {
        private static readonly string FilePath = "Saves/khbbs_ventus.DAT";
        private SaveKhBbs.SaveFinalMix save;

        public KhBbsTests()
        {
            using (FileStream stream = File.OpenRead(FilePath))
                save = BinaryMapping.ReadObject<SaveKhBbs.SaveFinalMix>(stream);
        }

        [Fact]
        public void TestRead()
        {
            Assert.Equal(999999U, save.Character.Money);
            Assert.Equal(DifficultyType.Critical, save.Difficulty);

            //Deck 1
            Assert.Equal(CommandType.TimeSplicer, save.CommandList[save.Decks[0].BattleCommands[0].Id].Id);
            Assert.Equal(CommandType.ArsArcanum, save.CommandList[save.Decks[0].BattleCommands[2].Id].Id);
            Assert.Equal(CommandType.Curaga, save.CommandList[save.Decks[0].BattleCommands[6].Id].Id);

            //Deck 2
            Assert.Equal(CommandType.Blitz, save.CommandList[save.Decks[1].BattleCommands[0].Id].Id);
            Assert.Equal(CommandType.SonicBlade, save.CommandList[save.Decks[1].BattleCommands[1].Id].Id);
            Assert.Equal(CommandType.Curaga, save.CommandList[save.Decks[1].BattleCommands[6].Id].Id);
            Assert.Equal(CommandType.Thundara, save.CommandList[save.Decks[1].BattleCommands[7].Id].Id);
            
            Assert.Equal(CommandType.Jump, save.CommandList[save.Decks[1].ActionCommands[0].Id].Id);
            Assert.Equal(CommandType.FlameSalvo, save.CommandList[save.Decks[1].Shotlock.Id].Id);

            //Deck 3
            Assert.Equal(CommandType.FireDash, save.CommandList[save.Decks[2].BattleCommands[7].Id].Id);
        }

        [Fact]
        public void TestChecksum()
        {
            File.OpenRead(FilePath).Using(stream => Assert.Equal(0x681DA0C8U, SaveKhBbs.CalculateChecksum(stream)));
        }

        [Fact]
        public void TestWriteBackTheSameExactFile() =>
        File.OpenRead(FilePath).Using(stream => Helpers.AssertStream(stream, inStream =>
        {
            var save = SaveKhBbs.Read<SaveKhBbs.SaveFinalMix>(inStream);

            var outStream = new MemoryStream();
            SaveKhBbs.Write(outStream, save);

            return outStream;
        }));
    }
}
