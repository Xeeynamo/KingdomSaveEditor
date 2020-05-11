using KHSave.Attributes;
using KHSave.Lib2.Types;

namespace KHSave.SaveEditor.Kh2.Models
{
    public class RoomModel
    {
        public WorldType World { get; set; }
        public int RoomIndex { get; set; }
        public GameType GameType { get; }
        public GameType Edition { get; set; }
        public string Description { get; set; }

        public RoomModel(WorldType world, int roomIndex, GameType gameType, string description = null)
        {
            World = world;
            RoomIndex = roomIndex;
            GameType = gameType;
            Description = description;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Description))
                return Description;

            return $"{WorldAttribute.GetWorldId(World)}_{RoomIndex:D02}";
        }
    }
}
