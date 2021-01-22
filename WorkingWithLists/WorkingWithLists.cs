using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WorkingWithLists
{
    class WorkingWithLists
    {
        static void Main(string[] args)
        {
            List<string> cities = new List<string>(){ "Sydney", "Paris" };
            cities.Add("Moscow");

            var immutableCities = cities.ToImmutableList<string>();
            var newCitiesList = immutableCities.Add("London");

            Console.Write("Immutable list of cities: ");
            foreach (var city  in immutableCities)
            {
                Console.Write($"{city}, ");
            }
            Console.WriteLine();

            Console.Write("NewCitiesList: ");
            foreach (var city in newCitiesList)
            {
                Console.Write($"{city}, ");
            }
        }
    }
}
