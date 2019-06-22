using KHSave.Lib2;
using KHSave.Lib2.Types;
using System.IO;
using System.Linq;
using Xunit;

namespace KHSave.Tests
{
    public class Kh2Tests
    {
        private static readonly string FilePath = "Saves/kh2fm.bin";
        private SaveKh2.SaveFinalMix save;

        public Kh2Tests()
        {
            using (var stream = File.OpenRead(FilePath))
            {
                save = Xe.BinaryMapper.BinaryMapping.ReadObject<SaveKh2.SaveFinalMix>(stream);
            }
        }

        [Theory]
        [InlineData(0x4a32484b, true)]
        [InlineData(0x5532484b, true)]
        [InlineData(0x4532484b, true)]
        [InlineData(0xcccccccc, false)]
        public void TestIsValid(uint header, bool expected)
        {
            var stream = new MemoryStream(4);
            new BinaryWriter(stream).Write(header);
            stream.Position = 0;

            Assert.Equal(expected, SaveKh2.IsValid(stream));
        }

        [Theory]
        [InlineData(0x4a32484b, 0x2a, GameVersion.Japanese)]
        [InlineData(0x5532484b, 0x2a, GameVersion.Japanese)]
        [InlineData(0x4532484b, 0x2a, GameVersion.Japanese)]
        [InlineData(0x4532484b, 0x2d, GameVersion.American)]
        [InlineData(0x4532484b, 0x3a, GameVersion.FinalMix)]
        [InlineData(0xcccccccc, 0x2a, null)]
        public void TestVersion(uint header, int version, GameVersion? expected)
        {
            var stream = new MemoryStream(4);
            var writer = new BinaryWriter(stream);
            writer.Write(header);
            writer.Write(version);
            stream.Position = 0;

            Assert.Equal(expected, SaveKh2.GetGameVersion(stream));
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

        [Fact]
        public void TestRead()
        {
            Assert.Equal(0x1f4, save.Characters[0].Weapon);
            Assert.Equal(60, save.Characters[0].HpCur);
            Assert.Equal(60, save.Characters[0].HpMax);
            Assert.Equal(120, save.Characters[0].MpMax);
            Assert.Equal(120, save.Characters[0].MpMax);
            Assert.Equal(99, save.Characters[0].Level);
            Assert.Equal(4, save.Characters[0].AccessoryCount);
            Assert.Equal(4, save.Characters[0].ArmorCount);
            Assert.Equal(8, save.Characters[0].ItemCount);
            Assert.Equal(0, save.Characters[0].UnknownCount);
            Assert.Equal(137, save.Characters[0].Abilities[0]);
            Assert.Equal(0x81, save.Characters[0].Abilities[0x8d]);

            Assert.Equal(BattleStyleType.SoraAttack, save.Characters[1].BattleStyle);
            Assert.Equal(305, save.Characters[1].Armors[0]);
            Assert.Equal(AbilityStyleType.Free, save.Characters[1].AbilityStyle1);
            Assert.Equal(AbilityStyleType.Free, save.Characters[1].AbilityStyle2);
            Assert.Equal(AbilityStyleType.Free, save.Characters[1].AbilityStyle3);
            Assert.Equal(AbilityStyleType.Free, save.Characters[1].AbilityStyle4);
            Assert.Equal(0, save.Characters[2].Armors[0]);
            Assert.Equal(57, save.Characters[2].Accessories[0]);
            Assert.Equal(0, save.Characters[12].Armors[0]);

            Assert.Equal(PlayableCharacterType.Sora, save.PlayableCharacter);
            Assert.Equal(PlayableCharacterType.Riku, save.CompanionCharacter1);
            Assert.Equal(PlayableCharacterType.Goofy, save.CompanionCharacter2);
            Assert.Equal(PlayableCharacterType.Donald, save.CompanionCharacter3);
        }
    }
}
