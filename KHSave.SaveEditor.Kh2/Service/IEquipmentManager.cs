using KHSave.Lib2.Types;

namespace KHSave.SaveEditor.Kh2.Service
{
    public interface IEquipmentManager
    {
        uint Count { get; set; }

        EquipmentType GetEquipment(uint index);
        void SetEquipment(uint index, EquipmentType equipment);
    }
}
