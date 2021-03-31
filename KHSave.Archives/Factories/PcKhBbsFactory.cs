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

using System.IO;

namespace KHSave.Archives.Factories
{
    public class PcKhBbsactory : IArchiveFactory
    {
        private const int EntryCount = 100;
        private const int Stride = 0x13C00;
        private const int Size = 0x7D3B94;

        public string Name => "PC KHBBS";

        public string Description => "Kingdom Hearts Birth By Sleep (PC)";

        public IArchive Create() =>
            new PcSaveArchive(EntryCount, Stride);

        public IArchive Read(Stream stream)
        {
            var archive = PcSaveArchive.Read(stream, EntryCount, Stride);
            archive.Name = Description;

            return archive;
        }

        public bool IsValid(Stream stream) => stream.Length == Size;

        public IArchiveEntry CreateEntry() => new PcSaveArchive.Entry();
    }
}
