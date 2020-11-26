using KHSave.LibBbs.Models;
using KHSave.LibBbs.Types;

namespace KHSave.LibBbs
{
    public interface ISaveKhBbs
    {
        uint MagicCode { get; set; }

        int Version { get; set; }

        uint Size { get; set; }

        uint Checksum { get; set; }

        byte Report { get; set; }
        byte Dummy1 { get; set; }
        byte Dummy2 { get; set; }
        byte Dummy3 { get; set; }
        WorldType World { get; set; }
        byte Room { get; set; }
        byte Location { get; set; }
        CharacterType PlayableCharacter { get; set; }
        int Timer { get; set; }

        Command[] CommandList { get; set; }
        Character Character { get; set; }
        Deck[] Decks { get; set; }

        DifficultyType Difficulty { get; set; }
    }
}
