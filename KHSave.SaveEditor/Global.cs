using KHSave.Attributes;

namespace KHSave.SaveEditor
{
	public static class Global
	{
		public static bool IsAdvancedMode
		{
			get => Properties.Settings.Default.AdvancedMode;
			set
			{
				Properties.Settings.Default.AdvancedMode = value;
				Properties.Settings.Default.Save();
			}
		}

		public static bool CanDisplay(object item)
		{
			return IsAdvancedMode ||
				item.GetType() == typeof(string) ||
				!UnusedAttribute.IsUnused(item);
		}
	}
}
