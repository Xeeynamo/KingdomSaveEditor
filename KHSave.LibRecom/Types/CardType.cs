using KHSave.Attributes;
using KHSave.LibRecom.Attributes;

namespace KHSave.LibRecom.Types
{
    public enum CardType
    {
        [Info] Empty,
        [CardWeapon("Kingdom Key")] KingdomKey,
        [CardWeapon("Three Wishes")] ThreeWishes,
        [CardWeapon("Crabclaw")] Crabclaw,
        [CardWeapon("Pumpkinhead")] Pumpkinhead,
        [CardWeapon("Fairy Harp")] FairyHarp,
        [CardWeapon("Wishing Star")] WishingStar,
        [CardWeapon("Spellbinder")] Spellbinder,
        [CardWeapon("Metal Chocobo")] MetalChocobo,
        [CardWeapon("Olympia")] Olympia,
        [CardWeapon("Lionheart")] Lionheart,
        [CardWeapon("Lady Luck")] LadyLuck,
        [CardWeapon("Divine Rose")] DivineRose,
        [CardWeapon("Oathkeeper")] Oathkeeper,
        [CardWeapon("Oblivion")] Oblivion,
        [CardWeapon("Ultima Weapon")] UltimaWeapon,
        [CardWeapon("Diamond Dust")] DiamondDust,
        [CardWeapon("One-Winged Angel")] OneWingedAngel,
        [CardWeapon("Soul Eater")] SoulEater,
        [CardWeapon("Star Seeker")] StarSeeker,
        [CardWeapon("Monochrome")] Monochrome,
        [CardWeapon("Follow the Wind")] FollowTheWind,
        [CardWeapon("Hidden Dragon")] HiddenDragon,
        [CardWeapon("Photon Debugger")] PhotonDebugger,
        [CardWeapon("Bond of Flame")] BondOfFlame,
        [CardMagic] Fire,
        [CardMagic] Blizzard,
        [CardMagic] Thunder,
        [CardMagic] Cure,
        [CardMagic] Gravity,
        [CardMagic] Stop,
        [CardMagic] Aero,
    }
}
