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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KHSave.Attributes;
using Xe.Tools.Models;

namespace KH02.SaveEditor.Models
{
	public class EnumIconTypeModel<T> : EnumItemModel<T>
		where T : struct, IConvertible
	{
		private static readonly Dictionary<string, Uri> ICONS = new Dictionary<string, string>()
		{
			["Consumable"] = "ItemIcon",
			["Tent"] = "TentIcon",
			["KeyItem"] = "KeyItemIcon",
			["Food"] = "FoodIcon",
            ["Snack"] = "SnackIcon",
            ["Synthesis"] = "MineralIcon",
            ["MogItem"] = "KupoCoinIcon",
			["Magic"] = "MagicIcon",
			["Link"] = "LinkIcon",
			["Keyblade"] = "KeybladeIcon",
			["Staff"] = "StaffIcon",
			["Shield"] = "ShieldIcon",
			["Weapon"] = "MiscWeaponIcon",
			["Armor"] = "ArmorIcon",
			["Accessory"] = "AccessoryIcon",
			["Ability"] = "AbilityEquippedIcon",
			["CombatStyle"] = "CombatStyleIcon",
			["Command"] = "AbilityUnequippedIcon",
		}.ToDictionary(x => x.Key, x => new Uri($"pack://application:,,,/KH02.SaveEditor;component/Images/{x.Value}.png"));

		public ImageSource Icon
		{
			get
			{
				var types = InfoAttribute.GetItemTypes(Value);
				foreach (var type in types)
				{
					if (ICONS.TryGetValue(type, out var uri))
						return new BitmapImage(uri);
				}

				return null;
			}
		}
	}
}
