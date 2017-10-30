using AmazonTool.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AmazonTool.Core.Extensions
{
    public static class OrderByExtension
    {
        /// <summary>
        /// Sorts the elements of a sequence in ascending or ascending order specified by the sort direction.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="sort">The sort direction.</param>
        /// <returns></returns>
        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Sort sort)
        {
            return sort == Sort.Asc ? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending or ascending order specified by the sort direction.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="sort">The sort direction.</param>
        /// <returns></returns>
        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>(this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector, Sort sort)
        {
            return sort == Sort.Asc ? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
        }
    }
}
