/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

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

using KHSave.SaveEditor.Common.Models;
using KHSave.Trssv.Models;
using KHSave.Trssv.Types;

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
        }

        public DifficultyType Difficulty { get => slot.Difficulty; set => slot.Difficulty = value; }
        public byte DisplayLevel { get => slot.Level; set => slot.Level = value; }
        public int TotalExp { get => slot.Experience; set => slot.Experience = value; }
        public LocationType Location { get => slot.Location; set => slot.Location = value; }
        public int StoryProgression { get => slot.StoryProgression; set => slot.StoryProgression = value; }
        public string MapPath { get => slot.MapPath; set => slot.MapPath = value; }
        public string MapSpawn { get => slot.MapSpawn; set => slot.MapSpawn = value; }
        public string PlayerScript { get => slot.PlayerScript; set => slot.PlayerScript = value; }
        public string PlayerCharacter { get => slot.PlayerCharacter; set => slot.PlayerCharacter = value; }
        public string SupportCharacter { get => slot.SupportCharacter; set => slot.SupportCharacter = value; }
    }
}
