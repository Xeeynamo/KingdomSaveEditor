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

			WeaponType = new GenericEnumModel<EnumIconTypeModel<WeaponType>, WeaponType>();
			AiCombatStyleType = new GenericEnumModel<AiCombatStyleType>();
			AiAbilityType = new GenericEnumModel<AiAbilityType>();
			AiRecoveryType = new GenericEnumModel<AiRecoveryType>();

			Armors = new EquipmentItemsViewModel<ArmorType>(playableCharacter.Armors);
			Accessories = new EquipmentItemsViewModel<AccessoryType>(playableCharacter.Accessories);
			Consumables = new EquipmentItemsViewModel<ConsumableType>(playableCharacter.Items);
		}

		public string Name => ((PlayableCharacterType)index).ToString();

		public GenericEnumModel<EnumIconTypeModel<WeaponType>, WeaponType> WeaponType { get; }
		public GenericEnumModel<AiCombatStyleType> AiCombatStyleType { get; }
		public GenericEnumModel<AiAbilityType> AiAbilityType { get; }
		public GenericEnumModel<AiRecoveryType> AiRecoveryType { get; }

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

		public WeaponType Weapon1
		{
			get => playableCharacter.Weapons[0].WeaponId;
			set => playableCharacter.Weapons[0].WeaponId = value;
		}

		public WeaponType Weapon2
		{
			get => playableCharacter.Weapons[1].WeaponId;
			set => playableCharacter.Weapons[1].WeaponId = value;
		}

		public WeaponType Weapon3
		{
			get => playableCharacter.Weapons[2].WeaponId;
			set => playableCharacter.Weapons[2].WeaponId = value;
		}

		public EquipmentItemsViewModel<ArmorType> Armors { get; }
		public EquipmentItemsViewModel<AccessoryType> Accessories { get; }
		public EquipmentItemsViewModel<ConsumableType> Consumables { get; }

		//public EquipmentItemsViewModel<AiCombatStyleType> AiCombatStyle { get; }
		public AiCombatStyleType AiCombatStyle
		{
			get => playableCharacter.Ai.CombatStyle;
			set => playableCharacter.Ai.CombatStyle = value;
		}

		public AiAbilityType AiAbility
		{
			get => playableCharacter.Ai.Abilitiy;
			set => playableCharacter.Ai.Abilitiy = value;
		}

		public AiRecoveryType AiRecovery
		{
			get => playableCharacter.Ai.Recovery;
			set => playableCharacter.Ai.Recovery = value;
		}


		public IEnumerable<Ability> Abilities
		{
			get => playableCharacter.Abilities;
			set { }
		}

		public string Text => playableCharacter.ToString();
	}
}
