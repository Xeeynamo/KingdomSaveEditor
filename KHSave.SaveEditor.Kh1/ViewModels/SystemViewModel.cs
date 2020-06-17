using KHSave.Lib1;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class SystemViewModel
    {
        private readonly ISaveKh1 save;

        public SystemViewModel(ISaveKh1 save)
        {
            this.save = save;
            ShortcutItems = new KhEnumListModel<EnumIconTypeModel<CommandType>, CommandType>(() => default(CommandType), x => { });
            Pc0 = new KhEnumListModel<PlayableCharacterType>(() => save.PlayableCharacter, x => save.PlayableCharacter = x);
            Pc1 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter1, x => save.CompanionCharacter1 = x);
            Pc2 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter2, x => save.CompanionCharacter2 = x);
            Pc3 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter3, x => save.CompanionCharacter3 = x);
            Abilities = new KhEnumListModel<AbilityType>();
            DifficultiesFm = new KhEnumListModel<DifficultyFm>(() => save.Difficulty, x => save.Difficulty = x);
            Worlds = new KhEnumListModel<WorldType>();
        }

        public KhEnumListModel<EnumIconTypeModel<CommandType>, CommandType> ShortcutItems { get; }
        public KhEnumListModel<PlayableCharacterType> Pc0 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc1 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc2 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc3 { get; }
        public KhEnumListModel<AbilityType> Abilities { get; }
        public KhEnumListModel<DifficultyFm> DifficultiesFm { get; }
        public KhEnumListModel<WorldType> Worlds { get; }

        public AbilityType SharedAbility1 { get => save.SharedAbility1; set => save.SharedAbility1 = value; }
        public AbilityType SharedAbility2 { get => save.SharedAbility2; set => save.SharedAbility2 = value; }
        public AbilityType SharedAbility3 { get => save.SharedAbility3; set => save.SharedAbility3 = value; }
        public AbilityType SharedAbility4 { get => save.SharedAbility4; set => save.SharedAbility4 = value; }

        public CommandType ShortcutCircle { get => save.ShortcutCircle; set => save.ShortcutCircle = value; }
        public CommandType ShortcutTriangle { get => save.ShortcutTriangle; set => save.ShortcutTriangle = value; }
        public CommandType ShortcutSquare { get => save.ShortcutSquare; set => save.ShortcutSquare = value; }

        public uint Munny { get => save.Munny; set => save.Munny = value; }
        public DifficultyFm Difficulty { get => save.Difficulty; set => save.Difficulty = value; }

        public WorldType World { get => save.World; set => save.World = value; }
        public uint Room { get => save.Room; set => save.Room = value; }
        public uint SpawnLocation { get => save.SpawnLocation; set => save.SpawnLocation = value; }
    }
}
