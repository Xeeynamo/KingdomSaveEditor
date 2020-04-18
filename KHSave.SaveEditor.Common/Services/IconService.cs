using KHSave.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KHSave.SaveEditor.Common.Services
{
    public class IconService
	{
		public static readonly Dictionary<string, Uri> Icons = new Dictionary<string, string>()
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
			["Boost"] = "kh2-icon-tent",
			["Form"] = "kh2-item-key",
			["Map"] = "kh2-item-key",
			["Report"] = "kh2-item-key",
			["Summon"] = "kh2-item-key",
			["Recipe"] = "KupoCoinIcon",
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
			["Materia"] = "materia-magic",
			["MagocMateria"] = "materia-magic",
			["CommandMateria"] = "materia-command",
			["SupportMateria"] = "materia-support",
			["CompleteMateria"] = "materia-complete",
			["SummonMateria"] = "materia-summon",
		}.ToDictionary(x => x.Key, x => new Uri($"pack://application:,,,/KHSave.SaveEditor;component/Images/{x.Value}.png"));

		public static ImageSource Icon(object item)
		{
			var types = InfoAttribute.GetItemTypes(item);
			foreach (var type in types)
			{
				if (Icons.TryGetValue(type, out var uri))
					return new BitmapImage(uri);
			}

			return null;
		}
	}
}
