using System;
using KH02.SaveEditor.Models;
using KHSave.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class EquipmentItemEntryViewModel<T>
		where T : struct, IConvertible
	{
		public GenericEnumModel<T> EquipmentType { get; }

		public EquipmentItem Item { get; }

		public T ItemId
		{
			get => (T)(object)Item.Id;
			set => Item.Id = (byte)(object)value;
		}

		public EquipmentItemEntryViewModel(EquipmentItem item)
		{
			EquipmentType = new GenericEnumModel<T>();
			Item = item;
		}
	}
}
