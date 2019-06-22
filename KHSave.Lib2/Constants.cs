namespace KHSave.Lib2
{
    internal class Constants
    {
        public const uint MagicCodeJp = 0x4B48324A;
        public const uint MagicCodeUs = 0x4B483255;
        public const uint MagicCodeEu = 0x4B483245;
    }

    public enum GameVersion
    {
        Japanese = 0x2a,
        American = 0x2d,
        FinalMix = 0x3a
    }
}
