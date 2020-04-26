using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib1
{
    public partial class SaveKh1
    {
        [Data] public uint MagicCode { get; set; }

        public static bool IsValid(Stream stream)
        {
            var prevPosition = stream.Position;
            var magicCode = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            switch (magicCode)
            {
                case Constants.MagicCodeFm:
                case Constants.MagicCodeEverythingElse:
                    return true;
                default:
                    return false;
            }
        }

        public static uint GetGameVersion(Stream stream)
        {
            if (!IsValid(stream))
                return 0;

            var prevPosition = stream.Position;
            stream.Position = 0;
            var version = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            return version;
        }

        public static TSaveKh1 Read<TSaveKh1>(Stream stream)
            where TSaveKh1 : class, ISaveKh1 =>
            BinaryMapping.ReadObject<TSaveKh1>(stream.SetPosition(0));

        public static void Write<TSaveKh1>(Stream stream, TSaveKh1 save)
            where TSaveKh1 : class, ISaveKh1 =>
            BinaryMapping.WriteObject(stream.FromBegin(), save);
    }
}
