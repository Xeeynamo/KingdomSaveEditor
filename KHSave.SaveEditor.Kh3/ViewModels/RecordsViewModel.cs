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

namespace KHSave.SaveEditor.Kh3.ViewModels
{
    public partial class RecordsViewModel
	{
		private readonly SaveKh3 save;

		public RecordShotlockListModel<RecordShotlockType> Shotlocks { get; }
		public RecordAttractionListModel<RecordAttractionType> Attractions { get; }
        public IEnumerable<FlantasticModel> Flantastics { get; }

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
