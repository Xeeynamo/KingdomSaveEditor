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

using KHSave.LibFf7Remake.Chunks;
using KHSave.LibFf7Remake.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake
{
    public class SaveFf7Remake
    {
        private static IBinaryMapping _mapping =
            MappingConfiguration.DefaultConfiguration()
            .Build();

        public const int Cloud = 0;
        public const int Barret = 1;
        public const int Tifa = 2;
        public const int Aerith = 3;
        public const int Red13 = 4;

        private SaveFf7Remake(List<Chunk> chunks)
        {
            Chunks = chunks.ToArray();
            _chunkCommon = ReadChunk<ChunkCommon>(0, 0);
            _chunkMirror = ReadChunk<ChunkMirror>(2, 0);
        }

        private ChunkCommon _chunkCommon;
        private ChunkMirror _chunkMirror;

        public Chunk[] Chunks { get; private set; }


        public Character[] Characters { get => _chunkCommon.Characters; set => _chunkCommon.Characters = value; }
        public Inventory[] Inventory { get => _chunkCommon.Inventory; set => _chunkCommon.Inventory = value; }
        public byte PlayableCharacter { get => _chunkCommon.PlayableCharacter; set => _chunkCommon.PlayableCharacter = value; }
        public byte CurrentChapter { get => _chunkCommon.CurrentChapter; set => _chunkCommon.CurrentChapter = value; }
        public Inventory[] InventoryMirror { get => _chunkCommon.Inventory; set => _chunkCommon.Inventory = value; }

        private T ReadChunk<T>(int type, int index)
            where T : class
        {
            var chunk = Chunks.FirstOrDefault(x =>
                x.Header.Unknown00 == type &&
                x.Header.Unknown01 == index);
            if (chunk == null)
                throw new ArgumentException($"Unable to find the chunk ({type}, {index}).");

            if (chunk.Content == null)
                throw new ArgumentException($"The chunk ({type}, {index}) does not contain any data.");

            using (var stream = new MemoryStream(chunk.Content.RawData))
                return BinaryMapping.ReadObject<T>(stream);
        }

        public static bool IsValid(Stream stream)
        {
            stream.Position = 0x10;
            return stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44 &&
                stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44 &&
                stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44 &&
                stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44;
        }

        public static SaveFf7Remake Read(Stream stream)
        {
            var chunks = new List<Chunk>();
            stream.SetPosition(0);

            while (true)
            {
                var chunk = Chunk.Read(stream);
                chunks.Add(chunk);
                if (chunk.IsLastChunk)
                    break;
            }

            return new SaveFf7Remake(chunks);
        }

        public SaveFf7Remake Write(Stream stream)
        {
            foreach (var chunk in Chunks)
                chunk.Write(stream);

            return this;
        }
    }
}
