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
	public static class StreamHelpers
	{
		public static bool ReadFlag(this BinaryReader reader, int offset, int bit)
		{
			reader.BaseStream.Position = offset;
			return reader.ReadByte().HasFlag(bit);
		}

		public static int ReadInt32(this BinaryReader reader, int offset)
		{
			reader.BaseStream.Position = offset;
			return reader.ReadInt32();
		}

		public static string ReadString(this BinaryReader reader, int length)
		{
			var data = reader.ReadBytes(length);
			var terminatorIndex = Array.FindIndex(data, x => x == 0);
			return Encoding.UTF8.GetString(data, 0, terminatorIndex);
		}

		public static string ReadString(this BinaryReader reader, int offset, int length)
		{
			reader.BaseStream.Position = offset;
			return reader.ReadString(length);
		}

		public static bool HasFlag(this byte c, int offset)
		{
			return (c & (1 << offset)) != 0;
		}
	}
}
