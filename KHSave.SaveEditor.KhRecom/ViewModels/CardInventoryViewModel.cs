using System;
using System.Collections.Generic;
using System.Linq;
using KHSave.LibRecom;
using KHSave.LibRecom.Models;
using KHSave.LibRecom.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.KhRecom.Interfaces;
using KHSave.SaveEditor.KhRecom.Models;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class CardInventoryViewModel : GenericListModel<CardInventoryEntryModel, CardType>
    {
        private CardInventoryEntryModel _selectedItem;

        public CardInventoryViewModel(DataRecom save, ICardCountService cardCountService) :
            this(GetEntries(save, cardCountService))
        {

        }

        public CardInventoryViewModel(IEnumerable<CardInventoryEntryModel> cards) :
            this(cards, () => CardType.Empty, _ => { })
        {

        }

        public CardInventoryViewModel(
            IEnumerable<CardInventoryEntryModel> items,
            Func<CardType> valueGetter,
            Action<CardType> valueSetter) :
            base(items, valueGetter, valueSetter)
        {
        }

        public CardInventoryEntryModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsItemSelected));
            }
        }

        public bool IsItemSelected => SelectedItem != null;


        private static IEnumerable<CardInventoryEntryModel> GetEntries(DataRecom save, ICardCountService cardCountService) =>
            CardModel.CardInventory
            .GroupBy(x => (int)x.Type | (x.IsPremium.HasValue ? (x.IsPremium.Value ? 0x40000000 : 0) : 0x20000000))
            .Select(x => new CardInventoryEntryModel(x.First(), cardCountService));
    }
}
