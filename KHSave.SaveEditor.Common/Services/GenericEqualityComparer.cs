using System;
using System.Collections;
using System.Collections.Generic;

namespace KHSave.SaveEditor.Common.Services
{
    public class GenericEqualityComparer<T> : IEqualityComparer<T>, IEqualityComparer
        where T : class
    {
        private Func<T, T, bool> _equals;

        public GenericEqualityComparer(Func<T, T, bool> equals)
        {
            _equals = equals;
        }

        public bool Equals(T x, T y) => _equals(x, y);

        public int GetHashCode(T obj) => 0;

        public new bool Equals(object x, object y) => _equals(x as T, y as T);

        public int GetHashCode(object obj) => 0;
    }
}
