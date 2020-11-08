using KHSave.Attributes;
using KHSave.Extensions;

namespace KHSave.LibPersona5.Types
{
    public class DemonAttribute : InfoAttribute
    {
        public bool Royal { get; }
        public string Arcana { get; }

        public DemonAttribute(string name = null, bool royal = false, string tarot = null) : base(name)
        {
            Royal = royal;
            Arcana = tarot ?? string.Empty;
        }

        public static string GetArcana(object obj) =>
            obj.GetAttribute<DemonAttribute>()?.Arcana;
    }
    public class MagicianAttribute : DemonAttribute
    {
        public MagicianAttribute(string name = null, bool royal = false) : base(name, royal, "Magician") { }
    }
    public class JusticeAttribute : DemonAttribute
    {
        public JusticeAttribute(string name = null, bool royal = false) : base(name, royal, "Justice") { }
    }
    public class DevilAttribute : DemonAttribute
    {
        public DevilAttribute(string name = null, bool royal = false) : base(name, royal, "Devil") { }
    }
    public class StarAttribute : DemonAttribute
    {
        public StarAttribute(string name = null, bool royal = false) : base(name, royal, "Star") { }
    }
    public class LoversAttribute : DemonAttribute
    {
        public LoversAttribute(string name = null, bool royal = false) : base(name, royal, "Lovers") { }
    }
    public class ChariotAttribute : DemonAttribute
    {
        public ChariotAttribute(string name = null, bool royal = false) : base(name, royal, "Chariot") { }
    }
    public class EmperorAttribute : DemonAttribute
    {
        public EmperorAttribute(string name = null, bool royal = false) : base(name, royal, "Emperor") { }
    }
    public class HangedAttribute : DemonAttribute
    {
        public HangedAttribute(string name = null, bool royal = false) : base(name, royal, "Hanged") { }
    }
    public class FoolAttribute : DemonAttribute
    {
        public FoolAttribute(string name = null, bool royal = false) : base(name, royal, "Fool") { }
    }
    public class TowerAttribute : DemonAttribute
    {
        public TowerAttribute(string name = null, bool royal = false) : base(name, royal, "Tower") { }
    }
    public class HierophantAttribute : DemonAttribute
    {
        public HierophantAttribute(string name = null, bool royal = false) : base(name, royal, "Hierophant") { }
    }
    public class PriestessAttribute : DemonAttribute
    {
        public PriestessAttribute(string name = null, bool royal = false) : base(name, royal, "Priestess") { }
    }
    public class StrengthAttribute : DemonAttribute
    {
        public StrengthAttribute(string name = null, bool royal = false) : base(name, royal, "Strength") { }
    }
    public class EmpressAttribute : DemonAttribute
    {
        public EmpressAttribute(string name = null, bool royal = false) : base(name, royal, "Empress") { }
    }
    public class SunAttribute : DemonAttribute
    {
        public SunAttribute(string name = null, bool royal = false) : base(name, royal, "Sun") { }
    }
    public class MoonAttribute : DemonAttribute
    {
        public MoonAttribute(string name = null, bool royal = false) : base(name, royal, "Moon") { }
    }
    public class JudgementAttribute : DemonAttribute
    {
        public JudgementAttribute(string name = null, bool royal = false) : base(name, royal, "Judgement") { }
    }
    public class DeathAttribute : DemonAttribute
    {
        public DeathAttribute(string name = null, bool royal = false) : base(name, royal, "Death") { }
    }
    public class TemperAttribute : DemonAttribute
    {
        public TemperAttribute(string name = null, bool royal = false) : base(name, royal, "Temper") { }
    }
    public class HermitAttribute : DemonAttribute
    {
        public HermitAttribute(string name = null, bool royal = false) : base(name, royal, "Hermit") { }
    }
    public class FortuneAttribute : DemonAttribute
    {
        public FortuneAttribute(string name = null, bool royal = false) : base(name, royal, "Fortune") { }
    }
    public class WorldAttribute : DemonAttribute
    {
        public WorldAttribute(string name = null, bool royal = false) : base(name, royal, "World") { }
    }
}
