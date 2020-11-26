using System;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.LibDDD
{
    public partial class SaveKhDDD
    {
        internal static IBinaryMapping Mapper;

        public static bool IsValid(Stream stream)
        {
            var prevPosition = stream.Position;
            var magicCode = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            switch (magicCode)
            {
                case Constants.MagicCode3DSEu:
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

        public static TSaveKhDDD Read<TSaveKhDDD>(Stream stream)
            where TSaveKhDDD : class, ISaveKhDDD =>
            BinaryMapping.ReadObject<TSaveKhDDD>(stream.SetPosition(0));

        public static ISaveKhDDD Read(Stream stream)
        {
            switch (GetGameVersion(stream))
            {
                case Constants.MagicCode3DSEu:
                    return Read<SaveKhDDD3DS>(stream);
                default:
                    throw new NotSupportedException("The version is not supported.");
            }
        }

        public static void Write<TSaveKhDDD>(Stream stream, TSaveKhDDD save)
            where TSaveKhDDD : class, ISaveKhDDD
        {
            BinaryMapping.WriteObject(stream.FromBegin(), save);
        }
    }
}
