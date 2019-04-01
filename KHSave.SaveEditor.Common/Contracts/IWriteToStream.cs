using System.IO;

namespace KHSave.SaveEditor.Common.Contracts
{
    public interface IWriteToStream
    {
        void WriteToStream(Stream stream);
    }
}
