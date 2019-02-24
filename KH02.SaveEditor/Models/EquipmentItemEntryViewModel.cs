using System;
using KHSave.Models;

namespace KH02.SaveEditor.Models
{
	public class EquipmentItemEntryViewModel<T> : ItemComboBoxModel<T>
		where T : struct, IConvertible
	{
		public EquipmentItem Item { get; }

		public bool Enabled
		{
			get => Item.Enabled;
			set => Item.Enabled = value;
		}

		public EquipmentItemEntryViewModel(EquipmentItem item) :
			base(() => (T)(object)item.Id, x => item.Id = (byte)(object)x)
		{
			Item = item;
		}
	}
}
