using System.IO;
using Xe.BinaryMapper;

namespace KHSave.LibBbs
{
    public partial class SaveKhBbs
    {
        public static bool IsValid(Stream stream)
        {
            var prevPosition = stream.Position;
            var magicCode = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            return magicCode == Constants.MagicCode;
        }

        public static GameVersion? GetGameVersion(Stream stream)
        {
            if (!IsValid(stream))
                return null;

            var prevPosition = stream.Position;
            stream.Position = 4;
            var version = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            switch ((GameVersion)version)
            {
                case GameVersion.Japanese:
                case GameVersion.AmericanEuropean:
                case GameVersion.FinalMix:
                    return (GameVersion)version;
                default:
                    return null;
            }
        }

        public static TSaveKhBbs Read<TSaveKhBbs>(Stream stream)
            where TSaveKhBbs : class, ISaveKhBbs =>
            BinaryMapping.ReadObject<TSaveKhBbs>(stream.SetPosition(0));

        public static void Write<TSaveKhBbs>(Stream stream, TSaveKhBbs save)
            where TSaveKhBbs : class, ISaveKhBbs
        {
            uint checksum;
            using (var tempStream = new MemoryStream())
            {
                BinaryMapping.WriteObject(tempStream, save);
                checksum = CalculateChecksum(tempStream);
            }

            save.Checksum = checksum;
            BinaryMapping.WriteObject(stream.FromBegin(), save);
        }


        public static uint CalculateChecksum(Stream stream)
        {
            uint checksum = 0;
            using (BinaryReader reader = new BinaryReader(stream))
            {
                reader.BaseStream.Seek(0x10, SeekOrigin.Begin);
                for (int i = 0; i < reader.BaseStream.Length / 4 - 4; i++)
                    checksum += reader.ReadUInt32();
            }
            return checksum;
        }
    }
}
