using KHSave.Lib2.Types;
using Xe.BinaryMapper;

namespace KHSave.Lib2.Models
{
    public class PartyMembers
    {
        [Data] public PlayableCharacterType PlayableCharacter { get; set; }
        [Data] public PlayableCharacterType CompanionCharacter1 { get; set; }
        [Data] public PlayableCharacterType CompanionCharacter2 { get; set; }
        [Data] public PlayableCharacterType CompanionCharacter3 { get; set; }
    }
}
