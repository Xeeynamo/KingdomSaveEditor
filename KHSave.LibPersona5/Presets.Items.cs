using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

/// <summary>
/// A big THANK YOU to TGEnigma, who made this possible:
/// https://github.com/TGEnigma/010-Editor-Templates
/// </summary>
namespace KHSave.LibPersona5
{
    public static partial class Presets
    {
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
        }

        public static Items GetItems(bool isRoyal)
        {
            using (var stream = File.OpenRead(isRoyal ?
                "Resources/itemr.bin" : "Resources/item.bin"))
            {
                return new Items
                {
                    Accessories = GetItems<Accessory>(stream, 0x40, "AccessoryNames"),
                };
            }
        }

        private static IEnumerable<TItem> GetItems<TItem>(
            Stream stream, int stride, string namesSource)
            where TItem : class, IItem
        {
            var length = stream.ReadInt32BE();
            var count = length / stride;

            var names = File.ReadAllLines($"Resources/{namesSource}.txt");
            var items = Enumerable.Range(0, count)
                .Select(i => SavePersona5.Mapper.ReadObject<TItem>(stream))
                .ToList();
            for (var i = 0; i < count; i++)
            {
                var item = items[i];
                item.Id = i;
                item.Name = i < items.Count ? names[i] : $"##{i}";
            }

            return items;
        }
    }
}
