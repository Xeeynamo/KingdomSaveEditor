/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.Archives
{
    internal class Ps4SaveArchive : IArchive
    {
        private const int Alignment = 0x400;

        public class Entry : IArchiveEntry
        {
            [Data(Count = 0x40)] public string Name { get; set; }
            [Data(0x40)] public DateTime DateCreated { get; set; }
            [Data(0x48)] public DateTime DateModified { get; set; }
            [Data(0x50)] public long Length { get; set; }
            public byte[] Data { get; set; }
        }

        private readonly int _stride;

        internal Ps4SaveArchive(int entryCount, int stride)
        {
            MaxEntryCount = entryCount;
            _stride = stride;
            Entries = new List<IArchiveEntry>(MaxEntryCount);
        }

        private Ps4SaveArchive(Stream stream, int entryCount, int stride)
        {
            MaxEntryCount = entryCount;
            _stride = stride;
            var entries = Enumerable.Range(0, entryCount)
                .Select(x => BinaryMapping.ReadObject<Entry>(stream, (int)stream.Position))
                .ToArray();

            var baseOffset = stream.Position;
            foreach (var entry in entries)
            {
                stream.Position = baseOffset;
                entry.Data = new byte[entry.Length];
                stream.Read(entry.Data, 0, (int)entry.Length);

                baseOffset += _stride;
            }

            Entries = entries;
        }

        public string Name { get; internal set; } = "PS4 Save Archive";
        public int MaxEntryCount { get; }
        public IList<IArchiveEntry> Entries { get; }

        public void Write(Stream stream)
        {
            var entries = Entries
                .Select(x => new Entry
                {
                    Name = x.Name,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    Length = x.Data.Length,
                    Data = x.Data
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
            foreach (var entry in entries)
            {
                BinaryMapping.WriteObject(stream, entry, (int)stream.Position);
            }

            var baseOffset = (int)stream.Position;
            foreach (var entry in entries)
            {
                stream.Position = baseOffset;
                baseOffset += _stride;

                stream.Write(entry.Data, 0, (int)entry.Length);

                var padding = _stride - entry.Length;
                while (--padding > 0)
                    stream.WriteByte(0);
            }

            stream.SetLength(baseOffset + Alignment - (baseOffset % Alignment));
        }

        public static Ps4SaveArchive Read(Stream stream, int entryCount, int stride) =>
            new Ps4SaveArchive(stream, entryCount, stride);
    }
}
