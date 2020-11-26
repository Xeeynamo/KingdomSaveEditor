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

using KHSave.Attributes;

namespace KHSave.Trssv.Types
{
    public enum CommandType
    {
        [Info("Empty")] Empty = 0,
        [Info("Counter Blast")] CounterBlast = 26,
        [Info("Attack")] Attack = 46,
        [Info("Magic")] Magic = 49,
        [Magic("Firaga")] Firaga = 51,
        [Magic("Firaja")] Firaja = 52,
        [Magic("Blizzaga")] Blizzaga = 55,
        [Magic("Blizzaja")] Blizzaja = 56,
        [Magic("Thundaga")] Thundaga = 59,
        [Magic("Thundaja")] Thundaja = 60,
        [Magic("Curaga")] Curaga = 71,
        [Info("Items")] Items = 77,
        [Consumable("Potion")] Potion,
        [Consumable("Hi-Potion")] HiPotion,
        [Consumable("Mega-Potion")] MegaPotion,
        [Consumable("Ether")] Ether,
        [Consumable("Mega-Ether")] MegaEther,
        [Consumable("Elixir")] Elixir,
        [Consumable("Megalixir")] Megalixir,
        [Info("Talk")] Talk = 88,
        [Info("Open")] Open,
        [Info("Examine")] Examine,
        [Info("Spellweaver")] Spellweaver = 112,
        [Info("Wayfinder")] Wayfinder,
        [Info("Finish Spellweaver")] Finish1 = 134,
        [Info("Finish Wayfinder")] Finish2,
        [Info("Wayfinder (final boss)")] WayfinderAlt = 167,
        [Info("Prism Rain")] PrismRain = 210,
    }
}
