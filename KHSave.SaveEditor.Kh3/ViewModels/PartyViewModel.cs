using KHSave.Lib3;
using KHSave.Lib3.Types;
using KHSave.SaveEditor.Common.Models;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
    public class PartyViewModel
    {
        private readonly SaveKh3 _save;

        public KhEnumListModel<DesireChoice> DesireChoice { get; }
        public KhEnumListModel<PowerChoice> PowerChoice { get; }
        public KhEnumListModel<PartyCharacter> PartyMembers { get; }

        public PartyCharacter PartyMember1 { get => _save.Party[0]; set => _save.Party[0] = value; }
        public PartyCharacter PartyMember2 { get => _save.Party[1]; set => _save.Party[1] = value; }
        public PartyCharacter PartyMember3 { get => _save.Party[2]; set => _save.Party[2] = value; }
        public PartyCharacter PartyMember4 { get => _save.Party[3]; set => _save.Party[3] = value; }
        public PartyCharacter PartyMember5 { get => _save.Party[4]; set => _save.Party[4] = value; }

        public PartyViewModel(SaveKh3 save)
        {
            _save = save;
            DesireChoice = new KhEnumListModel<DesireChoice>(() => save.DesireChoice, x => save.DesireChoice = x);
            PowerChoice = new KhEnumListModel<PowerChoice>(() => save.PowerChoice, x => save.PowerChoice = x);
            PartyMembers = new KhEnumListModel<PartyCharacter>(() => default(PartyCharacter), x => { });
        }
    }
}
