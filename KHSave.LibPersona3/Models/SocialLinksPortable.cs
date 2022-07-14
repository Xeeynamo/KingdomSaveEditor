using Xe.BinaryMapper;

namespace KHSave.LibPersona3.Models
{
    public enum SocialLinkArcanaPortable
    {
        Empty,
        Fool,
        Magician,
        Emperor,
        Hiero,
        Lovers,
        Priestess,
        Empress,
        Aeon,
        Hermit_HealthCommittee,
        Hermit_Librarian,
        Chariot_Volleyball,
        Chariot_Tennis,
        Strength,
        Fortune_LoveRoute,
        Fortune,
        Justice_LoveRoute,
        Justice,
        Hanged,
        Death,
        Temper,
        Devil,
        Tower,
        Star_LoveRoute,
        Star,
        Sun,
        Judgement,
        Moon,
    }

    public record SocialLinksPortable
    {
        public record Entry
        {
            [Data] public short Arcana { get; set; }
            [Data] public short Rank { get; set; }
            [Data] public short Points { get; set; }
            [Data] public short Unk06 { get; set; }
            [Data] public short Unk08 { get; set; }
            [Data] public short Unk0A { get; set; }
            [Data] public short Unk0C { get; set; }
            [Data] public short Unk0E { get; set; }
        }

        public record RankHistoryEntry
        {
            [Data] public byte Month { get; set; }
            [Data] public byte Day { get; set; }
        }

        public record RankHistory
        {
            [Data(Count = 11)] public RankHistoryEntry[] History { get; set; }
        }

        [Data] public int Unk08 { get; set; }
        [Data] public int Unk0C { get; set; }
        [Data(Count = 0x1C, Stride = 0x10)] public Entry[] Entries { get; set; }
        [Data(Count = 0x1C, Stride = 0x16)] public RankHistory[] History { get; set; }
    }
}
