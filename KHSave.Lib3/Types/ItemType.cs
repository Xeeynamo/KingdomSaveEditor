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

using KHSave.Attributes;

namespace KHSave.Types
{
	public enum ItemType : byte
	{
		[Consumable] Consumable,
		[Consumable("Consumable (same)")] ConsumableMirrored,
		[Tent] Tent,
		[Weapon] Weapon,
		[Armor] Armor,
		[Accessory] Accessory,
		[Snack] Snack,
		[Synthesis] Synthesis,
		[Food] Food,
		[KeyItem] KeyItem,
		[MogItem] Mog,
		[KeyItem("Gummiphone game")] Type0b,
		[Info] Untested0c,
		[KeyItem("Ansem report")] AnsemReport,
		[Info("Gummi block")] GummiBlock,
		[Info("Gummi related?")] GummiRelated,
		[Info] Untested10,
		[Info] Untested11,
		[Info] Untested12,
		[Info] Untested13,
	}
}
