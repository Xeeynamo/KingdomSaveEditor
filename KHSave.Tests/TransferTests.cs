using KHSave.Services;
using System.Linq;
using Xunit;

namespace KHSave.Tests
{
    public class TransferTests
    {
        [Fact]
        public void CopySaveTest()
        {
            var dst = new Lib2.SaveKh2.SaveEuropean()
            {
                InventoryCount = new byte[0x04],
                PlaceScripts = Enumerable.Range(0, 2).Select(x => new Lib2.Models.PlaceScriptVanilla()).ToArray(),
                Characters = new Lib2.Models.CharacterVanilla[0],
                DriveForms = new Lib2.Models.DriveFormVanilla[0],
            };
            var src = new Lib2.SaveKh2.SaveFinalMix()
            {
                Difficulty = Lib2.Types.Difficulty.Critical,
                WorldId = Lib2.Types.WorldType.DisneyCastle,
                MunnyAmount = 12345,
                InventoryCount = new byte[6] { 0, 1, 2, 3, 4, 5 },
                PlaceScripts = new Lib2.Models.PlaceScriptFinalMix[3]
                {
                    new Lib2.Models.PlaceScriptFinalMix { Map = 1, Battle = 2, Event = 3 },
                    new Lib2.Models.PlaceScriptFinalMix { Map = 4, Battle = 5, Event = 6 },
                    new Lib2.Models.PlaceScriptFinalMix { Map = 7, Battle = 8, Event = 7 },
                },
                Characters = new Lib2.Models.CharacterFinalMix[0],
                DriveForms = new Lib2.Models.DriveFormFinalMix[0],
            };

            TransferServiceLL.CopySave<Lib2.ISaveKh2>(dst, src, Lib2.SaveKh2.TransferMappings);

            Assert.Equal(12345, dst.MunnyAmount);
            Assert.Equal(new byte[] { 0, 1, 2, 3 }, dst.InventoryCount);
            Assert.Equal(Lib2.Types.Difficulty.Proud, dst.Difficulty);
            Assert.Equal(Lib2.Types.WorldType.DisneyCastle, dst.WorldId);

            Assert.Equal(2, dst.PlaceScripts.Length);
            Assert.Equal(1, dst.PlaceScripts[0].Map);
            Assert.Equal(2, dst.PlaceScripts[0].Battle);
            Assert.Equal(3, dst.PlaceScripts[0].Event);
            Assert.Equal(4, dst.PlaceScripts[1].Map);
            Assert.Equal(5, dst.PlaceScripts[1].Battle);
            Assert.Equal(6, dst.PlaceScripts[1].Event);
        }
    }
}
