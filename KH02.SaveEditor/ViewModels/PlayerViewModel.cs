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
using System.Windows;
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

			Weapon1 = new ItemComboBoxModel<WeaponType>(
				() => playableCharacter.Weapons[0].WeaponId,
				x => playableCharacter.Weapons[0].WeaponId = x);
			Weapon2 = new ItemComboBoxModel<WeaponType>(
				() => playableCharacter.Weapons[1].WeaponId,
				x => playableCharacter.Weapons[1].WeaponId = x);
			Weapon3 = new ItemComboBoxModel<WeaponType>(
				() => playableCharacter.Weapons[2].WeaponId,
				x => playableCharacter.Weapons[2].WeaponId = x);

			Armors = new EquipmentItemsViewModel<ArmorType>(playableCharacter.Armors);
			Accessories = new EquipmentItemsViewModel<AccessoryType>(playableCharacter.Accessories);
			Consumables = new EquipmentItemsViewModel<ConsumableType>(playableCharacter.Items);
			Abilities = new AbilitiesViewModel(playableCharacter.Abilities);

			AiCombatStyle = new ItemComboBoxModel<AiCombatStyleType>(
				() => playableCharacter.Ai.CombatStyle,
				x => playableCharacter.Ai.CombatStyle = x);
			AiAbility = new ItemComboBoxModel<AiAbilityType>(
				() => playableCharacter.Ai.Abilitiy,
				x => playableCharacter.Ai.Abilitiy = x);
			AiRecovery = new ItemComboBoxModel<AiRecoveryType>(
				() => playableCharacter.Ai.Recovery,
				x => playableCharacter.Ai.Recovery = x);
		}

		public string Name => ((PlayableCharacterType)index).ToString();

		public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
		public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

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

		public ItemComboBoxModel<WeaponType> Weapon1 { get; }
		public ItemComboBoxModel<WeaponType> Weapon2 { get; }
		public ItemComboBoxModel<WeaponType> Weapon3 { get; }

		public EquipmentItemsViewModel<ArmorType> Armors { get; }
		public EquipmentItemsViewModel<AccessoryType> Accessories { get; }
		public EquipmentItemsViewModel<ConsumableType> Consumables { get; }

		public ItemComboBoxModel<AiCombatStyleType> AiCombatStyle { get; }
		public ItemComboBoxModel<AiAbilityType> AiAbility { get; }
		public ItemComboBoxModel<AiRecoveryType> AiRecovery { get; }

		public AbilitiesViewModel Abilities { get; }

		public string Text => playableCharacter.ToString();
	}
}
