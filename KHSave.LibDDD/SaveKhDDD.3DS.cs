using KHSave.LibDDD.Types;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Xe.BinaryMapper;

// A thank you to Hollow_Dragonite, darkmanwe4ever, Bweep, delebile  and all the other people who found parts of the values
// https://gbatemp.net/threads/kingdom-hearts-3d-dream-drop-distance-save-hack.398408/

namespace KHSave.LibDDD
{
    public partial class SaveKhDDD : ISaveKhDDD
    {
        [Data(0, 0x163FF)] public byte[] Data { get; set; }
        [Data(0x20)] public DifficultyType Difficulty { get; set; }
        [Data(0x94)] public WorldType WorldId { get; set; }
        [Data] public byte RoomId { get; set; }
        [Data] public byte SpawnId { get; set; }
        //SoraXp d1cc-d1ce big endian max value 786680?
        [Data(0xd1f0)] public byte SoraLv { get; set; }
        //RikuXp d248-d24a big endian
        [Data(0xd26c)] public byte RikuLv { get; set; }
        [Data(0xd2c4)] public EquipmentType SoraKeyblade { get; set; }
        [Data(0xd2c6)] public EquipmentType RikuKeyblade { get; set; }

        //Munny d2c8-d2ca big endian max value 999999

        public void Write(Stream stream) =>
            BinaryMapping.WriteObject(stream.FromBegin(), this);
    }
}
