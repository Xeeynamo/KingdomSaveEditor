using KHSave.LibBbs;
using KHSave.LibBbs.Models;
using KHSave.SaveEditor.KhBbs.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class DecksViewModel : GenericListModel<DeckViewModel>
    {
        public DecksViewModel(ISaveKhBbs save) :
            this(save.Decks, save.CommandList.Select((_, i) => new CommandListModel(i, save.CommandList)))
        {
        }

        public DecksViewModel(Deck[] decks, IEnumerable<CommandListModel> commandList) :
            base(decks.Select(x => new DeckViewModel(x, commandList)))
        {

        }
    }
}
