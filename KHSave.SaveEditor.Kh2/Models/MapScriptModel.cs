using KHSave.Attributes;
using KHSave.Lib2.Models;
using KHSave.Lib2.Types;

namespace KHSave.SaveEditor.Kh2.Models
{
    public class MapScriptModel
    {
        private readonly WorldType _world;
        private readonly int _place;
        private readonly IPlaceScript _placeScript;

        public MapScriptModel(WorldType world, int placeIndex, IPlaceScript placeScript)
        {
            _world = world;
            _place = placeIndex;
            _placeScript = placeScript;
        }

        public string Name => $"{WorldAttribute.GetWorldId(_world)}{_place:D02}";

        public int Map
        {
            get => _placeScript.Map;
            set => _placeScript.Map = (byte)value;
        }

        public int Battle
        {
            get => _placeScript.Battle;
            set => _placeScript.Battle = (byte)value;
        }

        public int Event
        {
            get => _placeScript.Event;
            set => _placeScript.Event = (byte)value;
        }
    }
}
