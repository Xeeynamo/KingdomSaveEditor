using KHSave.LibRecom.Types;
using System.Collections.Generic;
using System.Linq;

namespace KHSave.LibRecom.Models
{
    public static class CardModel
    {
        public static readonly Card[] CardInventory =
            GetCardWithPremium(new CardType[]
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
            })
            .Concat(GetCardWithPremium(new CardType[]
            {
                CardType.Fire,
                CardType.Blizzard,
                CardType.Thunder,
                CardType.Cure,
                CardType.Gravity,
                CardType.Stop,
                CardType.Aero,
            }))
            .ToArray();

        public static int GetCardInventoryIndex(Card card) =>
            _cardInventoryLookup.TryGetValue(card, out var value) ? value : -1;

        private static readonly Dictionary<Card, int> _cardInventoryLookup =
            CardInventory.Select((Key, Value) => new { Key, Value })
            .ToDictionary(x => x.Key, x => x.Value);

        private static IEnumerable<Card> GetCardWithPremium(CardType[] cards) =>
            cards.Select(x => new Card { CardType = x, IsPremium = false })
            .Concat(cards.Select(x => new Card { CardType = x, IsPremium = true }));
    }
}
