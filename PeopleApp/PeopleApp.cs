using System;
using Packt.Shared;

namespace PeopleApp
{
    class PeopleApp
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.GreatPyramidOfGiza;
            bob.DateOfBirth = new DateTime(1964, 10, 9);
            bob.BucketList = WondersOfTheAncientWorld.GreatPyramidOfGiza
                | WondersOfTheAncientWorld.HangingGardensOfBabylon;
            bob.Children.Add(new Person { Name = "Aaron" });
            bob.Children.Add(new Person { Name = "Liza" });

            Console.WriteLine($"{bob.Name} is {Person.Species}");
            Console.WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
            Console.WriteLine($"{bob.Name} was born on " +
                $"{bob.DateOfBirth:dddd, d MMMM, yyyy}");
            Console.WriteLine($"{bob.Name}'s favorite wonder " +
                $"is {bob.FavoriteAncientWonder}. It's integer is {(int)bob.FavoriteAncientWonder}.");
            Console.WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
            Console.WriteLine($"{bob.Name} has {bob.Children.Count} children.");
            for(int child = 0; child < bob.Children.Count; child++)
            {
                Console.WriteLine($"{bob.Children[child].Name}");
            }
            foreach (var child in bob.Children)
            {
                Console.WriteLine($"{child.Name}");
            }




            Console.WriteLine();
            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };

            Console.WriteLine($"{alice.Name} was born on " +
                $"{alice.DateOfBirth:dd MMMM yy}");



            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////


            Console.WriteLine();

            BankAccount.InterestRate = 0.012M; //
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            Console.WriteLine($"{jonesAccount.AccountName} " +
                $"earned {jonesAccount.Balance * BankAccount.InterestRate:C}");

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            Console.WriteLine($"{gerrierAccount.AccountName} " +
                $"earned {gerrierAccount.Balance * BankAccount.InterestRate:C}");



            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////



            Console.WriteLine();

            var blankPerson = new Person();
            Console.WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} " +
                $"was created at {blankPerson.Instantiated:hh:mm:ss} on {blankPerson.Instantiated:dddd}");

            var aaron = new Person("Aaron", "Mars");
            Console.WriteLine($"{aaron.Name} of {aaron.HomePlanet} " +
                $"was created at {aaron.Instantiated:hh:mm:ss} on {aaron.Instantiated:dddd}");



            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            /// Default values


            Console.WriteLine();

            var thingsOfDefault = new ThingOfDefault();
            Console.WriteLine($"Default value of Population variable is: {thingsOfDefault.Population}");
            Console.WriteLine($"Default value of When variable is: {thingsOfDefault.When}");
            Console.WriteLine($"Default value of Name variable is: {thingsOfDefault.Name}");
            Console.WriteLine($"Default value of People variable is: {thingsOfDefault.People}");




            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            // Tuples

            Console.WriteLine();
            (string fruiteName, int amount) fruites = bob.GetFruite();
            Console.WriteLine($"there are {fruites.amount} {fruites.fruiteName}");




            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            // Readonly properties
            Console.WriteLine();
            var bill = new Person { Name = "Bill", DateOfBirth = new DateTime(1972, 1, 27) };
            Console.WriteLine();
            Console.WriteLine(bill.Origin);
            Console.WriteLine(bill.Greeting);
            Console.WriteLine(bill.Age);


            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            // properties with set method
            Console.WriteLine();

            bill.FavoriteIceCream = "Chocolate Fudge";
            Console.WriteLine($"{bill.Name} favorite icecream is {bill.FavoriteIceCream}");
            bill.FavoritePrimaryColor = "Green";
            Console.WriteLine($"{bill.Name} favorite color is {bill.FavoritePrimaryColor}");


            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            // indexer

            Console.WriteLine();
            bill.Children.Add(new Person { Name = "Janifer" });
            bill.Children.Add(new Person { Name = "Mathew" });

            Console.WriteLine(bill.Children[0].Name);
            Console.WriteLine(bill.Children[1].Name);
            Console.WriteLine(bill[0].Name);
            Console.WriteLine(bill[1].Name);


            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
            // Delegates and events
            
        }


    }
}