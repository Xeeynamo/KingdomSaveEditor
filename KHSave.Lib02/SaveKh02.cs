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

using KHSave.Trssv.Models;
using System.Collections.Generic;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Trssv
{
    public class SaveKh02
    {
        [Data(0, 0x1725B0)] public byte[] Data { get; set; }

        [Data(0x10)] public bool IsVibrationEnable { get; set; }
        [Data] public bool InvertCameraVertical { get; set; }
        [Data] public bool InvertCameraHorizontal { get; set; }
        [Data] public bool IsMapVisible { get; set; }
        [Data] public bool IsSubtitlesVisible { get; set; }
        [Data] public bool Unk10_Bit5 { get; set; }
        [Data] public bool CanEarnExp { get; set; }

        [Data(0x14)] public int CameraSpeed { get; set; }

        [Data(0x18)] public int Brightness { get; set; }

        [Data(0x1C)] public int TheaterModeWatched { get; set; }

        [Data(0x38)] public int TheaterMode { get; set; }

        [Data(0xB0, 100, 0x3B40)] public List<Slot> Slots { get; set; }

        public static bool IsValid(Stream stream)
        {
            var prevPosition = stream.Position;
            var magicCode = new BinaryReader(stream).ReadInt32();
            stream.Position = prevPosition;

            return magicCode == 0x45564153; // SAVE
        }

        public void Write(Stream stream) => BinaryMapping.WriteObject(stream, this);

        public static SaveKh02 Read(Stream stream) => BinaryMapping.ReadObject<SaveKh02>(stream);
    }
}
