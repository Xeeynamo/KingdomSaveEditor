using KHSave.LibDDD.Model;
using KHSave.LibDDD.Types;
using System.IO;

namespace KHSave.LibDDD
{
    public interface ISaveKhDDD
    {
        DifficultyType Difficulty { get; set; }
        WorldType WorldId { get; set; }
        byte RoomId { get; set; }
        byte SpawnId { get; set; }
        DreamEater[] DreamEaters { get; set; }
        byte SoraLv { get; set; }
        byte RikuLv { get; set; }
        EquipmentType SoraKeyblade { get; set; }
        EquipmentType RikuKeyblade { get; set; }

    }
}
