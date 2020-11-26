using KHSave.LibRecom.Types;
using System;

namespace KHSave.LibRecom.Models
{
    public struct Card : IEquatable<Card>
    {
        public CardType Type { get; set; }
        public int? Value { get; set; }
        public bool? IsPremium { get; set; }

        public bool Equals(Card other) =>
            Type == other.Type && Value == other.Value && IsPremium == other.IsPremium;

        public override bool Equals(object obj) =>
            obj is Card _card && Equals(_card);

        public override int GetHashCode() =>
            (int)Type | (Value.HasValue ? (Value.Value << 16) : 0x10000000) |
                (IsPremium.HasValue ? (IsPremium.Value ? 0x40000000 : 0) : 0x20000000);

        public override string ToString()
        {
            if (Value.HasValue)
                return (IsPremium ?? false) ? $"{Type} {Value} (P)" : $"{Type} {Value}";

            return Type.ToString();
        }
    }
}
