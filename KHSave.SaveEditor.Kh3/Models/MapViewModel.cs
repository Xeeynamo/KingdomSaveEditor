namespace KHSave.SaveEditor.Kh3.Models
{
    public class MapViewModel
    {
        private readonly string mapPath;
        private readonly Lib3.Presets.Presets.Map map;

        public MapViewModel(string id, Lib3.Presets.Presets.Map map)
        {
            this.mapPath = id;
            this.map = map;
            if (string.IsNullOrEmpty(map.Name))
                Description = id;
            else
                Description = $"{id} | {map.Name}";
        }

        public string Description { get; }

        public string Value => mapPath;
    }
}
