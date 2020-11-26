using KHSave.Lib2.Types;

namespace KHSave.Lib2.Models
{
    public interface IDriveForm
    {
        EquipmentType Weapon { get; set; }
        byte Level { get; set; }
        byte Unknown { get; set; }
        int Experience { get; set; }
        ushort[] Abilities { get; set; }
    }
}
