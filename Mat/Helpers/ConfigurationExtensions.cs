using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Mat.Helpers
{
    public static class ConfigurationExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this ConfigurationElementCollection collection)
        {
            foreach (T element in collection)
                yield return element;
        }
    }
}