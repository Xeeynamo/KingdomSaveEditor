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

            [JsonProperty("tiers")]
            public IEnumerable<TierDto> Tiers { get; set; }
        }
        private class PatronDto
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("totalAmount")]
            public int TotalAmount { get; set; }

            [JsonProperty("lastChargeDate")]
            public DateTime? LastChargeDate { get; set; }

            [JsonProperty("lastChargeStatus")]
            public DateTime? LastChargeStatus { get; set; }

            [JsonProperty("tiers")]
            public IEnumerable<string> Tiers { get; set; }
        }

        private class TierDto
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("patronCount")]
            public int PatronCount { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }

        public static async Task<PatreonInfo> GetPatreonInfo()
        {
            var response = await FetchPatreonInfo();
            var patreonInfo = new PatreonInfo
            {
                PatreonUrl = response.PatreonUrl,
                Patrons = response.Patrons?.Select(patron => new PatronModel
                {
                    Name = patron.Name,
                    Amount = patron.Amount,
                    TotalAmount = patron.TotalAmount,
                    HighestTier = patron.Tiers
                        .Select(x => GetTier(x))
                        .Max()
                }),
                Tiers = response.Tiers?
                    .Select(tier => new TierModel
                    {
                        Tier = GetTier(tier.Id),
                        PatronCount = tier.PatronCount,
                        Amount = tier.Amount
                    })
            };

            patreonInfo.Patrons = ScramblePatreonInfo(patreonInfo.Patrons);

            return patreonInfo;
        }

        private static Tier GetTier(string tierId)
        {
            switch (tierId)
            {
                case "3971168": return Tier.Bronze;
                case "3971171": return Tier.Silver;
                case "3971175": return Tier.Gold;
                case "3971183": return Tier.Platinum;
                default: return Tier.Unknown;
            }
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

        private static IEnumerable<PatronModel> ScramblePatreonInfo(IEnumerable<PatronModel> patrons)
        {
            var patronsFirstPart = patrons
                .Where(x => x.HighestTier != Tier.Bronze)
                .OrderByDescending(x => x.HighestTier)
                .ThenByDescending(x => x.Amount)
                .ThenByDescending(x => x.TotalAmount);

            var bronzePatrons = patrons
                .Where(x => x.HighestTier == Tier.Bronze)
                .ToArray();
            var bronzePatronsCount = bronzePatrons.Length;
            var targetBronzePatronsCount = Math.Min(20, (int)Math.Ceiling(bronzePatronsCount / 5.0 * 4));

            var selectedBronzePatrons = bronzePatrons
                .Select(x => new
                {
                    Seed = Guid.NewGuid(),
                    Patron = x
                })
                .OrderBy(x => x.Seed)
                .Select(x => x.Patron)
                .Take(targetBronzePatronsCount);

            return patronsFirstPart.Concat(selectedBronzePatrons);
        }
    }
}
