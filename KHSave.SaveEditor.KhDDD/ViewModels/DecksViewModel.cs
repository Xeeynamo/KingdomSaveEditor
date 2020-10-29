using KHSave.LibDDD.Model;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class DecksViewModel : GenericListModel<DeckViewModel>
    {
        public DecksViewModel(Deck[] decks):
            base(decks.Select(x => new DeckViewModel(x)))
        {

        }
    }
}
