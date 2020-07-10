using KHSave.Attributes;

namespace KHSave.LibPersona5.Types
{
    public class SkillAttribute : InfoAttribute
    {
        public SkillAttribute(string name) : base(name) { }
    }
    public class HitSkillAttribute : SkillAttribute
    {
        public HitSkillAttribute(string name) : base(name) { }
    }
    public class ThunderSkillAttribute : SkillAttribute
    {
        public ThunderSkillAttribute(string name) : base(name) { }
    }
    public class HolySkillAttribute : SkillAttribute
    {
        public HolySkillAttribute(string name) : base(name) { }
    }
    public class DeathSkillAttribute : SkillAttribute
    {
        public DeathSkillAttribute(string name) : base(name) { }
    }
    public class SupportSkillAttribute : SkillAttribute
    {
        public SupportSkillAttribute(string name) : base(name) { }
    }
    public class PoisonSkillAttribute : SkillAttribute
    {
        public PoisonSkillAttribute(string name) : base(name) { }
    }

    public enum Skill : short
    {
        [ThunderSkill("Zionga")] Zionga = 41,
        [ThunderSkill("Mahamaon")] Mahamaon = 53,
        [ThunderSkill("Makougaon")] Makougaon = 59,
        [DeathSkill("Eiha")] Eiha = 64,
        [HitSkill("Cleave")] Cleave = 210,
        [HitSkill("Giant Slice")] GiantSlice,
        [HitSkill("Sword Dance")] SwordDance = 213,
        [HitSkill("Cross Slash")] CrossSlash = 705,
        [SupportSkill("Tarukaja")] Tarukaja = 335,
        [PoisonSkill("Pulinpa")] Pulinpa = 82,
    }
}
