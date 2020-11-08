using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.Kh1.Interfaces
{
    public interface IGetAbilities
    {
        KhEnumListModel<AbilityType> Abilities { get; }
    }
}
