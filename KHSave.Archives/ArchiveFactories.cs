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

using KHSave.Archives.Factories;
using System.IO;

namespace KHSave.Archives
{
    public static class ArchiveFactories
    {
        public static IArchiveFactory Ps4Kh1 = new Ps4Kh1Factory();
        public static IArchiveFactory Ps4Kh2 = new Ps4Kh2Factory();
        public static IArchiveFactory Ps4KhRecom = new Ps4KhRecomFactory();

        public static bool TryGetFactory(Stream stream, out IArchiveFactory archiveFactory)
        {
            if (Ps4Kh1.IsValid(stream)) archiveFactory = Ps4Kh1;
            else if (Ps4Kh2.IsValid(stream)) archiveFactory = Ps4Kh2;
            else if (Ps4KhRecom.IsValid(stream)) archiveFactory = Ps4KhRecom;
            else archiveFactory = null;

            return archiveFactory != null;
        }
    }
}
