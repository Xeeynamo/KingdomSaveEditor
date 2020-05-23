using KHSave.LibBbs;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class DecksViewModel : GenericListModel<DeckViewModel>
    {
        public DecksViewModel(SaveKhBbs.SaveFinalMix save) :
            base(save.Decks.Select(x => new DeckViewModel(x, save.CommandList)))
        {
        }
    }
}
