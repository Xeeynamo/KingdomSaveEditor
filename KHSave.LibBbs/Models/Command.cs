using KHSave.LibBbs.Types;
using Xe.BinaryMapper;

namespace KHSave.LibBbs.Models
{
    public class Command
    {
        [Data] public CommandType Id { get; set; }
        [Data] public ushort Level { get; set; }
        [Data] public ushort Experience { get; set; }
        [Data] public AbilityType Ability { get; set; }
        [Data] public ushort Flags { get; set; }
    }
}
