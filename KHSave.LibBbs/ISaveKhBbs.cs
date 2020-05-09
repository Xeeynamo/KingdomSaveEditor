namespace KHSave.LibBbs
{
    public interface ISaveKhBbs
    {
        uint MagicCode { get; set; }

        int Version { get; set; }

        uint Size { get; set; }

        uint Checksum { get; set; }
    }
}
