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
