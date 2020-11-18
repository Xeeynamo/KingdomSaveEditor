using KHSave.LibDDD;
using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Models;
using System;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class SystemViewModel
    {
        private readonly ISaveKhDDD save;

        public SystemViewModel(ISaveKhDDD save)
        {
            this.save = save;
            Difficulty = new KhEnumListModel<DifficultyType>(() => save.Difficulty, x => save.Difficulty = x);
            Worlds = new KhEnumListModel<WorldType>();
        }

        public KhEnumListModel<DifficultyType> Difficulty { get; set; }
        public UInt32 Munny { get => save.Munny; set => save.Munny = value; }
        public KhEnumListModel<WorldType> Worlds { get; set; }

        public WorldType WorldId { get => save.WorldId; set => save.WorldId = value; }
        public byte RoomId { get => save.RoomId; set => save.RoomId = value; }
        public byte SpawnId { get => save.SpawnId; set => save.SpawnId = value; }
    }
}
