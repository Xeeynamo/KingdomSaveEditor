using System;
using KHSave.Lib2.Models;
using KHSave.Lib2.Types;

namespace KHSave.SaveEditor.Kh2.Service
{
    public static class EquipmentManagerFactory
    {
        private class ArmorEquipmentManager : IEquipmentManager
        {
            private readonly ICharacter character;

            internal ArmorEquipmentManager(ICharacter character)
            {
                this.character = character;
            }

            public uint Count { get => character.ArmorCount; set => character.ArmorCount = (byte)Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(uint index) => (EquipmentType)character.Armors[index];
            public void SetEquipment(uint index, EquipmentType equipment) => character.Armors[index] = (short)equipment;
        }

        private class AccessoryEquipmentManager : IEquipmentManager
        {
            private readonly ICharacter character;

            internal AccessoryEquipmentManager(ICharacter character)
            {
                this.character = character;
            }

            public uint Count { get => character.AccessoryCount; set => character.AccessoryCount = (byte)Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(uint index) => (EquipmentType)character.Accessories[index];
            public void SetEquipment(uint index, EquipmentType equipment) => character.Accessories[index] = (short)equipment;
        }

        private class ConsumableEquipmentManager : IEquipmentManager
        {
            private readonly ICharacter character;

            internal ConsumableEquipmentManager(ICharacter character)
            {
                this.character = character;
            }

            public uint Count { get => character.ItemCount; set => character.ItemCount = (byte)Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(uint index) => (EquipmentType)character.Items[index];
            public void SetEquipment(uint index, EquipmentType equipment) => character.Items[index] = (short)equipment;
        }

        public static IEquipmentManager ForArmor(ICharacter character) => new ArmorEquipmentManager(character);
        public static IEquipmentManager ForAccessory(ICharacter character) => new AccessoryEquipmentManager(character);
        public static IEquipmentManager ForConsumable(ICharacter character) => new ConsumableEquipmentManager(character);
    }
}
