using System.Collections.Generic;

namespace DocumentDevelopment.Helpers
{
    public static class DictionaryHelpers
    {
        public static void AddIfNotNull<T, U>(this IDictionary<T, U> dict, T key, U value) where U : class
        {
            if (value != null)
            {
                dict.Add(key, value);
            }
        }

        public static U GetValue<T, U>(this IDictionary<T, U> dict, T key, U defaultValue = default(U))
        {
            return dict.TryGetValue(key, out U value) ? value : defaultValue;
        }
    }
}
