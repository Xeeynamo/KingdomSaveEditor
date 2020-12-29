using KHSave.Lib2.Types;
using Xe.BinaryMapper;

namespace KHSave.Lib2.Models
{
    public class DriveFormVanilla : IDriveForm
    {
        [Data(0)] public EquipmentType Weapon { get; set; }
        [Data] public byte Level { get; set; }
        [Data] public byte AbilityLevel { get; set; }
        [Data] public int Experience { get; set; }
        [Data(Count = 0x10)] public ushort[] Abilities { get; set; }
    }
}
