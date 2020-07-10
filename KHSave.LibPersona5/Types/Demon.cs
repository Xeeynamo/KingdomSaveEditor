using KHSave.Attributes;

namespace KHSave.LibPersona5.Types
{
    public class DemonAttribute : InfoAttribute
    {
        public DemonAttribute(string name = null) : base(name) { }
    }
    public class MagicianAttribute : DemonAttribute
    {
        public MagicianAttribute(string name = null) : base(name) { }
    }
    public class JusticeAttribute : DemonAttribute
    {
        public JusticeAttribute(string name = null) : base(name) { }
    }
    public class DevilAttribute : DemonAttribute
    {
        public DevilAttribute(string name = null) : base(name) { }
    }
    public class StarAttribute : DemonAttribute
    {
        public StarAttribute(string name = null) : base(name) { }
    }
    public class LoversAttribute : DemonAttribute
    {
        public LoversAttribute(string name = null) : base(name) { }
    }
    public class ChariotAttribute : DemonAttribute
    {
        public ChariotAttribute(string name = null) : base(name) { }
    }
    public class EmperorAttribute : DemonAttribute
    {
        public EmperorAttribute(string name = null) : base(name) { }
    }
    public class HangedAttribute : DemonAttribute
    {
        public HangedAttribute(string name = null) : base(name) { }
    }
    public class FoolAttribute : DemonAttribute
    {
        public FoolAttribute(string name = null) : base(name) { }
    }
    public class TowerAttribute : DemonAttribute
    {
        public TowerAttribute(string name = null) : base(name) { }
    }
    public class HierophantAttribute : DemonAttribute
    {
        public HierophantAttribute(string name = null) : base(name) { }
    }
    public class PriestessAttribute : DemonAttribute
    {
        public PriestessAttribute(string name = null) : base(name) { }
    }
    public class StrengthAttribute : DemonAttribute
    {
        public StrengthAttribute(string name = null) : base(name) { }
    }
    public class EmpressAttribute : DemonAttribute
    {
        public EmpressAttribute(string name = null) : base(name) { }
    }
    public class SunAttribute : DemonAttribute
    {
        public SunAttribute(string name = null) : base(name) { }
    }
    public class MoonAttribute : DemonAttribute
    {
        public MoonAttribute(string name = null) : base(name) { }
    }
    public class JudgementAttribute : DemonAttribute
    {
        public JudgementAttribute(string name = null) : base(name) { }
    }
    public class DeathAttribute : DemonAttribute
    {
        public DeathAttribute(string name = null) : base(name) { }
    }
    public class TemperAttribute : DemonAttribute
    {
        public TemperAttribute(string name = null) : base(name) { }
    }
    public class HermitAttribute : DemonAttribute
    {
        public HermitAttribute(string name = null) : base(name) { }
    }
    public class FortuneAttribute : DemonAttribute
    {
        public FortuneAttribute(string name = null) : base(name) { }
    }

