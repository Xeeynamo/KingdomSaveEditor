using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHSave.Archives.Factories
{
    public class Ps2PsuFactory : IArchiveFactory
    {
        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public IArchive Create()
        {
            throw new NotImplementedException();
        }

        public IArchiveEntry CreateEntry()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(Stream stream)
        {
            var currentPosition = stream.Position;
            stream.Position = 0x240;
            var b1 = stream.ReadByte();

            stream.Position = 0x440;
            var b2 = stream.ReadByte();
            var b3 = stream.ReadByte();

            stream.SetPosition((int)currentPosition);
            return stream.Length > 0x600 &&
                (byte)b1 == '.' && (byte)b2 == '.' && (byte)b3 == '.';
        }

        public IArchive Read(Stream stream)
        {
            var archive = Ps2PsuArchive.Read(stream, 10);
            return archive;
        }
    }
}
