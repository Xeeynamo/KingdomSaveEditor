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

using System.Windows;
using Xe.Tools;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Kh3.Models;
using KHSave.SaveEditor.Kh3.ViewModels;
using KHSave.Lib3.Types;
using KHSave.Lib3.Models;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
	public class PlayerViewModel : BaseNotifyPropertyChanged
	{
		private readonly PlayableCharacter playableCharacter;
		private readonly int index;

		public PlayerViewModel(PlayableCharacter playableCharacter, int index)
		{
			this.playableCharacter = playableCharacter;
			this.index = index;

			Weapon1 = new EquipmentItemEntryViewModel(playableCharacter.Weapons[0]);
			Weapon2 = new EquipmentItemEntryViewModel(playableCharacter.Weapons[1]);
			Weapon3 = new EquipmentItemEntryViewModel(playableCharacter.Weapons[2]);
			Armors = new EquipmentItemsViewModel(playableCharacter.Armors);
			Accessories = new EquipmentItemsViewModel(playableCharacter.Accessories);
			Consumables = new EquipmentItemsViewModel(playableCharacter.Items);
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

		public EquipmentItemEntryViewModel Weapon1 { get; }
		public EquipmentItemEntryViewModel Weapon2 { get; }
		public EquipmentItemEntryViewModel Weapon3 { get; }
		public EquipmentItemsViewModel Armors { get; }
		public EquipmentItemsViewModel Accessories { get; }
		public EquipmentItemsViewModel Consumables { get; }

		public ItemComboBoxModel<AiCombatStyleType> AiCombatStyle { get; }
		public ItemComboBoxModel<AiAbilityType> AiAbility { get; }
		public ItemComboBoxModel<AiRecoveryType> AiRecovery { get; }

		public AbilitiesViewModel Abilities { get; }

		public string Text => playableCharacter.ToString();
	}
}
