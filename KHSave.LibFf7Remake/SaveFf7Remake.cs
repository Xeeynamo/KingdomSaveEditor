/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

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
        public const bool _EnableLastChapter = false;
        public const int ChapterCount = 18;
        public const int CharacterCount = 8;
        public const int Cloud = 0;
        public const int Barret = 1;
        public const int Tifa = 2;
        public const int Aerith = 3;
        public const int Red13 = 4;
        public const int Unequipped = 9;

        private SaveFf7Remake(List<Chunk> chunks)
        {
            Chunks = chunks.ToArray();
            if (_EnableLastChapter)
                Chapters = new ChunkChapter[ChapterCount + 1];
            else
                Chapters = new ChunkChapter[ChapterCount];
            ReimportChunks();
        }

        public SaveFf7Remake Write(Stream stream)
        {
            for (int i = 0, index = 0; i < Materia.Length; i++)
            {
                if (Materia[i].Type != Types.InventoryType.Empty)
                {
                    Materia[i].IsObtained = 1;
                    Materia[i].Index = ++index;
                }
                else
                    Materia[i].IsObtained = 0;
            }

            WriteChunk(_chunkCommon, 0, 0);
            for (var i = 0; i < ChapterCount; i++)
                WriteChunk(Chapters[i], 1, i);
            if (_EnableLastChapter)
                WriteChunk(Chapters[ChapterCount], 3);

            foreach (var chunk in Chunks)
                chunk.Write(stream);

            return this;
        }

        private ChunkCommon _chunkCommon;

        public Chunk[] Chunks { get; private set; }

        public Character[] Characters { get => _chunkCommon.Characters; set => _chunkCommon.Characters = value; }
        public CharacterStats[] CharactersStats { get => _chunkCommon.CharactersStats; set => _chunkCommon.CharactersStats = value; }
        public CharacterEquipment[] CharactersEquipment { get => _chunkCommon.CharactersEquipment; set => _chunkCommon.CharactersEquipment = value; }
        public Materia[] Materia { get => _chunkCommon.Materia; set => _chunkCommon.Materia = value; }
        public Inventory[] Inventory { get => _chunkCommon.Inventory; set => _chunkCommon.Inventory = value; }
        public MateriaEquipment[] CharacterMateria { get => _chunkCommon.CharacterMateria; set => _chunkCommon.CharacterMateria = value; }
        public MateriaEquipment[] WeaponMateria { get => _chunkCommon.WeaponMateria; set => _chunkCommon.WeaponMateria = value; }
        public byte PlayableCharacter { get => _chunkCommon.PlayableCharacter; set => _chunkCommon.PlayableCharacter = value; }
        public byte CurrentChapter { get => _chunkCommon.CurrentChapter; set => _chunkCommon.CurrentChapter = value; }
        public int[] SummonMateria { get => _chunkCommon.SummonMateria; set => _chunkCommon.SummonMateria = value; }
        public ChunkChapter[] Chapters { get; set; }

        public void ReimportChunks()
        {
            _chunkCommon = ReadChunk<ChunkCommon>(0, 0);
            for (var i = 0; i < ChapterCount; i++)
            {
                var chapter = ReadChunk<ChunkChapter>(1, i);
                if (chapter == null)
                    chapter = new ChunkChapter();

                Chapters[i] = chapter;
            }

            if (_EnableLastChapter)
                Chapters[ChapterCount] = ReadChunk<ChunkChapter>(3);
        }

        private Chunk GetChunk(int type, int index = -1)
        {
            var chunk = Chunks.FirstOrDefault(x =>
                x.Header.Unknown00 == type &&
                (index == -1 || x.Header.Unknown01 == index));
            if (chunk == null)
                throw new ArgumentException($"Unable to find the chunk ({type}, {index}).");

            if (chunk.Content == null)
                throw new ArgumentException($"The chunk ({type}, {index}) does not contain any data.");

            return chunk;
        }

        private T ReadChunk<T>(int type, int index = -1)
            where T : class
        {
            var chunk = GetChunk(type, index);
            if (chunk.Content.RawData.Length == 0)
                return default(T);

            using (var stream = new MemoryStream(chunk.Content.RawData))
                return BinaryMapping.ReadObject<T>(stream);
        }

        private void WriteChunk<T>(T item, int type, int index = -1)
            where T : class
        {
            var chunk = GetChunk(type, index);
            using (var stream = new MemoryStream())
            {
                BinaryMapping.WriteObject(stream, item);
                chunk.Content.RawData = stream.GetBuffer();
            }
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
    }
}
