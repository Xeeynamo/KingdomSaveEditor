using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Ff7Remake.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class ItemModel
    {
        private readonly ItemsPreset.ItemProperty _itemProperty;

        public ItemModel(ItemsPreset.ItemProperty itemProperty)
        {
            _itemProperty = itemProperty;
        }

        public int Id => _itemProperty.Id;
        public string Name => _itemProperty.Name;
        public ImageSource Icon => IconService.Icon(_itemProperty.Icon);

        public static IEnumerable<ItemModel> GetItemModels() =>
            ItemsPreset.GetAll().Select(x => new ItemModel(x));
    }
}
