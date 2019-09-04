using System;

namespace KHSave.Archives
{
    internal class GenericEntry : IArchiveEntry
    {
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public byte[] Data { get; set; }
    }
}
