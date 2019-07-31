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
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KHSave.Attributes;

namespace KHSave.SaveEditor.Common.Models
{
	public class EnumIconTypeModel<T> : GenericEntryModel<string, T>
		where T : struct, IConvertible
	{
		private static readonly Dictionary<string, Uri> ICONS = new Dictionary<string, string>()
		{
			["Consumable"] = "kh2-icon-item",
			["Tent"] = "kh2-icon-tent",
			["KeyItem"] = "kh2-item-key",
			["Food"] = "FoodIcon",
            ["Snack"] = "SnackIcon",
            ["Synthesis"] = "kh2-icon-synthesis",
            ["MogItem"] = "KupoCoinIcon",
			["Magic"] = "kh2-icon-magic",
			["Link"] = "LinkIcon",
			["Keyblade"] = "kh2-equip-keyblade",
			["Staff"] = "kh2-equip-staff",
			["Shield"] = "kh2-equip-shield",
			["Weapon"] = "MiscWeaponIcon",
			["Armor"] = "kh2-equip-armor",
			["Accessory"] = "kh2-equip-accessory",
			["Ability"] = "kh2-icon-ability",
			["CombatStyle"] = "kh2-icon-style",
			["Command"] = "kh2-icon-mickey",
			["Card"] = "card-generic",
			["CardEnemy"] = "card-enemy",
			["CardFriend"] = "card-friend",
			["CardItem"] = "card-item",
			["CardMagic"] = "card-magic",
			["CardMap"] = "card-world",
			["CardMapRed"] = "card-world",
			["CardMapGreen"] = "card-world",
			["CardMapBlue"] = "card-world",
			["CardMapSpecial"] = "card-world",
			["CardSpecial"] = "card-kingdom",
			["CardSummon"] = "card-magic",
			["CardWeapon"] = "card-weapon",
			["CardWorld"] = "card-world",
		}.ToDictionary(x => x.Key, x => new Uri($"pack://application:,,,/KHSave.SaveEditor;component/Images/{x.Value}.png"));

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
