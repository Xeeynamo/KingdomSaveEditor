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

namespace KHSave.Lib3.Types
{
    public enum CharacterIconType : byte
    {
        [Info] Empty,
        [Info] Sora,
        [Info] Riku,
        [Info] Kairi,
        [Info] Terra,
        [Info] Ventus,
        [Info] Aqua,
        [Info] Roxas,
        [Info] Axel,
        [Info] Xion,
        [Info] Mickey,
        [Info] Donald,
        [Info] Goofy,
        [Info] Jack,
        [Info] Woody,
        [Info] Buzz,
        [Info] Hercules,
        [Info] Rapunzel,
        [Info] Flynn,
        [Info] Sulley,
        [Info] Mike,
        [Info] Empty20,
        [Info] Marshmallow,
        [Info] Baymax,

        [Info] Leon = 0x96,
        [Info] Aerith = 0x97,
        [Info] Yuffie = 0x98,
        [Info] Cid = 0x99,
    }
}
