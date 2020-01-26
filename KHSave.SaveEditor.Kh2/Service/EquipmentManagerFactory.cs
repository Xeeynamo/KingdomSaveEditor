using System;
using System.Collections.Generic;
using System.Linq;
using KHSave.Lib2.Models;
using KHSave.Lib2.Types;

namespace KHSave.SaveEditor.Kh2.Service
{
    public static class EquipmentManagerFactory
    {
        private class ArmorEquipmentManager : IEquipmentManager
        {
            private readonly Character character;

            internal ArmorEquipmentManager(Character character)
            {
                this.character = character;
            }

            public uint Count { get => character.ArmorCount; set => character.ArmorCount = (byte)Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(uint index) => (EquipmentType)character.Armors[index];
            public void SetEquipment(uint index, EquipmentType equipment) => character.Armors[index] = (short)equipment;
        }

        private class AccessoryEquipmentManager : IEquipmentManager
        {
            private readonly Character character;

            internal AccessoryEquipmentManager(Character character)
            {
                this.character = character;
            }

            public uint Count { get => character.AccessoryCount; set => character.AccessoryCount = (byte)Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(uint index) => (EquipmentType)character.Accessories[index];
            public void SetEquipment(uint index, EquipmentType equipment) => character.Accessories[index] = (short)equipment;
        }

        private class ConsumableEquipmentManager : IEquipmentManager
        {
            private readonly Character character;

            internal ConsumableEquipmentManager(Character character)
            {
                this.character = character;
            }

            public uint Count { get => character.ItemCount; set => character.ItemCount = (byte)Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(uint index) => (EquipmentType)character.Items[index];
            public void SetEquipment(uint index, EquipmentType equipment) => character.Items[index] = (short)equipment;
        }

        public static IEquipmentManager ForArmor(Character character) => new ArmorEquipmentManager(character);
        public static IEquipmentManager ForAccessory(Character character) => new AccessoryEquipmentManager(character);
        public static IEquipmentManager ForConsumable(Character character) => new ConsumableEquipmentManager(character);
    }
}
