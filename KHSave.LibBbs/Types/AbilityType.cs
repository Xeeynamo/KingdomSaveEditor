using KHSave.Attributes;
using KHSave.LibBbs.Attributes;

namespace KHSave.LibBbs.Types
{
    public enum AbilityType : ushort
    {
        [AbilityPrice("Treasure Magnet")] TreasureMagnet = 0x01C4,
        [AbilityPrice("HP Prize Plus")] HpPrizePlus = 0x01C5,
        [AbilityPrice("Link Prize Plus")] LinkPrizePlus = 0x01C6,
        [AbilityPrice("Lucky Strike")] LuckyStrike = 0x01C7,
        [AbilityStatus("HP Boost")] HpBoost = 0x01C8,
        [AbilitySupport("EXP Zero")] ExpZero = 0x01C9,
        [AbilityStatus("Fire Boost")] FireBoost = 0x01CA,
        [AbilityStatus("Blizzard Boost")] BlizzardBoost = 0x01CB,
        [AbilityStatus("Thunder Boost")] ThunderBoost = 0x01CC,
        [AbilityStatus("Cure Boost")] CureBoost = 0x01CD,
        [AbilityStatus("Item Boost")] ItemBoost = 0x01CE,
        [AbilityStatus("Attack Haste")] AttackHaste = 0x01CF,
        [AbilityStatus("Magic Haste")] MagicHaste = 0x01D0,
        [AbilityStatus("Combo F Boost")] ComboFBoost = 0x01D1,
        [AbilityStatus("Finish Boost")] FinishBoost = 0x01D2,
        [AbilitySupport("Combo Plus")] ComboPlus = 0x01D3,
        [AbilitySupport("Air Combo Plus")] AirComboPlus = 0x01D4,
        [AbilityStatus("Fire Screen")] FireScreen = 0x01D5,
        [AbilityStatus("Blizzard Screen")] BlizzardScreen = 0x01D6,
        [AbilityStatus("Thunder Screen")] ThunderScreen = 0x01D7,
        [AbilityStatus("Dark Screen")] DarkScreen = 0x01D8,
        [AbilityStatus("Reload Boost")] ReloadBoost = 0x01D9,
        [AbilityStatus("Defender")] Defender = 0x01DA,
        [AbilitySupport("EXP Chance")] ExpChance = 0x01DB,
        [AbilitySupport("EXP Walker")] ExpWalker = 0x01DC,
        [AbilitySupport("Damage Syphon")] DamageSyphon = 0x01DD,
        [AbilitySupport("Second Chance")] SecondChance = 0x01DE,
        [AbilitySupport("Once More")] OnceMore = 0x01DF,
        [AbilitySupport("Scan")] Scan = 0x01E0,
        [AbilitySupport("Leaf Bracer")] LeafBracer = 0x01E1,
    }
}
