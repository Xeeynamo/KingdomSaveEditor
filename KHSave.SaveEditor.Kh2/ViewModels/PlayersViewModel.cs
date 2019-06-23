/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using KHSave.Lib2;
using KHSave.Lib2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class PlayersViewModel : GenericListModel<PlayerViewModel>
    {
        private readonly SaveKh2.SaveFinalMix save;

        public PlayersViewModel(SaveKh2.SaveFinalMix save) :
            this(save.Characters)
        {
            this.save = save;
        }

        public PlayersViewModel(IEnumerable<Character> list) :
            this(list.Select((pc, index) => new PlayerViewModel(pc, index)))
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
