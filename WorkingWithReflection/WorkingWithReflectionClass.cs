using System;
using System.Reflection;

namespace WorkingWithReflection
{
    class WorkingWithReflectionClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assembly metadata");
            Assembly assembly = Assembly.GetEntryAssembly();

            Console.WriteLine($"Full name: {assembly.FullName}");
            Console.WriteLine($"Location: {assembly.Location}");

            var attributes = assembly.GetCustomAttributes();
            Console.WriteLine("Attributes: ");
            foreach (Attribute attribute in attributes)
            {
                Console.WriteLine($"    {attribute.GetType()}");
            }

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            Console.WriteLine($"Version: {version.InformationalVersion}");

            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            Console.WriteLine($"Company name: {company.Company}");
        }

        [Coder("Mark Price", "22 August 2019")]
        [Coder("Johnni Rasmusen", "13 September 2019")]
        static void DoStuff() { } // Haven't finished with Attribute, decided to return later
        // when more proficient with C#
    }
}
