/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

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

using KHSave.Attributes;
using KHSave.Lib2.Models;
using KHSave.Lib2.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Kh2.Interfaces;
using KHSave.SaveEditor.Kh2.Models;
using KHSave.SaveEditor.Kh2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class CharacterViewModel
    {
        private readonly ICharacter character;
        private readonly int index;
        private readonly IResourceGetter _resourceGetter;

        public CharacterViewModel(ICharacter character, int index, IResourceGetter resourceGetter)
        {
            this.character = character;
            this.index = index;
            _resourceGetter = resourceGetter;

            Armors = new EquipmentItemsViewModel(EquipmentManagerFactory.ForArmor(character), resourceGetter);
            Accessories = new EquipmentItemsViewModel(EquipmentManagerFactory.ForAccessory(character), resourceGetter);
            Consumables = new EquipmentItemsViewModel(EquipmentManagerFactory.ForConsumable(character), resourceGetter);
            Abilities = character.Abilities.Select((_, i) => new AbilityModel(i, character.Abilities)).ToList();
        }
        public IEnumerable<KeyValuePair<EquipmentType, string>> AbilityTypes => _resourceGetter.Abilities;

        public string Name => InfoAttribute.GetInfo((CharacterType)index);

        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public KhEnumListModel<EnumIconTypeModel<EquipmentType>, EquipmentType> Equipments => _resourceGetter.Equipments;
        public EquipmentType Weapon { get => character.Weapon; set => character.Weapon = value; }
        public EquipmentItemsViewModel Armors { get; }
        public EquipmentItemsViewModel Accessories { get; }
        public EquipmentItemsViewModel Consumables { get; }
        public List<AbilityModel> Abilities { get; set; }
        public short Unk02 { get => character.Unk02; set => character.Unk02 = value; }
        public byte HpCur { get => character.HpCur; set => character.HpCur = value; }
        public byte HpMax { get => character.HpMax; set => character.HpMax = value; }
        public byte MpCur { get => character.MpCur; set => character.MpCur = value; }
        public byte MpMax { get => character.MpMax; set => character.MpMax = value; }
        public byte ApBoost { get => character.ApBoost; set => character.ApBoost = value; }
        public byte StrengthBoost { get => character.StrengthBoost; set => character.StrengthBoost = value; }
        public byte MagicBoost { get => character.MagicBoost; set => character.MagicBoost = value; }
        public byte DefenseBoost { get => character.DefenseBoost; set => character.DefenseBoost = value; }
        public byte Unk0c { get => character.Unk0c; set => character.Unk0c = value; }
        public byte Unk0d { get => character.Unk0d; set => character.Unk0d = value; }
        public byte Unk0e { get => character.Unk0e; set => character.Unk0e = value; }
        public byte Level { get => character.Level; set => character.Level = value; }
        public byte ArmorCount { get => character.ArmorCount; set => character.ArmorCount = value; }
        public byte AccessoryCount { get => character.AccessoryCount; set => character.AccessoryCount = value; }
        public byte ItemCount { get => character.ItemCount; set => character.ItemCount = value; }
        public byte UnknownCount { get => character.UnknownCount; set => character.UnknownCount = value; }

        public BattleStyleType BattleStyle { get => character.BattleStyle; set => character.BattleStyle = value; }
        public AbilityStyleType AbilityStyle1 { get => character.AbilityStyle1; set => character.AbilityStyle1 = value; }
        public AbilityStyleType AbilityStyle2 { get => character.AbilityStyle2; set => character.AbilityStyle2 = value; }
        public AbilityStyleType AbilityStyle3 { get => character.AbilityStyle3; set => character.AbilityStyle3 = value; }
        public AbilityStyleType AbilityStyle4 { get => character.AbilityStyle4; set => character.AbilityStyle4 = value; }
    }
}
