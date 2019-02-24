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
	public class EquipmentItemEntryViewModel<T>
		where T : struct, IConvertible
	{

		public GenericEnumModel<EnumIconTypeModel<T>, T> EquipmentType { get; }

		public EquipmentItem Item { get; }

		public bool Enabled
		{
			get => Item.Enabled;
			set => Item.Enabled = value;
		}

		public T ItemId
		{
			get => (T)(object)Item.Id;
			set => Item.Id = (byte)(object)value;
		}

		public EquipmentItemEntryViewModel(EquipmentItem item)
		{
			EquipmentType = new GenericEnumModel<EnumIconTypeModel<T>, T>();
			Item = item;
		}
	}
}
