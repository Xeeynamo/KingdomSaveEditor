using KHSave.Attributes;
using KHSave.LibRecom.Models;
using KHSave.LibRecom.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.KhRecom.Interfaces;
using System.Windows;

namespace KHSave.SaveEditor.KhRecom.Models
{
    public class CardInventoryEntryModel : EnumIconTypeModel<CardType>
    {
        private readonly ICardCountService cardCountService;
        private readonly Card _card;

        public CardInventoryEntryModel(Card card, ICardCountService cardCountService)
        {
            this.cardCountService = cardCountService;

            _card = card;
            Name = IsPremium ? $"{CardName} (P)" : CardName;
            Value = CardType;
        }

        public CardType CardType => _card.Type;
        public bool CanHaveMultipleValues => _card.Value.HasValue;
        public bool CanBePremium => _card.IsPremium.HasValue;
        public bool IsPremium => _card.IsPremium ?? false;
        public string CardName => InfoAttribute.GetInfo(CardType);

        public byte CountValue0 { get => GetCount(0); set => SetCount(0, value); }
        public byte CountValue1 { get => GetCount(1); set => SetCount(1, value); }
        public byte CountValue2 { get => GetCount(2); set => SetCount(2, value); }
        public byte CountValue3 { get => GetCount(3); set => SetCount(3, value); }
        public byte CountValue4 { get => GetCount(4); set => SetCount(4, value); }
        public byte CountValue5 { get => GetCount(5); set => SetCount(5, value); }
        public byte CountValue6 { get => GetCount(6); set => SetCount(6, value); }
        public byte CountValue7 { get => GetCount(7); set => SetCount(7, value); }
        public byte CountValue8 { get => GetCount(8); set => SetCount(8, value); }
        public byte CountValue9 { get => GetCount(9); set => SetCount(9, value); }

        public string CountTotal => CanHaveMultipleValues ? GetTotalFromIndexed() : $"{CountValue0}";

        public Visibility MultipleValueGroupVisibility =>
            CanHaveMultipleValues ? Visibility.Visible : Visibility.Collapsed;
        public Visibility SingleValueVisibility =>
            !CanHaveMultipleValues ? Visibility.Visible : Visibility.Collapsed;

        private string GetTotalFromIndexed() =>
            $"{CountValue0} {CountValue1} {CountValue2} {CountValue3} {CountValue4} {CountValue5} {CountValue6} {CountValue7} {CountValue8} {CountValue9}";


        private byte GetCount(CardIndex index)
        {
            if (index > 0 && !CanHaveMultipleValues)
                return 0;

            return cardCountService.GetCardCount(Value, index, IsPremium);
        }

        private void SetCount(CardIndex index, byte value)
        {
            cardCountService.SetCardCount(Value, index, IsPremium, value);
            OnPropertyChanged(nameof(CountTotal));
        }
    }
}
