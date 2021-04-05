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
        public static readonly IArchiveFactory Ps4Kh1 = new Ps4Kh1Factory();
        public static readonly IArchiveFactory Ps4Kh2 = new Ps4Kh2Factory();
        public static readonly IArchiveFactory Ps4KhRecom = new Ps4KhRecomFactory();
        public static readonly IArchiveFactory Ps4KhDdd = new Ps4KhDddFactory();
        public static readonly IArchiveFactory PcKh1 = new PcKh1Factory();
        public static readonly IArchiveFactory PcKh2 = new PcKh2Factory();
        public static readonly IArchiveFactory PcKhRecom = new PcKhRecomFactory();
        public static readonly IArchiveFactory PcKhBbs = new PcKhBbsactory();
        public static readonly IArchiveFactory PcKhDdd = new PcKhDddFactory();

        public static readonly IArchiveFactory Ps2Psu = new Ps2PsuFactory();
        public static readonly IArchiveFactory Ps2Cbs = new Ps2CbsFactory();

        public static readonly IArchiveFactory Ps3Psv = new Ps3PsvFactory();

        public static bool TryGetFactory(Stream stream, out IArchiveFactory archiveFactory)
        {
            if (Ps4Kh1.IsValid(stream))
                archiveFactory = Ps4Kh1;
            else if (Ps4Kh2.IsValid(stream))
                archiveFactory = Ps4Kh2;
            else if (Ps4KhRecom.IsValid(stream))
                archiveFactory = Ps4KhRecom;
            else if (Ps4KhDdd.IsValid(stream))
                archiveFactory = Ps4KhDdd;
            else if (PcKh1.IsValid(stream))
                archiveFactory = PcKh1;
            else if (PcKh2.IsValid(stream))
                archiveFactory = PcKh2;
            else if (PcKhRecom.IsValid(stream))
                archiveFactory = PcKhRecom;
            else if (PcKhBbs.IsValid(stream))
                archiveFactory = PcKhBbs;
            else if (PcKhDdd.IsValid(stream))
                archiveFactory = PcKhDdd;
            else if (Ps2Psu.IsValid(stream))
                archiveFactory = Ps2Psu;
            else if (Ps2Cbs.IsValid(stream))
                archiveFactory = Ps2Cbs;
            else if (Ps3Psv.IsValid(stream))
                archiveFactory = Ps3Psv;
            else
                archiveFactory = null;

            return archiveFactory != null;
        }
    }
}
