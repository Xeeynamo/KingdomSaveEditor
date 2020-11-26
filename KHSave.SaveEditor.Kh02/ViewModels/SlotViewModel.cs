/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

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

using KHSave.Attributes;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.Trssv.Models;
using KHSave.Trssv.Types;
using System;
using System.Windows;

namespace KHSave.SaveEditor.Kh02.ViewModels
{
    public class SlotViewModel : GenericEntryModel<string, SlotViewModel>
    {
        private readonly Slot slot;
        private readonly int slotIndex;

        public SlotViewModel(int slotIndex, Slot slot)
        {
            this.slotIndex = slotIndex;
            this.slot = slot;
            Name = $"Slot {slotIndex}";
            Value = this;

            Difficulty = new KhEnumListModel<DifficultyType>(() => slot.Difficulty, x => slot.Difficulty = x);
            Location = new KhEnumListModel<LocationType>(() => slot.Location, x => slot.Location = x);
            Maps = new KhEnumListModel<MapType>(
                () => Enum.TryParse<MapType>(CurrentMap, out var result) ? result : default(MapType),
                x => MapInfoAttribute.GetMapId(x),
                x => InfoAttribute.GetInfo(x));
            SpawnPoints = new KhEnumListModel<SpawnType>(
                () => Enum.TryParse<SpawnType>(MapSpawn, out var result) ? result : default(SpawnType),
                x => x.ToString());
        }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public KhEnumListModel<DifficultyType> Difficulty { get; }
        public KhEnumListModel<LocationType> Location { get; }
        public KhEnumListModel<MapType> Maps { get; }
        public KhEnumListModel<SpawnType> SpawnPoints { get; }

        public byte DisplayLevel { get => slot.Level; set => slot.Level = value; }
        public int TotalExp { get => slot.Experience; set => slot.Experience = value; }
        public int StoryProgression { get => slot.StoryProgression; set => slot.StoryProgression = value; }
        public string MapPath { get => slot.MapPath; set => slot.MapPath = value; }
        public string MapSpawn { get => slot.MapSpawn; set => slot.MapSpawn = value; }
        public string PlayerScript { get => slot.PlayerScript; set => slot.PlayerScript = value; }
        public string PlayerCharacter { get => slot.PlayerCharacter; set => slot.PlayerCharacter = value; }
        public string SupportCharacter { get => slot.SupportCharacter; set => slot.SupportCharacter = value; }

        public string CurrentMap
        {
            get
            {
                var separatorIndex = MapPath.LastIndexOf('/') + 1;
                return separatorIndex > 0 ? MapPath.Substring(separatorIndex) : string.Empty;
            }
            set
            {
                MapPath = $"/Game/Levels/dw/{value}/{value}";
                OnPropertyChanged();
                OnPropertyChanged(nameof(MapPath));
            }
        }
    }
}
