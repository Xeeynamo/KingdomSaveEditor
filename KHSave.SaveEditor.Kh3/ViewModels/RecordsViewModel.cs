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

using System.Collections.Generic;
using KHSave.Lib3.Types;
using KHSave.SaveEditor.Kh3.Models;
using KHSave.Types;
using KHSave.Extensions;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
    public partial class RecordsViewModel
	{
		private readonly SaveKh3 save;

		public RecordShotlockListModel<RecordShotlockType> Shotlocks { get; }
		public RecordAttractionListModel<RecordAttractionType> Attractions { get; }
        public IEnumerable<FlantasticModel> Flantastics { get; }

        public int VerumRexHighScore { get => save.Records.VerumRexHighScore; set => save.Records.VerumRexHighScore = value; }
        public int VerumRexTimer { get => save.Records.VerumRexTimer; set => save.Records.VerumRexTimer = value; }
        public int FlashTracer1HighScore { get => save.Records.FlashTracer1HighScore; set => save.Records.FlashTracer1HighScore = value; }
        public int FlashTracer2HighScore { get => save.Records.FlashTracer2HighScore; set => save.Records.FlashTracer2HighScore = value; }
        public int FlashTracer1Timer { get => save.Records.FlashTracer1Timer; set => save.Records.FlashTracer1Timer = value; }
        public int FlashTracer2Timer { get => save.Records.FlashTracer2Timer; set => save.Records.FlashTracer2Timer = value; }
        public int FrozenSliderHighScore { get => save.Records.FrozenSliderHighScore; set => save.Records.FrozenSliderHighScore = value; }
        public int FrozenSliderTimer { get => save.Records.FrozenSliderTimer; set => save.Records.FrozenSliderTimer = value; }
        public int FrozenSliderMedals { get => save.Records.FrozenSliderMedals; set => save.Records.FrozenSliderMedals = value; }
        public int FestivalDanceHighScore { get => save.Records.FestivalDanceHighScore; set => save.Records.FestivalDanceHighScore = value; }
        public int FestivalDanceLongestChain { get => save.Records.FestivalDanceLongestChain; set => save.Records.FestivalDanceLongestChain = value; }

        public bool FrozenSliderMedal1
        {
            get => save.Records.FrozenSliderMedals.GetFlag(0);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(0, value);
        }
        public bool FrozenSliderMedal2
        {
            get => save.Records.FrozenSliderMedals.GetFlag(1);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(1, value);
        }
        public bool FrozenSliderMedal3
        {
            get => save.Records.FrozenSliderMedals.GetFlag(2);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(2, value);
        }
        public bool FrozenSliderMedal4
        {
            get => save.Records.FrozenSliderMedals.GetFlag(3);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(3, value);
        }
        public bool FrozenSliderMedal5
        {
            get => save.Records.FrozenSliderMedals.GetFlag(4);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(4, value);
        }
        public bool FrozenSliderMedal6
        {
            get => save.Records.FrozenSliderMedals.GetFlag(5);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(5, value);
        }
        public bool FrozenSliderMedal7
        {
            get => save.Records.FrozenSliderMedals.GetFlag(6);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(6, value);
        }
        public bool FrozenSliderMedal8
        {
            get => save.Records.FrozenSliderMedals.GetFlag(7);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(7, value);
        }
        public bool FrozenSliderMedal9
        {
            get => save.Records.FrozenSliderMedals.GetFlag(8);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(8, value);
        }
        public bool FrozenSliderMedal10
        {
            get => save.Records.FrozenSliderMedals.GetFlag(9);
            set => save.Records.FrozenSliderMedals = save.Records.FrozenSliderMedals.SetFlag(9, value);
        }

        public RecordsViewModel(SaveKh3 save)
		{
			this.save = save;
			Shotlocks = new RecordShotlockListModel<RecordShotlockType>(save.RecordShotlocksUseCount, save.Records.ShotlocksHighScore);
            Attractions = new RecordAttractionListModel<RecordAttractionType>(save.RecordAttractionsUseCount, save.Records.AttractionsHighScore);
            Flantastics = GetFlantasticModels(save);
        }

        private static IEnumerable<FlantasticModel> GetFlantasticModels(SaveKh3 save) =>
            new FlantasticModel[]
            {
                new FlantasticModel("Cherry Flan", save.Records.CherryFlan),
                new FlantasticModel("Strawberry Flan", save.Records.StrawberryFlan),
                new FlantasticModel("Orange Flan", save.Records.OrangeFlan),
                new FlantasticModel("Banana Flan", save.Records.BananaFlan),
                new FlantasticModel("Grape Flan", save.Records.GrapeFlan),
                new FlantasticModel("Watermelon Flan", save.Records.WatermelonFlan),
                new FlantasticModel("Honeydew Flan", save.Records.HoneydewFlan),
            };
    }
}
