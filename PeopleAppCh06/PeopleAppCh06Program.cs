using System;
using System.Collections.Generic;
using Packt.SharedCh06;

namespace PeopleAppCh06
{
    class PeopleAppCh06Program
    {
        static void Main(string[] args)
        {
            var harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary" };
            var jill = new Person { Name = "Jill" };

            // using static method
            Person.Procreate(harry, mary);

            // using instance method
            harry.ProcreateWith(jill);

            // call a multiply operator
            var baby = harry * mary;

            Console.WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            Console.WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            Console.WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            Console.WriteLine(
              format: "{0}'s first child is named \"{1}\".",
              arg0: harry.Name,
              arg1: harry.Children[0].Name);



            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // testing the method with local function
            Console.WriteLine();
            Console.WriteLine($"5! is {Person.Factorial(5)}");


            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // delegates
            Console.WriteLine("\n\n");

            harry.ShoutEvent += Person_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();


            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Implementing interfaces
            Console.WriteLine("\n\n");

            Person[] teamA =
            {
                new Person{Name = "Richard"},
                new Person{Name = "Bobby"},
                new Person{Name = "Sasha"},
                new Person{Name = "Christopher"},
                new Person{Name = "Anna"},
            };

            Console.WriteLine("Initial list of teamA");
            foreach (var person in teamA)
            {
                Console.WriteLine($"{person.Name}");
            }

            Console.WriteLine("Use Person's IComparable impementation to sort:");
            Array.Sort(teamA);
            foreach (var person in teamA)
            {
                Console.WriteLine($"{person.Name}");
            }

            Console.WriteLine("Use PersonComparer's IComparer implementation to sort");
            Array.Sort(teamA, new PersonComparer());
            foreach (var person in teamA)
            {
                Console.WriteLine($"{person.Name}");
            }



            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Generics types
            Console.WriteLine("\n\n");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            Console.WriteLine($"GenericThing with an integer: {gt1.Process(42)}");

            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            Console.WriteLine($"GenericThing with an integer: {gt2.Process("apple")}");




            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Generics methods
            Console.WriteLine("\n\n");

            int four = 4;
            Console.WriteLine($"The square of {four} is: {Squarer.Square(four)}");

            string three = "3";
            Console.WriteLine($"The square of {three} is: {Squarer.Square<string>(three)}");


            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Inhereting from classes
            Console.WriteLine("\n\n");

            var empSergey = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1989, 01, 17),
                EmployeeCode = "SM001",
                HireDate = new DateTime(2018, 08, 30)
            };
            empSergey.WriteToConsole();

            Console.WriteLine($"{empSergey.Name} was hired on {empSergey.HireDate:MM/dd/yyy}");
            Console.WriteLine(empSergey.ToString());


            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Understanding polymorphism
            Console.WriteLine("\n\n");

            Employee aliceInEmployee = new Employee { Name = "Alice", EmployeeCode = "AA123" };
            Person aliceInPerson = aliceInEmployee; // implicite casting

            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            Console.WriteLine(aliceInEmployee.ToString());
            Console.WriteLine(aliceInPerson.ToString());


            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Casting within inheritance hierarchies 
            Console.WriteLine("\n\n");

            Person aliceInPersonn = aliceInEmployee; // implicite casting
            //Employee explicitAlice = (Employee)aliceInPerson; // explicit casting

            if (aliceInPerson is Employee)
            {
                Console.WriteLine($"{nameof(aliceInPerson)} IS an Employee");

                Employee explicitAlice = (Employee)aliceInPerson;
                // safely do something with explicitAlice
            }

            // or
            Employee aliceAsEmployee = aliceInPerson as Employee;
            if (aliceAsEmployee != null)
            {
                Console.WriteLine($"{nameof(aliceInPerson)} AS an Employee");
                // do something with aliceAsEmployee
            }



            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Inhereting excepions 
            Console.WriteLine("\n\n");

            try
            {
                empSergey.TimeTravel(new DateTime(100, 11, 09));
                empSergey.TimeTravel(new DateTime(2000, 01, 17));  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            // Using extension methods to reuse functionality
            Console.WriteLine("\n\n");

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";

            Console.WriteLine($"{email1} is a valid e-mail address: {email1.IsValidEmail()}");
            Console.WriteLine($"{email2} is a valid e-mail address: {email2.IsValidEmail()}");
        }

        private static void Person_Shout(object sender, EventArgs eventArgs)
        {
            Person p = (Person)sender;
            Console.WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }

    }
}
