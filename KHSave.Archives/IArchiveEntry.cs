using System;

namespace KHSave.Archives
{
    public interface IArchiveEntry
    {
        string Name { get; set; }
        DateTime DateCreated { get; }
        DateTime DateModified { get; }
        byte[] Data { get; set; }
    }
}
