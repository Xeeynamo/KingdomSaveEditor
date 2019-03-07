using KHSave.Attributes;

namespace KH02.SaveEditor
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
			return IsAdvancedMode || !UnusedAttribute.IsUnused(item);
		}
	}
}
