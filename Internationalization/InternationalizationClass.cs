using System;
using System.Globalization;

namespace Internationalization
{
    class InternationalizationClass
    {
        static void Main(string[] args)
        {
            CultureInfo globalization = CultureInfo.CurrentCulture;
            CultureInfo localization = CultureInfo.CurrentUICulture;

            Console.WriteLine($"The current globalization culture is {globalization.Name}: {globalization.DisplayName}");
            Console.WriteLine($"The current localization culture is {localization.Name}: {localization.DisplayName}");

            Console.WriteLine("en-US: English (United States)");
            Console.WriteLine("da-DK: Danish (Denmark)");
            Console.WriteLine("fr-CA: French (Canada)");
            Console.Write("Enter an ISO culture code: ");

            string newCulture = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCulture))
            {
                var ci = new CultureInfo(newCulture);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }

            Console.WriteLine();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your date of birth: ");
            string dob = Console.ReadLine();
            Console.Write("Enter your salary: ");
            string salary = Console.ReadLine();

            DateTime date = DateTime.Parse(dob);
            int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
            decimal earns = Decimal.Parse(salary);

            Console.WriteLine($"{name} was born on a {date:dddd}, is {minutes:N0} minutes old, and earns {earns:C}");

        }
    }
}
