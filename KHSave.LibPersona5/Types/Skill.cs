using KHSave.Attributes;

namespace KHSave.LibPersona5.Types
{
    public class SkillAttribute : InfoAttribute
    {
        public SkillAttribute(string name = null) : base(name) { }
    }
    public class HitSkillAttribute : SkillAttribute
    {
        public HitSkillAttribute(string name = null) : base(name) { }
    }
    public class GunSkillAttribute : SkillAttribute
    {
        public GunSkillAttribute(string name = null) : base(name) { }
    }
    public class FireSkillAttribute : SkillAttribute
    {
        public FireSkillAttribute(string name = null) : base(name) { }
    }
    public class IceSkillAttribute : SkillAttribute
    {
        public IceSkillAttribute(string name = null) : base(name) { }
    }
    public class WindSkillAttribute : SkillAttribute
    {
        public WindSkillAttribute(string name = null) : base(name) { }
    }
    public class ThunderSkillAttribute : SkillAttribute
    {
        public ThunderSkillAttribute(string name = null) : base(name) { }
    }
    public class HolySkillAttribute : SkillAttribute
    {
        public HolySkillAttribute(string name = null) : base(name) { }
    }
    public class DeathSkillAttribute : SkillAttribute
    {
        public DeathSkillAttribute(string name = null) : base(name) { }
    }
    public class AlmightySkillAttribute : SkillAttribute
    {
        public AlmightySkillAttribute(string name = null) : base(name) { }
    }
    public class NuclearSkillAttribute : SkillAttribute
    {
        public NuclearSkillAttribute(string name = null) : base(name) { }
    }
    public class PsychoSkillAttribute : SkillAttribute
    {
        public PsychoSkillAttribute(string name = null) : base(name) { }
    }
    public class SupportSkillAttribute : SkillAttribute
    {
        public SupportSkillAttribute(string name = null) : base(name) { }
    }
    public class AutoSkillAttribute : SkillAttribute
    {
        public AutoSkillAttribute(string name = null) : base(name) { }
    }
    public class PoisonSkillAttribute : SkillAttribute
    {
        public PoisonSkillAttribute(string name = null) : base(name) { }
    }
    public class HealSkillAttribute : SkillAttribute
    {
        public HealSkillAttribute(string name = null) : base(name) { }
    }

    public enum Skill : short
    {
        [FireSkill] Agi = 10,
        [FireSkill] Agilao,
        [FireSkill] Agidyne,
        [FireSkill] Maragi,
        [FireSkill] Maragion,
        [FireSkill] Maragidyne,

        [IceSkill] Bufu = 20,
        [IceSkill] Bufula,
        [IceSkill] Bufudyne,
        [IceSkill] Mabufu,
        [IceSkill] Mabufula,
        [IceSkill] Mabufudyne,

        [WindSkill] Garu = 30,
        [WindSkill] Garula,
        [WindSkill] Garudyne,
        [WindSkill] Magaru,
        [WindSkill] Magarula,
        [WindSkill] Magarudyne,

        [ThunderSkill] Zio = 40,
        [ThunderSkill] Ziola,
        [ThunderSkill] Ziodyne,
        [ThunderSkill] Mazio,
        [ThunderSkill] Maziola,
        [ThunderSkill] Maziodyne,

        [HolySkill] Hama = 50,
        [HolySkill] Hamaom,
        [HolySkill] Mahama,
        [HolySkill] Mahamaon,
        [HolySkill] Kouha,
        [HolySkill] Kouga,
        [HolySkill] Kougaon,
        [HolySkill] Makouha,
        [HolySkill] Makouga,
        [HolySkill] Makougaon,

        [DeathSkill] Mudo,
        [DeathSkill] Mudoon,
        [DeathSkill] Mamudo,
        [DeathSkill] Mamudoon,
        [DeathSkill] Eiha,
        [DeathSkill] Eiga,
        [DeathSkill] Eigaon,
        [DeathSkill] Maeiha,
        [DeathSkill] Maeiga,
        [DeathSkill] Maeigaon,

        [AlmightySkill] Megido,
        [AlmightySkill] Megidola,
        [AlmightySkill] Megidolaon,
        [NuclearSkill] Frei,
        [NuclearSkill] Freila,
        [NuclearSkill] Freidyne,
        [NuclearSkill] Mafrei,
        [NuclearSkill] Mafreila,
        [NuclearSkill] Mafreidyne,

