using System;
using System.Collections.Generic; // for IEnumerable<T>
using System.Linq; // for LINQ extension methods

namespace LinqWithSets
{
    class LinqWithSetsClass
    {
        static void Main(string[] args)
        {
            var cohort1 = new string[]{ "Rachel", "Gareth", "Jonathan", "George" };
            var cohort2 = new string[]{ "Jack", "Stephen", "Daniel", "Jack", "Jared" };
            var cohort3 = new string[]{ "Declan", "Jack", "Jack", "Jasmine", "Conor" };
            Output(cohort1, "Cohort 1");
            Output(cohort2, "Cohort 2");
            Output(cohort3, "Cohort 3");
            Console.WriteLine();

            Output(cohort2.Distinct(), "cohort2.Distinct():");
            Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)");
        }

        private static void Output(IEnumerable<string> cohort, string description = "")
        {
            if (!string.IsNullOrEmpty(description))
            {
                Console.WriteLine(description);
            }
            Console.Write(" ");

            Console.WriteLine($"{string.Join(", ", cohort.ToArray())}");
        }
    }
}
