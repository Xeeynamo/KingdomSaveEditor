using KHSave.Attributes;

namespace KHSave.LibPersona5.Types
{
    public class ConsumableHpAttribute : ConsumableAttribute
    {
        public ConsumableHpAttribute(string name = null) : base(name) { }
    }

    public enum Inventory
    {
        [Consumable("Blank")] Blank,
        [ConsumableHp("Devil Fruit")] DevilFruit,
        [Consumable("Recov-R: 50mg")] Item2,
        [Consumable("Recov-R: 100mg")] Item3,
        [Consumable("Takemedic")] Item4,
    }
}
