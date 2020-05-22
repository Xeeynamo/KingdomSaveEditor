using KHSave.Lib2.Types;
using System.IO;

namespace KHSave.Lib2
{
    public interface ISaveKh2
    {
        uint MagicCode { get; set; }
        int Version { get; set; }
        uint Checksum { get; set; }

        WorldType WorldId { get; }
        byte RoomId { get; }
        byte SpawnId { get; }

        int MunnyAmount { get; }
        byte[] InventoryCount { get; }

        void Write(Stream stream);
    }
}