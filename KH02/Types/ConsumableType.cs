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
	public enum ConsumableType : byte
	{
		[Consumable("Empty")] Empty,
		[Consumable("Potion")] Potion,
		[Consumable("Hi-Potion")] HiPotion,
		[Consumable("Mega-Potion")] MegaPotion,
		[Consumable("Ether")] Ether,
		[Consumable("Mega-Ether")] MegaEther,
		[Consumable("Elixir")] Elixir,
		[Consumable("Megalixir")] Megalixir,
		[Consumable("Refocuser")] Refocuser,
		[Consumable("Hi-Refocuser")] HiRefocuser,
		[Consumable("Panacea")] Panacea,
		[Consumable("Hi-Ether")] HiEther,
	}
}
