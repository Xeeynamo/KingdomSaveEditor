namespace KHSave.Lib2
{
    internal class Constants
    {
        public const uint MagicCodeJp = 0x4a32484b;
        public const uint MagicCodeUs = 0x5532484b;
        public const uint MagicCodeEu = 0x4532484b;

        public const int WorldCount = 19;
    }

    public enum GameVersion
    {
        Japanese = 0x2a,
        American = 0x2d,
        FinalMix = 0x3a
    }
}
