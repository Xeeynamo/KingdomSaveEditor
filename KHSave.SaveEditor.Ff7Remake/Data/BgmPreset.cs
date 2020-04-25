using KHSave.SaveEditor.Ff7Remake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace KHSave.SaveEditor.Ff7Remake.Data
{
    public static class BgmPreset
    {
        private class BgmResource
        {
            [YamlMember(Alias = "name")]
            public string Name { get; set; }

            [YamlMember(Alias = "bgm")]
            public List<BgmItem> Bgm { get; set; }
        }

        private class BgmItem
        {
            [YamlMember(Alias = "id")]
            public int Id { get; set; }

            [YamlMember(Alias = "name")]
            public string Name { get; set; }
        }

        private static List<BgmModel> _bgm;

        public static void LazyInitialize()
        {
            try
            {
                Task.Run(async () =>
                {
                    _bgm = (await InternalFetchLocations()).Select(x => new BgmModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToList();
                });
            }
            catch
            {
                // Whatever happens, we do not want to cause fatal crashes
            }
        }

        public static List<BgmModel> Get() => _bgm;

        private static async Task<List<BgmItem>> InternalFetchLocations()
        {
            const string url = "https://raw.githubusercontent.com/Xeeynamo/KH3SaveEditor/master/resources/ff7r-meta-bgm.yml";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        return new DeserializerBuilder()
                            .Build()
                            .Deserialize<BgmResource>(body)
                            .Bgm;
                    }

                    throw new Exception($"Fetch failed: the server returned {response.StatusCode}.");
                }
            }
        }
    }
}
