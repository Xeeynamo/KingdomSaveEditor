using KHSave.SaveEditor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KHSave.SaveEditor.Services
{
    public static class PatreonService
    {
        private class PatreonResponse
        {
            [JsonProperty("patreonUrl")]
            public string PatreonUrl { get; set; }

            [JsonProperty("patrons")]
            public IEnumerable<PatronDto> Patrons { get; set; }
        }
        private class PatronDto
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("profileUrl")]
            public string ProfileUrl { get; set; }

            [JsonProperty("tierId")]
            public int TierId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("badgeUrl")]
            public string BadgeUrl { get; set; }

            [JsonProperty("glow")]
            public bool Glow { get; set; }
        }

        public static async Task<PatreonInfo> GetPatreonInfo()
        {
            var response = await FetchPatreonInfo();
            return new PatreonInfo
            {
                PatreonUrl = response.PatreonUrl,
                Patrons = response.Patrons?.Select(patron => new PatronModel
                {
                    Name = patron.Name,
                    ProfileUrl = patron.ProfileUrl,
                    TierId = patron.TierId,
                    Color = patron.Color,
                    BadgeUrl = patron.BadgeUrl,
                    Glow = patron.Glow
                })
            };
        }

        private static async Task<PatreonResponse> FetchPatreonInfo()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.xee.dev/v1/khsaveeditor/patreon");
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PatreonResponse>(content);
            }
        }
    }
}
