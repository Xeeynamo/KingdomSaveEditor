using KHSave;
using System;
using Xe.Tools.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class SystemViewModel
	{
		private readonly Kh3 save;

		public SystemViewModel(Kh3 save)
		{
			this.save = save;
			DifficultyType = new EnumModel<DifficultyType>();
			WorldIconType = new EnumModel<WorldType>();
			CharacterIconType = new EnumModel<CharacterIconType>();
		}

		public EnumModel<DifficultyType> DifficultyType { get; }
		public EnumModel<WorldType> WorldIconType { get; }
		public EnumModel<CharacterIconType> CharacterIconType { get; }

		public DifficultyType Difficulty
		{
			get => save.Difficulty;
			set => save.Difficulty = value;
		}

		public WorldType WorldIcon
		{
			get => save.WorldLogo;
			set => save.WorldLogo = value;
		}

		public CharacterIconType CharacterIcon
		{
			get => save.MySaveIcon;
			set => save.MySaveIcon = value;
		}

		public string GameTimer => $"{(int)save.GameTime.TotalHours}:{save.GameTime.Minutes:D02}:{save.GameTime.Seconds:D02}";

		public int TotalExp
		{
			get => save.TotalExp;
			set => save.TotalExp = value;
		}

		public int Munny
		{
			get => save.Munny;
			set => save.Munny = value;
		}

		public byte DisplayLevel
		{
			get => save.Level;
			set => save.Level = value;
		}

		public short SavesCount
		{
			get => save.SavesCount;
			set => save.SavesCount = value;
		}
	}
}
