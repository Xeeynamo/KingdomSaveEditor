using KHSave.Attributes;
using KHSave.LibFf7Remake.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace KHSave.SaveEditor.Ff7Remake.Data
{
    public class ItemName
    {
        [YamlMember(Alias = "id")]
        public int Id { get; set; }

        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        [YamlMember(Alias = "icon")]
        public string Icon { get; set; }
    }

    public static class ItemsPreset
    {
        public class ItemsResource
        {
            [YamlMember(Alias = "name")]
            public string Name { get; set; }

            [YamlMember(Alias = "items")]
            public List<ItemName> Items { get; set; }
        }

        public class ItemProperty
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Icon { get; set; }
        }

        private static Dictionary<int, ItemProperty> _data = Enum.GetValues(typeof(InventoryType))
            .Cast<InventoryType>()
            .ToDictionary(x => (int)x, x => new ItemProperty
            {
                Id = (int)x,
                Name = InfoAttribute.GetInfo(x),
                Icon = GetIconAttribute(x)
            });

        public static void LazyInitialize()
        {
            try
            {
                Task.Run(async () =>
                {
                    foreach (var item in await InternalFetchLocations())
                    {
                        _data[item.Id] = new ItemProperty
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Icon = item.Icon
                        };
                    }
                });
            }
            catch
            {
                // Whatever happens, we do not want to cause fatal crashes
            }
        }

        public static ItemProperty Get(InventoryType type) => Get((int)type) ?? new ItemProperty
        {
            Id = (int)type,
            Name = $"{(int)type}",
            Icon = null
        };
        public static IEnumerable<ItemProperty> GetAll() =>
            _data.Values.OrderBy(x => x.Id);

        public static ItemProperty Get(int itemId) =>
            _data.TryGetValue(itemId, out var item) ? item : null;

        private static string GetIconAttribute(InventoryType item)
        {
            var memberInfo = typeof(InventoryType).GetMember(item.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                return memberInfo.CustomAttributes
                    .Select(x =>
                    {
                        var name = x.AttributeType.Name;
                        var indexAttributeStr = name.IndexOf("Attribute");
                        return indexAttributeStr > 0 ? name.Substring(0, indexAttributeStr) : null;
                    })
                    .FirstOrDefault();
            }

            return null;
        }

        private static async Task<IEnumerable<ItemName>> InternalFetchLocations()
        {
            const string url = "https://raw.githubusercontent.com/Xeeynamo/KH3SaveEditor/master/resources/ff7r-meta-items.yml";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var model = new DeserializerBuilder()
                            .Build()
                            .Deserialize<ItemsResource>(body);

                        return model.Items;
                    }

                    throw new Exception($"Fetch failed: the server returned {response.StatusCode}.");
                }
            }
        }
    }
}
