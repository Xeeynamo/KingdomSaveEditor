using KHSave.LibFf7Remake;
using KHSave.LibFf7Remake.Types;
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

			Assert.Equal(51, save.CharactersStats[SaveFf7Remake.Cloud].Vitality);
			Assert.Equal(68, save.CharactersStats[SaveFf7Remake.Barret].Magic);

			Assert.Equal(23, save.CharactersEquipment[SaveFf7Remake.Cloud].Weapon);
			Assert.Equal(4, save.CharactersEquipment[SaveFf7Remake.Red13].Weapon);
			Assert.Equal(0, save.CharactersEquipment[SaveFf7Remake.Red13].Armor);
			Assert.Equal(-1, save.CharactersEquipment[SaveFf7Remake.Red13].Accessory);

			Assert.Equal(1200, save.Materia[0].AbilityPoint);
			Assert.Equal(3, save.Materia[0].Level);
			Assert.Equal(1, save.Materia[0].Index);
			Assert.Equal(CharacterType.Cloud, (CharacterType)save.Materia[0].Character);
			Assert.Equal(InventoryType.Fire, (InventoryType)save.Materia[0].ItemId);

			Assert.Equal(InventoryType.BronzeBangle, save.Inventory[0].Type);
			Assert.Equal(3, save.Inventory[0].Count);

			Assert.Equal(CharacterType.Cloud, (CharacterType)save.CharacterMateria[0].Character);
			Assert.Equal(22, save.CharacterMateria[0].MateriaIndex[0]);

			Assert.Equal(InventoryType.BusterSword, (InventoryType)save.WeaponMateria[0].ItemId);
			Assert.Equal(-1, save.WeaponMateria[0].MateriaIndex[0]);
			Assert.Equal(InventoryType.TwinStinger, (InventoryType)save.WeaponMateria[23].ItemId);
			Assert.Equal(7, save.WeaponMateria[23].MateriaIndex[0]);

			Assert.Equal(51, save.SummonMateria[SaveFf7Remake.Cloud]);

			Assert.Equal(18, save.CurrentChapter);
		}
	}
}
