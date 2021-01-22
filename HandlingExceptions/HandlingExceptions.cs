using System;

namespace HandlingExceptions
{
    class HandlingExceptions
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Before parsing");
            Console.Write("What is your age?");
            string input = Console.ReadLine();

            try
            {
                int age = int.Parse(input);
                Console.WriteLine($"You are {age} years old.");

            }
            catch (OverflowException)
            {
                Console.WriteLine("Your age is a valid number format " +
                    "but it is either too big or small.");
            }
            catch (FormatException)
            {
                Console.WriteLine("The age you entered is not a valid number format.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} says: {ex.Message}");
            }

            Console.WriteLine("After parsing.");
        }
    }
}
