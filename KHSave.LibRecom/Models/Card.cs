using KHSave.LibRecom.Types;
using System;

namespace KHSave.LibRecom.Models
{
    public struct Card : IEquatable<Card>
    {
        public CardType CardType { get; set; }
        public bool IsPremium { get; set; }

        public bool Equals(Card other) =>
            CardType == other.CardType && IsPremium == other.IsPremium;

        public override bool Equals(object obj) =>
            obj is Card _card && Equals(_card);

        public override int GetHashCode() =>
            (int)CardType | (IsPremium ? 0x40000000 : 0);

        public override string ToString() =>
            IsPremium ? $"{CardType} (P)" : $"{CardType}";
    }
}
