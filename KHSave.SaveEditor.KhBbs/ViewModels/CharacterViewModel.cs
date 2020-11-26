using KHSave.LibBbs.Models;
using KHSave.LibBbs.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using System.Windows;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class CharacterViewModel
    {
        private readonly Character character;

        public CharacterViewModel(Character character)
        {
            this.character = character;
            Weapon = new ItemComboBoxModel<WeaponType>(() => character.Weapon, x => character.Weapon = x);
        }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public ItemComboBoxModel<WeaponType> Weapon { get; set; }

        public uint Experience { get => character.Experience; set => character.Experience = value; }
        public uint Money { get => character.Money; set => character.Money = value; }
        public uint Medals { get => character.Medals; set => character.Medals = value; }
        public ushort Level { get => character.Level; set => character.Level = value; }
        public ushort Hp1 { get => character.Hp1; set => character.Hp1 = value; }
        public ushort Hp2 { get => character.Hp2; set => character.Hp2 = value; }
        public ushort Unk12 { get => character.Unk12; set => character.Unk12 = value; }
        public ushort Unk14 { get => character.Unk14; set => character.Unk14 = value; }
        public ushort Unk16 { get => character.Unk16; set => character.Unk16 = value; }
        public ushort Magic { get => character.Magic; set => character.Magic = value; }
        public ushort Defense { get => character.Defense; set => character.Defense = value; }
        public ushort ArenaLevel { get => character.ArenaLevel; set => character.ArenaLevel = value; }
        public ushort Strength { get => character.Strength; set => character.Strength = value; }
        public ushort Unk20 { get => character.Unk20; set => character.Unk20 = value; }
        public ushort Unk22 { get => character.Unk22; set => character.Unk22 = value; }
        public ushort Unk24 { get => character.Unk24; set => character.Unk24 = value; }
        public ushort Unk26 { get => character.Unk26; set => character.Unk26 = value; }
        public ushort Unk28 { get => character.Unk28; set => character.Unk28 = value; }
        public ushort Unk2C { get => character.Unk2C; set => character.Unk2C = value; }
        public ushort Unk2E { get => character.Unk2E; set => character.Unk2E = value; }
    }
}
