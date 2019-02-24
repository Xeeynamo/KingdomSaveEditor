using System;
using System.Collections.Generic;
using KH02.SaveEditor.Models;
using KH02.SaveEditor.Views;
using KHSave.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class EquipmentItemsViewModel<T>
		where T : struct, IConvertible
	{
		public EquipmentItemEntryViewModel<T> Item1 { get; }
		public EquipmentItemEntryViewModel<T> Item2 { get; }
		public EquipmentItemEntryViewModel<T> Item3 { get; }
		public EquipmentItemEntryViewModel<T> Item4 { get; }
		public EquipmentItemEntryViewModel<T> Item5 { get; }
		public EquipmentItemEntryViewModel<T> Item6 { get; }
		public EquipmentItemEntryViewModel<T> Item7 { get; }
		public EquipmentItemEntryViewModel<T> Item8 { get; }

		public EquipmentItemsViewModel(IReadOnlyList<EquipmentItem> items)
		{
			Item1 = new EquipmentItemEntryViewModel<T>(items[0]);
			Item2 = new EquipmentItemEntryViewModel<T>(items[1]);
			Item3 = new EquipmentItemEntryViewModel<T>(items[2]);
			Item4 = new EquipmentItemEntryViewModel<T>(items[3]);
			Item5 = new EquipmentItemEntryViewModel<T>(items[4]);
			Item6 = new EquipmentItemEntryViewModel<T>(items[5]);
			Item7 = new EquipmentItemEntryViewModel<T>(items[6]);
			Item8 = new EquipmentItemEntryViewModel<T>(items[7]);
		}
	}
}
