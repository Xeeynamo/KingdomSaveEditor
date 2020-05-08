namespace KHSave.Lib2
{
    public interface ISaveKh2
    {
        uint MagicCode { get; set; }
        int Version { get; set; }
        uint Checksum { get; set; }

        int MunnyAmount { get; }
        byte[] InventoryCount { get; }
    }
}