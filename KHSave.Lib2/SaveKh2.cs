using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib2
{
    public class SaveKh2
    {
        [Data] public uint MagicCode { get; set; }
        [Data] public int Version { get; set; }

        public static bool IsValid(Stream stream)
        {
            var prevPosition = stream.Position;
            var magicCode = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            switch (magicCode)
            {
                case Constants.MagicCodeJp:
                case Constants.MagicCodeUs:
                case Constants.MagicCodeEu:
                    return true;
                default:
                    return false;
            }
        }
    }
}
