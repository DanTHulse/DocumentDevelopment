using System.Collections.Generic;

namespace DocumentDevelopment.Helpers
{
    public static class DictionaryExtensions
    {
        public static void AddIfNotNull<T, U>(this IDictionary<T, U> dict, T key, U value) where U : class
        {
            if (value != null)
            {
                dict.Add(key, value);
            }
        }

        public static string GetValue(this IDictionary<string, string> dict, string key, string defaultValue = "")
        {
            return dict.TryGetValue(key, out var value) ? value : defaultValue;
        }
    }
}
