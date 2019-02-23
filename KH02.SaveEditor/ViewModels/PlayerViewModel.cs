using KHSave;
using System.Collections.Generic;
using KH02.SaveEditor.Models;
using KHSave.Models;
using KHSave.Types;
using Xe.Tools;

namespace KH02.SaveEditor.ViewModels
{
	public class PlayerViewModel : BaseNotifyPropertyChanged
	{
		private readonly PlayableCharacter playableCharacter;
		private readonly int index;

		public PlayerViewModel(PlayableCharacter playableCharacter, int index)
		{
			this.playableCharacter = playableCharacter;
			this.index = index;

			WeaponType = new GenericEnumModel<WeaponType>();
			ArmorType = new GenericEnumModel<ArmorType>();
			AccessoryType = new GenericEnumModel<AccessoryType>();
			ItemType = new GenericEnumModel<ConsumableType>();
		}

		public string Name => ((PlayableCharacterType)index).ToString();

		public GenericEnumModel<WeaponType> WeaponType { get; }
		public GenericEnumModel<ArmorType> ArmorType { get; }
		public GenericEnumModel<AccessoryType> AccessoryType { get; }
		public GenericEnumModel<ConsumableType> ItemType { get; }

		public byte AtkBoost
		{
			get => playableCharacter.AtkBoost;
			set => playableCharacter.AtkBoost = value;
		}

		public byte MagBoost
		{
			get => playableCharacter.MagBoost;
			set => playableCharacter.MagBoost = value;
		}

		public byte DefBoost
		{
			get => playableCharacter.DefBoost;
			set => playableCharacter.DefBoost = value;
		}

		public byte ApBoost
		{
			get => playableCharacter.ApBoost;
			set => playableCharacter.ApBoost = value;
		}

		public int Hp {
			get => playableCharacter.Hp;
			set => playableCharacter.Hp = value;
		}

		public int Mp
		{
			get => playableCharacter.Mp;
			set => playableCharacter.Mp = value;
		}

		public int Focus
		{
			get => playableCharacter.Focus;
			set => playableCharacter.Focus = value;
		}

		public int Weapon1Id
		{
			get => (int)playableCharacter.Weapons[0].WeaponId;
			set
			{
				playableCharacter.Weapons[0].WeaponId = (WeaponType)value;
				OnPropertyChanged(nameof(Weapon1));
			}
		}

		public WeaponType Weapon1
		{
			get => playableCharacter.Weapons[0].WeaponId;
			set
			{
				playableCharacter.Weapons[0].WeaponId = value;
				OnPropertyChanged(nameof(Weapon1Id));
			}
		}

		public int Weapon2Id
		{
			get => (int)playableCharacter.Weapons[1].WeaponId;
			set
			{
				playableCharacter.Weapons[1].WeaponId = (WeaponType)value;
				OnPropertyChanged(nameof(Weapon2));
			}
		}

		public WeaponType Weapon2
		{
			get => playableCharacter.Weapons[1].WeaponId;
			set
			{
				playableCharacter.Weapons[1].WeaponId = value;
				OnPropertyChanged(nameof(Weapon2Id));
			}
		}

		public int Weapon3Id
		{
			get => (int)playableCharacter.Weapons[2].WeaponId;
			set
			{
				playableCharacter.Weapons[2].WeaponId = (WeaponType)value;
				OnPropertyChanged(nameof(Weapon3));
			}
		}

		public WeaponType Weapon3
		{
			get => playableCharacter.Weapons[2].WeaponId;
			set
			{
				playableCharacter.Weapons[2].WeaponId = value;
				OnPropertyChanged(nameof(Weapon3Id));
			}
		}

		public ArmorType Armor1
		{
			get => playableCharacter.Armors[0].ArmorId;
			set => playableCharacter.Armors[0].ArmorId = value;
		}

