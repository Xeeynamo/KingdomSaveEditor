using KHSave.LibRecom;
using KHSave.LibRecom.Models;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class StoryViewModel
    {
        private readonly DataRecom _save;
        private StoryFlag Sora => _save.SoraStoryFlag;
        private StoryFlag Riku => _save.RikuStoryFlag;
        private PoohFlags Pooh => _save.PoohFlags;
        private TutorialFlags Tuto => _save.Tutorial;

        public StoryViewModel(DataRecom save)
        {
            _save = save;
        }

        public bool SoraTraverseTown { get => Sora.TraverseTown; set => Sora.TraverseTown = value; }
        public bool SoraAgrabah { get => Sora.Agrabah; set => Sora.Agrabah = value; }
        public bool SoraOlympusColiseum { get => Sora.OlympusColiseum; set => Sora.OlympusColiseum = value; }
        public bool SoraWonderland { get => Sora.Wonderland; set => Sora.Wonderland = value; }
        public bool SoraMonstro { get => Sora.Monstro; set => Sora.Monstro = value; }
        public bool SoraHalloweenTown { get => Sora.HalloweenTown; set => Sora.HalloweenTown = value; }
        public bool SoraAtlantica { get => Sora.Atlantica; set => Sora.Atlantica = value; }
        public bool SoraNeverland { get => Sora.Neverland; set => Sora.Neverland = value; }
        public bool SoraHollowBastion { get => Sora.HollowBastion; set => Sora.HollowBastion = value; }
        public bool SoraHundredAcreWood { get => Sora.HundredAcreWood; set => Sora.HundredAcreWood = value; }
        public bool SoraTwilightTown { get => Sora.TwilightTown; set => Sora.TwilightTown = value; }
        public bool SoraDestinyIsland { get => Sora.DestinyIsland; set => Sora.DestinyIsland = value; }
        public bool SoraCastleOblivion { get => Sora.CastleOblivion; set => Sora.CastleOblivion = value; }

        public bool RikuTraverseTown { get => Riku.TraverseTown; set => Riku.TraverseTown = value; }
        public bool RikuAgrabah { get => Riku.Agrabah; set => Riku.Agrabah = value; }
        public bool RikuOlympusColiseum { get => Riku.OlympusColiseum; set => Riku.OlympusColiseum = value; }
        public bool RikuWonderland { get => Riku.Wonderland; set => Riku.Wonderland = value; }
        public bool RikuMonstro { get => Riku.Monstro; set => Riku.Monstro = value; }
        public bool RikuHalloweenTown { get => Riku.HalloweenTown; set => Riku.HalloweenTown = value; }
        public bool RikuAtlantica { get => Riku.Atlantica; set => Riku.Atlantica = value; }
        public bool RikuNeverland { get => Riku.Neverland; set => Riku.Neverland = value; }
        public bool RikuHollowBastion { get => Riku.HollowBastion; set => Riku.HollowBastion = value; }
        public bool RikuHundredAcreWood { get => Riku.HundredAcreWood; set => Riku.HundredAcreWood = value; }
        public bool RikuTwilightTown { get => Riku.TwilightTown; set => Riku.TwilightTown = value; }
        public bool RikuDestinyIsland { get => Riku.DestinyIsland; set => Riku.DestinyIsland = value; }
        public bool RikuCastleOblivion { get => Riku.CastleOblivion; set => Riku.CastleOblivion = value; }

        public bool PoPiglet { get => Pooh.Piglet; set => Pooh.Piglet = value; }
        public bool PoOwl { get => Pooh.Owl; set => Pooh.Owl = value; }
        public bool PoRoo { get => Pooh.Roo; set => Pooh.Roo = value; }
        public bool PoEeyore { get => Pooh.Eeyore; set => Pooh.Eeyore = value; }
        public bool PoTigger { get => Pooh.Tigger; set => Pooh.Tigger = value; }
        public bool PoRabbit { get => Pooh.Rabbit; set => Pooh.Rabbit = value; }
        public bool PoGoal1 { get => Pooh.Goal1; set => Pooh.Goal1 = value; }
        public bool PoGoal2 { get => Pooh.Goal2; set => Pooh.Goal2 = value; }

        public bool TuKeyRoom { get => Tuto.KeyRoom; set => Tuto.KeyRoom = value; }
        public bool TuMoogleShop { get => Tuto.MoogleShop; set => Tuto.MoogleShop = value; }
        public bool TuFloorMove { get => Tuto.FloorMove; set => Tuto.FloorMove = value; }
        public bool TuWarpPoint { get => Tuto.WarpPoint; set => Tuto.WarpPoint = value; }
        public bool TuSavePoint { get => Tuto.SavePoint; set => Tuto.SavePoint = value; }
        public bool TuField { get => Tuto.Field; set => Tuto.Field = value; }
        public bool TuWorldSelect { get => Tuto.WorldSelect; set => Tuto.WorldSelect = value; }
    }
}
