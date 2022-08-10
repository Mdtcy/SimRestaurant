using System.Collections.Generic;

namespace TT.Extensions
{
    public static class DictionaryExtensions
    {
        // Works in C#3/VS2008:
        // Returns a new dictionary of this ... others merged leftward.
        // Keeps the type of 'this', which must be default-instantiable.
        // Example:
        //   result = map.MergeLeft(other1, other2, ...)
        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(IEnumerable<Dictionary<TKey, TValue>> dictionaries)
        {
            var result = new Dictionary<TKey, TValue>();
            foreach (var dict in dictionaries)
                foreach (var x in dict)
                    result[x.Key] = x.Value;
            return result;
        }

        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> self, TKey key, TValue defaultValue)
        {
            return self.ContainsKey(key) ? self[key] : defaultValue;
        }

        public static TValue GetOrAddValue<TKey, TValue>(this Dictionary<TKey, TValue> self,
                                                         TKey key,
                                                         TValue defaultValue)
        {
            if (!self.ContainsKey(key))
            {
                self[key] = defaultValue;
            }
            return self[key];
        }

        public static string DictionaryToString<TKey, TValue>(this Dictionary<TKey, TValue> self)
        {
            if (self == null)
            {
                return "null";
            }

            if (self.Count == 0)
            {
                return "{}";
            }

#if ZSTRING
            using (var sb = MyString.CreateStringBuilder())
#else
            var sb = new System.Text.StringBuilder();
#endif
            {
                sb.Append("{");
                sb.AppendFormat("[{0}]", self.Count);

                foreach (var s in self.Keys)
                {
                    sb.AppendFormat("({0}, {1}),", s, self[s]);
                }

                sb.Append("}");

                return sb.ToString();
            }
        }

        public static void Accumulate<TKey>(this Dictionary<TKey, int> self, TKey key, int value)
        {
            if (self == null || key == null)
            {
                return;
            }

            if (self.ContainsKey(key))
            {
                self[key] += value;
            }
            else
            {
                self[key] = value;
            }
        }

        public static void AddNullSkipped<TKey, TValue>(this Dictionary<TKey, TValue> self, TKey key, TValue value)
        {
            if (key == null || value == null || self.ContainsKey(key))
            {
                return;
            }

            self.Add(key, value);
        }
    }
}