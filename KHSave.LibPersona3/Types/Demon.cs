using KHSave.Attributes;
using KHSave.Extensions;

namespace KHSave.LibPersona3.Types
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
    
    public class AeonAttribute : DemonAttribute
    {
        public AeonAttribute(string name = null, bool royal = false) : base(name, royal, "Aeon") { }
    }

    public enum Demons : short
    {
        [Unused] Invalid = -1,
        [Demon("-")] Empty,
        [Fool("Orpheus")] Orpheus,
        [Fool("Susano-o")] Susanoo,
        [Hierophant("Flauros")] Flauros,
        [Fool("Loki")] Loki,
        [Magician("Nekomata")] Nekomata,
        [Magician("Pyro Jack")] PyroJack,
        [Magician("Jack Frost")] JackFrost,
        [Priestess("Scathach")] Scathach,
        [Magician("Rangda")] Rangda,
        [Chariot("Nata Taishi")] NataTaishi,
        [Tower("Cu Chulainn")] CuChulainn,
        [Fool("Ose")] Ose,
        [Demon("Kusi Mitama")] KusiMitama,
        [Demon("Apsaras")] Apsaras,
        [Demon("Laksmi")] Laksmi,
        [Demon("Parvati")] Parvati,
        [Demon("Kikuri-Hime")] KikuriHime,
        [Demon("Sati")] Sati,
        [Demon("Sarasvati")] Sarasvati,
        [Demon("Unicorn")] Unicorn,
        [Demon("Cybele")] Cybele,
        [Demon("Skadi")] Skadi,
        [Demon("Hariti")] Hariti,
        [Demon("Kali")] Kali,
        [Demon("Ganga")] Ganga,
        [Demon("Taraka")] Taraka,
        [Demon("Lamia")] Lamia,
        [Demon("Odin")] Odin,
        [Demon("King Frost")] KingFrost,
        [Demon("Okuninushi")] Okuninushi,
        [Demon("Kingu")] Kingu,
        [Demon("Naga Raja")] NagaRaja,
        [Demon("Forneus")] Forneus,
        [Demon("Kohryu")] Kohryu,
        [Demon("Mithra")] Mithra,
        [Demon("Daisoujou")] Daisoujou,
        [Demon("Ananta")] Ananta,
        [Demon("Omoikane")] Omoikane,
        [Demon("Principality")] Principality,
        [Demon("Raphael")] Raphael,
        [Demon("Titania")] Titania,
        [Demon("Oberon")] Oberon,
        [Demon("Narcissus")] Narcissus,
        [Demon("Queen Mab")] QueenMab,
        [Demon("Leanan Sidhe")] LeananSidhe,
        [Demon("Pixie")] Pixie,
        [Demon("Uriel")] Uriel,
        [Demon("Surt")] Surt,
        [Demon("Throne")] Throne,
        [Demon("Ares")] Ares,
        [Demon("Titan")] Titan,
        [Demon("Chimera")] Chimera,
        [Demon("Ara Mitama")] AraMitama,
        [Demon("Valkyrie")] Valkyrie,
        [Demon("Melchizedek")] Melchizedek,
        [Demon("Dominion")] Dominion,
        [Demon("Siegfried")] Siegfried,
        [Demon("Virtue")] Virtue,
        [Demon("Power")] Power,
        [Demon("Archangel")] Archangel,
        [Demon("Angel")] Angel,
        [Demon("Alilat")] Alilat,
        [Demon("Arahabaki")] Arahabaki,
        [Demon("Nebiros")] Nebiros,
        [Demon("Decarabia")] Decarabia,
        [Demon("Kurama Tengu")] KuramaTengu,
        [Demon("Yomotsu Shikome")] YomotsuShikome,
        [Demon("Naga")] Naga,
        [Demon("Norn")] Norn,
        [Demon("Atropos")] Atropos,
        [Demon("Orobas")] Orobas,
        [Demon("Lachesis")] Lachesis,
        [Demon("Saki Mitama")] SakiMitama,
        [Demon("Eligor")] Eligor,
        [Demon("Clotho")] Clotho,
        [Demon("Fortuna")] Fortuna,
        [Demon("Thor")] Thor,
        [Demon("Bishamonten")] Bishamonten,
        [Demon("Take-Mikazuchi")] TakeMikazuchi,
        [Demon("Jikokuten")] Jikokuten,
        [Demon("Hanuman")] Hanuman,
        [Demon("Koumokuten")] Koumokuten,
        [Demon("Zouchouten")] Zouchouten,
        [Demon("Attis")] Attis,
        [Demon("Vasuki")] Vasuki,
        [Demon("Orthrus")] Orthrus,
        [Demon("Take-Minakata")] TakeMinakata,
        [Demon("Ubelluris")] Ubelluris,
        [Demon("Inugami")] Inugami,
        [Demon("Thanatos")] Thanatos,
        [Demon("Alice")] Alice,
        [Demon("Seth")] Seth,
        [Demon("Mot")] Mot,
        [Demon("Samael")] Samael,
        [Demon("Vetala")] Vetala,
        [Demon("Loa")] Loa,
        [Demon("Pale Rider")] PaleRider,
        [Demon("Michael")] Michael,
        [Demon("Byakko")] Byakko,
        [Demon("Suzaku")] Suzaku,
        [Demon("Seiryuu")] Seiryuu,
        [Demon("Nigi Mitama")] NigiMitama,
        [Demon("Genbu")] Genbu,
        [Demon("Beelzebub")] Beelzebub,
        [Demon("Mother Harlot")] MotherHarlot,
        [Demon("Abaddon")] Abaddon,
        [Demon("Lilith")] Lilith,
        [Demon("Incubus")] Incubus,
        [Demon("Succubus")] Succubus,
        [Demon("Lilim")] Lilim,
        [Demon("Chi You")] ChiYou,
        [Demon("Shiva")] Shiva,
        [Demon("Masakado")] Masakado,
        [Demon("Seiten Taisei")] SeitenTaisei,
        [Demon("Yamatano-orochi")] Yamatanoorochi,
        [Demon("Oumitsunu")] Oumitsunu,
        [Demon("Helel")] Helel,
        [Demon("Sandalphon")] Sandalphon,
        [Demon("Black Frost")] BlackFrost,
        [Demon("Garuda")] Garuda,
        [Demon("Kaiwan")] Kaiwan,
        [Demon("Ganesha")] Ganesha,
        [Demon("Nandi")] Nandi,
        [Demon("Chernobog")] Chernobog,
        [Demon("Dionysus")] Dionysus,
        [Demon("Narasimha")] Narasimha,
        [Demon("Girimehkala")] Girimehkala,
        [Demon("Gurr")] Gurr,
        [Demon("Legion")] Legion,
        [Demon("Berith")] Berith,
        [Demon("Saturnus")] Saturnus,
        [Demon("Vishnu")] Vishnu,
        [Demon("Barong")] Barong,
        [Demon("Jatayu")] Jatayu,
        [Demon("Horus")] Horus,
        [Demon("Quetzalcoatl")] Quetzalcoatl,
        [Demon("Yatagarasu")] Yatagarasu,
        [Demon("Messiah")] Messiah,
        [Demon("Asura")] Asura,
        [Demon("Metatron")] Metatron,
        [Demon("Satan")] Satan,
        [Demon("Gabriel")] Gabriel,
        [Demon("Hokuto Seikun")] HokutoSeikun,
        [Demon("Trumpeter")] Trumpeter,
        [Demon("Anubis")] Anubis,
        [Demon("Slime")] Slime, // FES, P3P
        [Demon("Hua Po")] HuaPo, // FES, P3P
        [Demon("High Pixie")] HighPixie, // FES, P3P
        [Demon("Yaksini")] Yaksini, // FES, P3P
        [Demon("Shiisaa")] Shiisaa, // FES, P3P
        [Demon("Thoth")] Thoth, // FES, P3P
        [Demon("Alp")] Alp, // FES, P3P
        [Demon("Mothman")] Mothman, // FES, P3P
        [Demon("Kumbhanda")] Kumbhanda, // FES, P3P
        [Demon("Empusa")] Empusa, // FES, P3P
        [Demon("Rakshasa")] Rakshasa, // FES, P3P
        [Demon("Hecatoncheires")] Hecatoncheires, // FES, P3P
        [Demon("Hell Biker")] HellBiker, // FES, P3P
        [Demon("Ghoul")] Ghoul, // FES, P3P
        [Demon("Yurlungur")] Yurlungur,
        [Demon("Pazuzu")] Pazuzu, // FES, P3P
        [Demon("Mara")] Mara, // FES, P3P
        [Demon("Kartikeya")] Kartikeya, // FES, P3P
        [Demon("Baal Zebul")] BaalZebul, // FES, P3P
        [Demon("Suparna")] Suparna, // FES, P3P
        [Demon("Lucifer")] Lucifer, // FES, P3P
        [Demon("Nidhoggr")] Nidhoggr, // FES, P3P
        [Demon("Atavaka")] Atavaka, // FES, P3P
        [Demon("Orpheus Telos")] OrpheusTelos, // FES, P3P
        [Demon("Mokoi")] Mokoi, // P3P
        [Demon("Neko Shogun")] NekoShogun, // P3P
        [Demon("Setanta")] Setanta, // P3P
        [Demon("Tam Lin")] TamLin, // P3P
        [Demon("Orpheus (female)")] OrpheusFemale, // P3P
        [Unused] Demon0AF,
        [Unused] Demon0B0,
        [Unused] Demon0B1,
        [Unused] Demon0B2,
        [Unused] Demon0B3,
        [Unused] Demon0B4,
        [Unused] Demon0B5,
        [Unused] Demon0B6,
        [Unused] Demon0B7,
        [Unused] Demon0B8,
        [Unused] Demon0B9,
        [Unused] Demon0BA,
        [Unused] Demon0BB,
        [Unused] Demon0BC,
        [Unused] Demon0BD,
        [Unused] Demon0BE,
        [Demon("Universe")] Universe,
        [Demon("Isis")] Isis,
        [Demon("Palladion")] Palladion,
        [Demon("Athena")] Athena,
        [Demon("Penthesilea")] Penthesilea,
        [Demon("Artemisia")] Artemisia,
        [Demon("Hermes")] Hermes,
        [Demon("Trismegistus")] Trismegistus,
        [Demon("Lucia")] Lucia,
        [Demon("Juno")] Juno,
        [Demon("Polydeuces")] Polydeuces,
        [Demon("Caesar")] Caesar,
        [Demon("Nemesis")] Nemesis,
        [Demon("Kala-Nemi")] KalaNemi,
        [Demon("Castor")] Castor,
        [Demon("Cerberus")] Cerberus,
        [Demon("Hypnos")] Hypnos,
        [Demon("Moros")] Moros,
        [Demon("Medea")] Medea,
        [Demon("Psyche")] Psyche, // FES, P3P
        [Unused] Demon0D3,
        [Unused] Demon0D4,
        [Unused] Demon0D5,
        [Unused] Demon0D6,
        [Unused] Demon0D7,
        [Unused] Demon0D8,
        [Unused] Demon0D9,
        [Unused] Demon0DA,
        [Unused] Demon0DB,
        [Unused] Demon0DC,
        [Unused] Demon0DD,
        [Unused] Demon0DE,
        [Unused] Demon0DF,
        [Unused] Demon0E0,
        [Unused] Demon0E1,
        [Unused] Demon0E2,
        [Unused] Demon0E3,
        [Unused] Demon0E4,
        [Unused] Demon0E5,
        [Unused] Demon0E6,
        [Unused] Demon0E7,
        [Unused] Demon0E8,
        [Unused] Demon0E9,
        [Unused] Demon0EA,
        [Unused] Demon0EB,
        [Unused] Demon0EC,
        [Unused] Demon0ED,
        [Unused] Demon0EE,
        [Unused] Demon0EF,
        [Unused] Demon0F0,
        [Unused] Demon0F1,
        [Unused] Demon0F2,
        [Unused] Demon0F3,
        [Unused] Demon0F4,
        [Unused] Demon0F5,
        [Unused] Demon0F6,
        [Unused] Demon0F7,
        [Unused] Demon0F8,
        [Unused] Demon0F9,
        [Unused] Demon0FA,
        [Unused] Demon0FB,
        [Unused] Demon0FC,
        [Unused] Demon0FD,
        [Unused] Demon0FE,
        [Unused] Demon0FF,
    }
}
