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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KHSave.Archives
{
    public class UnrealAsset
    {
        public class Import
        {
            private readonly List<KeyValuePair<uint, string>> _entries;
            private readonly int _classPackageIndex;
            private readonly int _classNameIndex;
            private readonly int _packageIndex;
            private readonly int _objectNameIndex;

            public Import(List<KeyValuePair<uint, string>> entries, Stream stream)
            {
                _entries = entries;

                _classPackageIndex = stream.ReadInt32();
                stream.ReadInt32();

                _classNameIndex = stream.ReadInt32();
                stream.ReadInt32();

                _packageIndex = stream.ReadInt32();

                _objectNameIndex = stream.ReadInt32();
                stream.ReadInt32();
            }

            public KeyValuePair<uint, string> ClassPackage => _entries[_classPackageIndex];
            public KeyValuePair<uint, string> ClassName => _entries[_classNameIndex];
            public KeyValuePair<uint, string> ObjectName => _entries[_objectNameIndex];

            public override string ToString() =>
                $"{ClassName.Value} {ClassPackage.Value} {ObjectName.Value}";
        }

        /// <summary>
        /// FObjectExport
        /// </summary>
        public class Export
        {
            private List<KeyValuePair<uint, string>> _entries;
            private int _objectName;

            public KeyValuePair<uint, string> ObjectName => _entries[_objectName];

            public Export(List<KeyValuePair<uint, string>> entries, Stream stream)
            {
                _entries = entries;
                var classIndex = stream.ReadInt32();
                var superIndex = stream.ReadInt32();
                var templateIndex = stream.ReadInt32();
                var packageIndex = stream.ReadInt32();

                _objectName = stream.ReadInt32();
                stream.ReadInt32();

                var objectFlags = stream.ReadUInt32();
                var serialSize = stream.ReadInt64();
                var serialOffset = stream.ReadInt64();
                var isForcedExport = stream.ReadInt32() != 0;
                var isNotForClient = stream.ReadInt32() != 0;
                var isNotForServer = stream.ReadInt32() != 0;
                var guid = new Guid(stream.ReadBytes(16));
                var packageFlags = stream.ReadUInt32();
                var isNotForEditorGame = stream.ReadInt32() != 0;
                var isAsset = stream.ReadInt32() != 0;
                var firstExportDependency = stream.ReadInt32();
                var serializationBeforeSerializationDependencies = stream.ReadInt32();
                var createBeforeSerializationDependencies = stream.ReadInt32();
                var serializationBeforeCreateDependencies = stream.ReadInt32();
                var createBeforeCreateDependencies = stream.ReadInt32();

            }
        }

        private const uint UnrealEngine418AssetHeader = 0x9E2A83C1;
        private const int ExpectedAssetVersion = -7;

        public string Comment { get; }
        public string Name { get; }
        public Guid Guid { get; }
        public List<KeyValuePair<uint, string>> Entries { get; }
        public List<Import> Imports { get; }
        public List<Export> Exports { get; }

        public UnrealAsset(Stream stream)
        {
            Entries = new List<KeyValuePair<uint, string>>();

            if (!IsValid(stream))
                throw new InvalidDataException("Invalid or unsupported UnrealAsset stream");

            stream.ReadInt32();
            stream.ReadInt32();
            stream.ReadInt32();
            stream.ReadInt32();
            var fileLength = stream.ReadInt32();
            Comment = ReadString(stream);
            stream.ReadInt32();
            var entryCount = stream.ReadInt32();
            var entryOffset = stream.ReadInt32();

            stream.ReadInt32();
            stream.ReadInt32();

            var exportCount = stream.ReadInt32();
            var exportOffset = stream.ReadInt32();
            var importCount = stream.ReadInt32();
            var importOffset = stream.ReadInt32();
            var dependenciesOffset = stream.ReadInt32();

            stream.ReadInt32();
            stream.ReadInt32();
            stream.ReadInt32();
            Guid = new Guid(stream.ReadBytes(16));

            var unkCount = stream.ReadInt32();
            for (var i = 0; i < unkCount; i++)
            {
                stream.ReadInt32();
                stream.ReadInt32();
                stream.ReadInt32();
            }

            // ???

            stream.SetPosition(entryOffset);
            while (entryCount-- > 0)
            {
                var value = ReadString(stream);
                var key = stream.ReadUInt32();
                Entries.Add(new KeyValuePair<uint, string>(key, value));
            }

            Name = Entries[0].Value; // ???

            stream.SetPosition(importOffset);
            Imports = new List<Import>();
            for (var i = 0; i < importCount; i++)
                Imports.Add(new Import(Entries, stream));

            stream.SetPosition(exportOffset);
            Exports = new List<Export>(exportCount);
            for (var i = 0; i < exportCount; i++)
                Exports.Add(new Export(Entries, stream));
            }

        public static bool IsValid(Stream stream) =>
            stream.SetPosition(0).ReadUInt32() == UnrealEngine418AssetHeader &&
            stream.ReadInt32() == ExpectedAssetVersion;

        public static UnrealAsset Read(Stream stream) => new UnrealAsset(stream);

        private static string ReadString(Stream stream) => ReadString(stream, Encoding.UTF8);
        private static string ReadString(Stream stream, Encoding encoding)
        {
            var length = stream.ReadInt32();
            return encoding.GetString(stream.ReadBytes(length), 0, length - 1);
        }
    }
}