		public ArmorType Armor2
		{
			get => playableCharacter.Armors[1].ArmorId;
			set => playableCharacter.Armors[1].ArmorId = value;
		}
		public ArmorType Armor3
		{
			get => playableCharacter.Armors[2].ArmorId;
			set => playableCharacter.Armors[2].ArmorId = value;
		}
		public ArmorType Armor4
		{
			get => playableCharacter.Armors[3].ArmorId;
			set => playableCharacter.Armors[3].ArmorId = value;
		}
		public ArmorType Armor5
		{
			get => playableCharacter.Armors[4].ArmorId;
			set => playableCharacter.Armors[4].ArmorId = value;
		}
		public ArmorType Armor6
		{
			get => playableCharacter.Armors[5].ArmorId;
			set => playableCharacter.Armors[5].ArmorId = value;
		}
		public ArmorType Armor7
		{
			get => playableCharacter.Armors[6].ArmorId;
			set => playableCharacter.Armors[6].ArmorId = value;
		}
		public ArmorType Armor8
		{
			get => playableCharacter.Armors[7].ArmorId;
			set => playableCharacter.Armors[7].ArmorId = value;
		}

		public AccessoryType Accessory1
		{
			get => playableCharacter.Accessories[0].AccessoryId;
			set => playableCharacter.Accessories[0].AccessoryId = value;
		}

		public AccessoryType Accessory2
		{
			get => playableCharacter.Accessories[1].AccessoryId;
			set => playableCharacter.Accessories[1].AccessoryId = value;
		}
		public AccessoryType Accessory3
		{
			get => playableCharacter.Accessories[2].AccessoryId;
			set => playableCharacter.Accessories[2].AccessoryId = value;
		}
		public AccessoryType Accessory4
		{
			get => playableCharacter.Accessories[3].AccessoryId;
			set => playableCharacter.Accessories[3].AccessoryId = value;
		}
		public AccessoryType Accessory5
		{
			get => playableCharacter.Accessories[4].AccessoryId;
			set => playableCharacter.Accessories[4].AccessoryId = value;
		}
		public AccessoryType Accessory6
		{
			get => playableCharacter.Accessories[5].AccessoryId;
			set => playableCharacter.Accessories[5].AccessoryId = value;
		}
		public AccessoryType Accessory7
		{
			get => playableCharacter.Accessories[6].AccessoryId;
			set => playableCharacter.Accessories[6].AccessoryId = value;
		}
		public AccessoryType Accessory8
		{
			get => playableCharacter.Accessories[7].AccessoryId;
			set => playableCharacter.Accessories[7].AccessoryId = value;
		}

		public ConsumableType Item1
		{
			get => playableCharacter.Items[0].ConsumableId;
			set => playableCharacter.Items[0].ConsumableId = value;
		}

		public ConsumableType Item2
		{
			get => playableCharacter.Items[1].ConsumableId;
			set => playableCharacter.Items[1].ConsumableId = value;
		}
		public ConsumableType Item3
		{
			get => playableCharacter.Items[2].ConsumableId;
			set => playableCharacter.Items[2].ConsumableId = value;
		}
		public ConsumableType Item4
		{
			get => playableCharacter.Items[3].ConsumableId;
			set => playableCharacter.Items[3].ConsumableId = value;
		}
		public ConsumableType Item5
		{
			get => playableCharacter.Items[4].ConsumableId;
			set => playableCharacter.Items[4].ConsumableId = value;
		}
		public ConsumableType Item6
		{
			get => playableCharacter.Items[5].ConsumableId;
			set => playableCharacter.Items[5].ConsumableId = value;
		}
		public ConsumableType Item7
		{
			get => playableCharacter.Items[6].ConsumableId;
			set => playableCharacter.Items[6].ConsumableId = value;
		}
		public ConsumableType Item8
		{
			get => playableCharacter.Items[7].ConsumableId;
			set => playableCharacter.Items[7].ConsumableId = value;
		}

		public IEnumerable<Ability> Abilities
		{
			get => playableCharacter.Abilities;
			set { }
		}

		public string Text => playableCharacter.ToString();
	}
}
