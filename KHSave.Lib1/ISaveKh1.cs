using KHSave.Lib1.Types;
using KHSave.Lib1.Models;
using System.IO;

namespace KHSave.Lib1
{
    public interface ISaveKh1
    {
        uint MagicCode { get; set; }
        byte[] SharedAbilities { get; }
        CommandType ShortcutCircle { get; set; }
        CommandType ShortcutTriangle { get; set; }
        CommandType ShortcutSquare { get; set; }
        uint Munny { get; set; }
        DifficultyFm Difficulty { get; set; }
        PlayableCharacterType PlayableCharacter { get; set; }
        PlayableCharacterType CompanionCharacter1 { get; set; }
        PlayableCharacterType CompanionCharacter2 { get; set; }
        PlayableCharacterType CompanionCharacter3 { get; set; }
        byte[] InventoryCount { get; set; }
        Character[] Characters { get; set; }
        WorldType World { get; set; }
        uint Room { get; set; }
        uint SpawnLocation { get; set; }

        void Write(Stream stream);
    }
}
