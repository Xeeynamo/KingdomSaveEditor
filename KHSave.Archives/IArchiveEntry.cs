using System;

namespace KHSave.Archives
{
    public interface IArchiveEntry
    {
        string Name { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        byte[] Data { get; set; }
    }
}
