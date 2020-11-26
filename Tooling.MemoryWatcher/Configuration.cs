using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace Tooling.MemoryWatcher
{
    public class GameLabelConfiguration
    {
        [YamlMember(Alias = "comment")]
        public string Comment { get; set; }

        [YamlMember(Alias = "offset")]
        public long Offset { get; set; }

        [YamlMember(Alias = "length")]
        public uint Length { get; set; }

        [YamlMember(Alias = "hidden")]
        public bool Hidden { get; set; }

        public GameLabelConfiguration()
        {
            // Set default content
            Comment = "<no label?";
            Offset = -1;
            Length = 1;
            Hidden = false;
        }
    }

    public class GameConfiguration
    {
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        [YamlMember(Alias = "process")]
        public string Process { get; set; }

        [YamlMember(Alias = "offset")]
        public uint Offset { get; set; }

        [YamlMember(Alias = "length")]
        public uint Length { get; set; }

        [YamlMember(Alias = "labels")]
        public List<GameLabelConfiguration> Labels { get; set; }
    }

    public class Configuration
    {
        public List<GameConfiguration> Games;

        private Configuration(string content)
        {
            Games = new DeserializerBuilder()
                .Build()
                .Deserialize<List<GameConfiguration>>(content);
        }

        public static Configuration ReadFromYaml(string fileName) =>
            new Configuration(File.ReadAllText(fileName));
    }
}
