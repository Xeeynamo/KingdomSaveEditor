using System.Collections.Generic;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class PlayersViewModel : GenericListModel<PlayerViewModel>
	{
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
