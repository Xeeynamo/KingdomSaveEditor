using KHSave.LibDDD.Model;
using KHSave.LibDDD.Types;
using System;
using System.IO;

namespace KHSave.LibDDD
{
    public interface ISaveKhDDD
    {
        uint GameTimeLoading { get; set; }
        DifficultyType DifficultyLoading { get; set; }
        uint SoraXpLoading { get; set; }
        DifficultyType Difficulty { get; set; }
        WorldType WorldId { get; set; }
        byte RoomId { get; set; }
        byte SpawnId { get; set; }
        uint GameTime { get; set; }
        DreamEater[] DreamEaters { get; set; }
        CommandEntry[] CommandInventory { get; }
        UInt32 SoraXp { get; set; }
        ushort SoraDroplets { get; set; }
        byte SoraLv { get; set; }
        UInt32 RikuXp { get; set; }
        ushort RikuDroplets { get; set; }
        byte RikuLv { get; set; }
        EquipmentType SoraKeyblade { get; set; }
        EquipmentType RikuKeyblade { get; set; }
        UInt32 Munny { get; set; }
        IDeck[] SoraDecks { get; }
        IDeck[] RikuDecks { get; }

        void Write(Stream stream);
    }
}
