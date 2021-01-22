using System;
using System.Collections.Generic;

namespace Packt.SharedCh06
{
    public class Person : IComparable<Person>
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        public int AngerLevel;

        //EventHandler delegate field
        public EventHandler ShoutDelegate;
        public event EventHandler ShoutEvent;

        // methods
        public void WriteToConsole()
        {
            Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        // method which raises Shout event
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                ShoutEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        // static method to multiply
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person { Name = $"Baby of {p1.Name} and {p2.Name}" };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        // instance method to multiply
        public Person ProcreateWith(Person person)
        {
            return Procreate(this, person);
        }

        // operator to multiply
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

        // method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} " +
                    $"cannot be less than zero.");
            }

            var result = LocalFactorial(number);
            return result;
            //return LocalFactorial(number);

            int LocalFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                var result = localNumber * LocalFactorial(localNumber - 1);
                return result;
                //return localNumber * LocalFactorial(localNumber - 1);
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                Console.WriteLine($"Welcome to {when:yyyy}");
            }
            else
            {
                throw new PersonException("If you travel back in time to a date " +
                    "earlier than your own birth, then the universe will explode!");
            }
        }
    }
}
