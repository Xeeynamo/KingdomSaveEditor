using KHSave.Attributes;

namespace KHSave.Lib2.Types
{
    public enum ItemType : short
    {
        Empty,
        Attack,
        Magic,
        Items,
        Drive,
        Revert,
        ValorForm,
        WisdomForm,
        Talk = 10,
        MasterForm,
        FinalForm,
        Antiform,
        Examine,


        [Consumable("Hi-Potion")] HiPotion = 0x14,
        [Consumable("Ether")] Ether,
        [Consumable("Elixir")] Elixir,
        [Consumable("Potion")] Potion,
        Reversal,
        FullSwing,
        Tackle,
        Snag,
        SparkleRay,
        [Magic("Firaga")] Firaga = 0x78,
        [Magic("Blizzaga")] Blizzaga = 0x7a,
        [Magic("Thundaga")] Thundaga = 0x7c,
        [Magic("Curaga")] Curaga = 0x7e,
        [Magic("Magnega")] Magnega = 0xb0,
        [Magic("Reflega")] Reflega = 0xb3,
        [Consumable("Mega-Potion")] MegaPotion = 0xf2,
        [Consumable("Mega-Ether")] MegaEther = 0xf3,
        [Consumable("Megalixir")] Megalixir = 0xf4,
    }
}
