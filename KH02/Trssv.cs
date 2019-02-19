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

using System;
using System.IO;
using System.Text;

namespace KHSave
{
	public class Trssv
	{
		public int MagicCode { get; set; }

		public int IsFirstRun { get; set; }


		public bool IsVibrationVisible { get; set; }

		public bool InvertCameraVertical { get; set; }

		public bool InvertCameraHorizontal { get; set; }

		public bool IsMapVisible { get; set; }

		public bool IsSubtitlesVisible { get; set; }

		public bool Unk10_Bit5 { get; set; }

		public bool CanEarnExp { get; set; }

		public int CameraSpeed { get; set; }

		public int Brightness { get; set; }

		public int TheaterModeWatched { get; set; }

		public int TheaterMode { get; set; }

		public string MapName { get; set; }

		public int Hp { get; set; }

		public int Mp { get; set; }

		private Trssv MyRead(Stream stream)
		{
			var reader = new BinaryReader(stream);

			IsVibrationVisible = reader.ReadFlag(0x10, 0);
			InvertCameraHorizontal = reader.ReadFlag(0x10, 1);
			InvertCameraVertical = reader.ReadFlag(0x10, 2);
			IsMapVisible = reader.ReadFlag(0x10, 3);
			IsSubtitlesVisible = reader.ReadFlag(0x10, 4);
			Unk10_Bit5 = reader.ReadFlag(0x10, 5);
			CanEarnExp = reader.ReadFlag(0x10, 6);
			CameraSpeed = reader.ReadInt32(0x14);
			Brightness = reader.ReadInt32(0x18);
			TheaterModeWatched = reader.ReadInt32(0x1C);
			TheaterMode = reader.ReadInt32(0x38);

			Hp = reader.ReadInt32(0x24C0);
			Mp = reader.ReadInt32(0x24C4);
			MapName = reader.ReadString(0x33D4, 0x100);

			return this;
		}

		public static Trssv Read(Stream stream) => new Trssv().MyRead(stream);
	}

}
