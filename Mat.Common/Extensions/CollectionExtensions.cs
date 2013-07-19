using System.Collections.Generic;

namespace Mat.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var i in items)
            {
                collection.Add(i);
            }
        }
    }
}
