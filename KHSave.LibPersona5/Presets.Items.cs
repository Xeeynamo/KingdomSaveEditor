using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xe.BinaryMapper;

/// <summary>
/// A big THANK YOU to TGEnigma, who made this possible:
/// https://github.com/TGEnigma/010-Editor-Templates
/// </summary>
namespace KHSave.LibPersona5
{
    public static partial class Presets
    {
        public const int Protagonist = 0x0002;
        public const int Ryuji = 0x0004;
        public const int Morgana = 0x0008;
        public const int Ann = 0x0010;
        public const int Yusuke = 0x0020;
        public const int Makoto = 0x0040;
        public const int Haru = 0x0080;
        public const int Futaba = 0x0100;
        public const int Goro = 0x0200;
        public const int Violet = 0x0400;

        public const int ArmorEquipMaleMask = Protagonist | Ryuji | Yusuke | Goro;
        public const int ArmorEquipFemaleMask = Ann | Makoto | Haru | Futaba;
        public const int ArmorEquipCatMask = Morgana;
        public const int ArmorEquipUnisexMask = ArmorEquipMaleMask | ArmorEquipFemaleMask;
        public const int ArmorEquipAllMask = ArmorEquipUnisexMask | ArmorEquipCatMask;

        public interface IItem
        {
            int Id { get; set; }
            string Name { get; set; }
        }

        public class Items
        {
            public IEnumerable<Accessory> Accessories { get; set; }
            public IEnumerable<Armor> Armors { get; set; }
            public IEnumerable<Consumable> Consumables { get; set; }
            public IEnumerable<KeyItem> KeyItems { get; set; }
            public IEnumerable<Material> Materials { get; set; }
            public IEnumerable<MeleeWeapon> MeleeWeapons { get; set; }
            public IEnumerable<Outfit> Outfits { get; set; }
            public IEnumerable<SkillCard> SkillCards { get; set; }
            public IEnumerable<RangeWeapon> RangeWeapons { get; set; }
        }

        public class Accessory : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [Data(Count = 0x40)] public byte[] Ignore { get; set; }
        }

        public class Armor : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            [Data] public int Unk00 { get; set; }
            [Data] public short Unk04 { get; set; }
            [Data] public short Unk06 { get; set; }
            [Data] public short Unk08 { get; set; }
            [Data] public short EquippableFlags { get; set; }
            [Data(Count = 0x24)] public byte[] Ignore { get; set; }
        }

        public class Consumable : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class KeyItem : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Material : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class MeleeWeapon : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [Data] public int Unk00 { get; set; }
            [Data] public short Unk04 { get; set; }
            [Data] public short Unk06 { get; set; }
            [Data] public short Unk08 { get; set; }
            [Data] public short EquippableFlags { get; set; }
            [Data(Count = 0x24)] public byte[] Ignore { get; set; }
        }

        public class Outfit : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class SkillCard : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class RangeWeapon : IItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [Data] public int Unk00 { get; set; }
            [Data] public short Unk04 { get; set; }
            [Data] public short Unk06 { get; set; }
            [Data] public short Unk08 { get; set; }
            [Data] public short EquippableFlags { get; set; }
            [Data(Count = 0x28)] public byte[] Ignore { get; set; }
        }

        public static Items GetItems(bool isRoyal)
        {
            using (var stream = File.OpenRead(GetResourceFileName("Item.bin", isRoyal)))
            {
                return new Items
                {
                    Accessories = GetItems<Accessory>(stream, 0x40, "AccessoryNames", isRoyal),
                    Armors = GetItems<Armor>(stream, 0x30, "ArmorNames", isRoyal),
                    Consumables = GetItems<Consumable>(stream, 0x30, "ConsumableItemNames", isRoyal),
                    KeyItems = GetItems<KeyItem>(stream, 0xc, "KeyItemNames", isRoyal),
                    Materials = GetItems<Material>(stream, 0x2c, "MaterialNames", isRoyal),
                    MeleeWeapons = GetItems<MeleeWeapon>(stream, 0x30, "MeleeWeaponNames", isRoyal),
                    Outfits = GetItems<Outfit>(stream, 0x20, "OutfitNames", isRoyal),
                    SkillCards = GetItems<SkillCard>(stream, 0x18, "SkillCardNames", isRoyal),
                    RangeWeapons = GetItems<RangeWeapon>(stream, 0x34, "RangedWeaponNames", isRoyal),
                };
            }
        }

        private static IEnumerable<TItem> GetItems<TItem>(
            Stream stream, int stride, string namesSource, bool isRoyal)
            where TItem : class, IItem
        {
            var length = stream.ReadInt32BE();
            var count = length / stride;
            var startPosition = stream.Position;

            var names = File.ReadAllLines(GetResourceFileName($"{namesSource}.txt", isRoyal));
            var items = Enumerable.Range(0, count)
                .Select(i => SavePersona5.Mapper.ReadObject<TItem>(stream))
                .ToList();
            for (var i = 0; i < count; i++)
            {
                var item = items[i];
                item.Id = i;
                item.Name = i < names.Length ? names[i] : $"##{i}";
            }

            var nextPosition = startPosition + length;
            while ((nextPosition % 16) != 0)
                nextPosition++;
            stream.Position = nextPosition;

            return items;
        }
    }
}
