using KHSave.Attributes;

namespace KHSave.LibPersona5.Types
{
    public class EquipmentAttribute : InfoAttribute
    {
        public EquipmentAttribute(string name = null) : base(name) { }
    }

    public class DaggerAttribute : EquipmentAttribute
    {
        public DaggerAttribute(string name = null) : base(name) { }
    }

    public class PoleAttribute : EquipmentAttribute
    {
        public PoleAttribute(string name = null) : base(name) { }
    }

    public class SaberAttribute : EquipmentAttribute
    {
        public SaberAttribute(string name = null) : base(name) { }
    }

    public class RangeAttribute : EquipmentAttribute
    {
        public RangeAttribute(string name = null) : base(name) { }
    }

    public class RangeJokerAttribute : RangeAttribute
    {
        public RangeJokerAttribute(string name = null) : base(name) { }
    }

    public class RangeCrowAttribute : RangeAttribute
    {
        public RangeCrowAttribute(string name = null) : base(name) { }
    }

    public class ProtectorAttribute : EquipmentAttribute
    {
        public ProtectorAttribute(string name = null) : base(name) { }
    }

    public class ProtectorMaleAttribute : ProtectorAttribute
    {
        public ProtectorMaleAttribute(string name = null) : base(name) { }
    }

    public class ProtectorFemaleAttribute : ProtectorAttribute
    {
        public ProtectorFemaleAttribute(string name = null) : base(name) { }
    }

    public class ProtectorUnisexAttribute : ProtectorAttribute
    {
        public ProtectorUnisexAttribute(string name = null) : base(name) { }
    }

    public class ProtectorCatAttribute : ProtectorAttribute
    {
        public ProtectorCatAttribute(string name = null) : base(name) { }
    }

    public class OutfitAttribute : EquipmentAttribute
    {
        public OutfitAttribute(string name = null) : base(name) { }
    }

    public enum Equipment : ushort
    {
        [Dagger("Generic Gear")] GenericGear = 0x0001,
        [Dagger("Rebel Knife")] RebelKnife = 0x0002,
        [Dagger("Frenzy Dagger")] FrenzyDagger = 0x0016,
        [Pole("Dragon God Pole")] DragonGodPole = 0x0039,
        [Dagger("Black Kogatana")] BlackKogatana = 0x00eb,
        [Saber("Lumina Saber")] LuminaSaber = 0xdf,
        [Protector("Thief Clothes")] ThiefClothes = 0x1001,
        [ProtectorMale("Dark Undershirt")] DarkUndershirt = 0x1002,
        [ProtectorMale("Print T-Shirt")] PrintTShirt = 0x1003,
        [ProtectorCat("Neckerchief")] Neckerchief = 0x1004,
        [ProtectorFemale("Baseball Jacket")] BaseballJacket = 0x1005,
        [ProtectorMale("Dress Shirt")] DressShirt = 0x1006,
        [ProtectorFemale("Turtleneck")] Turtleneck = 0x1007,
        [ProtectorFemale("Pink Top")] PinkTop = 0x1008,
        [ProtectorFemale("Loose Cutsew")] LooseCutsew = 0x1009,
        [ProtectorMale("Formal Shirt")] FormalShirt = 0x100A,
        [ProtectorMale("UFO Vest")] UfoVest = 0x1060,
        [ProtectorMale("Moon Man Vest")] MoonManVest = 0x1068,
        [ProtectorFemale("Gambler Dress")] GamblerDress = 0x107D,
        [ProtectorMale("Fireman Happi")] FiremanHappi = 0x108c,
        [ProtectorFemale("Mizuha Doumaru")] MizuhaDoumaru = 0x108D,
        [ProtectorCat("Gorgeous Collar")] GorgeousCollar = 0x1093,
        [ProtectorFemale("Titanium Set")] TitaniumSet = 0x1099,
        [ProtectorFemale("Haten Robe")] HatenRobe = 0x10A1,
        [Accessory("Hip Glasses")] HipGlasses = 0x2001,
        [Accessory("Fanny Pack")] FannyPack = 0x2003,
        [Accessory("Hairpin")] Hairpin = 0x2004,
        [Accessory("Silver Key Ring")] SilverKeyRing = 0x2005,
        [Accessory("Black Tights")] BlackTights = 0x2006,
        [Accessory("Dotted Tights")] DottedTights = 0x2007,
        [Accessory("Headphones")] Headphones = 0x2008,
        [Accessory("Gale Cape")] GaleCape = 0x209D,
        [Accessory("Blitz Ring")] BlitzRing = 0x207C,
        [Accessory("Druid Amulet")] DruidAmulet = 0x2053,
        [Accessory("Sonic Socks")] SonicSocks = 0x2061,
        [Accessory("Black Necktie")] BlackNecktie = 0x2009,
        [Accessory("Stamina Sash")] StaminaSash = 0x200c,
        [Accessory("Ignis Ring")] IgnisRing = 0x2076,
        [Accessory("Hero Eyepatch")] HeroEyepatch = 0x2091,
        [Accessory("Stone of Scone")] StoneOfScone = 0x20B9,
        [Accessory("Koh-i-Noor")] KohiNoor = 0x20ba,
        [Accessory("SP Adhesive 3")] SpAdhesive3 = 0x20E3,
        [Outfit("Phantom Suit")] PhantomSuit = 0x7002,
        [Outfit("Pirate Armor")] PirateArmor = 0x7003,
        [Outfit("Morgana Classic")] MorganaClassic = 0x7004,
        [Outfit("Red Latex Suit")] RedLatexSuit = 0x7005,
        [Outfit("Outlaw's Attire")] OutlawAttire = 0x7006,
        [Outfit("Metal Rider")] MetalRider = 0x7007,
        [Outfit("Musketeer Suit")] MusketeerSuit = 0x7008,
        [Outfit("Cyber Gear")] CyberGear = 0x7009,
        [Outfit("Prince Suit")] PrinceSuit = 0x700A,
        [Outfit("Swimsuit")] Swimsuit = 0x7038,
        [RangeJoker("Tkachev II")] Tkachev2 = 0x8013,
        [RangeJoker("Aura Gun 1")] AuraGun1 = 0x8008,
        [RangeCrow("Moebius")] Moebius = 0x80E0,
        [RangeJoker("Cocytus")] Cocytus = 0x80fa,
    }
}
