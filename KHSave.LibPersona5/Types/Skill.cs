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
    public class SupportSkillAttribute : SkillAttribute
    {
        public SupportSkillAttribute(string name = null) : base(name) { }
    }
    public class PoisonSkillAttribute : SkillAttribute
    {
        public PoisonSkillAttribute(string name = null) : base(name) { }
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

        [HitSkill("Cleave")] Cleave = 210,
        [HitSkill("Giant Slice")] GiantSlice,
        [HitSkill("Sword Dance")] SwordDance = 213,
        [HitSkill("Cross Slash")] CrossSlash = 705,
        [SupportSkill("Tarukaja")] Tarukaja = 335,
    }
}
