using KHSave.LibPersona5;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Persona5.Interfaces;
using System;
using System.Linq;
using Xe.Tools;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class InventoryEntry : BaseNotifyPropertyChanged, SearchEngine.IName, SearchEngine.ICount
    {
        private readonly byte[] _elementCount;
        private readonly int _elementIndex;

        public InventoryEntry(IConsumableList consumables, byte[] elementCount, int elementIndex)
        {
            _elementCount = elementCount;
            _elementIndex = elementIndex;

            Name = consumables.ConsumableItems.FirstOrDefault(x => x.Id == elementIndex)?.Name;
        }

        public string Name { get; }

        public int Count
        {
            get => _elementCount[_elementIndex];
            set => _elementCount[_elementIndex] = (byte)Math.Min(255, Math.Max(0, value));
        }
    }

    public class InventoryViewModel : GenericListModel<InventoryEntry>
    {
        private ISavePersona5 _save;
        private string _searchTerm;

        public InventoryViewModel(ISavePersona5 save, IConsumableList consumables) :
            base(save.InventoryCount.Select((_, i) => new InventoryEntry(consumables, save.InventoryCount, i)))
        {
            _save = save;
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                Filter(items => SearchEngine.Filter(_searchTerm, items));
            }
        }
    }
}
