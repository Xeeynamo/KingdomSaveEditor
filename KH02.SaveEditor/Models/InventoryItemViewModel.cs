using System;
using KHSave.Models;
using KHSave.Types;
using Xe.Tools;

namespace KH02.SaveEditor.Models
{
	public class InventoryItemViewModel : BaseNotifyPropertyChanged
	{
		private InventoryEntry inventoryEntry;
		private int index;

		public InventoryItemViewModel(InventoryEntry inventoryEntry, int index)
		{
			this.inventoryEntry = inventoryEntry;
			this.index = index;
		}

		public string Name => ((InventoryType)index).ToString();

		public int Count
		{
			get => inventoryEntry.Count;
			set => inventoryEntry.Count = (byte)Math.Min(byte.MaxValue, Math.Max(byte.MinValue, value));
		}

		public override string ToString()
		{
			return $"{Name} x{Count}";
		}
	}
}
