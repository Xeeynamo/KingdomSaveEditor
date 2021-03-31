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

        private const string _hiddenEntryName = "NONAME";

        private readonly int _stride;

        private byte[] _pngHeader;
        private byte[] _pngFooter;

        internal PcSaveArchive(int entryCount, int stride)
        {
            MaxEntryCount = entryCount;
            _stride = stride;
            Entries = new List<IArchiveEntry>(MaxEntryCount);
        }

        private PcSaveArchive(Stream stream, int entryCount, int stride)
        {
            MaxEntryCount = entryCount;
            _stride = stride;

            _pngHeader = new byte[0x1C8];
            stream.Read(_pngHeader, 0, 0x1C8);

            var entries = Enumerable.Range(0, (entryCount - 1))
                .Select(x => BinaryMapping.ReadObject<Entry>(stream, (int)stream.Position))
                .ToList();

            //if you open an empty save file, there's also no data in here
            //need to check this better
            var hiddenEntry = new Entry()
            {
                Name = _hiddenEntryName,
            };

            hiddenEntry.Data = new byte[_stride];
            stream.Read(hiddenEntry.Data, 0, _stride);

            var baseOffset = stream.Position;
            foreach (var entry in entries)
            {
                entry.Data = new byte[entry.Length];
                stream.Read(entry.Data, 0, (int)entry.Length);

                baseOffset += _stride;
                stream.Position = baseOffset;
            }
            entries.Insert(0, hiddenEntry);

            Entries = entries.ToArray();

            var len = stream.Length - stream.Position;

            _pngFooter = new byte[len];
            stream.Read(_pngFooter, 0, (int)len);
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
            foreach (var entry in entries)
            {
                if (entry.Name == _hiddenEntryName)
                    continue;

                BinaryMapping.WriteObject(stream, entry, (int)stream.Position);
            }

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
