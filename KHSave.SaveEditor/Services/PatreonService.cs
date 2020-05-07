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

            [JsonProperty("sponsorshipInfo")]
            public SponsorshipInfo SponsorshipInfo { get; set; }

            [JsonProperty("headerInfo")]
            public HeaderInfo HeaderInfo { get; set; }
        }

        public class SponsorshipInfo
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("startGoal")]
            public int StartGoal { get; set; }

            [JsonProperty("endGoal")]
            public int EndGoal { get; set; }
        }

        public class HeaderInfo
        {
            [JsonProperty("messages")]
            public HeaderMessage[] Messages { get; set; }
        }

        public class HeaderMessage
        {
            [JsonProperty("text")]
            public string Text { get; set; }
            
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("fontSize")]
            public double FontSize { get; set; }

            [JsonProperty("isBold")]
            public bool IsBold { get; set; }

            [JsonProperty("isItalic")]
            public bool IsItalic { get; set; }
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
                }),
                SponsorshipInfo = new Models.SponsorshipInfo
                {
                    Title = response.SponsorshipInfo?.Title,
                    Description = response.SponsorshipInfo?.Description,
                    StartGoal = response.SponsorshipInfo?.StartGoal ?? 0,
                    EndGoal = response.SponsorshipInfo?.EndGoal ?? 1,
                    Count = response.Patrons?.Count() ?? 0
                },
                Messages = response.HeaderInfo?.Messages?.Select(x => new ServiceMessage
                {
                    Text = x.Text,
                    Title = x.Title,
                    Url = x.Url,
                    FontSize = x.FontSize,
                    IsBold = x.IsBold,
                    IsItalic = x.IsItalic,
                }),
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
