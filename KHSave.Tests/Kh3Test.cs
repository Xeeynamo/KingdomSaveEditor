/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

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
using KHSave.Types;
using Xunit;

namespace KHSave.Tests
{
	public class Kh3Test
    {
        private static readonly string FilePath = "Saves/kh3.bin";
        private Kh3 save;

		public Kh3Test()
		{
			using (var stream = File.OpenRead(FilePath))
			{
				save = Kh3.Read(stream);
			}
		}

        [Fact]
        public void TestIsValid()
        {
            using (var stream = File.OpenRead(FilePath))
            {
                Assert.True(Kh3.IsValid(stream));
            }
        }

		[Fact]
		public void TestRead()
		{
			Assert.Equal(DifficultyType.Proud, save.Difficulty);
			Assert.Equal(WorldType.ToyBox, save.WorldLogo);
			Assert.Equal(new TimeSpan(47, 0, 39), save.GameTime);
			Assert.Equal(689472, save.TotalExp);
			Assert.Equal(31886, save.Munny);
			Assert.Equal(63, save.Level);
            Assert.True(save.SaveClear);
			Assert.Equal(CharacterIconType.Sora, save.MySaveIcon);

			Assert.Equal(WeaponType.UltimaWeapon, save.Pc[0].Weapons[0].WeaponId);
			Assert.Equal(WeaponType.Starlight, save.Pc[0].Weapons[1].WeaponId);
			Assert.Equal(WeaponType.HunnySpout, save.Pc[0].Weapons[2].WeaponId);
			Assert.Equal(ArmorType.CosmicChain, save.Pc[1].Armors[0].ArmorId);
			Assert.Equal(AccessoryType.FlanniversaryBadge, save.Pc[0].Accessories[1].AccessoryId);
			Assert.Equal(0x444, save.Pc[0].Abilities[0].Data);
			Assert.Equal(0x444, save.Pc[0].Abilities[save.Pc[0].Abilities.Count - 1].Data);
			Assert.Equal(AiCombatStyleType.StickBySora, save.Pc[1].Ai.CombatStyle);
			Assert.Equal(AiAbilityType.GoWild, save.Pc[1].Ai.Abilitiy);
			Assert.Equal(AiRecoveryType.UseInEmergencies, save.Pc[1].Ai.Recovery);
			Assert.Equal(0b1111, save.Pc[1].Ai.RecoveryTargets);

			Assert.Equal(CommandType.Firaga, save.Magics[0]);

			Assert.Equal(52, save.Inventory[(int)InventoryType.Potion].Count);
			Assert.Equal(8, save.Inventory[(int)InventoryType.ApBoost].Count);

			Assert.Equal(270, save.Pc[0].Hp);
			Assert.Equal(135, save.Pc[0].Mp);
			Assert.Equal(100, save.Pc[0].Focus);
			Assert.Equal(180, save.Pc[1].Hp);

			Assert.Equal(CommandType.Cure, save.Shortcuts[0].Circle);
			Assert.Equal(CommandType.Thundaga, save.Shortcuts[0].Triangle);
			Assert.Equal(CommandType.Waterga, save.Shortcuts[0].Square);
			Assert.Equal(CommandType.Fira, save.Shortcuts[0].Cross);
			Assert.Equal(3, save.Shortcuts.Count);

			Assert.Equal("/Game/Levels/ts/ts_02/ts_02", save.MapPath);
			Assert.Equal("ts_02_Lv_Save_01", save.MapSpawn);
			Assert.Equal("/Script/TresGame.TresPlayerControllerSora", save.PlayerScript);
			Assert.Equal("/Game/Blueprints/Player/p_ts001/p_ts001_Pawn.p_ts001_Pawn_C", save.PlayerCharacter);
		}

		[Fact]
		public void TestWriteWithoutChanges()
		{
			var mem = new MemoryStream(9758960);
			save.Write(mem);

			mem.Position = 0;
			save = Kh3.Read(mem);
			TestRead();
		}

		[Fact]
		public void TestWriteWithChanges()
		{
			save.TotalExp = 1234;
			save.Difficulty = DifficultyType.Normal;
			save.GameTime = new TimeSpan(12, 34, 56);
			save.MapPath = "TestPath";
			save.Shortcuts[0].Triangle = CommandType.SeaBlizzard;
			save.Magics[0] = CommandType.SeaFire;

			var mem = new MemoryStream(9758960);
			save.Write(mem);

			mem.Position = 0;
			var save2 = Kh3.Read(mem);

			Assert.Equal(1234, save2.TotalExp);
			Assert.Equal(DifficultyType.Normal, save2.Difficulty);
			Assert.Equal(new TimeSpan(12, 34, 56), save2.GameTime);
			Assert.Equal("TestPath", save2.MapPath);
			Assert.Equal(CommandType.SeaBlizzard, save2.Shortcuts[0].Triangle);
			Assert.Equal(CommandType.SeaFire, save2.Magics[0]);


		}
	}
}