        [PoisonSkill] Dazzler = 80,
        [PoisonSkill("Nocturnal Flash")] NocturnalFlash,
        [PoisonSkill] Pulinpa,
        [PoisonSkill] Tentarafoo,
        [PoisonSkill("Evil Touch")] EvilTouch,
        [PoisonSkill("Evil Smile")] EvilSmile,
        [PoisonSkill] Makajama,
        [PoisonSkill] Makajamaon,
        [PoisonSkill("Famine's Breath")] FamineBreath,
        [PoisonSkill("Famine's Scream")] FamineScream,
        [PoisonSkill] Dormina,
        [PoisonSkill] Lullaby,
        [PoisonSkill] Taunt,
        [PoisonSkill("Wage War")] WageWar,
        [PoisonSkill("Ominous Words")] OminousWords,
        [PoisonSkill("Abysmal Surge")] AbysmalSurge,
        [PoisonSkill("Marin Karin")] MarinKarin,
        [PoisonSkill("Brain Jack")] BrainJack,
        [AlmightySkill("Trapped Rat")] TrappedRat,

        [AlmightySkill("Self-Destruct")] SefDestruct1 = 100,
        [AlmightySkill("Self-Destruct")] SefDestruct2,
        [AlmightySkill("Self-Destruct")] SefDestruct3,
        [AlmightySkill("Life Drain")] LifeDrain,
        [AlmightySkill("Spirit Drain")] SpiritDrain,
        [AlmightySkill("Life Leech")] LifeLeech,
        [AlmightySkill("Spirit Leech")] SpiritLeech,
        [AlmightySkill("Spirit Drain")] SpiritDrain2,

        [AlmightySkill("Foul Breath")] FoulBreath = 110,
        [AlmightySkill("Stagnant Air")] StagnantAir,
        [AlmightySkill("Reverse Rub")] ReverseRub,
        [AlmightySkill("Ghastly Wail")] GhastlyWail,

        [FireSkill] Inferno = 120,
        [FireSkill("Blazing Hell")] BlazingHell,
        [AutoSkill("Low Burn")] LowBurn,
        [AutoSkill("Mid Burn")] MidBurn,
        [AutoSkill("High Burn")] HighBurn,
        [AutoSkill("Low Freeze")] LowFreeze,
        [AutoSkill("Mid Freeze")] MidFreeze,
        [AutoSkill("High Freeze")] HighFreeze,
        [AutoSkill("Low Shock")] LowShock,
        [AutoSkill("Mid Shock")] MidShock,
        [IceSkill("Diamond Dust")] DiamondDust,
        [IceSkill("Ice Age")] IceAge,
        [AutoSkill("High Shock")] HighShock,
        [AutoSkill("Low Dizzy")] LowDizzy,
        [AutoSkill("Mid Dizzy")] MidDizzy,
        [AutoSkill("High Dizzy")] HighDizzy,
        [AutoSkill("Low Confuse")] LowConfuse,
        [AutoSkill("Mid Confuse")] MidConfuse,
        [AutoSkill("High Confuse")] HighConfuse,
        [AutoSkill("Low Fear")] LowFear,
        [WindSkill("Panta Rhei")] PantaRhei,
        [WindSkill("Vacuum Wave")] VacuumWave,
        [AutoSkill("Mid Fear")] MidFear,
        [AutoSkill("High Fear")] HighFear,
        [AutoSkill("Low Forget")] LowForget,
        [AutoSkill("Mid Forget")] MidForget,
        [AutoSkill("High Forget")] HighForget,
        [AutoSkill("Low Brainwash")] LowBrainwash,
        [AutoSkill("Mid Brainwash")] MidBrainwash,
        [AutoSkill("High Brainwash")] HighBrainwash,
        [ThunderSkill("Thunder Reign")] ThunderReign,
        [ThunderSkill("Wild Thunder")] WildThunder,
        [AutoSkill("Low Sleep")] LowSleep,
        [AutoSkill("Mid Sleep")] MidSleep,
        [AutoSkill("High Sleep")] HighSleep,
        [AutoSkill("Low Rage")] LowRage,
        [AutoSkill("Mid Rage")] MidRage,
        [AutoSkill("High Rage")] HighRage,
        [AutoSkill("Low Despair")] LowDespair,
        [AutoSkill("Mid Despair")] MidDespair,
        [HolySkill("Divine Judgment")] DivineJudgment,
        [HolySkill] Samsara,
        [AutoSkill("High Despair")] HighDespair,
        [AutoSkill("Low All Ail")] LowAllAil,
        [AutoSkill("Mid All Ail")] MidAllAil,
        [AutoSkill("High All Ail")] HighAllAil,
        [DeathSkill("Demonic Decree")] DemonicDecree = 170,
        [DeathSkill("Die For Me!")] DieForMe,

        [NuclearSkill("Atomic Flare")] AtomicFlare = 176,
        [NuclearSkill("Cosmic Flare")] CosmicFlare,

