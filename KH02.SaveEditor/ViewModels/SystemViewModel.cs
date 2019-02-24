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

using System;
using System.Windows;
using KHSave;
using KH02.SaveEditor.Models;
using KHSave.Attributes;
using KHSave.Types;
using Xe.Tools;
using Xe.Tools.Models;

namespace KH02.SaveEditor.ViewModels
{
	public class SystemViewModel : BaseNotifyPropertyChanged
	{
		private readonly Kh3 save;
		private bool _isAdvanceMode;

		public enum RoomSpawnType
		{
			[Info("Start")] Lv_Start,
			[Info("Save")] Lv_Save,
			[Info("AutoSave")] AutoSave
		}

		public SystemViewModel(Kh3 save)
		{
			this.save = save;
			DifficultyType = new GenericEnumModel<DifficultyType>();
			WorldIconType = new GenericEnumModel<WorldType>();
			LocationType = new GenericEnumModel<LocationType>();
			CharacterIconType = new GenericEnumModel<CharacterIconType>();
			RoomWorldType = new GenericEnumModel<EnumItemModel<string>, WorldType, string>(x => WorldAttribute.GetWorldId(x));
			SpawnType = new GenericEnumModel<RoomSpawnType>();
		}

		public bool IsAdvancedMode
		{
			get => _isAdvanceMode;
			set
			{
				_isAdvanceMode = value;
				OnPropertyChanged(nameof(IsAdvancedMode));
				OnPropertyChanged(nameof(SimpleVisibility));
				OnPropertyChanged(nameof(AdvancedVisibility));
			}
		}

		public Visibility SimpleVisibility => IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
		public Visibility AdvancedVisibility => IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

		public GenericEnumModel<DifficultyType> DifficultyType { get; }
		public GenericEnumModel<WorldType> WorldIconType { get; }
		public GenericEnumModel<LocationType> LocationType { get; }
		public GenericEnumModel<CharacterIconType> CharacterIconType { get; }
		public GenericEnumModel<EnumItemModel<string>, WorldType, string> RoomWorldType { get; }
		public GenericEnumModel<RoomSpawnType> SpawnType { get; }

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

		public string MapPath
		{
			get => save.MapPath;
			set
			{
				save.MapPath = value;
				OnPropertyChanged(nameof(RoomWorldId));
				OnPropertyChanged(nameof(RoomMapIndex));
			}
		}

		public string MapSpawn
		{
			get => save.MapSpawn;
			set
			{
				save.MapSpawn = value;
				OnPropertyChanged(nameof(SpawnTypeValue));
				OnPropertyChanged(nameof(SpawnIndex));
			}
		}

		public string PlayerScript
		{
			get => save.PlayerScript;
			set => save.PlayerScript = value;
		}

		public string PlayerCharacter
		{
			get => save.PlayerCharacter;
			set => save.PlayerCharacter = value;
		}

		public string RoomWorldId
		{
			get => MapPath.Length > 5 ? MapPath.Substring(MapPath.Length - 5, 2) : "";
			set
			{
				MapPath = $"/Game/Levels/{value}/{value}_{RoomMapIndex:D02}/{value}_{RoomMapIndex:D02}";
				OnPropertyChanged(nameof(MapPath));
				OnPropertyChanged(nameof(RoomWorldId));
				OnPropertyChanged(nameof(RoomMapIndex));
				ResetSpawnPoint(SpawnTypeValue, SpawnIndex);
			}
		}

		public int RoomMapIndex
		{
			get
			{
				var index = 0;
				if (MapPath.Length > 2)
				{
					int.TryParse(MapPath.Substring(MapPath.Length - 2), out index);
				}

				return index;
			}
			set
			{
				var index = Math.Min(99, Math.Max(0, value));
				MapPath = $"/Game/Levels/{RoomWorldId}/{RoomWorldId}_{index:D02}/{RoomWorldId}_{index:D02}";
				OnPropertyChanged(nameof(MapPath));
				OnPropertyChanged(nameof(RoomWorldId));
				OnPropertyChanged(nameof(RoomMapIndex));
				ResetSpawnPoint(SpawnTypeValue, SpawnIndex);
			}
		}

		public string SpawnTypeValue
		{
			get
			{
				if (MapSpawn.Length > 7)
				{
					var lastPart = MapSpawn.Substring(6);
					var spawnIndex = SpawnIndex;
					if (spawnIndex > 0)
					{
						var separator = lastPart.LastIndexOf("_");
						return separator > 0 ? lastPart.Substring(0, separator) : lastPart;
					}

					return lastPart;
				}

				return MapSpawn;
			}
			set => ResetSpawnPoint(value, SpawnIndex);
		}

		public int SpawnIndex
		{
			get
			{
				var index = 0;
				if (MapSpawn.Length > 2)
				{
					int.TryParse(MapSpawn.Substring(MapSpawn.Length - 2), out index);
				}

				return index;
			}
			set => ResetSpawnPoint(SpawnTypeValue, value);
		}

		private void ResetSpawnPoint(string spawnType, int spawnIndex)
		{
			var mapSpawn = $"{RoomWorldId}_{RoomMapIndex:D02}_{spawnType}";
			// TODO kg_01_Lv_Start_ex38: the 'ex' part is missing
			mapSpawn += spawnIndex == 0 ? "" : $"_{spawnIndex:D02}";

			MapSpawn = mapSpawn;
			OnPropertyChanged(nameof(MapSpawn));
			OnPropertyChanged(nameof(SpawnTypeValue));
			OnPropertyChanged(nameof(SpawnIndex));
		}
	}
}
