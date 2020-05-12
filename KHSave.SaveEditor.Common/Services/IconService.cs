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
		public enum IconPack
		{
			KingdomHearts2,
			KingdomHeartsBbs,
			FF7Remake,
		}

		private static readonly Dictionary<string, string> IconsDefault = new Dictionary<string, string>()
		{
			["Tent"] = "kh2-icon-tent",
			["Food"] = "FoodIcon",
			["Snack"] = "SnackIcon",
			["Synthesis"] = "kh2-icon-synthesis",
			["MogItem"] = "KupoCoinIcon",
			["Magic"] = "kh2-icon-magic",
			["Link"] = "LinkIcon",
			["Keyblade"] = "kh2-equip-keyblade",
			["Staff"] = "kh2-equip-staff",
			["Shield"] = "kh2-equip-shield",
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

			["MagicMateria"] = "materia-magic",
			["CommandMateria"] = "materia-command",
			["SupportMateria"] = "materia-support",
			["CompleteMateria"] = "materia-complete",
			["SummonMateria"] = "materia-summon",
		};

		private static readonly Dictionary<IconPack, Dictionary<string, string>> IconPacks = new Dictionary<IconPack, Dictionary<string, string>>()
		{
			[IconPack.KingdomHearts2] = new Dictionary<string, string>()
			{
				["Consumable"] = "kh2-icon-consumable",
				["KeyItem"] = "kh2-item-key",
				["Money"] = "ff7r-item-gil", // TODO replace with munny
				["Weapon"] = "kh2-icon-weapon",
				["Armor"] = "kh2-equip-armor",
				["Accessory"] = "kh2-equip-accessory",
			},
			[IconPack.KingdomHeartsBbs] = new Dictionary<string, string>()
			{
				["Attack"] = "kh2-equip-keyblade",
				["Consumable"] = "kh2-icon-consumable",
				["AbilityPrice"] = "khbbs-icon-ability-price",
				["AbilityStatus"] = "khbbs-icon-ability-status",
				["AbilitySupport"] = "khbbs-icon-ability-support",
				["Defense"] = "khbbs-icon-defense",
				["Finisher"] = "khbbs-icon-finisher",
				["Movement"] = "khbbs-icon-movement",
				["Reprisal"] = "khbbs-icon-reprisal",
				["Shotlock"] = "khbbs-icon-shotlock",
				["Dlink"] = "khbbs-icon-dlink",
			},
			[IconPack.FF7Remake] = new Dictionary<string, string>()
			{
				["Consumable"] = "ff7r-icon-consumable",
				["KeyItem"] = "ff7r-icon-key",
				["Money"] = "ff7r-icon-gil",
				["Weapon"] = "ff7r-icon-weapon",
				["Armor"] = "ff7r-icon-armor",
				["Accessory"] = "ff7r-icon-accessory",

				["WeaponCloud"] = "ff7r-icon-cloud",
				["WeaponBarret"] = "ff7r-icon-barret",
				["WeaponTifa"] = "ff7r-icon-tifa",
				["WeaponAerith"] = "ff7r-icon-aerith",
				["Manuscript"] = "ff7r-icon-manuscript",
				["Materia"] = "ff7r-icon-materia",
				["Track"] = "ff7r-icon-track",
			},
		};

		private static Dictionary<string, Uri> Icons = new Dictionary<string, Uri>();

		static IconService()
		{
			UseIconPack(IconPack.KingdomHearts2);
		}

		public static void UseIconPack(IconPack iconPack)
		{
			Icons = IconPacks[iconPack].Concat(IconsDefault)
				.ToDictionary(x => x.Key, x => new Uri($"pack://application:,,,/KHSave.SaveEditor;component/Images/{x.Value}.png"));
		}

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

		public static ImageSource Icon(string iconName) =>
			iconName == null ? null :
			Icons.TryGetValue(iconName, out var uri) ? new BitmapImage(uri) : null;
	}
}
