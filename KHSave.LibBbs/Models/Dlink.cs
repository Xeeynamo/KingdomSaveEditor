using KHSave.LibBbs.Types;
using Xe.BinaryMapper;

namespace KHSave.LibBbs.Models
{
    public class Dlink
    {
        [Data] public CommandType Id { get; set; }
        [Data] public ushort Status { get; set; }
        [Data] public uint Dummy { get; set; }
    }
}