        [AlmightySkill("Black Viper")] BlackViper = 180,
        [AlmightySkill("Morning Star")] MorningStar,

        [PsychoSkill] Psi = 190,
        [PsychoSkill] Psio,
        [PsychoSkill] Psiodyne,
        [PsychoSkill] Mapsi,
        [PsychoSkill] Mapsio,
        [PsychoSkill] Mapsiodyne,
        [PsychoSkill("Psycho Force")] PsychoForce = 197,
        [PsychoSkill("Psycho Blast")] PsychoBlast,

        [HitSkill] Lunge = 200,
        [HitSkill("Assault Dive")] AssaultDive,
        [HitSkill("Megaton Raid")] MegatonRaid,
        [HitSkill("God's Hand")] GodHand,
        [HitSkill("Lunge")] Lunge2,
        [HitSkill("Lucky Punch")] LuckyPunch,
        [HitSkill("Miracle Punch")] MiraclePunch,

        [HitSkill("Cleave")] Cleave = 210,
        [HitSkill("Giant Slice")] GiantSlice,
        [HitSkill("Brave Blade")] BraveBlade,
        [HitSkill("Sword Dance")] SwordDance,
        [HitSkill("Hassou Tobi")] HassouTobi = 215,
        [HitSkill] Ayamur,
        [HitSkill("Cornered Fang")] CorneredFang = 220,
        [HitSkill("Rising Slash")] RisingSlash,
        [HitSkill("Deadly Fury")] DeadlyFury,

        [GunSkill] Snap = 224,
        [GunSkill("Triple Down")] TripleDown,
        [GunSkill("One-shot Kill")] OneShotKill,
        [GunSkill("Riot Gun")] RiotGun,

        [HitSkill("Vajra Blast")] VajraBlast = 230,
        [HitSkill("Vorpal Blade")] VorpalBlade,

        [HitSkill("ViciousStrike")] ViciousStrike = 235,
        [HitSkill("Heat Wave")] HeatWave,
        [HitSkill] Gigantomachia,

        [HitSkill] Rampage = 241,
        [HitSkill("Swift Strike")] SwiftStrike,
        [HitSkill] Deathbound,
        [HitSkill] Agneyastra,
        [HitSkill("Rising Slash (2)")] RisingSlash2 = 247,
        [HitSkill("Deadly Fury (2)")] DeadlyFury2,
        [HitSkill("Double Fangs")] DoubleFangs = 250,
        [HitSkill("Tempest Slash")] TempestSlash = 253,
        [HitSkill("Myriad Slashes")] MyriadSlashes,

        [HitSkill] Sledgehammer = 260,
        [HitSkill("Skull Cracker")] SkullCracker,
        [HitSkill("Terror Claw")] TerrorClaw,
        [HitSkill("Headbutt")] Headbutt,
        [HitSkill("Stomach Blow")] StomachBlow,
        [HitSkill("Dream Needle")] DreamNeedle,
        [HitSkill("Hysterical Slap")] HystericalSlap,
        [HitSkill("Negative Pile")] NegativePile,
        [HitSkill("Brain Shake")] BrainShake,

        [HitSkill("Flash Bomb")] FlashBomb = 270,
        [HitSkill("Mind Slice")] MindSlice,
        [HitSkill("Bloodybath")] Bloodybath,
        [HitSkill("Memory Blow")] MemoryBlow,
        [HitSkill("Insatiable Strike")] InsatiableStrike,
        [HitSkill("Dormin Rush")] DorminRush,
        [HitSkill("Oni-Kagura")] OniKagura,
        [HitSkill("Bad Beat")] BadBeat,
        [HitSkill("Brain Buster")] BrainBuster,
        [GunSkill] Handgun = 280,
        [GunSkill] Shotgun,
        [GunSkill] Slingshot,
        [GunSkill("Machine Gun")] MachineGun,
        [GunSkill("Assault Rifle")] AssaultRifle,
        [GunSkill] Revolver,
        [GunSkill("Grenade Launcher")] GrenadeLauncher,
        [GunSkill("Laser Gun")] LaserGun,

        [Skill] AttackSupport = 299,
        [HealSkill] Dia,
        [HealSkill] Diarama,
        [HealSkill] Diarahan,
        [HealSkill] Media = 305,
        [HealSkill] Mediarama,
        [HealSkill] Mediarahan,
        [HealSkill] Recarm = 310,
        [HealSkill] Samarecarm,
        [HealSkill] Recarmdra,
        [HealSkill("Amrita Drop")] AmritaDrop = 315,
        [HealSkill("Amrita Shower")] AmritaShower,
        [HealSkill("BLANK")] Blank317,
        [HealSkill("Salvation")] Salvation,
        [HealSkill("Patra")] Patra = 325,
        [HealSkill("BLANK")] Blank326,
        [HealSkill("Energy Shower")] EnergyShower,
        [HealSkill("Energy Drop")] EnergyDrop,
        [HealSkill("Baisudi")] Baisudi,
        [HealSkill("Me Patra")] MePatra,
        [HealSkill("Mabaisudi")] Mabaisudi,

