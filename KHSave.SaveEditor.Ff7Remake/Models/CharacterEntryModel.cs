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
using KHSave.LibFf7Remake;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common;
using System;
using System.Windows;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class CharacterEntryModel
    {
        private readonly CharacterType _characterType;
        private readonly Character _character;
        private readonly CharacterStats _characterStats;

        public CharacterEntryModel(SaveFf7Remake save, int index)
        {
            _characterType = (CharacterType)index;
            _character = save.Characters[index];
            _characterStats = save.CharactersStats[index];
        }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public string Name => InfoAttribute.GetInfo(_characterType);
        public bool IsUnused => _characterType >= CharacterType.Unused5;

        public byte Level { get => _character.Level; set => _character.Level = value; }
        public bool IsUnlocked { get => _character.IsUnlocked; set => _character.IsUnlocked = value; }
        public byte AtbBarCount { get => _character.AtbBarCount; set => _character.AtbBarCount = value; }
        public byte Speed { get => _character.Speed; set => _character.Speed = value; }
        public int Limit { get => _character.Limit; set => _character.Limit = Math.Max(0, Math.Min(1000, value)); }
        public int Unknown08 { get => _character.Unknown08; set => _character.Unknown08 = value; }
        public int Unknown0c { get => _character.Unknown0c; set => _character.Unknown0c = value; }
        public int CurrentHp { get => _character.CurrentHp; set => _character.CurrentHp = value; }
        public int MaxHp { get => _character.MaxHp; set => _character.MaxHp = value; }
        public int CurrentMp { get => _character.CurrentMp; set => _character.CurrentMp = value; }
        public int MaxMp { get => _character.MaxMp; set => _character.MaxMp = value; }
        public int Experience { get => _character.Experience; set => _character.Experience = value; }
        public int Unknown14 { get => _character.Unknown14; set => _character.Unknown14 = value; }
        public int Attack { get => _character.Attack; set => _character.Attack = value; }
        public int MagicAttack { get => _character.MagicAttack; set => _character.MagicAttack = value; }
        public int Defense { get => _character.Defense; set => _character.Defense = value; }
        public int MagicDefense { get => _character.MagicDefense; set => _character.MagicDefense = value; }
        public int Luck { get => _character.Luck; set => _character.Luck = value; }
        public int Unknown3c { get => _character.Unknown3c; set => _character.Unknown3c = value; }

        public int Strength { get => _characterStats.Strength; set => _characterStats.Strength = value; }
        public int Magic { get => _characterStats.Magic; set => _characterStats.Magic = value; }
        public int Vitality { get => _characterStats.Vitality; set => _characterStats.Vitality = value; }
        public int Spirit { get => _characterStats.Spirit; set => _characterStats.Spirit = value; }
    }
}
