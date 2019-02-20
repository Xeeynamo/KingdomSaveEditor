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

using KHSave.Attributes;
using System.Collections.Generic;
using System.IO;

namespace KHSave
{
	public class Kh3
	{
		[Data(0x14)] public DifficultyType Difficulty { get; set; }
		[Data(0x18)] public WorldType WorldLogo { get; set; }

        [Data(0x20)] public System.DateTime GameTime { get; set; }
		[Data(0x24)] public int TotalExp { get; set; }
		[Data(0x28)] public int Munny { get; set; }
		[Data(0x2C)] public byte Level { get; set; }
		[Data(0x60)] public CharacterIconType MySaveIcon { get; set; }
		[Data(0x5B0)] public short SavesCount { get; set; }

		[Data(0x1878, 3, 0x18)]
		public List<Item> Weapons { get; set; }

		[Data(0x2178, 16, 0x9C0)]
		public List<PlayableCharacter> Pc { get; set; }

		[Data(0xBB18, 0x100)]
		public string MapPath { get; set; }

		[Data(0xBC18, 0x40)]
		public string MapSpawn { get; set; }

		[Data(0xBC58, 0x100)]
		public string PlayerScript { get; set; }

		[Data(0xBD58, 0x100)]
		public string PlayerCharacter { get; set; }

		[Data(0xBE98, 3)]
		public List<ShortcutGroup> Shortcuts { get; set; }

		[Data(0xBEC8, 9, 4)] public List<CommandType> Magics { get; set; }

		[Data(0xBE98, 90, 0x19004)]
		public List<PhotoEntry> Photos { get; set; }

		public static Kh3 Read(Stream stream) =>
			DataAttribute.ReadObject(new BinaryReader(stream), new Kh3()) as Kh3;
	}
}
