using KHSave.SaveEditor.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace KHSave.SaveEditor.Ff7Remake.Data
{
    public class Location
    {
        [YamlMember(Alias = "chapter")]
        public int Chapter { get; set; }

        [YamlMember(Alias = "oob")]
        public bool OutOfBounds { get; set; }

        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        [YamlMember(Alias = "x")]
        public float PositionX { get; set; }

        [YamlMember(Alias = "y")]
        public float PositionY { get; set; }

        [YamlMember(Alias = "z")]
        public float PositionZ { get; set; }

        public Location()
        {

        }

        public Location(int chapter, bool oob, string description, double x, double y, double z)
        {
            Chapter = chapter;
            OutOfBounds = oob;
            Description = description;
            PositionX = (float)x;
            PositionY = (float)y;
            PositionZ = (float)z;
        }
    }

    public static class LocationPresets
    {
        public class LocationsResource
        {
            [YamlMember(Alias = "name")]
            public string Name { get; set; }

            [YamlMember(Alias = "locations")]
            public List<Location> Locations { get; set; }
        }

        private static GenericEqualityComparer<Location> _locationEqualityComparer = new GenericEqualityComparer<Location>((x, y) =>
            x.Description == y.Description);
        private static List<Location> _offlineData = new List<Location>
        {
            new Location(1, false, "Inside the train station", 5483.766, -8462.45, 6662.088),
            new Location(1, false, "End of Chapter 1", 14145, -10470, 5290),
            new Location(2, false, "Beginning of Chapter 2", -24580.36, -12204.58, -228.8734),
            new Location(2, false, "Nibhelim flashback pt.1", -21708.71, -1268.751, -80),
            new Location(2, false, "Nibhelim flashback pt.2", -18852.58, -3145.46, -39.16602),
            new Location(2, false, "Before meeting Aerith", -14485.03, -898.4921, -69.99866),
            new Location(2, false, "Before battling The Huntsman", 19275.55, 3117.768, -579.7065),
            new Location(2, false, "In the train", 8.310989, -10064.3, -5000),
        };

        private static List<Location> _onlineData;

        public static List<Location> GetLocationsOffline() => _offlineData;

        public static async Task<List<Location>> FetchLocations()
        {
            if (_onlineData == null)
            {
                var onlineData = await InternalFetchLocations();
                _onlineData = _offlineData.Concat(onlineData)
                    .Distinct(_locationEqualityComparer)
                    .ToList();
            }

            return _onlineData;
        }

        private static async Task<IEnumerable<Location>> InternalFetchLocations()
        {
            const string url = "https://raw.githubusercontent.com/Xeeynamo/KH3SaveEditor/master/resources/ff7r-meta-locations.yml";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        var model = new DeserializerBuilder()
                            .Build()
                            .Deserialize<LocationsResource>(body);

                        return model.Locations;
                    }

                    throw new Exception($"Fetch failed: the server returned {response.StatusCode}.");
                }
            }
        }
    }
}
