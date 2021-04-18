using KHSave.LibDDD.Model;
using System.Text;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class DeckViewModel : BaseNotifyPropertyChanged
    {
        private readonly IDeck deck;

        public DeckViewModel(IDeck deck)
        {
            this.deck = deck;
        }

        public string Name { get => Encoding.GetEncoding(932).GetString(deck.Name); set => deck.Name = Encoding.GetEncoding(932).GetBytes(value); }
    }
}
