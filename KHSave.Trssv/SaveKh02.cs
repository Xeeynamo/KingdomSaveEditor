/*
    Kingdom Hearts 0.2 and 3 Save Editor
    Copyright (C) 2019  Luciano Ciccariello

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

using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Trssv
{
    public class SaveKh02
    {
        [Data(0, 0x1725B0)] public byte[] Data { get; set; }

        public bool IsVibrationEnable { get; set; }

        public bool InvertCameraVertical { get; set; }

        public bool InvertCameraHorizontal { get; set; }

        public bool IsMapVisible { get; set; }

        public bool IsSubtitlesVisible { get; set; }

        public bool Unk10_Bit5 { get; set; }

        public bool CanEarnExp { get; set; }

        [Data(0x14)] public int CameraSpeed { get; set; }

        [Data(0x18)] public int Brightness { get; set; }

        [Data(0x1C)] public int TheaterModeWatched { get; set; }

        [Data(0x38)] public int TheaterMode { get; set; }

        [Data(0x24C0)] public int Hp { get; set; }

        [Data(0x24C4)] public int Mp { get; set; }

        [Data(0x33d4, 0x100)] public string MapName { get; set; }

        private SaveKh02 MyRead(Stream stream)
        {
            var reader = new BinaryReader(stream);

            IsVibrationEnable = reader.ReadFlag(0x10, 0);
            InvertCameraHorizontal = reader.ReadFlag(0x10, 1);
            InvertCameraVertical = reader.ReadFlag(0x10, 2);
            IsMapVisible = reader.ReadFlag(0x10, 3);
            IsSubtitlesVisible = reader.ReadFlag(0x10, 4);
            Unk10_Bit5 = reader.ReadFlag(0x10, 5);
            CanEarnExp = reader.ReadFlag(0x10, 6);

            return this;
        }

        public void Write(Stream stream) =>
            BinaryMapping.WriteObject(new BinaryWriter(stream), this);

        public static SaveKh02 Read(Stream stream)
        {
            var oldPosition = stream.Position;
            var save = new SaveKh02().MyRead(stream);
            stream.Position = oldPosition;

            return BinaryMapping.ReadObject(new BinaryReader(stream), save) as SaveKh02;
        }
    }
}
