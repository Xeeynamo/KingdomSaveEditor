// https://github.com/root670/PS2SaveUtility/blob/master/src/PSUFile.cpp

using System;
using System.Collections.Generic;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Archives
{
    public class Ps2PsuArchive : IArchive
    {
        private const int Alignment = 1024;

        public class Entry : IArchiveEntry
        {
            [Data] public uint Mode { get; set; }
            [Data] public uint Length { get; set; }
            [Data] public sceMcStDateTime Created { get; set; }
            [Data] public uint Cluster { get; set; }
            [Data] public uint DirIndex { get; set; }
            [Data] public sceMcStDateTime Modified { get; set; }
            [Data] public uint Attr { get; set; }
            [Data(Count = 28)] public byte[] Padding { get; set; }
            [Data(Count = 32)] public string Name { get; set; }
            [Data(Count = 0x1A0)] public byte[] Padding2 { get; set; }

            public byte[] Data { get; set; }

            public DateTime DateCreated { get => Map(Created); set => throw new NotImplementedException(); }
            public int FlagCreated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public DateTime DateModified { get => Map(Modified); set => throw new NotImplementedException(); }
            public int FlagModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            private static DateTime Map(sceMcStDateTime date) => new(date.Year, date.Month, date.Day, date.Hour, date.Min, date.Sec);
        }

        internal Ps2PsuArchive(int entryCount)
        {
            MaxEntryCount = entryCount;
            Entries = new List<IArchiveEntry>(MaxEntryCount);
        }

        private Ps2PsuArchive(Stream stream, int entryCount)
        {
            MaxEntryCount = entryCount;
            Entries = new List<IArchiveEntry>(MaxEntryCount);

            var header = BinaryMapping.ReadObject<Entry>(stream);
            for (int i = 0; i < header.Length; i++)
            {
                var file = BinaryMapping.ReadObject<Entry>(stream);
                file.Data = new byte[file.Length];
                stream.Read(file.Data, 0, (int)file.Length);

                var offset_shift = file.Length % Alignment;
                var pos2 = offset_shift > 0 ? stream.Position + Alignment - offset_shift : stream.Position;

                stream.Position = pos2;

                Entries.Add(file);
            }
        }

        public string Name => "PS2 PSU Archive";

        public int MaxEntryCount { get; }

        public IList<IArchiveEntry> Entries { get; }

        public void Write(Stream stream)
        {
            throw new NotImplementedException();
        }

        public static Ps2PsuArchive Read(Stream stream, int entryCount) =>
            new Ps2PsuArchive(stream, entryCount);
    }

    public class sceMcStDateTime
    {
        [Data] public byte Resv2 { get; set; }
        [Data] public byte Sec { get; set; }
        [Data] public byte Min { get; set; }
        [Data] public byte Hour { get; set; }
        [Data] public byte Day { get; set; }
        [Data] public byte Month { get; set; }
        [Data] public ushort Year { get; set; }
    }
}
