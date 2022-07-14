using Xe.BinaryMapper;

namespace KHSave.LibPersona3.Models
{
    public enum SocialLinkArcana
    {
        Fool,
        Magician,
        Priestess_Beta,
        Empress_Beta,
        Emperor,
        Hiero,
        Lovers,
        Priestess,
        Empress,
        Lovers_Beta,
        Strength,
        Justice,
        Chariot_TrackTeam,
        Chariot_KendoTeam,
        Chariot_SwimTeam,
        Justice_Beta,
        Hermit,
        Fortune_PhotographyClub,
        Fortune_ArtClub,
        Fortune_MusicClub,
        Strenght_Beta,
        Hanged,
        Death,
        Temper,
        Devil,
        Tower,
        Star,
        Moon,
        Sun,
        Judgement,
    }

    public record SocialLinks
    {
        public record Unk
        {
            [Data] public int Unk00 { get; set; }
            [Data] public int Unk04 { get; set; }
        }


        private const int SL_Num = 30;

        [Data] public short Flag { get; set; } // word_859574 (flags, max 0xFF)
        [Data(Count = SL_Num)] public byte[] Ranks { get; set; } // byte_859576 (min 0, max 10)
        [Data(Count = SL_Num)] public int[] RankData { get; set; } // //dword_859594[30] ?
        [Data(Count = SL_Num)] public byte[] dword_859594 { get; set; } //byte_85960C[30] (min 0, max 9)
        [Data(Count = SL_Num)] public short[] word_85962A { get; set; } //word_85962A[30] (min 0, max 360)
        [Data(Count = SL_Num)] public short[] word_859666 { get; set; } //word_859666[30] (min 0, max 360)
        [Data(Count = SL_Num)] public short[] word_8596A2 { get; set; } //word_8596A2[30] (min 0, max 360)
        [Data(Count = 0x7A)] public byte[] unused_16A { get; set; }
        [Data] public int dword_859758 { get; set; } // dword_859758
        [Data] public int unused_1E8 { get; set; }
        [Data] public byte byte_859760 { get; set; } // byte_859760 (always 0?)
        [Data] public byte unused_1ED { get; set; }
        [Data] public short unused_1EE { get; set; }
        [Data] public int unused_1F0 { get; set; }
        [Data] public int dword_859768 { get; set; } //dword_859768 (either 0 or 1)
        [Data(Count = 0x10)] public byte[] unused_1F8 { get; set; }
        [Data] public byte byte_85977C { get; set; } //byte_85977C (never set?)
        [Data] public byte unused_209 { get; set; }
        [Data] public short unused_20A { get; set; }
        [Data] public byte byte_859790 { get; set; } //byte_859790 (always 1?)
        [Data] public byte unused_20D { get; set; }
        [Data] public short word_859792 { get; set; } //word_859792 (always 0?)
        [Data] public int word_859794 { get; set; } //word_859794 (copied from word_859A9C?)
        [Data(Count = 9)] public int[] dword_859798 { get; set; } //dword_859798[9] (?)
        [Data(Count = 7, Stride = 8)] public Unk[] byte_8597BC { get; set; } //byte_8597BC[7][8]
        [Data(Count = 0x40)] public int[] dword_8597F4 { get; set; } //dword_8597F4[0x40]
        [Data(Count = 0x40)] public int[] dword_8598F4 { get; set; } //dword_8598F4[0x40]
        [Data(Count = 0x40)] public byte[] byte_8599F4 { get; set; } //byte_8599F4[0x40]
        [Data(Count = SL_Num)] public byte[] byte_859A34 { get; set; } //byte_859A34[30]
        [Data(Count = SL_Num)] public byte[] byte_859A52 { get; set; } //byte_859A52[30]
        [Data(Count = 8)] public byte[] byte_859A70 { get; set; } //byte_859A70[8]

    }
}
