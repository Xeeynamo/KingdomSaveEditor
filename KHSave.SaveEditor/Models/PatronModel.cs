namespace KHSave.SaveEditor.Models
{
    public enum Tier
    {
        Unknown,
        Bronze,
        Silver,
        Gold,
        Platinum
    }

    public class PatronModel
    {
        public string Name { get; set; }

        public string ProfileUrl { get; set; }

        public string PhotoUrl { get; set; }

        public int TierId { get; set; }

        public string Color { get; set; }

        public string BadgeUrl { get; set; }

        public bool Glow { get; set; }
    }
}
