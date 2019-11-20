using KHSave.Attributes;

namespace KHSave.LibRecom.Attributes
{
    public class CardMapAttribute : InfoAttribute
    {
        public CardMapAttribute(string info = null) : base(info)
        {
        }
    }

    public class CardMapRedAttribute : CardMapAttribute
    {
        public CardMapRedAttribute(string info = null) : base(info)
        {
        }
    }

    public class CardMapGreenAttribute : CardMapAttribute
    {
        public CardMapGreenAttribute(string info = null) : base(info)
        {
        }
    }

    public class CardMapBlueAttribute : CardMapAttribute
    {
        public CardMapBlueAttribute(string info = null) : base(info)
        {
        }
    }

    public class CardMapSpecialAttribute : CardMapAttribute
    {
        public CardMapSpecialAttribute(string info = null) : base(info)
        {
        }
    }
}
