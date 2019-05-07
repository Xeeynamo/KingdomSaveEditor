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

using System;
using System.Collections.Generic;
using KHSave.Attributes;

namespace KHSave.SaveEditor.Kh3.Models
{
    public class AttractionRecordItemModel<T>
        where T : struct, IConvertible
    {
        private readonly List<short> itemsTotalUses;
        private readonly List<int> itemsScore;
        private readonly int index;

        public AttractionRecordItemModel(List<short> itemsTotalUses, List<int> itemsScore, int index)
        {
            this.itemsTotalUses = itemsTotalUses;
            this.itemsScore = itemsScore;
            this.index = index;
        }

        public string Name => InfoAttribute.GetInfo((T)(object)index);

        public int HighScore
        {
            get => itemsScore[index];
            set => itemsScore[index] = value;
        }

        public short TotalUses
        {
            get => itemsTotalUses[index];
            set => itemsTotalUses[index] = value;
        }
    }
}
