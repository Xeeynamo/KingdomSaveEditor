using KHSave.Services;
using System;
using System.Linq;

namespace KHSave.Extensions
{
    public static class AttributeExtensions
    {
        private static CacheService<Attribute> cache = new CacheService<Attribute>();

        public static T GetAttribute<T>(this object value) where T : Attribute => (T)cache.Get(value, x =>
        {
            var memberValue = x.ToString();
            var memberInfo = x.GetType().GetMember(memberValue).FirstOrDefault();

            if (memberInfo != null)
            {
                if (memberInfo.GetCustomAttributes(typeof(T), false)
                        .FirstOrDefault() is T attribute)
                    return attribute;
            }

            return null;
        });
    }
}
