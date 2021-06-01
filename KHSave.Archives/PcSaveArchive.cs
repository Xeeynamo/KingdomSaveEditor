using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.Archives
{
    internal class PcSaveArchive : IArchive
    {
        public class Entry : IArchiveEntry
        {
            private static readonly long UnixTimeBase = new DateTime(1970, 1, 1).Ticks;

            [Data(Count = 0x40)] public string Name { get; set; }
            [Data(0x40)] public int RawDateCreated { get; set; }
            [Data(0x44)] public int FlagCreated { get; set; }
            [Data(0x48)] public int RawDateModified { get; set; }
            [Data(0x4c)] public int FlagModified { get; set; }
            [Data(0x50)] public int Length { get; set; }
            [Data(0x54)] public int SomeKindOfFlag { get; set; }
            [Data(0x58, Count = 0x100)] public byte[] Padding { get; set; }

            public DateTime DateCreated { get => Map(RawDateCreated); set => RawDateCreated = Map(value); }
            public DateTime DateModified { get => Map(RawDateModified); set => RawDateModified = Map(value); }

            public byte[] Data { get; set; }

            private static DateTime Map(int ticks) => new DateTime(ticks * TimeSpan.TicksPerSecond + UnixTimeBase);
            private static int Map(DateTime dateTime) => (int)((dateTime.Ticks - UnixTimeBase) / TimeSpan.TicksPerSecond);
        }

        private const int PngHeaderLength = 0x70;
        private const int EncryptedLength = 0xF0;
        private const int KeyLength = 0x10;
        private const int KeyOffset = EncryptedLength - KeyLength;
        private const int EntryLength = 0x158;

        private readonly int _stride;
        private readonly byte[] _encryptionKey;

        private byte[] _pngHeader;
        private byte[] _pngFooter;

        internal PcSaveArchive(int entryCount, int stride)
        {
            MaxEntryCount = entryCount;
            _stride = stride;
            _encryptionKey = new byte[KeyLength];
            Entries = new List<IArchiveEntry>(MaxEntryCount);
        }

        private PcSaveArchive(Stream stream, int entryCount, int stride)
        {
            MaxEntryCount = entryCount;
            _stride = stride;

            _pngHeader = new byte[PngHeaderLength];
            stream.Read(_pngHeader);

            var entryData = new byte[entryCount * EntryLength];
            stream.Read(entryData);

            _encryptionKey = new byte[KeyLength];
            Array.Copy(entryData, KeyOffset, _encryptionKey, 0, KeyLength);
            for (var i = 0; i < EncryptedLength; i++)
                entryData[i] ^= _encryptionKey[i & 15];

            var entryStream = new MemoryStream(entryData);
            Entries = Enumerable.Range(0, entryCount)
                .Select(i => BinaryMapping.ReadObject<Entry>(entryStream, i * EntryLength))
                .ToArray();

            var baseOffset = stream.Position;
            foreach (var entry in Entries.Cast<Entry>())
            {
                entry.Data = new byte[entry.Length];
                stream.Read(entry.Data, 0, entry.Length);

                baseOffset += _stride;
                stream.Position = baseOffset;
            }

            var remainingByteCount = stream.Length - stream.Position;
            _pngFooter = new byte[remainingByteCount];
            stream.Read(_pngFooter);
        }

        public string Name { get; internal set; } = "Kingdom Hearts PC Save Archive";
        public int MaxEntryCount { get; }
        public IList<IArchiveEntry> Entries { get; }

        public void Write(Stream stream)
        {
            var entries = Entries
                .Select(x => new Entry
                {
                    Name = x.Name,
                    DateCreated = x.DateCreated,
                    FlagCreated = x.FlagCreated,
                    DateModified = x.DateModified,
                    FlagModified = x.FlagModified,
                    Length = x.Data.Length,
                    Data = x.Data,
                    Padding = new byte[0x100]
                })
            .Take(MaxEntryCount)
            .ToList();

            while (entries.Count < MaxEntryCount)
                entries.Add(new Entry
                {
                    Name = string.Empty,
                    Data = new byte[0]
                });

            stream.Position = 0;
            stream.Write(_pngHeader);

            var entryData = new byte[entries.Count * EntryLength];
            using var entryStream = new MemoryStream(entryData);
            foreach (var entry in entries)
                BinaryMapping.WriteObject(entryStream, entry, (int)entryStream.Position);

            for (var i = 0; i < EncryptedLength; i++)
                entryData[i] ^= _encryptionKey[i & 15];
            stream.Write(entryData);

            var baseOffset = (int)stream.Position;
            foreach (var entry in entries)
            {
                stream.Write(entry.Data, 0, (int)entry.Length);

                var padding = _stride - entry.Length;
                while (--padding > 0)
                    stream.WriteByte(0);

                baseOffset += _stride;
                stream.Position = baseOffset;
            }

            stream.Write(_pngFooter);
        }

        public static PcSaveArchive Read(Stream stream, int entryCount, int stride) =>
            new PcSaveArchive(stream, entryCount, stride);
    }
}
