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

using System;
using System.IO;
using System.Text;

namespace KHSave
{
    public static class StreamHelpers
    {
        public static T FromBegin<T>(this T stream) where T : Stream => stream.SetPosition(0);

        public static T SetPosition<T>(this T stream, int position) where T : Stream
        {
            stream.Seek(position, SeekOrigin.Begin);
            return stream;
        }

        public static bool ReadFlag(this BinaryReader reader, int offset, int bit)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            return reader.ReadByte().HasFlag(bit);
        }

        public static int ReadInt32(this BinaryReader reader, int offset)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            return reader.ReadInt32();
        }

        public static byte[] ReadBytes(this Stream stream) =>
            stream.ReadBytes((int)(stream.Length - stream.Position));

        public static byte[] ReadBytes(this Stream stream, int length)
        {
            var data = new byte[length];
            stream.Read(data, 0, length);
            return data;
        }

        public static byte[] ReadAllBytes(this Stream stream)
        {
            var data = stream.SetPosition(0).ReadBytes();
            stream.Position = 0;
            return data;
        }

        public static string ReadString(this BinaryReader reader, int length)
        {
            var data = reader.ReadBytes(length);
            var terminatorIndex = Array.FindIndex(data, x => x == 0);
            return Encoding.UTF8.GetString(data, 0, terminatorIndex);
        }

        public static string ReadString(this BinaryReader reader, int offset, int length)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            return reader.ReadString(length);
        }

        public static bool HasFlag(this byte c, int offset)
        {
            return (c & (1 << offset)) != 0;
        }

        public static void Write(this BinaryWriter writer, string str, int length)
        {
            var data = Encoding.UTF8.GetBytes(str);
            if (data.Length <= length)
            {
                writer.Write(data, 0, data.Length);
                int remainsBytes = length = data.Length;
                if (remainsBytes > 0)
                {
                    writer.Write(new byte[remainsBytes]);
                }
            }
            else
            {
                writer.Write(data, 0, length);
            }
        }

        public static void Copy(this Stream source, Stream destination, int length, int bufferSize = 65536)
        {
            int read;
            byte[] buffer = new byte[Math.Min(length, bufferSize)];

            while ((read = source.Read(buffer, 0, Math.Min(length, bufferSize))) != 0)
            {
                destination.Write(buffer, 0, read);
                length -= read;
            }
        }
    }
}
