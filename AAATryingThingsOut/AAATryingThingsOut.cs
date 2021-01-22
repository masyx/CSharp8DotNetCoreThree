using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace AAATryingThingsOut
{
    class AAATryingThingsOut
    {
        static void Main(string[] args)
        {
            var xs = new[] { 4, 7, 9 };
            var limits = FindMinMax(xs);
            Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");

        }

        static(int min, int max) FindMinMax(int[] input)
        {
            if (input is null || input.Length == 0)
            {
                throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
            }
            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var i in input)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            return (min, max);
        }
    }
}
