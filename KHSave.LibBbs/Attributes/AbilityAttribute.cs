using KHSave.Attributes;

namespace KHSave.LibBbs.Attributes
{
    public class AbilityStatusAttribute : AbilityAttribute
    {
        public AbilityStatusAttribute(string name = null) : base(name) 
        { 
        }
    }

    public class AbilityPriceAttribute : AbilityAttribute
    {
        public AbilityPriceAttribute(string name = null) : base(name)
        {
        }
    }
}
