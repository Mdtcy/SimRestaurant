/**
 * @author [jie.wen]
 * @email [jie.wen@hellomeowlab.com]
 * @create date 2021-06-13 15:06:24
 * @modify date 2021-06-13 15:06:24
 * @desc [description]
 */
#if ZSTRING
using MyString = Cysharp.Text.ZString;
#else
using MyString = System.String;
#endif
using System.Collections.Generic;

namespace TT.Extensions
{
    public static class HashSetExtensions
    {
        /// <summary>
        /// Returns a pretty string representation of the given set. The resulting string looks something like
        /// <c>[a, b, c]</c>.
        /// </summary>
        public static string SetToString<T>(this HashSet<T> source)
        {
            if (source == null)
            {
                return "null";
            }

            if (source.Count == 0)
            {
                return "[]";
            }

            #if ZSTRING
            using (var sb = MyString.CreateStringBuilder())
            #else
            var sb = new System.Text.StringBuilder();
            #endif
            {
                sb.AppendFormat("[({0})", source.Count);

                foreach (var s in source)
                {
                    sb.AppendFormat("{0}, ", s);
                }

                sb.Append("]");

                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns <c>true</c> if the hashset is either null or empty. Otherwise <c>false</c>.
        /// </summary>
        /// <param name="hashset"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this HashSet<T> hashset)
        {
            if (hashset != null)
            {
                return hashset.Count == 0;
            }

            return true;
        }
    }
}