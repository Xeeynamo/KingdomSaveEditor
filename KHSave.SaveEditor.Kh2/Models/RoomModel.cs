using KHSave.Attributes;
using KHSave.Lib2.Types;
using System.Text;

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
            var sb = new StringBuilder();
            sb.Append($"{WorldAttribute.GetWorldId(World)}_{RoomIndex:D02}");
            sb.Append($" | {WorldAttribute.GetInfo(World)}");

            if (!string.IsNullOrEmpty(Description))
                sb.Append($" - {Description}");

            return sb.ToString();
        }
    }
}
