using System.Collections.Generic;
using System.Linq;
using KHSave.Models;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class PlayersViewModel : GenericListModel<PlayerViewModel>
	{
		public PlayersViewModel(IEnumerable<PlayableCharacter> list) :
			base(list.Select((pc, index) => new PlayerViewModel(pc, index)))
		{

		}

		public PlayersViewModel(IEnumerable<PlayerViewModel> list) :
			base(list)
		{

		}

		protected override PlayerViewModel OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}
}
