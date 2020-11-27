using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.KhDDD.Interfaces
{
    public interface IResourceGetter
    {
        KhEnumListModel<EnumIconTypeModel<EquipmentType>, EquipmentType> Equipments { get; }
    }
}