        [SupportSkill] Tarukaja = 335,
        [SupportSkill] Rakukaja,
        [SupportSkill] Sukukaja,
        [SupportSkill("Heat Riser")] HeatRiser,
        [SupportSkill] Matarukaja = 340,
        [SupportSkill] Marakukaja,
        [SupportSkill] Masukukaja,
        [SupportSkill] Thermopylae,
        [SupportSkill] Tarunda = 345,
        [SupportSkill] Rakunda,
        [SupportSkill] Sukunda,
        [SupportSkill] Debilitate,
        [SupportSkill] Matarunda = 350,
        [SupportSkill] Marukunda,
        [SupportSkill] Masukunda,
        [SupportSkill] Dekunda = 355,
        [SupportSkill] Dekaja,
        [SupportSkill] Charge = 360,
        [SupportSkill] Concentrate,
        [SupportSkill] Rebellion = 365,
        [SupportSkill] Revolution,
        [SupportSkill] Tetrakarn = 370,
        [SupportSkill] Makarakarn,
        [SupportSkill] Tetraja,
        [SupportSkill("Tetra Break")] TetraBreak = 375,
        [SupportSkill("Makara Break")] MakaraBreak,
        [SupportSkill("Fire Wall")] FireWall = 380,
        [SupportSkill("Ice Wall")] IceWall,
        [SupportSkill("Elec Wall")] ElecWall,
        [SupportSkill("Wind Wall")] WindWall,

        [SupportSkill("Fire Break")] FireBreak = 385,
        [SupportSkill("Ice Break")] IceBreak,
        [SupportSkill("Wind Break")] WindBreak,
        [SupportSkill("Elec Break")] ElecBreak,
        [SupportSkill] Trafuri = 390,
        [SupportSkill] Traesto,
        [SupportSkill("Nuke Wall")] NukeWall = 393,
        [SupportSkill("Psy Wall")] PsyWall,
        [SupportSkill("Nuke Break")] NukeBreak,
        [SupportSkill("Psy Break")] PsyBreak,
        [AlmightySkill("All-out Lv 1")] AllOutLv1 = 400,
        [AlmightySkill("All-out Lv 2")] AllOutLv2,
        [AlmightySkill("All-out Lv 3")] AllOutLv3,
        [SupportMateria("Emergency Escape")] EmergencyEscape,
        [HitSkill] Attack,
        [AlmightySkill("Down Shot")] DownShot,
        [SupportMateria] Support,
        [SupportMateria("Call for Backup")] CallForBackup,
        [SupportMateria("Outlaw Attack")] OutlawAttack,
        [SupportMateria("Barrage")] Barrage,
        [AlmightySkill("Follow Crush")] FollowCrush,
        [AlmightySkill("Follow Claw")] FollowClaw,
        [AlmightySkill("Follow Whip")] FollowWhip,
        [AlmightySkill("Follow Blade")] FollowBlade,
        [AlmightySkill("Follow Knuckle")] FollowKnuckle,
        [AlmightySkill("Follow Axe")] FollowAxe,
        [AlmightySkill("Follow Saber")] FollowSaber,
        [SupportSkill("Dispose Item")] DisposeItem,
        [SupportSkill("Heal Enemy")] HealEnemy,
        [AlmightySkill("Death (Despair)")] DeathDespair,
        [AlmightySkill("Ally1 Follow-Up")] Ally1FollowUp,
        [AlmightySkill("Ally2 Follow-Up")] Ally2FollowUp,
        [AlmightySkill("Ally3 Follow-Up")] Ally3FollowUp,
        [AlmightySkill("Ally4 Follow-Up")] Ally4FollowUp,
        [AlmightySkill("Ally5 Follow-Up")] Ally5FollowUp,
        [AlmightySkill("Ally6 Follow-Up")] Ally6FollowUp,
        [AlmightySkill("Ally7 Follow-Up")] Ally7FollowUp,
        [SupportSkill("Power Up Enemy")] PowerUpEnemy,
        [SupportSkill("Power Up Enemy (2)")] PowerUpEnemy2,
        [SupportSkill("Steal Info")] StealInfo,
        [AutoSkill("Sup Matarukaja")] SupMatarukaja,
        [AutoSkill("Sup Marakukaja")] SupMarakukaja, // 432

        [HitSkill("Cross Slash")] CrossSlash = 705,
    }
}