    public enum Demon
    {
        [Demon] None,
        [Justice] Metatron = 1,
        [Devil] Belzebub,
        [Star("Cu Chulainn")] CuChulainn,
        [Magician("Jack-o'-Lantern")] JackOLantern,
        [Magician("Jack Frost")] JackFrost,
        [Lovers] Pixie,
        [Chariot] Cerberus,
        [Devil] Lili,
        [Emperor] Eligor,
        [Emperor] Odin,
        [Hanged("Hua Po")] HuaPo,
        [Fool] Decarabia,
        [Tower] Mara,
        [Fool] Ose,
        [Chariot] Thor,
        [Hierophant] Unicorn,
        [Justice] Uriel,
        [Priestess] Sarasvati,
        [Strength] Valkyrie,
        [Empress] Yaksini,
        [Sun] Ganesha,
        [Judgement] Anbus,
        [Death] Mot,
        [Lovers] Raphael,
        [Priestess] Scathach,
        [Fool("High Pixie")] HighPixie,
        [Emperor] Barong,
        [Moon] Girimehkala,
        [Emperor("King Frost")] KingFrost,
        [Lovers] Narcissus,
        [Priestess] Isis,
        [Empress] Lamia,
        [Fool] Legion,
        [Strength] Rakshasa,
        [Death] Mokoi,
        [Hierophant] Forneus,
        [Emperor] Setanta,
        [Empress] Titania,
        [Devil] Incubus,
        [Strength] Oni,
        [Moon] Lilith,
        [Magician] Rangda,
        [Temper] Makami,
        [Lovers] Parvati,
        [Temper] Gabriel,
        [Strength("Zaou-Gongen")] ZaouGongen,
        [Death] Alice,
        [Empress] Kali,
        [Hermit("Kurama Tengu")] KuramaTengu,
        [Emperor] Oberon,
        [Chariot("Shiki-Ouji")] ShikiOuji,
        [Judgement("Yamata-no-Orochi")] YamataNoOrochi,
        [Hierophant] Orobas,
        [Star] Hanuman,
        [Justice] Archangel,
        [Fool] Obariyon,
        [Magician("Queen Mab")] QueenMab,
        [Moon] Sandalphon,
        [Judgement] Abaddon,
        [Chariot] Shiisaa,
        [Magician] Sandman,
        [Devil] Belial,
        [Lovers("Leanan Sidhe")] LeananSidhe,
        [Priestess] Cybele,
        [Death] Chernobog,
        [Devil] Flauros,
        [Hermit("Ippon-Datara")] IpponDatara,
        [Hanged] Orthrus,
        [Moon] Succubus,
        [Moon] Motham,
        [Unused] Demon71,
        [Justice] Dominion,
        [Magician] Nekomata,
        [Fool("Black Frost")] BlackFrost,
        [Hermit] Arahabaki,
        [Justice] Angel,
        [Priestess] Skadi,
        [Priestess("Kikuri-Hime")] KikuriHime,
        [Chariot("Chi You")] ChiYou,
        [Justice] Power,
        [Hanged] Inugami,
        [Devil] Nebiros,
        [Unused] Demon83,
        [Chariot] Slime,
        [Hierophant] Anzu,
        [Sun] Yatagarasu,
        [Tower] Yoshitsune,
        [Hanged("Take-Minakata")] TakeMinakata,
        [Lovers("Ame-no-Uzume")] AmeNoUzume,
        [Lovers] Kushinada,
        [Hermit] Kumbhanda,
        [Hermit("Ongyo-Ki")] OngyoKi,
        [Chariot("Kin-KI")] KinKi,
        [Moon("Sui-Ki")] SuiKi,
        [Star("Fuu-Ki")] FuuKi,
        [Tower] Jatayu,
        [Star] Kaiwan,
        [Strength] Kelpie,
        [Emperor] Thoth,
        [Fool] Dinonysus,
        [Priestess] Apsaras,
        [Devil] Andras,
        [Unused] Demon103,
        [Hermit] Koropokguru,
        [Temper("Koppa-Tengu")] KoppaTengu,
        [Emperor] Regent,
        [Empress("Queen's Necklace")] QueenNecklace,
        [Fortune("Stone of Scone")] StoneOfScone,
        [Priestess("Koh-i-Noor")] KohINoor,
        [Strength] Orlov,
        [Hanged("Emperor's Amulet")] EmperorAmulet,
        [Death("Hope Diamond")] HopeDiamond,
        [Fool("Crystal Skull")] CrystalSkull,
        [Unused] Demon114,
        [Unused] Demon115,
        [Unused] Demon116,
        [Unused] Demon117,
        [Unused] Demon118,
        [Unused] Demon119,
        [Unused] Demon120,
        [Death] Mandrake,
        [Emperor] Baal,
        [Empress] Dakini,
        [Priestess] Silky,
        [Fool] Bugs,
        [Moon("Black Ooze")] BlackOoze,
        [Hermit] Bicorn,
        [Sun] Mithras,
        [Hermit] Sudama,
        [Star] Kodama,
        [Chariot] Agathion,
        [Moon] Onmoraki,
        [Moon] Nue,
        [Death] Picasa,
        [Justice] Melchizedek,
        [Devil] Baphomet,
        [Temper("Raja Naga")] RajaNaga,
        [Hermit] Naga,
        [Star] Garuda,
        [Hanged] Moloch,
        [Fortune] Norn,
        [Tower] Belphegor,
        [Hierophant] Berith,
        [Magician] Choronzon,
        [Unused] Demon145,
        [Unused] Demon146,
        [Unused] Demon147,
        [Unused] Demon148,
        [Unused] Demon149,
        [Unused] Demon150,
        [Temper("Nigi Mitama")] NigiMitama,
        [Strength("Kushi Mitama")] KushiMitama,
        [Chariot("Ara Mitama")] AraMitama,
        [Lovers("Saki Mitama")] SakiMitama,
        [Unused] Demon155,
        [Judgement] Shiva,
        [Judgement] Michael,
        [Sun] Asura,
        [Tower] Mada,
        [Empress("Mother Harlot")] MotherHarlot,
        [Fortune] Clotho,
        [Fortune] Lachesis,
        [Fortune] Atropos,
        [Temper] Ardha,
        [Unused] Demon165,
        [Fool] Vishnu,
        [Empress] Hariti,
        [Sun] Yurlungur,
        [Hanged] Hecatoncheires,
        [Unused] Demon170,
        [Unused] Demon171,
        [Unused] Demon172,
        [Unused] Demon173,
        [Unused] Demon174,
        [Unused] Demon175,
        [Unused] Demon176,
        [Unused] Demon177,
        [Unused] Demon178,
        [Unused] Demon179,
        [Unused] Demon180,
        [Fool] Orpheus,
        [Death] Thanatos,
        [Fool] Izanagi,
        [Tower("Magatsu-Izanagi")] MagatsuIzanagi,
        [Moon] Kaguya,
        [Fortune] Ariadne,
        [Fortune] Asterius,
        [Moon] Tsukiyomi,
        [Judgement] Messiah,
        [Judgement("Messiah Picaro")] MessiahPicaro,
        [Fool("Orpheus Picaro")] OrpheusPicaro,
        [Death("Thanatos Picaro")] ThanatosPicaro,
        [Fool("Izanagi Picaro")] IzanagiPicaro,
        [Tower("M. Izanagi Picaro")] MIzanagiPicaro,
        [Moon("Kaguya Picaro")] KaguyaPicaro,
        [Fortune("Ariadne Picaro")] AriadnePicaro,
        [Fortune("Asterius Picaro")] AsteriusPicaro,
        [Moon("Tsukiyomi Picaro")] TsukiyomiPicaro,
        [Fool("Satanel")] Satanel,
        [Fool("???")] Demon200,
        [Fool("Arsene")] Arsene,
        [Chariot("Capitain Kidd")] CapitainKidd,
        [Magician] Zorro,
        [Lovers] Carmen,
        [Emperor] Goemon,
        [Priestess] Johanna,
        [Empress] Milady,
        [Hermit] Necronomicon,
        [Justice("Robin Hood")] RobinHood,
        [Justice("Loki (untested)")] Loki,
        [Fool("Satanel (crash)")] Satanel2,
        [Chariot("Seiten Taisei")] SeitenTaisei,
        [Magician] Mercurius,
        [Lovers] Hecate,
        [Emperor("Kamu Susanoo-o")] KamuSusanoo,
        [Priestess] Anat,
        [Empress] Astarte,
        [Hermit] Prometheus,
        [Justice("Loki")] Loki2,
        [Unused] Arsene2,
        [Unused] CapitainKidd2,
        [Unused] Zorro2,
        [Unused] Carmen2,
        [Unused] Goemon2,
        [Unused] Johanna2,
        [Unused] Milady2,
        [Unused] Necronomicon2,
        [Unused] RobinHood2,
        [Unused] Demon229,
        [Unused] Lucifer,
        [Unused] SeitenTaisei2,
        [Unused] Mercurius2,
        [Unused] Hecate2,
        [Unused] KamuSusanoo2,
        [Unused] Anat2,
        [Unused] Astarte2,
        [Unused] Prometheus2,
        [Unused] Loki3,
        [Unused] Demon239,
        [Unused] Demon240,
        [Unused] Demon241,
        [Unused] Demon242,
        [Unused] Demon243,
        [Unused] Demon244,
        [Unused] Demon245,
        [Unused] Demon246,
        [Unused] Demon247,
        [Unused] Demon248,
        [Unused] Demon249,
        [Unused] Demon250,
        [Unused] Demon251,
        [Judgement] Satan,
        [Star("Lucifer")] Lucifer2,
        [Hierophant] Kohryu,
        [Emperor] Okuninushi,
        [Unused] Norn2,
        [Unused] Demon257,
        [Unused] Demon258,
        [Unused] Demon259,
        [Unused] Demon260,
        [Tower] Seth,
        [Lovers] Ishtar,
        [Unused] Demon263,
        [Magician] Surt,
        [Strength] Siegfried,
        [Fortune] Lakshmi,
        [Unused] Demon267,
        [Unused] Demon268,
        [Unused] Demon269,
        [Unused] Demon270,
        [Unused] Demon271,
        [Fortune] Fortuna,
        [Sun] Suzaku,
        [Temper] Seiryu,
        [Temper] Genbu,
        [Temper] Byakko,
        [Hierophant] Bishamonten,
        [Hermit] Koumokuten,
        [Temper] Jikokuten,
        [Strength] Zouchouten,
        [Death("Hell Biker")] HellBiker,
        [Hierophant] Daisoujou,
        [Judgement] Trumpeter,
        [Chariot("White Rider")] WhiteRider,
        [Death] Matador,
        [Death("Pale Rider")] PaleRider,
        [Sun] Horus,
        [Unused] Demon288,
        [Hanged] Attis,
        [Unused] Demon290,
        [Unused] Demon291,
        [Star] Sraosha,
        [Unused] Demon293,
        [Unused] Demon294,
        [Temper] Mitra,
        [Hierophant] Phoenix,
        [Justice] Principality,
        [Star("Neko Shogun")] NekoShogun,
        [Hanged] Vasuki,
        [Star] Ananta,
        [Justice] Throne,
        [Unused] Demon302,
        [Sun] Quetzalcoalt,
        [Tower("Red Rider")] RedRider,
        [Tower("Black Rider")] BlackRider,
        [Unused] Demon306,
        [Unused] Demon307,
        [Devil] Pazuzu,
    }
}
