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

using System.Linq;
using KHSave.SaveEditor.Models;
using KHSave;
using KHSave.Types;

namespace KHSave.SaveEditor.ViewModels
{
	public class ShortcutsViewModel
	{
		public class ShortcutGroupViewModel
		{
			private readonly Kh3 _save;
			public ItemComboBoxModel<CommandType> Circle { get; set; }
			public ItemComboBoxModel<CommandType> Triangle { get; set; }
			public ItemComboBoxModel<CommandType> Square { get; set; }
			public ItemComboBoxModel<CommandType> Cross { get; set; }

			public ShortcutGroupViewModel(Kh3 save, int groupIndex)
			{
				_save = save;

				Circle = new ItemComboBoxModel<CommandType>(
					() => save.Shortcuts[groupIndex].Circle,
					x => save.Shortcuts[groupIndex].Circle = x);

				Triangle = new ItemComboBoxModel<CommandType>(
					() => save.Shortcuts[groupIndex].Triangle,
					x => save.Shortcuts[groupIndex].Triangle = x);

				Square = new ItemComboBoxModel<CommandType>(
					() => save.Shortcuts[groupIndex].Square,
					x => save.Shortcuts[groupIndex].Square = x);

				Cross = new ItemComboBoxModel<CommandType>(
					() => save.Shortcuts[groupIndex].Cross,
					x => save.Shortcuts[groupIndex].Cross = x);
			}
		}

		private readonly Kh3 _save;

		public ShortcutsViewModel(Kh3 save)
		{
			_save = save;
			Shortcut1 = new ShortcutGroupViewModel(_save, 0);
			Shortcut2 = new ShortcutGroupViewModel(_save, 1);
			Shortcut3 = new ShortcutGroupViewModel(_save, 2);

			Magic1 = new ItemComboBoxModel<CommandType>(() => save.Magics[0], x => save.Magics[0] = x);
			Magic2 = new ItemComboBoxModel<CommandType>(() => save.Magics[1], x => save.Magics[1] = x);
			Magic3 = new ItemComboBoxModel<CommandType>(() => save.Magics[2], x => save.Magics[2] = x);
			Magic4 = new ItemComboBoxModel<CommandType>(() => save.Magics[3], x => save.Magics[3] = x);
			Magic5 = new ItemComboBoxModel<CommandType>(() => save.Magics[4], x => save.Magics[4] = x);
			Magic6 = new ItemComboBoxModel<CommandType>(() => save.Magics[5], x => save.Magics[5] = x);
			Link1 = new ItemComboBoxModel<CommandType>(() => save.Links[0], x => save.Links[0] = x);
			Link2 = new ItemComboBoxModel<CommandType>(() => save.Links[1], x => save.Links[1] = x);
			Link3 = new ItemComboBoxModel<CommandType>(() => save.Links[2], x => save.Links[2] = x);
			Link4 = new ItemComboBoxModel<CommandType>(() => save.Links[3], x => save.Links[3] = x);
			Link5 = new ItemComboBoxModel<CommandType>(() => save.Links[4], x => save.Links[4] = x);
		}


		public ShortcutGroupViewModel Shortcut1 { get; set; }
		public ShortcutGroupViewModel Shortcut2 { get; set; }
		public ShortcutGroupViewModel Shortcut3 { get; set; }
		public ItemComboBoxModel<CommandType> Magic1 { get; set; }
		public ItemComboBoxModel<CommandType> Magic2 { get; set; }
		public ItemComboBoxModel<CommandType> Magic3 { get; set; }
		public ItemComboBoxModel<CommandType> Magic4 { get; set; }
		public ItemComboBoxModel<CommandType> Magic5 { get; set; }
		public ItemComboBoxModel<CommandType> Magic6 { get; set; }
		public ItemComboBoxModel<CommandType> Link1 { get; set; }
		public ItemComboBoxModel<CommandType> Link2 { get; set; }
		public ItemComboBoxModel<CommandType> Link3 { get; set; }
		public ItemComboBoxModel<CommandType> Link4 { get; set; }
		public ItemComboBoxModel<CommandType> Link5 { get; set; }


	}
}
