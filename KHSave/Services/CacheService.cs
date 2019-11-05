using System;
using System.Collections.Generic;

namespace KHSave.Services
{
    public class CacheService<T>
    {
        private Dictionary<object, T> _cache = new Dictionary<object, T>();

        public T Get(object value, Func<object, T> getter)
        {
            if (_cache.TryGetValue(value, out var response))
                return (T)response;

            response = getter(value);
            _cache.Add(value, response);

            return (T)response;
        }
    }
}
