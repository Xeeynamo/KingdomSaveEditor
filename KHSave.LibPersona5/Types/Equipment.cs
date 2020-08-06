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
        [Pole("Dragon God Pole")] DragonGodPole = 0x0025,
        [Dagger("Black Kogatana")] BlackKogatana = 0x00eb,
        [Saber("Lumina Saber")] LuminaSaber = 0xdf,
        [ProtectorMale("Dark Undershirt")] DarkUndershirt = 0x1002,
        [ProtectorCat("Gorgeous Collar")] GorgeousCollar = 0x1004,
        [ProtectorFemale("Titanium Set")] TitaniumSet = 0x1005,
        [ProtectorMale("Formal Shirt")] FormalShirt = 0x100A,
        [ProtectorMale("UFO Vest")] UfoVest = 0x1060,
        [ProtectorMale("Moon Man Vest")] MoonManVest = 0x1068,
        [ProtectorFemale("Gambler Dress")] GamblerDress = 0x107D,
        [ProtectorMale("Fireman Happi")] FiremanHappi = 0x108c,
        [Accessory("Hip Glasses")] HipGlasses = 0x2001,
        [Accessory("Gale Cape")] GaleCape = 0x2002,
        [Accessory("Blitz Ring")] BlitzRing = 0x2003,
        [Accessory("Druid Amulet")] DruidAmulet = 0x2004,
        [Accessory("Sonic Socks")] SonicSocks = 0x2005,
        [Accessory("Black Necktie")] BlackNecktie = 0x2009,
        [Accessory("Stamina Sash")] StaminaSash = 0x200c,
        [Accessory("Ignis Ring")] IgnisRing = 0x2076,
        [Accessory("Koh-i-Noor")] KohiNoor = 0x20ba,
        [RangeJoker("Cocytus")] Cocytus = 0x80fa,
        [Outfit("Phantom Suit")] PhantomSuit = 0x7002,
        [Outfit("Pirate Armor")] PirateArmor = 0x7003,
        [Outfit("Morgana Classic")] MorganaClassic = 0x7004,
        [Outfit("Red Latex Suit")] RedLatexSuit = 0x7005,
        [Outfit("Cyber Gear")] CyberGear = 0x7009,
        [Outfit("Prince Suit")] PrinceSuit = 0x700A,
        [Outfit("Swimsuit")] Swimsuit = 0x7038,
        [RangeJoker("Tkachev II")] Tkachev2 = 0x8013,
        [RangeJoker("Aura Gun 1")] AuraGun1 = 0x8008,
        [RangeCrow("Moebius")] Moebius = 0x80E0,
    }
}
