/**
 * @author BoLuo
 * @email [ tktetb@163.com ]
 * @create date  2021/09/06 18:22
 * @modify date 2021/09/06 18:22
 * @desc [集合扩展类]
 */

#pragma warning disable 0649
using System;
using System.Collections;

namespace TT.Extensions
{
    /// <summary>
    /// 集合扩展类
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 查找T类型的元素
        /// </summary>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Find<T>(this T[] items, Predicate<T> predicate) => Array.Find<T>(items, predicate);


        /// <summary>
        /// 查找所有T类型的元素
        /// </summary>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] items, Predicate<T> predicate) => Array.FindAll<T>(items, predicate);

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this IEnumerable @this) => @this == null || !@this.GetEnumerator().MoveNext();
    }
}

#pragma warning restore 0649