using KHSave.LibDDD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class DeckViewModel : BaseNotifyPropertyChanged
    {
        private readonly Deck deck;

        public DeckViewModel(Deck deck)
        {
            this.deck = deck;
        }

        public string Name { get => Encoding.GetEncoding(932).GetString(deck.Name); set => deck.Name = Encoding.GetEncoding(932).GetBytes(value);  }
    }
}
