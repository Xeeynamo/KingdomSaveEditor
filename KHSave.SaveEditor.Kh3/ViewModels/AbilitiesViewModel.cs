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

using System.Collections.Generic;
using System.Linq;
using KHSave.Attributes;
using KHSave.Lib3.Models;
using KHSave.Lib3.Types;
using Xe.Tools.Wpf.Models;
using KHSave.SaveEditor.Common.Models;
using System.Windows;
using KHSave.SaveEditor.Common;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
	public class AbilitiesViewModel : GenericListModel<AbilityEntryViewModel>
	{
		public AbilitiesViewModel(IEnumerable<Ability> list)
			: this(list
                  .Select((x, i) => new AbilityEntryViewModel(x, i))
                  .Where(x => Global.CanDisplay(x.Value)))
		{ }

		public AbilitiesViewModel(IEnumerable<AbilityEntryViewModel> list)
			: base(list)
		{
            
		}

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
		protected override AbilityEntryViewModel OnNewItem()
		{
			throw new System.NotImplementedException();
		}
	}

	public class AbilityEntryViewModel : EnumIconTypeModel<AbilityType>
	{
		private readonly Ability ability;

		public AbilityEntryViewModel(Ability ability, int index)
		{
			this.ability = ability;
			Value = (AbilityType)index;
		}

		public override string Name => InfoAttribute.GetInfo(Value);

        public string Raw
        {
            get => $"{ability.Data:X07}";
            set
            {
                if (!int.TryParse(value, System.Globalization.NumberStyles.HexNumber, null, out var newVaule))
                    return;

                ability.Data = newVaule;
                OnPropertyChanged(nameof(Unlocked));
                OnPropertyChanged(nameof(Active));
                OnPropertyChanged(nameof(Unseen));
                OnPropertyChanged(nameof(Duplicate));
            }
        }

        public bool Unlocked { get => ability.Unlocked; set { ability.Unlocked = value; OnPropertyChanged(nameof(Raw)); } }
		public bool Active { get => ability.Enabled; set { ability.Enabled = value; OnPropertyChanged(nameof(Raw)); } }
		public bool Unseen { get => ability.Unseen; set { ability.Unseen = value; OnPropertyChanged(nameof(Raw)); } }
		public bool Duplicate { get => ability.Flag3; set { ability.Flag3 = value; OnPropertyChanged(nameof(Raw)); } }

		public override string ToString()
		{
			return Name;
		}}
}
