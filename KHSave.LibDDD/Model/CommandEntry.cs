using KHSave.LibDDD.Types;
using Xe.BinaryMapper;

namespace KHSave.LibDDD.Model
{
    public class CommandEntry
    {
        [Data] public EquipmentType Id { get; set; }
        [Data] public byte SoraEquipFlags { get; set; }
        [Data] public byte RikuEquipFlags { get; set; }
        [Data] public byte Unk04 { get; set; }
        [Data] public byte Amount { get; set; }
        [Data] public ushort Padding06 { get; set; }
    }
}
