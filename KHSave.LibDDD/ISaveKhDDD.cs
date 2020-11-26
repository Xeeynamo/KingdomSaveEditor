using KHSave.LibDDD.Model;
using KHSave.LibDDD.Types;
using System;
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
        UInt32 SoraXp { get; set; }
        byte SoraLv { get; set; }
        UInt32 RikuXp { get; set; }
        byte RikuLv { get; set; }
        EquipmentType SoraKeyblade { get; set; }
        EquipmentType RikuKeyblade { get; set; }
        UInt32 Munny { get; set; }
        Deck[] SoraDecks { get; set; }
        Deck[] RikuDecks { get; set; }

        void Write(Stream stream);
    }
}
