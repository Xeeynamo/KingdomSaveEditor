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
        public const int ChapterCount = 18;
        public const int CharacterCount = 8;
        public const int Cloud = 0;
        public const int Barret = 1;
        public const int Tifa = 2;
        public const int Aerith = 3;
        public const int Red13 = 4;
        public const int Yuffie = 5;
        public const int Sonon = 6;
        public const int LastKnownCharacter = Sonon;
        public const int Unequipped = 9;

        private SaveFf7Remake(List<Chunk> chunks)
        {
            Chunks = chunks.ToArray();
            Chapters = new ChunkChapter[21];
            ReimportChunks();
        }

        public SaveFf7Remake Write(Stream stream)
        {
            WriteChunk(ChunkCommon, 0);
            WriteChunk(Chapters[0], 1);
            WriteChunk(Chapters[1], 2);
            WriteChunk(Chapters[2], 3);
            WriteChunk(Chapters[3], 4);
            WriteChunk(Chapters[4], 5);
            WriteChunk(Chapters[5], 6);
            WriteChunk(Chapters[6], 7);
            WriteChunk(Chapters[7], 8);
            WriteChunk(Chapters[8], 9);
            WriteChunk(Chapters[9], 10);
            WriteChunk(Chapters[10], 11);
            WriteChunk(Chapters[11], 12);
            WriteChunk(Chapters[12], 13);
            WriteChunk(Chapters[13], 14);
            WriteChunk(Chapters[14], 15);
            WriteChunk(Chapters[15], 16);
            WriteChunk(Chapters[16], 17);
            WriteChunk(Chapters[17], 18);
            WriteChunk(ChunkCommonPrev, 19);
            WriteChunk(Chapters[18], 20);
            WriteChunk(Chapters[19], 21);
            WriteChunk(Chapters[20], 22);

            foreach (var chunk in Chunks)
                chunk.Write(stream);

            return this;
        }

        public ChunkCommon ChunkCommon { get; private set; }
        public ChunkCommon ChunkCommonPrev { get; private set; }

        public Chunk[] Chunks { get; private set; }

        public byte CurrentChapterChunk { get => ChunkCommon.CurrentChapterChunk; set => ChunkCommon.CurrentChapterChunk = value; }
        public byte CurrentChapterId { get => ChunkCommon.CurrentChapterId; set => ChunkCommon.CurrentChapterId = value; }
        public byte CurrentChapterChunk2 { get => ChunkCommon.CurrentChapterChunk2; set => ChunkCommon.CurrentChapterChunk2 = value; }
        public Character[] Characters { get => ChunkCommon.Characters; set => ChunkCommon.Characters = value; }
        public CharacterStats[] CharactersStats { get => ChunkCommon.CharactersStats; set => ChunkCommon.CharactersStats = value; }
        public CharacterEquipment[] CharactersEquipment { get => ChunkCommon.CharactersEquipment; set => ChunkCommon.CharactersEquipment = value; }
        public Materia[] Materia { get => ChunkCommon.Materia; set => ChunkCommon.Materia = value; }
        public Inventory[] Inventory { get => ChunkCommon.Inventory; set => ChunkCommon.Inventory = value; }
        public MateriaEquipment[] CharacterMateria { get => ChunkCommon.CharacterMateria; set => ChunkCommon.CharacterMateria = value; }
        public MateriaEquipment[] WeaponMateria { get => ChunkCommon.WeaponMateria; set => ChunkCommon.WeaponMateria = value; }
        public WeaponFound[] WeaponFound { get => ChunkCommon.WeaponFound; set => ChunkCommon.WeaponFound = value; }
        public byte PlayableCharacter { get => ChunkCommon.PlayableCharacter; set => ChunkCommon.PlayableCharacter = value; }
        public byte CurrentChapter { get => ChunkCommon.CurrentChapter; set => ChunkCommon.CurrentChapter = value; }
        public int[] SummonMateria { get => ChunkCommon.SummonMateria; set => ChunkCommon.SummonMateria = value; }
        public ChunkChapter[] Chapters { get; set; }

        public void ReimportChunks()
        {
            ChunkCommon = ReadChunk<ChunkCommon>(0);
            Chapters[0] = ReadChunk<ChunkChapter>(1);
            Chapters[1] = ReadChunk<ChunkChapter>(2);
            Chapters[2] = ReadChunk<ChunkChapter>(3);
            Chapters[3] = ReadChunk<ChunkChapter>(4);
            Chapters[4] = ReadChunk<ChunkChapter>(5);
            Chapters[5] = ReadChunk<ChunkChapter>(6);
            Chapters[6] = ReadChunk<ChunkChapter>(7);
            Chapters[7] = ReadChunk<ChunkChapter>(8);
            Chapters[8] = ReadChunk<ChunkChapter>(9);
            Chapters[9] = ReadChunk<ChunkChapter>(10);
            Chapters[10] = ReadChunk<ChunkChapter>(11);
            Chapters[11] = ReadChunk<ChunkChapter>(12);
            Chapters[12] = ReadChunk<ChunkChapter>(13);
            Chapters[13] = ReadChunk<ChunkChapter>(14);
            Chapters[14] = ReadChunk<ChunkChapter>(15);
            Chapters[15] = ReadChunk<ChunkChapter>(16);
            Chapters[16] = ReadChunk<ChunkChapter>(17);
            Chapters[17] = ReadChunk<ChunkChapter>(18);
            ChunkCommonPrev = ReadChunk<ChunkCommon>(19);
            Chapters[18] = ReadChunk<ChunkChapter>(20);
            Chapters[19] = ReadChunk<ChunkChapter>(21);
            Chapters[20] = ReadChunk<ChunkChapter>(22);
        }

        private T ReadChunk<T>(int index)
            where T : class
        {
            var chunk = Chunks[index];
            if ((chunk?.Content?.RawData?.Length ?? 0) == 0)
                return default;

            using var stream = new MemoryStream(chunk.Content.RawData);
            return BinaryMapping.ReadObject<T>(stream);
        }

        private void WriteChunk<T>(T item, int index)
            where T : class
        {
            var chunk = Chunks[index];
            using var stream = new MemoryStream(chunk.Content.RawData);
            BinaryMapping.WriteObject(stream, item);
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

        private static readonly Chunk.Type[] ReadPattern = new[]
        {
            Chunk.Type.RESD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.RESD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.TAIL,
        };

        public static SaveFf7Remake Read(Stream stream)
        {
            stream.SetPosition(0);
            var chunks = ReadPattern
                .Select(x => Chunk.Read(stream, x))
                .ToList();
            return new SaveFf7Remake(chunks);
        }
    }
}
