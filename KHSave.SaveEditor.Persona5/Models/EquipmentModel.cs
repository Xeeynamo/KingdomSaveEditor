using KHSave.LibPersona5;
using KHSave.SaveEditor.Common.Services;
using System.Windows.Media;

namespace KHSave.SaveEditor.Persona5.Models
{
    public class EquipmentModel
    {
        public string Name { get; }
        public ushort Value { get; }
        public ImageSource Icon { get; }

        public EquipmentModel(
            Presets.IItem item, int baseId, string iconType)
        {
            Value = (ushort)(item.Id | baseId);
            Name = item.Name;
            Icon = IconService.Icon(iconType);
        }
    }
}
