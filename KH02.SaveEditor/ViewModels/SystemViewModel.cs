/*
    Kingdom Hearts 0.2 and 3 Save Editor
    Copyright (C) 2019  Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using KHSave;
using KH02.SaveEditor.Models;
using KHSave.Types;

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

		public bool SaveClear
		{
			get => save.SaveClear;
			set => save.SaveClear = value;
		}

		public short SavesCount
		{
			get => save.SavesCount;
			set => save.SavesCount = value;
		}
	}
}
