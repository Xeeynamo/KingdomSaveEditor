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

using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkChapter
    {
        private const int Length = 0x660E8;
        private const int MaxObjectCount = 0x800;

        [Data(Count = Length)] public byte[] Data { get; set; }

        [Data(0)] public byte IsChapterInPlay { get; set; }
        [Data(1)] public byte ChapterId { get; set; }
        [Data(3)] public byte PlayableCharacter { get; set; }
        [Data(4, Count = SaveFf7Remake.CharacterCount)] public CharacterStatusType[] CharacterStatus { get; set; }
        [Data(0xC, Count = SaveFf7Remake.CharacterCount)] public Vector3f[] Positions { get; set; }
        [Data(0x6C, Count = SaveFf7Remake.CharacterCount)] public Vector3f[] Rotations { get; set; }
        [Data(0x1A2)] public ushort Bgm { get; set; }
        [Data(0xCBD8, Count = MaxObjectCount, Stride = 0x20)] public ChapterObject[] Objects { get; set; }

        public ChunkChapter()
        {
            Data = new byte[Length];
            CharacterStatus = new CharacterStatusType[SaveFf7Remake.CharacterCount];
            Positions = Enumerable.Range(0, SaveFf7Remake.CharacterCount).Select(x => new Vector3f()).ToArray();
            Rotations = Enumerable.Range(0, SaveFf7Remake.CharacterCount).Select(x => new Vector3f()).ToArray();
            Objects = Enumerable.Range(0, MaxObjectCount).Select(x => new ChapterObject()).ToArray();
        }
    }
}
