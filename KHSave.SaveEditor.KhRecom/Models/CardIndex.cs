using System;

namespace KHSave.SaveEditor.KhRecom.Models
{
    public struct CardIndex : IEquatable<CardIndex>, IEquatable<int>
    {
        private const int MaxValueCount = Constants.MaxCardValue - 1;
        private const int MinValueCount = 0;

        public CardIndex(int index)
        {
            if (index < MinValueCount || index > MaxValueCount)
                throw new ArgumentOutOfRangeException(nameof(index), $"Must be between {MinValueCount} and {MaxValueCount}");

            Index = (byte)index;
        }

        public byte Index { get; }

        public bool Equals(CardIndex otherCardIndex) => Index == otherCardIndex.Index;
        public bool Equals(int index) => Index == index;

        public static implicit operator int(CardIndex cardIndex) => cardIndex.Index;

        public static implicit operator CardIndex(int index) => new CardIndex(index);
    }
}
