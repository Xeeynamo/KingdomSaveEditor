using KHSave.Attributes;

namespace KHSave
{
	public class InventoryEntry
	{
		[Data] public byte Count { get; set; }
		[Data] public byte Unknown { get; set; }
	}
}
