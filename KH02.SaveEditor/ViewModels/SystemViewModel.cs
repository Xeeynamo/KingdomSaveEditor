using KHSave;
using System;
using KH02.SaveEditor.Models;
using KHSave.Types;
using Xe.Tools.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class SystemViewModel
	{
		private readonly Kh3 save;

		public SystemViewModel(Kh3 save)
		{
			this.save = save;
			DifficultyType = new GenericEnumModel<DifficultyType>();
			WorldIconType = new GenericEnumModel<WorldType>();
			LocationType = new GenericEnumModel<LocationType>();
			CharacterIconType = new GenericEnumModel<CharacterIconType>();
		}

		public GenericEnumModel<DifficultyType> DifficultyType { get; }
		public GenericEnumModel<WorldType> WorldIconType { get; }
		public GenericEnumModel<LocationType> LocationType { get; }
		public GenericEnumModel<CharacterIconType> CharacterIconType { get; }

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

		public LocationType Location
		{
			get => save.LocationName;
			set => save.LocationName = value;
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
