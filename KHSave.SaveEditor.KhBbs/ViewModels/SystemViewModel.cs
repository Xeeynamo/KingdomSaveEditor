using KHSave.LibBbs;
using KHSave.LibBbs.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class SystemViewModel
    {
        private readonly ISaveKhBbs save;

        public SystemViewModel(ISaveKhBbs save)
        {
            this.save = save;
            Difficulty = new KhEnumListModel<DifficultyType>(() => save.Difficulty, x => save.Difficulty = x);
            Character = new KhEnumListModel<CharacterType>(() => save.PlayableCharacter, x => save.PlayableCharacter = x);
            Worlds = new KhEnumListModel<WorldType>();
        }

        public KhEnumListModel<DifficultyType> Difficulty { get; set; }
        public KhEnumListModel<CharacterType> Character { get; set; }
        public KhEnumListModel<WorldType> Worlds { get; set; }

        public WorldType WorldId { get => save.World; set => save.World = value; }
        public byte RoomId { get => save.Room; set => save.Room = value; }
        public byte SpawnId { get => save.Location; set => save.Location = value; }
    }
}
