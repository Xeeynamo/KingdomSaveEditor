using KHSave.Lib1;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class SystemViewModel
    {
        private readonly SaveKh1.SaveFinalMix save;

        public SystemViewModel(SaveKh1.SaveFinalMix save)
        {
            this.save = save;
            ShortcutItems = new KhEnumListModel<EnumIconTypeModel<CommandType>, CommandType>(() => default(CommandType), x => { });
            Pc0 = new KhEnumListModel<PlayableCharacterType>(() => save.PlayableCharacter, x => save.PlayableCharacter = x);
            Pc1 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter1, x => save.CompanionCharacter1 = x);
            Pc2 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter2, x => save.CompanionCharacter2 = x);
            Pc3 = new KhEnumListModel<PlayableCharacterType>(() => save.CompanionCharacter3, x => save.CompanionCharacter3 = x);
        }

        public KhEnumListModel<EnumIconTypeModel<CommandType>, CommandType> ShortcutItems { get; }
        public KhEnumListModel<PlayableCharacterType> Pc0 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc1 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc2 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc3 { get; }

        public CommandType ShortcutCircle { get => save.ShortcutCircle; set => save.ShortcutCircle = value; }
        public CommandType ShortcutTriangle { get => save.ShortcutTriangle; set => save.ShortcutTriangle = value; }
        public CommandType ShortcutSquare { get => save.ShortcutSquare; set => save.ShortcutSquare = value; }
    }
}
