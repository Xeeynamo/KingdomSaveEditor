using KHSave.LibBbs;
using KHSave.LibBbs.Models;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class CommandListViewModel : GenericListModel<CommandViewModel>
    {
        private readonly SaveKhBbs.SaveFinalMix save;

        public CommandListViewModel(SaveKhBbs.SaveFinalMix save) :
            this(save.CommandList)
        {
            this.save = save;
        }

        public CommandListViewModel(IEnumerable<Command> list) :
            this(list.Select(x => new CommandViewModel(x)))
        {

        }

        public CommandListViewModel(IEnumerable<CommandViewModel> list) :
            base(list)
        {

        }
    }
}
