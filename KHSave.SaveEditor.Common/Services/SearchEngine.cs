using System;
using System.Collections.Generic;
using System.Linq;

namespace KHSave.SaveEditor.Common.Services
{
    public class SearchEngine
    {
        private const int InvalidNumber = int.MinValue;

        public interface IName
        {
            string Name { get; }
        }

        public interface ICount
        {
            int Count { get; }
        }

        public static IEnumerable<T> Filter<T>(
            string searchTerm,
            IEnumerable<T> collection,
            Func<string, T, bool> additionalFilter = null)
            where T : class
        {
            var subSearchTerms = searchTerm
                .Split(new char[] { ',', ';' })
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            var searchTermsCount = subSearchTerms.Length;
            if (searchTermsCount == 0)
                foreach (var item in collection)
                    yield return item;

            foreach (var item in collection)
            {
                for (var i = 0; i < searchTermsCount; i++)
                {
                    var mySearchTerm = subSearchTerms[i];
                    if (item is IName name && FilterByName(mySearchTerm, name))
                    {
                        yield return item;
                        break;
                    }
                    if (item is ICount count && FilterByCount(mySearchTerm, count))
                    {
                        yield return item;
                        break;
                    }
                    if (additionalFilter != null && additionalFilter(mySearchTerm, item))
                    {
                        yield return item;
                        break;
                    }
                }
            }
        }

        public static bool FilterByName(string searchTerm, IName name) =>
            name.Name.IndexOf(searchTerm, StringComparison.InvariantCultureIgnoreCase) >= 0;

        public static bool FilterByCount(string searchTerm, ICount count)
        {
            var op = searchTerm[0];
            var n = InvalidNumber;
            if (char.IsNumber(op))
            {
                if (!int.TryParse(searchTerm, out n))
                    n = InvalidNumber;
                op = '=';
            }
            else if (searchTerm.Length > 1)
            {
                var subValue = searchTerm.Substring(1).Trim();
                if (!int.TryParse(subValue, out n))
                    n = InvalidNumber;
            }

            if (n == InvalidNumber)
                return false;

            switch (op)
            {
                case '=': return count.Count == n;
                case '>': return count.Count > n;
                case '<': return count.Count < n;
                default: return true;
            }


        }
    }
}
