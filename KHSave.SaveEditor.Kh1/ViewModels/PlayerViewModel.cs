using KHSave.Attributes;
using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Kh1.Service;
using System.Windows;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class PlayerViewModel
    {
        private readonly Character character;
        private readonly int index;

        public PlayerViewModel(Character character, int index)
        {
            this.character = character;
            this.index = index;

            Weapon = new ItemComboBoxModel<EquipmentType>(() => character.Weapon, x => character.Weapon = x);
            Accessories = new EquipmentItemsViewModel(EquipmentManagerFactory.ForAccessory(character));
            Consumables = new EquipmentItemsViewModel(EquipmentManagerFactory.ForConsumable(character));
        }

        public string Name => InfoAttribute.GetInfo((PlayableCharacterType)index);
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public ItemComboBoxModel<EquipmentType> Weapon { get; }
        public EquipmentItemsViewModel Accessories { get; }
        public EquipmentItemsViewModel Consumables { get; }
        public byte HpCur { get => character.HpCur; set => character.HpCur = value; }
        public byte HpMax { get => character.HpMax; set => character.HpMax = value; }
        public byte MpCur { get => character.MpCur; set => character.MpCur = value; }
        public byte MpMax { get => character.MpMax; set => character.MpMax = value; }
        public byte ApMax { get => character.ApMax; set => character.ApMax = value; }
        public byte Level { get => character.Level; set => character.Level = value; }
        public int Experience { get => character.Experience; set => character.Experience = value; }
        public byte Strength { get => character.Strength; set => character.Strength = value; }
        public byte Defense { get => character.Defense; set => character.Defense = value; }
        public byte AccessoryCount { get => character.AccessoryCount; set => character.AccessoryCount = value; }
        public byte ItemCount { get => character.ItemCount; set => character.ItemCount = value; }
    }
}