using KHSave.LibBbs.Models;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class DecksViewModel : GenericListModel<DeckViewModel>
    {
        public DecksViewModel(Deck[] decks, CommandListViewModel commandList) :
            base(decks.Select(x => new DeckViewModel(x, commandList)))
        {

        }
    }
}
