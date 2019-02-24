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

namespace KHSave.Types
{
	public enum AccessoryType : byte
	{
		Empty,
		Unknown01,
		Unknown02,
		Unknown03,
		Unknown04,
		Unknown05,
		Unknown06,
		Unknown07,
		Unknown08,
		Unknown09,
		Unknown0a,
		Unknown0b,
		Unknown0c,
		Unknown0d,
		Unknown0e,
		[Accessory("Phantom Ring")] PhantomRing,
		Unknown10,
		Unknown11,
		[Accessory("Rune Ring")] RuneRing,
		[Accessory("Force Ring")] ForceRing,
		Unknown14,
		Unknown15,
		Unknown16,
		Unknown17,
		[Accessory("Master's Necklace")] MasterNecklace,
		Unknown19,
		Unknown1a,
		Unknown1b,
		Unknown1c,
		Unknown1d,
		Unknown1e,
		[Accessory("Mickey Clasp")] MickeyClasp,
		Unknown20,
		Unknown21,
		Unknown22,
		Unknown23,
		Unknown24,
		Unknown25,
		Unknown26,
		Unknown27,
		Unknown28,
		Unknown29,
		Unknown2a,
		Unknown2b,
		Unknown2c,
		[Accessory("Celestriad")] Celestriad,
		Unknown2e,
		Unknown2f,
		Unknown30,
		Unknown31,
		[Accessory("Flanniversary Badge")] FlanniversaryBadge,
		Unknown33,
		Unknown34,
		Unknown35,
		Unknown36,
		Unknown37,
		Unknown38,
		Unknown39,
		Unknown3a,
		Unknown3b,
		Unknown3c,
		Unknown3d,
		Unknown3e,
		Unknown3f,
	}
}
