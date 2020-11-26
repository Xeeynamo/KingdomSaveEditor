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

namespace KHSave.LibFf7Remake.Types
{
    public enum CharacterType
    {
        [Info("Cloud")] Cloud = SaveFf7Remake.Cloud,
        [Info("Barret")] Barret = SaveFf7Remake.Barret,
        [Info("Tifa")] Tifa = SaveFf7Remake.Tifa,
        [Info("Aerith")] Aerith = SaveFf7Remake.Aerith,
        [Info("Red XIII")] Red13 = SaveFf7Remake.Red13,
        [Info("5")] Unused5, // Cait Sith
        [Info("6")] Unused6, // Cid
        [Info("7")] Unused7, // Yuffie
        [Info("8")] Unused8, // Vincent
        [Info("None")] None = SaveFf7Remake.Unequipped,
    }
}
