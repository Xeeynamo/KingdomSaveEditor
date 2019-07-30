using KHSave.LibRecom.Types;
using System.Collections.Generic;
using System.Linq;

namespace KHSave.LibRecom.Models
{
    public static class CardModel
    {
        public static readonly Card[] CardInventory =
            new CardType[]
            {
                CardType.KingdomKey,
                CardType.ThreeWishes,
                CardType.Crabclaw,
                CardType.Pumpkinhead,
                CardType.FairyHarp,
                CardType.WishingStar,
                CardType.Spellbinder,
                CardType.MetalChocobo,
                CardType.Olympia,
                CardType.Lionheart,
                CardType.LadyLuck,
                CardType.DivineRose,
                CardType.Oathkeeper,
                CardType.Oblivion,
                CardType.UltimaWeapon,
                CardType.DiamondDust,
                CardType.OneWingedAngel,
                CardType.SoulEater,
                CardType.StarSeeker,
                CardType.Monochrome,
                CardType.FollowTheWind,
                CardType.HiddenDragon,
                CardType.PhotonDebugger,
                CardType.BondOfFlame,
            }.Project().Indexed().WithPremium()
            .Concat(new CardType[]
            {
                CardType.Fire,
                CardType.Blizzard,
                CardType.Thunder,
                CardType.Cure,
                CardType.Gravity,
                CardType.Stop,
                CardType.Aero,
                CardType.DummyMagic1,
                CardType.DummyMagic2,
                CardType.Simba,
                CardType.Genie,
                CardType.Bambi,
                CardType.Dumbo,
                CardType.TinkerBell,
                CardType.Mushu,
                CardType.Cloud,
            }.Project().Indexed().WithPremium())
            .Concat(new CardType[]
            {
                CardType.Potion,
                CardType.HiPotion,
                CardType.MegaPotion,
                CardType.Ether,
                CardType.MegaEther,
                CardType.Elixir,
                CardType.Megalixir,
            }.Project().Indexed())
            .Concat(new CardType[]
            {
                CardType.TranquilDarkness,
                CardType.TeemingDarkness,
                CardType.FeebleDarkness,
                CardType.AlmightyDarkness,
                CardType.SleepingDarkness,
                CardType.LoomingDarkness,
                CardType.PremiumRoom,
                CardType.WhiteRoom,
                CardType.BlackRoom,
                CardType.BottomlessDarkness,
                CardType.RouletteDarkness,
                CardType.MartialWaking,
                CardType.SorcerousWaking,
                CardType.AlchemicWaking,
                CardType.MeetingGround,
                CardType.StagnantSpace,
                CardType.StrongInitiative,
                CardType.LastingDaze,
                CardType.CalmBounty,
                CardType.GuardedTrove,
                CardType.FalseBounty,
                CardType.MomentsReprieve,
                CardType.MinglingWorlds,
                CardType.MoogleRoom,
                CardType.RandomJoker,
            }.Project().Indexed())
            .Concat(new CardType[]
            {
                CardType.Shadow,
                CardType.Soldier,
                CardType.LargeBody,
                CardType.RedNocturne,
                CardType.BlueRhapsody,
                CardType.YellowOpera,
                CardType.GreenRequiem,
                CardType.Powerwild,
                CardType.Bouncywild,
                CardType.AirSoldier,
                CardType.Bandit,
                CardType.FatBandit,
                CardType.BarrelSpider,
                CardType.SearchGhost,
                CardType.SeaNeon,
                CardType.Screwdiver,
                CardType.Aquatank,
                CardType.WightKnight,
                CardType.Gargoyle,
                CardType.Pirate,
                CardType.AirPirate,
                CardType.Darkball,
                CardType.Defender,
                CardType.Wyvern,
                CardType.Wizard,
                CardType.Neoshadow,
                CardType.WhiteMushroom,
                CardType.BlackFungus,
                CardType.CreeperPlant,
                CardType.TornadoStep,
                CardType.Crescendo,
                CardType.GuardArmor,
                CardType.ParasiteCage,
                CardType.Trickmaster,
                CardType.Darkside,
                CardType.CardSoldier,
                CardType.Hades,
                CardType.Jafar,
                CardType.OogieBoogie,
                CardType.Ursula,
                CardType.Hook,
                CardType.DragonMaleficient,
                CardType.Riku,
                CardType.Axel,
                CardType.Larxene,
                CardType.Vexen,
                CardType.Marluxia,
                CardType.Lexaeus,
                CardType.Ansem,
                CardType.Zexion,
                CardType.Xemnas,
                CardType.Xigbar,
                CardType.Xaldin,
                CardType.Saix,
                CardType.Demyx,
                CardType.Luxord,
                CardType.Roxas,
            }.Project())
            .Concat(new CardType[]
            {
                CardType.GoldCard,
                CardType.PlatinumCard,
                CardType.Unused
            }.Project())
            .ToArray();

        public static int GetCardInventoryIndex(CardType cardType, bool isPremium = false) =>
            _cardInventoryLookup.TryGetValue(new Card
            {
                Type = cardType,
                IsPremium = isPremium
            }.ToKey(), out var value) ? value : -1;

        private const int MaxValue = 10; // Cards from 0 to 9

        private static readonly Dictionary<Card, int> _cardInventoryLookup =
            CardInventory
            .Select((Key, Value) => new { Key, Value })
            .Where(x => !x.Key.Value.HasValue || x.Key.Value.Value == 0)
            .ToDictionary(x => x.Key.ToKey(), x => x.Value);

        private static Card ToKey(this Card card) => new Card
        {
            Type = card.Type,
            IsPremium = card.IsPremium
        };

        private static IEnumerable<Card> Project(this CardType[] cards) =>
            cards.Select(x => new Card { Type = x, IsPremium = false });

        private static IEnumerable<Card> Indexed(this IEnumerable<Card> cards) =>
            cards.Select(x => Enumerable.Range(0, MaxValue).Select(i => new Card
            {
                Type = x.Type,
                Value = i,
                IsPremium = x.IsPremium
            })).SelectMany(x => x);

        private static IEnumerable<Card> WithPremium(this IEnumerable<Card> cards) =>
            cards.Concat(cards.Select(x => new Card { Type = x.Type, Value = x.Value, IsPremium = true }));
    }
}
