using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KH02.SaveEditor.Models;
using KHSave.Attributes;
using KHSave.Models;

namespace KH02.SaveEditor.ViewModels
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
