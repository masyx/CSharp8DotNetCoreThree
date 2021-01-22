using System;
using System.Text.RegularExpressions;

namespace WorkingWithRegularExpressions
{
    class WorkingWithRegularExpressions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter person's age");

            string age = Console.ReadLine();

            var ageChecker = new Regex(@"^\d{1,2}$");

            if (ageChecker.IsMatch(age))
            {
                Console.WriteLine($"Person is {age} years old.");
            }
            else
            {
                Console.WriteLine($"This is not valid input \"{age}\".");
            }
            
        }
    }
}
