using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KHSave.LibRecom;
using KHSave.LibRecom.Models;
using KHSave.LibRecom.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.KhRecom.Interfaces;
using KHSave.SaveEditor.KhRecom.Models;

namespace KHSave.SaveEditor.KhRecom.ViewModels
{
    public class CardInventoryViewModel : GenericListModel<CardInventoryEntryViewModel, CardType>
    {
        private CardInventoryEntryViewModel _selectedItem;

        public CardInventoryViewModel(DataRecom save, ICardCountService cardCountService) :
            this(GetEntries(save, cardCountService))
        {

        }

        public CardInventoryViewModel(IEnumerable<CardInventoryEntryViewModel> cards) :
            this(cards, () => CardType.Empty, _ => { })
        {

        }

        public CardInventoryViewModel(
            IEnumerable<CardInventoryEntryViewModel> items,
            Func<CardType> valueGetter,
            Action<CardType> valueSetter) :
            base(items, valueGetter, valueSetter)
        {
        }

        public CardInventoryEntryViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsItemSelected));
                OnPropertyChanged(nameof(CardEntryVisibility));
                OnPropertyChanged(nameof(CardEntrySelectionMessageVisibility));
            }
        }

        public bool IsItemSelected => SelectedItem != null;

        public Visibility CardEntryVisibility => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility CardEntrySelectionMessageVisibility => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        private static IEnumerable<CardInventoryEntryViewModel> GetEntries(DataRecom save, ICardCountService cardCountService) =>
            CardModel.CardInventory
            .GroupBy(x => (int)x.Type | (x.IsPremium.HasValue ? (x.IsPremium.Value ? 0x40000000 : 0) : 0x20000000))
            .Select(x => new CardInventoryEntryViewModel(x.First(), cardCountService));
    }
}
