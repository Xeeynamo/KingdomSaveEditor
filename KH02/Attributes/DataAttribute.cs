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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace KHSave.Attributes
{
	public class DataAttribute : Attribute
	{
		public int? Offset { get; set; }

		public int Count { get; set; }

		public int Stride { get; set; }

		public DataAttribute()
		{
			Offset = null;
			Count = 1;
		}

		public DataAttribute(int offset, int count = 1, int stride = 0)
		{
			Offset = offset;
			Count = count;
			Stride = stride;
		}

		public static object ReadObject(BinaryReader reader, object obj, int baseOffset = 0)
		{
			var properties = obj.GetType()
				.GetProperties()
				.Select(x => new
				{
					MemberInfo = x,
					DataInfo = GetCustomAttribute(x, typeof(DataAttribute)) as DataAttribute
				})
				.Where(x => x.DataInfo != null)
				.ToList();

			foreach (var property in properties)
			{
				object value;
				var type = property.MemberInfo.PropertyType;
				var offset = property.DataInfo.Offset;

				if (offset.HasValue)
				{
					reader.BaseStream.Position = baseOffset + offset.Value;
				}

				if (type == typeof(bool)) value = reader.ReadByte() != 0;
				else if (type == typeof(byte)) value = reader.ReadByte();
				else if (type == typeof(sbyte)) value = reader.ReadSByte();
				else if (type == typeof(short)) value = reader.ReadInt16();
				else if (type == typeof(ushort)) value = reader.ReadUInt16();
				else if (type == typeof(int)) value = reader.ReadInt32();
				else if (type == typeof(uint)) value = reader.ReadUInt32();
				else if (type == typeof(long)) value = reader.ReadInt64();
				else if (type == typeof(ulong)) value = reader.ReadUInt64();
				else if (type == typeof(string)) value = reader.ReadString(property.DataInfo.Count);
				else if (type == typeof(byte[])) value = reader.ReadBytes(property.DataInfo.Count);
				else if (type == typeof(TimeSpan)) value = new TimeSpan(0, 0, 0, reader.ReadInt32(), 0);
				else if (type.IsEnum)
				{
					var underlyingType = Enum.GetUnderlyingType(type);

					if (underlyingType == typeof(byte)) value = reader.ReadByte();
					else if (underlyingType == typeof(sbyte)) value = reader.ReadSByte();
					else if (underlyingType == typeof(short)) value = reader.ReadInt16();
					else if (underlyingType == typeof(ushort)) value = reader.ReadUInt16();
					else if (underlyingType == typeof(int)) value = reader.ReadInt32();
					else if (underlyingType == typeof(uint)) value = reader.ReadUInt32();
					else if (underlyingType == typeof(long)) value = reader.ReadInt64();
					else if (underlyingType == typeof(ulong)) value = reader.ReadUInt64();
					else throw new InvalidDataException($"The enum {type.Name} has an unspported size.");
				}
				else if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
				{
					var listType = type.GetGenericArguments().FirstOrDefault();
					if (listType == null)
						throw new InvalidDataException($"The list {property.MemberInfo.Name} does not have any specified type.");

					var addMethod = type.GetMethod("Add");
					value = Activator.CreateInstance(typeof(List<>).MakeGenericType(listType));

					for (int i = 0; i < property.DataInfo.Count; i++)
					{
						var oldPosition = (int)reader.BaseStream.Position;
						addMethod.Invoke(value, new object[] { ReadObject(reader, Activator.CreateInstance(listType), oldPosition) });

						var newPosition = reader.BaseStream.Position;
						reader.BaseStream.Position += Math.Max(0, property.DataInfo.Stride - (newPosition - oldPosition));
					}


				}
				else throw new NotSupportedException($"Type {type.Name} is not supported by {nameof(ReadObject)}.");

				property.MemberInfo.SetValue(obj, value);
			}

			return obj;
		}
	}
}
