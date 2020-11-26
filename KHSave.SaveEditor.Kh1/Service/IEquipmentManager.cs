using KHSave.Lib1.Types;

namespace KHSave.SaveEditor.Kh1.Service
{
    public interface IEquipmentManager
    {
        byte Count { get; set; }

        EquipmentType GetEquipment(byte index);
        void SetEquipment(byte index, EquipmentType equipment);
    }
}
