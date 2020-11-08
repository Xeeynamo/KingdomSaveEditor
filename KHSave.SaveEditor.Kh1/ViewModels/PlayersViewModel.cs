using KHSave.Lib1;
using KHSave.Lib1.Models;
using KHSave.SaveEditor.Kh1.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class PlayersViewModel : GenericListModel<PlayerViewModel>
    {
        private readonly ISaveKh1 save;

        public PlayersViewModel(ISaveKh1 save, IGetAbilities getAbilities) :
            this(save.Characters, getAbilities)
        {
            this.save = save;
        }

        public PlayersViewModel(IEnumerable<Character> list, IGetAbilities getAbilities) :
            this(list.Select((pc, index) => new PlayerViewModel(pc, index, getAbilities)))
        {

        }

        public PlayersViewModel(IEnumerable<PlayerViewModel> list) :
            base(list)
        {

        }

        public Visibility PlayerVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility PlayerNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(PlayerViewModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(PlayerVisible));
            OnPropertyChanged(nameof(PlayerNotVisible));
        }

        protected override PlayerViewModel OnNewItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
