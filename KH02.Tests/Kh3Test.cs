/*
    Kingdom Hearts 0.2 and 3 Save Editor
    Copyright (C) 2019  Luciano Ciccariello

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

using KHSave.Attributes;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
	public class Kh3Test
	{
		private readonly Kh3 save;

		public Kh3Test()
		{
			using (var stream = File.OpenRead("Saves/kh3.bin"))
			{
				save = Kh3.Read(stream);
			}
		}

		[Fact]
		public void TestRead()
		{
			Assert.Equal(DifficultyType.Proud, save.Difficulty);
			Assert.Equal(WorldType.ToyBox, save.WorldLogo);
			Assert.Equal(689472, save.TotalExp);
			Assert.Equal(31886, save.Munny);
			Assert.Equal(63, save.Level);
            Assert.True(save.SaveClear);
			Assert.Equal(CharacterIconType.Sora, save.MySaveIcon);

			Assert.Equal(270, save.Pc[0].Hp);
			Assert.Equal(135, save.Pc[0].Mp);
			Assert.Equal(100, save.Pc[0].Focus);
			Assert.Equal(180, save.Pc[1].Hp);

			Assert.Equal(CommandType.Aeroza, save.Shortcuts[0].Circle);
			Assert.Equal(CommandType.Thundaga, save.Shortcuts[0].Triangle);
			Assert.Equal(3, save.Shortcuts.Count);

			Assert.Equal("/Game/Levels/ts/ts_02/ts_02", save.MapPath);
			Assert.Equal("ts_02_Lv_Save_01", save.MapSpawn);
			Assert.Equal("/Script/TresGame.TresPlayerControllerSora", save.PlayerScript);
			Assert.Equal("/Game/Blueprints/Player/p_ts001/p_ts001_Pawn.p_ts001_Pawn_C", save.PlayerCharacter);
		}
	}
}
