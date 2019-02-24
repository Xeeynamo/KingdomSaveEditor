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
			["KeyItem"] = "KeyItemIcon",
			["Food"] = "FoodIcon",
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
