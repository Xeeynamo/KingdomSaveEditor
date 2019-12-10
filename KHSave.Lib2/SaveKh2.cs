using System.Collections.Generic;
﻿using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.Lib2
{
    public partial class SaveKh2
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

        public static TSaveKh2 Read<TSaveKh2>(Stream stream)
            where TSaveKh2 : class, ISaveKh2 =>
            BinaryMapping.ReadObject<TSaveKh2>(stream.SetPosition(0));

        public static void Write<TSaveKh2>(Stream stream, TSaveKh2 save)
            where TSaveKh2 : class, ISaveKh2
        {
            uint checksum;
            using (var tempStream = new MemoryStream())
            {
                BinaryMapping.WriteObject(tempStream, save);
                var rawData = tempStream.SetPosition(0x10).ReadBytes();
                checksum = CalculateChecksum(rawData, rawData.Length);
            }

            save.Checksum = checksum;
            BinaryMapping.WriteObject(stream.FromBegin(), save);
        }

        private const int CrcPolynomial = 0x04c11db7;
        private static uint[] crc_table = GetCrcTable(CrcPolynomial)
                .Take(0x100)
                .ToArray();

        public static uint CalculateChecksum(byte[] data, int offset)
        {
            var checksum = uint.MaxValue;
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
