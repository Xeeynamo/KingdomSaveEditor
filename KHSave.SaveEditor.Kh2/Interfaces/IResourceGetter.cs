using KHSave.Lib2.Types;
using KHSave.SaveEditor.Common.Models;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Kh2.Interfaces
{
    public interface IResourceGetter
    {
        KhEnumListModel<EnumIconTypeModel<EquipmentType>, EquipmentType> Equipments { get; }

        IEnumerable<EnumIconTypeModel<EquipmentType>> Abilities { get; }
    }
}
