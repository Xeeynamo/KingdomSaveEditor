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
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkCommon
    {
        [Data(Count = 0x00050008)] public byte[] Data { get; set; }

        [Data(0)] public byte CurrentChapterChunk { get; set; }
        [Data] public byte Unk01 { get; set; }
        [Data] public byte Unk02 { get; set; }
        [Data] public byte Unk03 { get; set; }
        [Data] public byte Unk04 { get; set; }
        [Data] public byte Unk05 { get; set; }
        [Data(6)] public byte CurrentChapterId { get; set; }
        [Data(7)] public byte CurrentChapterChunk2 { get; set; }
        [Data(8, Count = SaveFf7Remake.CharacterCount, Stride = 0x40)] public Character[] Characters { get; set; }
        [Data(0x208, Count = SaveFf7Remake.CharacterCount, Stride = 0x10)] public CharacterStats[] CharactersStats { get; set; }
        [Data(0x288)] public int Unk288 { get; set; }
        [Data(0x28c)] public int Unk28c { get; set; }
        [Data(0x290)] public float Unk290 { get; set; }
        [Data(0x294)] public int Unk294 { get; set; }
        [Data(0x298, Count = SaveFf7Remake.CharacterCount)] public Vector3f[] Positions { get; set; }
        [Data(0x2F8, Count = SaveFf7Remake.CharacterCount)] public Vector3f[] Rotations { get; set; }
        [Data(0x358, Count = 0x340)] public byte[] Unk358 { get; set; }
        [Data(0x698, Count = SaveFf7Remake.CharacterCount, Stride = 0x10)] public UnknownStructure[] CharactersUnknown { get; set; }
        [Data(0x718, Count = 0x80, Stride = 0x10)] public UnknownStructure2[] UnknownStructure2 { get; set; }
        [Data(0xf18, Count = 0x80, Stride = 0x10)] public WeaponFound[] WeaponFound { get; set; }
        [Data(0x1718, Count = SaveFf7Remake.CharacterCount, Stride = 0x20)] public CharacterEquipment[] CharactersEquipment { get; set; }
        [Data(0x1818, Count = 1000, Stride = 0x20)] public Materia[] Materia { get; set; }
        // [...]
        [Data(0x34DA8, Count = 0x800, Stride = 0x18)] public Inventory[] Inventory { get; set; }
        [Data(0x40DA8, Count = SaveFf7Remake.CharacterCount, Stride = 0x30)] public MateriaEquipment[] CharacterMateria { get; set; }
        [Data(0x40F28, Count = 0x78, Stride = 0x30)] public MateriaEquipment[] WeaponMateria { get; set; }
        // [425A8...]

        // 0x42862 Cloud Dress

        [Data(0x42F5C)] public byte PlayableCharacter { get; set; }
        [Data(0x42F5D)] public byte CurrentChapter { get; set; }
        [Data(0x44EAC, Count = SaveFf7Remake.CharacterCount)] public int[] SummonMateria { get; set; }
        [Data(0x46DC4, Count = 100, Stride = 0x30)] public UnknownStructure3[] UnknownStructure3 { get; set; }
    }
}
