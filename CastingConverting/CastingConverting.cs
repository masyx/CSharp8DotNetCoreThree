using System;

namespace CastingConverting
{
    class CastingConverting
    {
        public static void Main(string[] args)
        {
            int a = 10;
            double b = a; // an int can be safely cast into double
            Console.WriteLine(b);

            double c = 9.8;
            //int d = c; // compiler gives an error for this line
            int d = (int)c;
            Console.WriteLine(d);

            long e = 10;
            int f = (int)e;
            Console.WriteLine($"e is {e:N0} and f is {f:N0}");

            e = 5_000_000_000;
            f = (int)e;
            Console.WriteLine($"e is {e:N0} and f is {f:N0}");

            double g = 9.8;
            int h = Convert.ToInt32(g);
            Console.WriteLine($"g is {g} and h is {h}");


            //===============================================
            //===============================================

            double[] doubles = new[]{ 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

            foreach (double n in doubles)
            {
                Console.WriteLine($"Math.Rount({n}, 0, MidpointRounding.AwayFromZero)" +
                    $"is {Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero)}");
            }


            //===============================================
            //===============================================

            byte[] binaryObject = new byte[128];

            // populate the array with random bites
            new Random().NextBytes(binaryObject);

            Console.WriteLine("Binary Object as bytes:");

            for (int i = 0; i < binaryObject.Length; i++)
            {
                Console.Write($"{binaryObject[i]:X}");
            }
            Console.WriteLine();

            // convert to Base64 string and output as text
            string encoded = Convert.ToBase64String(binaryObject);
            Console.WriteLine($"Binary Object as Base64: {encoded}");

            //===============================================
            //===============================================

            Console.WriteLine("How many eggs are there?");
            int count;
            string input = Console.ReadLine();
            if (int.TryParse(input, out count))
            {
                Console.WriteLine($"There are {count} eggs.");
            }
            else
            {
                Console.WriteLine("I could not parse the input.");
            }
        }
    }
}
