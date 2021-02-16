using System;
using System.Collections.Generic;

namespace System.Linq // extend Microsoft's namespace
{
    public static class MyLinqExtensions
    {
        // this is a chainable LINQ extension method
        public static IEnumerable<T> ProcessSequence<T>(IEnumerable<T> sequence)
        {
            return sequence;
        }

        public static int? Median(this IEnumerable<int?> sequence)
        {
            var orderedSequence = sequence.OrderBy(item => item);
            //static T MyComparer<T>(T item) => item;
            var middlePosition = orderedSequence.Count() / 2;
            return orderedSequence.ElementAt(middlePosition);
        }
        
        public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Median();
        }

        public static decimal? Median(this IEnumerable<decimal?> sequence)
        {
            var orderedSequence = sequence.OrderBy(item => item);
            var middlePosition = orderedSequence.Count() / 2;
            return orderedSequence.ElementAt(middlePosition);
        }

        public static decimal? Median<T>(this IEnumerable<T> sequence, Func<T, decimal?> selector)
        {
            return sequence.Select(selector).Median();
        }

        // Mode - The most common number.
        public static int? Mode(this IEnumerable<int?> sequence)
        {
            var groupedSequence = sequence.GroupBy(item => item);
            var orderedGroups = groupedSequence.OrderByDescending(group => group.Count());
            return orderedGroups.FirstOrDefault().Key;
        }

        public static int? Mode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Mode();
        }

        public static decimal? Mode(this IEnumerable<decimal?> sequence)
        {
            var groupedSequence = sequence.GroupBy(item => item);
            var orderedGroups = groupedSequence.OrderByDescending(group => group.Count());
            return orderedGroups.FirstOrDefault().Key;
        }

        public static decimal? Mode<T>(this IEnumerable<T> sequence, Func<T, decimal?> selector)
        {
            return sequence.Select(selector).Mode();
        }
    }
}
