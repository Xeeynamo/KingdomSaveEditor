using KHSave.Lib1;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Kh1.Interfaces;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class SystemViewModel
    {
        private readonly ISaveKh1 save;
        private readonly IGetAbilities _getAbilities;

        public SystemViewModel(ISaveKh1 save, IGetAbilities getAbilities)
        {
            this.save = save;
            _getAbilities = getAbilities;
            ShortcutItems = new KhEnumListModel<EnumIconTypeModel<CommandType>, CommandType>(() => default(CommandType), x => { });
            Pc0 = new KhEnumListModel<PlayableCharacterType>(() => save.PlayableCharacter, x => save.PlayableCharacter = x);
            Pc1 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter1, x => save.CompanionCharacter1 = x);
            Pc2 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter2, x => save.CompanionCharacter2 = x);
            Pc3 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter3, x => save.CompanionCharacter3 = x);
            DifficultiesFm = new KhEnumListModel<DifficultyFm>(() => save.Difficulty, x => save.Difficulty = x);
            Worlds = new KhEnumListModel<WorldType>();

            SharedAbility1 = new AbilityViewModel(save.SharedAbilities, 0, getAbilities);
            SharedAbility2 = new AbilityViewModel(save.SharedAbilities, 1, getAbilities);
            SharedAbility3 = new AbilityViewModel(save.SharedAbilities, 2, getAbilities);
            SharedAbility4 = new AbilityViewModel(save.SharedAbilities, 3, getAbilities);
        }

        public KhEnumListModel<EnumIconTypeModel<CommandType>, CommandType> ShortcutItems { get; }
        public KhEnumListModel<PlayableCharacterType> Pc0 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc1 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc2 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc3 { get; }
        public KhEnumListModel<AbilityType> Abilities => _getAbilities.Abilities;
        public KhEnumListModel<DifficultyFm> DifficultiesFm { get; }
        public KhEnumListModel<WorldType> Worlds { get; }

        public AbilityViewModel SharedAbility1 { get; }
        public AbilityViewModel SharedAbility2 { get; }
        public AbilityViewModel SharedAbility3 { get; }
        public AbilityViewModel SharedAbility4 { get; }

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
