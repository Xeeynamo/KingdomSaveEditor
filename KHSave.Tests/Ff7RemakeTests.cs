using KHSave.LibFf7Remake;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
	public class Ff7RemakeTests
	{
		private const string FilePath = "Saves/ff7remake007";

		[Fact]
		public void TestIsValid()
		{
			using (var stream = File.OpenRead(FilePath))
			{
				Assert.True(SaveFf7Remake.IsValid(stream));
			}
		}

		[Fact]
		public void ReadSaveTest() =>
			File.OpenRead(FilePath).Using(stream =>
				AssertSaveGame(SaveFf7Remake.Read(stream)));

		[Fact]
		public void TestWriteBackTheSameExactFile() =>
		File.OpenRead(FilePath).Using(stream => Helpers.AssertStream(stream, inStream =>
		{
			var save = SaveFf7Remake.Read(inStream);

			var outStream = new MemoryStream();
			save.Write(outStream);

			return outStream;
		}));

		private static void AssertSaveGame(SaveFf7Remake save)
		{
			Assert.Equal(36, save.Characters[SaveFf7Remake.Cloud].Level);
			Assert.True(save.Characters[SaveFf7Remake.Cloud].IsUnlocked);
			Assert.Equal(2, save.Characters[SaveFf7Remake.Cloud].AtbBarCount);
			Assert.Equal(4078, save.Characters[SaveFf7Remake.Cloud].CurrentHp);
			Assert.Equal(5882, save.Characters[SaveFf7Remake.Cloud].MaxHp);
			Assert.Equal(112, save.Characters[SaveFf7Remake.Cloud].CurrentMp);
			Assert.Equal(123, save.Characters[SaveFf7Remake.Cloud].MaxMp);

			Assert.Equal(5436, save.Characters[SaveFf7Remake.Barret].MaxHp);
			Assert.Equal(5230, save.Characters[SaveFf7Remake.Tifa].MaxHp);
			Assert.Equal(3265, save.Characters[SaveFf7Remake.Aerith].MaxHp);
			Assert.Equal(3770, save.Characters[SaveFf7Remake.Red13].MaxHp);

			Assert.Equal(18, save.CurrentChapter);
		}
	}
}
