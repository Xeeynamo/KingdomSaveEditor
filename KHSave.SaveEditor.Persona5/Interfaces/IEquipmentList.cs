using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Persona5.Models;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Persona5.Interfaces
{
    public interface IEquipmentList
    {
        KhEnumListModel<EnumIconTypeModel<Equipment>, Equipment> EquipmentList { get; }

        IEnumerable<EquipmentModel> Accessories { get; }
        IEnumerable<EquipmentModel> Armors { get; }
        IEnumerable<EquipmentModel> Outfits { get; }
        IEnumerable<EquipmentModel> MeleeWeapons { get; }
        IEnumerable<EquipmentModel> RangeWeapons { get; }
    }
}
