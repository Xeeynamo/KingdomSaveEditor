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

using KHSave.LibFf7Remake.Models;
using System.IO;
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

        [Data(0, Count = 0x8ff680)] public byte[] Data { get; set; }
        [Data(0x30, Count = 5, Stride = 0x40)] public Character[] Characters { get; set; }
        [Data(0x34DD0, Count = 0x800, Stride = 0x18)] public Inventory[] Inventory { get; set; }
        [Data(0x42f84)] public byte PlayableCharacter { get; set; }
        [Data(0x42f85)] public byte CurrentChapter { get; set; }
        [Data(0x7b2100, Count = 0x800, Stride = 0x18)] public Inventory[] InventoryCopy { get; set; }

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

        public static SaveFf7Remake Read(Stream stream) => _mapping.ReadObject<SaveFf7Remake>(stream);

        public SaveFf7Remake Write(Stream stream)
        {
            for (int i = 0; i < Inventory.Length; i++)
                InventoryCopy[i] = Inventory[i];
            
            return _mapping.WriteObject(stream, this);
        }
    }
}
