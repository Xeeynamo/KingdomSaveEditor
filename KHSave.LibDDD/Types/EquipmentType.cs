using KHSave.Attributes;

// thank you HOLLOW_DRAGONITE for this list of ID's you made my life a lot easier

namespace KHSave.LibDDD.Types
{
    public enum EquipmentType : short
    {
        // xx00 - Command Deck Action (not Combat) Commands
        [Info("Jump")] Jump = 0x0100,
        [Info("High Jump")] HighJump = 0x0200,
        [Info("Dodge Roll")] DodgeRoll = 0x0300,
        [Info("Shield Roll")] ShieldRoll = 0x0400,
        [Info("Dark Roll")] DarkRoll = 0x0500,
        [Info("Air Slide")] AirSlide = 0x0600,
        [Info("Sonic Impact")] SonicImpact = 0x0700,
        [Info("Double Impact")] DoubleImpact = 0x0800,
        [Info("Glide")] Glide = 0x0900,
        // xx02 - keyblades
        [Keyblade("Kingdom Key")] KingdomKey = 0x0002,
        [Keyblade("Skull Noise (Sora)")] SkullNoiseS = 0x0102,
        [Keyblade("Guardian Bell (Sora)")] GuardianBellS = 0x0202,
        [Keyblade("Ferris Gear")] FerrisGear = 0x0302,
        [Keyblade("Dual Disc (Sora)")] DualDiscS = 0x0402,
        [Keyblade("All for One (Sora)")] AllForOneS = 0x0502,
        [Keyblade("Counterpoint (Sora)")] CounterpointS = 0x0602,
        [Keyblade("Sweet Dreams (Sora)")] SweetDreamsS = 0x0702,
        [Keyblade("Ultima Weapon (Sora)")] UltimaWeaponS = 0x0802,
        [Keyblade("Unbound (Sora)")] UnboundS = 0x0902,
        [Keyblade("Dive Wing (Sora)")] DiveWingS = 0x0A02,
        [Keyblade("End of Pain (Sora)")] EndOfPainS = 0x0B02,
        [Keyblade("Knockout Punch (Sora)")] KnockoutPunchS = 0x0c02,
        [Keyblade("UNNAMED (Description: RS-READY LARGE KEYBLADE ROSE HELP)")] UnnamedK1 = 0x0d02,
        [Keyblade("UNNAMED (Description: RS-READY LARGE KEYBLADE ASSEMBLY HELP)")] UnnamedK2 = 0x0e02,
        [Keyblade("SORA UNUSED KBLADE (Description: SORA UNUSED KEYBLADE 3 HELP)")] UnusedK1 = 0x0f02,
        [Keyblade("Soul Eater")] SoulEater = 0x1002,
        [Keyblade("Skull Noise (Riku)")] SkullNoiseR = 0x1102,
        [Keyblade("Guardian Bell (Riku)")] GuardianBellR = 0x1202,
        [Keyblade("Ocean's Rage")] OceansRage = 0x1302,
        //start assumption based on patern
        [Keyblade("Dual Disc (Riku)")] DualDiscR = 0x1402,
        [Keyblade("All for One (Riku)")] AllForOneR = 0x1502,
        [Keyblade("Counterpoint (Riku)")] CounterpointR = 0x1602,
        [Keyblade("Sweet Dreams (Riku)")] SweetDreamsR = 0x1702,
        [Keyblade("Ultima Weapon (Riku)")] UltimaWeaponR = 0x1802,
        [Keyblade("Unbound (Riku)")] UnboundR = 0x1902,
        [Keyblade("Dive Wing (Riku)")] DiveWingR = 0x1a02,
        [Keyblade("End of Pain (Riku)")] EndOfPainR = 0x1b02,
        [Keyblade("Knockout Punch (Riku)")] KnockoutPunchR = 0x1c02,
        [Unused] Unused1D02 = 0x1d02,
        // end assumption
        [Keyblade("Way to the Dawn")] WayToTheDawn = 0x1F02,
    }
}
