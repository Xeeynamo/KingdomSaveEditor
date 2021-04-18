using KHSave.LibDDD.Types;
using System;
using System.IO;
using Xe.BinaryMapper;
using KHSave.LibDDD.Model;

namespace KHSave.LibDDD
{
    public partial class SaveKhDDD
    {
        public class SaveKhDDDPS4 : ISaveKhDDD
        {
            [Data(0, 0x165FF)] public byte[] Data { get; set; }
            [Data(0x20)] public DifficultyType Difficulty { get; set; }
            [Data(0x94)] public WorldType WorldId { get; set; }
            [Data] public byte RoomId { get; set; }
            [Data] public byte SpawnId { get; set; }
            //3 in party and 99 on the bank
            [Data(0x53a0, Count = 102)] public DreamEater[] DreamEaters { get; set; }

            [Data(0xc004, Count = 511)] public CommandEntry[] CommandInventory { get; set; }

            //SoraXp max value 786680?
            [Data(0xd1f0)] public uint SoraXp { get; set; }
            [Data(0xd214)] public byte SoraLv { get; set; }
            //RikuXp max value 786680?
            [Data(0xd26c)] public uint RikuXp { get; set; }
            [Data(0xd290)] public byte RikuLv { get; set; }
            [Data(0xd2e8)] public EquipmentType SoraKeyblade { get; set; }
            [Data(0xd2ea)] public EquipmentType RikuKeyblade { get; set; }
            //Munny max value 999999?
            [Data(0xd2ec)] public uint Munny { get; set; }
            [Data(0xd314, Count = 3)] public DeckPS4[] SoraDecks { get; set; }
            [Data(0xd620, Count = 3)] public DeckPS4[] RikuDecks { get; set; }

            IDeck[] ISaveKhDDD.SoraDecks => Array.ConvertAll(SoraDecks, x => (IDeck)x);
            IDeck[] ISaveKhDDD.RikuDecks => Array.ConvertAll(SoraDecks, x => (IDeck)x);

            public void Write(Stream stream) =>
                BinaryMapping.WriteObject(stream.FromBegin(), this);
        }
    }
}
