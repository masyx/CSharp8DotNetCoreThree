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
            var meddlePosition = orderedSequence.Count() / 2;
            return orderedSequence.ElementAt(meddlePosition);
        }
        
        public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Median();
        }


    }
}
