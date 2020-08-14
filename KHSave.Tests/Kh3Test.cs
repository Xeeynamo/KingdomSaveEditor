/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using KHSave.Lib3;
using KHSave.Lib3.Types;
using Xunit;

namespace KHSave.Tests
{
	public class Kh3Test
    {
        private const string FilePath = "Saves/kh3.bin";
        private const string File109Path = "Saves/kh3_109.bin";

        [Theory]
		[InlineData(FilePath)]
		[InlineData(File109Path)]
        public void TestIsValid(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                Assert.True(SaveKh3.IsValid(stream));
            }
        }

		[Theory]
		[InlineData(FilePath)]
		[InlineData(File109Path)]
		public void ReadSaveTest(string filePath) =>
			File.OpenRead(filePath).Using(stream =>
				AssertSaveGame(SaveKh3.Read(stream)));

		[Theory]
		[InlineData(FilePath)]
		[InlineData(File109Path)]
		public void TestWriteWithoutChanges(string filePath) => File.OpenRead(filePath).Using(stream =>
		{
			var mem = new MemoryStream((int)stream.Length);
			SaveKh3.Read(stream).Write(mem);

			AssertSaveGame(SaveKh3.Read(mem.SetPosition(0)));
		});

		[Theory]
		[InlineData(FilePath)]
		[InlineData(File109Path)]
		public void TestWriteWithChanges(string filePath)
		{
			MemoryStream mem = null;
			File.OpenRead(filePath).Using(stream =>
			{
				var tempSave = SaveKh3.Read(stream);
				tempSave.TotalExp = 1234;
				tempSave.Difficulty = DifficultyType.Normal;
				tempSave.GameTime = new TimeSpan(12, 34, 56);
				tempSave.MapPath = "TestPath";
				tempSave.Shortcuts[0].Triangle = CommandType.SeaBlizzard;
				tempSave.Magics[0] = CommandType.SeaFire;

				mem = new MemoryStream((int)stream.Length);
				tempSave.Write(mem);

			});

			var save = SaveKh3.Read(mem.SetPosition(0));

			Assert.Equal(1234, save.TotalExp);
			Assert.Equal(DifficultyType.Normal, save.Difficulty);
			Assert.Equal(new TimeSpan(12, 34, 56), save.GameTime);
			Assert.Equal("TestPath", save.MapPath);
			Assert.Equal(CommandType.SeaBlizzard, save.Shortcuts[0].Triangle);
			Assert.Equal(CommandType.SeaFire, save.Magics[0]);
		}

		[Fact]
		public void IgnoreDlcFieldsFor100()
		{
			var save = File.OpenRead(FilePath).Using(stream => SaveKh3.Read(stream));
			save.DlcMapPath = "DlcMapPath";
			save.DlcSpawnPoint = "DlcSpawnPoint";

			Assert.Equal(string.Empty, save.DlcMapPath);
			Assert.Equal(string.Empty, save.DlcSpawnPoint);
		}

		[Fact]
		public void ReadDlcFieldsFor109()
		{
			var save = File.OpenRead(File109Path).Using(stream => SaveKh3.Read(stream));

			Assert.Equal("/Game/Levels/rg_DLC/rg_03/rg_03", save.DlcMapPath);
			Assert.Equal("rg_03_Lv_Start_01", save.DlcSpawnPoint);
		}

		[Fact]
		public void TestChecksum()
		{
			File.OpenRead(FilePath).Using(stream => Assert.Equal(0xE5783B63, SaveKh3.CalculateChecksum(stream)));
		}

