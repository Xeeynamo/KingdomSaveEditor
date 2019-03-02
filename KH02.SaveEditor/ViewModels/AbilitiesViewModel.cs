
using System.Collections.Generic;
using System.Linq;
using KH02.SaveEditor.Models;
using KHSave.Attributes;
using KHSave.Models;
using KHSave.Types;
using Xe.Tools;
using Xe.Tools.Wpf.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class AbilitiesViewModel : GenericListModel<AbilityEntryViewModel>
	{
		public AbilitiesViewModel(IEnumerable<Ability> list)
			: this(list.Select((x, i) => new AbilityEntryViewModel(x, i)))
		{ }

		public AbilitiesViewModel(IEnumerable<AbilityEntryViewModel> list)
			: base(list)
		{
		}

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

		public string Name => InfoAttribute.GetInfo(Value);

		public string Raw => $"{ability.Data:X07}";
		public bool Unlocked { get => ability.Unlocked; set { ability.Unlocked = value; OnPropertyChanged(nameof(Raw)); } }
		public bool Active { get => ability.Enabled; set { ability.Enabled = value; OnPropertyChanged(nameof(Raw)); } }
		public bool Unseen { get => ability.Unseen; set { ability.Unseen = value; OnPropertyChanged(nameof(Raw)); } }
		public bool Flag3 { get => ability.Flag3; set { ability.Flag3 = value; OnPropertyChanged(nameof(Raw)); } }

		public override string ToString()
		{
			return Name;
		}}
}
