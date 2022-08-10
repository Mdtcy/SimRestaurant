/**
 * @author BoLuo
 * @email [ tktetb@163.com ]
 * @create date  2021/09/09 16:31
 * @modify date 2021/09/09 16:31
 * @desc [Queue扩展方法]
 */

#pragma warning disable 0649
using System.Collections.Generic;

namespace TT.Extensions
{
    /// <summary>
    /// Queue扩展方法
    /// </summary>
    public static class QueueExtension
    {
        /// <summary>
        /// 返回Queue最后一个或default
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LastOrDefault<T>(this Queue<T> items)
        {
            var array = items.ToArray();

            if (array.Length > 0)
            {
                return array[array.Length - 1];
            }

            var tDefault = default(T);
            return tDefault;
        }
    }
}

#pragma warning restore 0649