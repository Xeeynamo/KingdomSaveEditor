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
	}
}
