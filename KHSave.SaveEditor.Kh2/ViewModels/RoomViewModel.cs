using KHSave.Attributes;
using KHSave.Lib2.Types;
using KHSave.SaveEditor.Kh2.Models;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel(RoomModel room)
        {
            World = room.World;
            Value = (byte)room.RoomIndex;
            Name = $"{WorldAttribute.GetWorldId(World)}{room.RoomIndex:D02} {room.Description}";
            if (room.Edition == GameType.Fm)
                Name += " (Final Mix)";
        }

        public WorldType World { get; }

        public byte Value { get; }

        public string Name { get; }
    }
}
