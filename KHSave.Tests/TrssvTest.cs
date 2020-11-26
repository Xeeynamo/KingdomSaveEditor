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

using KHSave.Trssv;
using KHSave.Trssv.Types;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
    public class TrssvTest
    {
        private static readonly string FilePath = "Saves/kh02.sav";
        private readonly SaveKh02 save;

        public TrssvTest()
        {
            using (var stream = File.OpenRead(FilePath))
            {
                save = SaveKh02.Read(stream);
            }
        }

        [Fact]
        public void TestIsValid()
        {
            using (var stream = File.OpenRead(FilePath))
            {
                Assert.True(SaveKh02.IsValid(stream));
            }
        }

        [Fact]
        public void TestRead()
        {
            Assert.True(save.IsVibrationEnable);
            Assert.False(save.InvertCameraVertical);
            Assert.False(save.InvertCameraHorizontal);
            Assert.True(save.IsMapVisible);
            Assert.True(save.IsSubtitlesVisible);
            Assert.True(save.Unk10_Bit5);
            Assert.False(save.CanEarnExp);
            Assert.Equal(2, save.CameraSpeed);
            Assert.Equal(200, save.Brightness);
            Assert.Equal(-1, save.TheaterModeWatched);
            Assert.Equal(-1, save.TheaterMode);
            Assert.Equal(100, save.Slots.Count);

            var slot = save.Slots[1];
            Assert.Equal(DifficultyType.Beginner, slot.Difficulty);
            Assert.Equal(474344, slot.Experience);
            Assert.Equal(53, slot.Level);
            Assert.Equal(129, slot.EnemiesDefeated);
            Assert.Equal(14, slot.StyleChangesPerformed);
            Assert.Equal(48, slot.MagicFiragaUses);
            Assert.Equal(10, slot.MagicBlizzardUses);
            Assert.Equal(55, slot.MagicThundagaUses);
            Assert.Equal(2, slot.MagicCuragaUses);
            Assert.Equal(350, slot.StoryProgression);
            Assert.Equal(115, slot.Pc[0].Hp);
            Assert.Equal(80, slot.Pc[0].Mp);
            Assert.Equal(100, slot.Pc[0].Focus);
            Assert.Equal(140, slot.Pc[1].Hp);
            Assert.Equal(130, slot.Pc[1].Mp);
            Assert.Equal(100, slot.Pc[1].Focus);
            Assert.Equal("/Game/Levels/dw/dw_08/dw_08", slot.MapPath);
            Assert.Equal("dw_08_Lv_Save_03", slot.MapSpawn);
            Assert.Equal("/Script/TresGame.TresPlayerControllerSora", slot.PlayerScript);
            Assert.Equal("/Game/Blueprints/Player/p_ex002/p_ex002_Pawn.p_ex002_Pawn_C", slot.PlayerCharacter);
            Assert.Equal("/Game/Blueprints/Npc/n_dw003/n_dw003_Pawn.n_dw003_Pawn_C", slot.SupportCharacter);
            Assert.Equal(CommandType.Firaga, slot.Shortcut1Circle);
            Assert.Equal(CommandType.Blizzaga, slot.Shortcut1Triangle);
            Assert.Equal(CommandType.Thundaga, slot.Shortcut1Square);
            Assert.Equal(CommandType.Curaga, slot.Shortcut1Cross);
            Assert.Equal(CommandType.Empty, slot.Shortcut2Circle);
            Assert.Equal(CommandType.Empty, slot.Shortcut2Triangle);
            Assert.Equal(CommandType.Ether, slot.Shortcut2Square);
            Assert.Equal(CommandType.HiPotion, slot.Shortcut2Cross);
        }
    }
}
