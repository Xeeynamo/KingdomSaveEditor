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
using KHSave.Lib3;
using KHSave.Lib3.Types;
using KHSave.SaveEditor.Common.Models;
using System;

namespace KHSave.SaveEditor.Kh3.Models
{
    public class MaterialModel : EnumIconTypeModel<MaterialType>
    {
        private readonly ISaveKh3 save;
        private readonly int index;

        public MaterialModel(ISaveKh3 save, int index)
        {
            this.save = save;
            this.index = index;
        }

        public MaterialType MaterialType => (MaterialType)index;

        public override string Name => InfoAttribute.GetInfo(MaterialType);
        public int Count
        {
            get => save.MaterialsCount[index];
            set
            {
                save.MaterialsCount[index] = (short)Math.Min(short.MaxValue, Math.Max(0, value));
                OnPropertyChanged(nameof(Count));
            }
        }
    }
}
