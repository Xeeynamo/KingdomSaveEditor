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

    public static class LocationsPreset
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
            new Location(3, false, "Sector 7 Slums: Train Station", 1999.344, -14238.85, 126.1621),
            new Location(4, false, "Sector 7 Plate: After bike mini-game", -87719.63, 15676.29, -1538.711),
            new Location(5, false, "Train to Sector 4", 292.2432, 15003.34, 14178.34),
            new Location(6, false, "Sector 4 Plate: Section F-01", -12493.72, 15620.63, 342.5763),
            new Location(7, false, "Mako Reactor 5: Beginning", 6020.055, 2282.69, 2345.815),
            new Location(8, false, "Sector 5 Slums: Church", -69892.78, 37427, 192.523),
            new Location(8, false, "Sector 5 Slums: Aerith's house roof", 2282.001, 23048.63, 1634.191),
            new Location(8, false, "Sector 5 Slums: Aerith's garden", 1094.311, 25737.78, 1080.449),
            new Location(8, false, "Sector 6 Slums: Gate", 67969.91, -35484.38, 127.1474),
            new Location(10, false, "Sewers: Beginning", -275.946, 26.4429, -50),
            new Location(11, false, "Train Graveyard: Beginning", -50452.12, 41068.95, 16.79639),
            new Location(15, false, "Sector 7 Plate: Beginning", -189.5129, 3905.749, -30.82977),
            new Location(16, false, "Sector 0: Electric power tower", 35556.4, -12843.36, -23791.25),
            new Location(16, false, "Sector 0: Close to the bridge", 21762.28, -14453.08, -29488.62),
            new Location(17, false, "Shinra: Aerith's room", 7314.688, 3183.011, 5026.195),
            new Location(18, false, "End of the road", 31915.78, 27313.2, -0.9995728),
            new Location(18, false, "Destiny's crossroads", 31739.57, 46240.6, 558.6942),
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
