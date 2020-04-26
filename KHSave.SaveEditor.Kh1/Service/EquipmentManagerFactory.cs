using System;
using System.Collections.Generic;
using System.Linq;
using KHSave.Lib1.Models;
using KHSave.Lib1.Types;

namespace KHSave.SaveEditor.Kh1.Service
{
    public static class EquipmentManagerFactory
    {
        private class AccessoryEquipmentManager : IEquipmentManager
        {
            private readonly Character character;

            internal AccessoryEquipmentManager(Character character)
            {
                this.character = character;
            }

            public byte Count { get => character.AccessoryCount; set => character.AccessoryCount = Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(byte index) => (EquipmentType)character.Accessories[index];
            public void SetEquipment(byte index, EquipmentType equipment) => character.Accessories[index] = (byte)equipment;
        }

        private class ConsumableEquipmentManager : IEquipmentManager
        {
            private readonly Character character;

            internal ConsumableEquipmentManager(Character character)
            {
                this.character = character;
            }

            public byte Count { get => character.ItemCount; set => character.ItemCount = Math.Min(byte.MaxValue, value); }

            public EquipmentType GetEquipment(byte index) => (EquipmentType)character.Items[index];
            public void SetEquipment(byte index, EquipmentType equipment) => character.Items[index] = (byte)equipment;
        }

        public static IEquipmentManager ForAccessory(Character character) => new AccessoryEquipmentManager(character);
        public static IEquipmentManager ForConsumable(Character character) => new ConsumableEquipmentManager(character);
    }
}
