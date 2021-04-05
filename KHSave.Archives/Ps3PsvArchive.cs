// https://github.com/PMStanley/PSV-Exporter/blob/master/PSVFormat.pas

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.Archives
{
    public class Ps3PsvArchive : IArchive
    {
        private class Header
        {
            [Data] public uint Magic { get; set; }
            [Data] public int Padding { get; set; }
            [Data(Count = 0x14)] public byte[] KeySeed { get; set; }
            [Data(Count = 0x14)] public byte[] Signature { get; set; }
            [Data(Count = 8)] public byte[] Padding2 { get; set; }
            [Data] public int HeaderSize { get; set; }
            [Data] public int SaveType { get; set; }
        }
        private class Ps2Header
        {
            [Data] public int DisplaySize { get; set; }
            [Data] public int SysPos { get; set; }
            [Data] public int SysSize { get; set; }
            [Data] public int Icon1Pos { get; set; }
            [Data] public int Icon1Size { get; set; }
            [Data] public int Icon2Pos { get; set; }
            [Data] public int Icon2Size { get; set; }
            [Data] public int Icon3Pos { get; set; }
            [Data] public int Icon3Size { get; set; }
            [Data] public int NumFiles { get; set; }
        }
        private class Ps2MainDirInfo
        {
            [Data] public sceMcStDateTime Created { get; set; }
            [Data] public sceMcStDateTime Modified { get; set; }
            [Data] public int NumFilesInDir { get; set; }
            [Data] public int Attr { get; set; }
            [Data(Count = 32)] public string Name { get; set; }
        }
        private class Ps2FileEntry : IArchiveEntry
        {
            [Data] public sceMcStDateTime Created { get; set; }
            [Data] public sceMcStDateTime Modified { get; set; }
            [Data] public int Size { get; set; }
            [Data] public int Attr { get; set; }
            [Data(Count = 32)] public string Name { get; set; }
            [Data] public int Offset { get; set; }
            
            public byte[] Data { get; set; }

            public DateTime DateCreated { get => Map(Created); set => throw new NotImplementedException(); }
            public int FlagCreated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public DateTime DateModified { get => Map(Modified); set => throw new NotImplementedException(); }
            public int FlagModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            private static DateTime Map(sceMcStDateTime date) => new(date.Year, date.Month, date.Day, date.Hour, date.Min, date.Sec);
        }

        internal Ps3PsvArchive()
        {
            Entries = new List<IArchiveEntry>(MaxEntryCount);
        }

        private Ps3PsvArchive(Stream stream)
        {
            Entries = new List<IArchiveEntry>(MaxEntryCount);

            var header = BinaryMapping.ReadObject<Header>(stream);

            //psv could also store ps1 saves
            //i'm ignoring that fact right now and only implement the ps2 side
            if (header.SaveType == 1)
                return;

            var ps2Header = BinaryMapping.ReadObject<Ps2Header>(stream);
            stream.Position += 0x38;

            var entries = Enumerable.Range(0, ps2Header.NumFiles)
                .Select(x => BinaryMapping.ReadObject<Ps2FileEntry>(stream, (int)stream.Position))
                .ToArray();

            foreach(var entry in entries)
            {
                stream.Position = entry.Offset;
                entry.Data = new byte[entry.Size];
                stream.Read(entry.Data, 0, entry.Size);
            }

            Entries = entries;
        }

        public string Name => "PS3 PSV";

        public int MaxEntryCount { get; }

        public IList<IArchiveEntry> Entries { get; }

        public void Write(Stream stream)
        {
            throw new NotImplementedException();
        }

        public static Ps3PsvArchive Read(Stream stream) =>
            new Ps3PsvArchive(stream);
    }
}
