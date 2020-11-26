using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.Lib2
{
    public partial class SaveKh2
    {
        internal static IBinaryMapping Mapper;

        static SaveKh2()
        {
            Mapper = MappingConfiguration
                .DefaultConfiguration()
                .ForType<TimeSpan>(
                    x => new TimeSpan(0, 0, 0, x.Reader.ReadInt32(), 0),
                    x => x.Writer.Write((int)((TimeSpan)x.Item).TotalSeconds)
                )
                .Build();
        }

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
                case GameVersion.American:
                case GameVersion.FinalMix:
                    return (GameVersion)version;
                default:
                    return null;
            }
        }

        private static TSaveKh2 Read<TSaveKh2>(Stream stream)
            where TSaveKh2 : class, ISaveKh2 =>
            BinaryMapping.ReadObject<TSaveKh2>(stream.FromBegin());

        public static ISaveKh2 Read(Stream stream)
        {
            switch (GetGameVersion(stream))
            {
                case GameVersion.Japanese:
                    throw new NotImplementedException("Japanese save file is not yet supported.");
                case GameVersion.American:
                    return Read<SaveEuropean>(stream);
                case GameVersion.FinalMix:
                    return Read<SaveFinalMix>(stream);
                case null:
                    throw new NotImplementedException("An invalid version has been specified.");
                default:
                    throw new NotImplementedException("The version has been recognized but it is not supported.");
            }
        }

        public static void Write<TSaveKh2>(Stream stream, TSaveKh2 save)
            where TSaveKh2 : class, ISaveKh2
        {
            uint checksum;
            using (var tempStream = new MemoryStream())
            {
                save.Write(tempStream);
                var rawData = tempStream.SetPosition(0xc).ReadBytes();
                checksum = CalculateChecksum(tempStream.FromBegin().ReadBytes(8), 8, uint.MaxValue);
                checksum = CalculateChecksum(rawData, rawData.Length, checksum ^ uint.MaxValue);
            }

            save.Checksum = checksum;
            save.Write(stream.FromBegin());
        }

        private const int CrcPolynomial = 0x04c11db7;
        private static uint[] crc_table = GetCrcTable(CrcPolynomial)
                .Take(0x100)
                .ToArray();

        public static uint CalculateChecksum(byte[] data, int offset, uint checksum)
        {
            for (var i = 0; i < offset; i++)
                checksum = crc_table[(checksum >> 24) ^ data[i]] ^ (checksum << 8);

            return checksum ^ uint.MaxValue;
        }

        private static IEnumerable<uint> GetCrcTable(int polynomial)
        {
            for (var x = 0; ; x++)
            {
                var r = x << 24;
                for (var j = 0; j < 0xff; j++)
                    r = r << 1 ^ (r < 0 ? polynomial : 0);
                yield return (uint)r;
            }
        }
    }
}
