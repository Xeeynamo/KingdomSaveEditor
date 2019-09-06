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

        public int Amount { get; set; }

        public int TotalAmount { get; set; }

        public Tier HighestTier { get; set; }
    }
}
