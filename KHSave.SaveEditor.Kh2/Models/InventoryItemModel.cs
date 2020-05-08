using KHSave.Attributes;
using KHSave.Lib2.Types;
using KHSave.SaveEditor.Common.Services;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh2.Models
{
    public class InventoryItemModel :
        BaseNotifyPropertyChanged,
        SearchEngine.ICount,
        SearchEngine.IName
    {
        private readonly int _index;
        private readonly byte[] _inventoryCount;

        public InventoryItemModel(int index, byte[] inventoryCount)
        {
            _index = index;
            _inventoryCount = inventoryCount;
        }

        public InventoryType Type => (InventoryType)_index;
        public string Name => InfoAttribute.GetInfo(Type);
        public ImageSource Icon => IconService.Icon(Type);

        public int Count => Amount;

        public byte Amount
        {
            get => _inventoryCount[_index];
            set
            {
                _inventoryCount[_index] = value;
                OnPropertyChanged();
            }
        }
    }
}
