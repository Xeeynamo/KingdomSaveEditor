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

using KHSave.Lib2;
using KHSave.Lib2.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class SystemViewModel
    {
        private readonly SaveKh2.SaveFinalMix save;

        public SystemViewModel(SaveKh2.SaveFinalMix save)
        {
            this.save = save;
            ShortcutItems = new KhEnumListModel<EnumIconTypeModel<ItemType>, ItemType>(() => default(ItemType), x => { });
        }

        public KhEnumListModel<EnumIconTypeModel<ItemType>, ItemType> ShortcutItems { get; }

        public int Timer { get => save.Timer; set => save.Timer = value; }

        public ItemType ShortcutCircle { get => save.ShortcutCircle; set => save.ShortcutCircle = value; }
        public ItemType ShortcutTriangle { get => save.ShortcutTriangle; set => save.ShortcutTriangle = value; }
        public ItemType ShortcutSquare { get => save.ShortcutSquare; set => save.ShortcutSquare = value; }
        public ItemType ShortcutCross { get => save.ShortcutCross; set => save.ShortcutCross = value; }
    }
}
