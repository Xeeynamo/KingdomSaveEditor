using KHSave.SaveEditor.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KHSave.SaveEditor.Services
{
    public class PatreonService
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

            [JsonProperty("photoUrl")]
            public string PhotoUrl { get; set; }

            [JsonProperty("badgeUrl")]
            public string BadgeUrl { get; set; }

            [JsonProperty("glow")]
            public bool Glow { get; set; }
        }

        private readonly IAppIdentity _appIdentity;

        public PatreonService(IAppIdentity appIdentity)
        {
            _appIdentity = appIdentity;
        }

        public async Task<PatreonInfo> GetPatreonInfo()
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
                    PhotoUrl = patron.PhotoUrl,
                    BadgeUrl = patron.BadgeUrl,
                    Glow = patron.Glow
                })
            };
        }

        private async Task<PatreonResponse> FetchPatreonInfo()
        {
            using (var client = new HttpClient())
            {
                var version = _appIdentity.Version;
#if DEBUG
                version += "d";
#endif
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("khsaveeditor", version));

                var response = await client.GetAsync("https://api.xee.dev/v1/khsaveeditor/patreon");
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PatreonResponse>(content);
            }
        }
    }
}