		private static void AssertSaveGame(ISaveKh3 save)
		{
			Assert.Equal(0x45764053, save.MagicCode);
			Assert.Equal(DifficultyType.Proud, save.Difficulty);
			Assert.Equal(WorldType.ScalaAdCaelum, save.WorldLogo);
			Assert.Equal(new TimeSpan(52, 54, 3), save.GameTime);
			Assert.Equal(1413899, save.TotalExp);
			Assert.Equal(223439, save.Munny);
			Assert.Equal(94, save.Level);
			Assert.Equal(DesireChoice.Vitality, save.DesireChoice);
			Assert.Equal(PowerChoice.Warrior, save.PowerChoice);
			Assert.Equal(PartyCharacter.Sora, save.Party[0]);
			Assert.Equal(PartyCharacter.Donald, save.Party[1]);
			Assert.Equal(PartyCharacter.Goofy, save.Party[2]);
			Assert.Equal(PartyCharacter.Sora, save.Party[3]);
			Assert.Equal(PartyCharacter.Sora, save.Party[4]);
			Assert.True(save.SaveClear);
			Assert.Equal(LocationType.Location57, save.LocationName);
			Assert.Equal(CharacterIconType.Sora, save.BaseSaveIcon);
			Assert.Equal(6485, save.EnemiesDefeated);
			Assert.Equal(161, save.SavesCount);

			Assert.Equal(41, save.RecordAttractionsUseCount[0]);
			Assert.Equal(24, save.RecordAttractionsUseCount[1]);
			Assert.Equal(32, save.RecordAttractionsUseCount[4]);
			//Assert.Equal(3, save.RecordShotlocksUseCount[0]);
			//Assert.Equal(3, save.RecordShotlocksUseCount[1]);
			//Assert.Equal(10, save.RecordShotlocksUseCount[16]);
			//Assert.Equal(1, save.RecordShotlocksUseCount[27]);
			//Assert.Equal(0, save.RecordShotlocksUseCount[29]);

			Assert.Equal(54, save.Inventory[(int)InventoryType.Potion].Count);
			Assert.Equal(5, save.Inventory[(int)InventoryType.ApBoost].Count);

			Assert.Equal(60, save.MaterialsCount[0]);
			Assert.Equal(51, save.MaterialsCount[1]);
			Assert.Equal(139, save.MaterialsCount[40]);

			Assert.Equal(1723, save.CrabsCollected);

			Assert.Equal(WeaponType.UltimaWeapon, save.Pc[0].Weapons[0].WeaponId);
			Assert.Equal(WeaponType.GrandChef, save.Pc[0].Weapons[1].WeaponId);
			Assert.Equal(WeaponType.HunnySpout, save.Pc[0].Weapons[2].WeaponId);
			Assert.Equal(ArmorType.CosmicChain, save.Pc[1].Armors[0].ArmorId);
			Assert.Equal(AccessoryType.FlanniversaryBadge, save.Pc[0].Accessories[1].AccessoryId);
			Assert.Equal(0x444, save.Pc[0].Abilities[0].Data);
			Assert.Equal(0x444, save.Pc[0].Abilities[save.Pc[0].Abilities.Count - 1].Data);
			Assert.Equal(AiCombatStyleType.StickBySora, save.Pc[1].Ai.CombatStyle);
			Assert.Equal(AiAbilityType.GoWild, save.Pc[1].Ai.Abilitiy);
			Assert.Equal(AiRecoveryType.UseInEmergencies, save.Pc[1].Ai.Recovery);
			Assert.Equal(0b11111, save.Pc[1].Ai.RecoveryTargets);
			Assert.Equal(180, save.Pc[3].Hp);
			Assert.Equal(100, save.Pc[3].Mp);
			Assert.Equal(100, save.Pc[3].Focus);
			Assert.Equal(175, save.Pc[4].Hp);

			Assert.Equal(44, save.BonusHp);
			Assert.Equal(33, save.BonusMp);
			Assert.Equal(2, save.BonusStrength);
			Assert.Equal(2, save.BonusMagic);
			Assert.Equal(2, save.BonusDefense);

			Assert.Equal(100, save.Storyflags[0]);
			Assert.Equal(382, save.Storyflags[5]);
			Assert.Equal(2120, save.Storyflags[21]);
			Assert.Equal(6000, save.Storyflags[61]);
			Assert.Equal(0, save.Storyflags[63]);

			Assert.Equal("/Game/Levels/ex/ex_26/ex_26", save.MapPath);
			Assert.Equal("TresPlayerStart_Debug", save.MapSpawn);
			Assert.Equal("/Script/TresGame.TresPlayerControllerLowerBase", save.PlayerScript);
			Assert.Equal("Pawn path", save.PlayerCharacter);

			Assert.Equal(CommandType.Firaga, save.Magics[0]);

			Assert.Equal(3, save.Shortcuts.Count);
			Assert.Equal(CommandType.Curaga, save.Shortcuts[0].Circle);
			Assert.Equal(CommandType.Thundaga, save.Shortcuts[0].Triangle);
			Assert.Equal(CommandType.Waterga, save.Shortcuts[0].Square);
			Assert.Equal(CommandType.Firaga, save.Shortcuts[0].Cross);
			Assert.Equal(CommandType.UnionX, save.Shortcuts[2].Triangle);

			Assert.Equal(CommandType.Firaga, save.Magics[0]);
			Assert.Equal(CommandType.Aeroga, save.Magics[5]);
			Assert.Equal(CommandType.MeowWowBaloon, save.Links[0]);
			Assert.Equal(CommandType.PlasmaEncounter, save.Links[4]);

			Assert.Equal(20722, save.Records.CherryFlan.HighScore);
			Assert.Equal(20722, save.Records.CherryFlan.HighScore2);
			Assert.Equal(11, save.Records.CherryFlan.AttemptCount);
			Assert.Equal(24050, save.Records.StrawberryFlan.HighScore);
			Assert.Equal(24050, save.Records.StrawberryFlan.HighScore2);
			Assert.Equal(17, save.Records.ShotlocksHighScore[0]);
			Assert.Equal(23, save.Records.ShotlocksHighScore[1]);

			Assert.Equal(200, save.PhotoMaxCount);
			Assert.Equal(84725, save.Photos[0].Length);
			Assert.Equal(84065, save.Photos[89].Length);
		}
	}
}
