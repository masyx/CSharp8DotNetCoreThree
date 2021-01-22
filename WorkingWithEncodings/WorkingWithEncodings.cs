using System;
using System.Text;
using static System.Console;

namespace WorkingWithEncodings
{
    class WorkingWithEncodings
    {
        static void Main(string[] args)
        {
            WorkingWithEncodingsMethod();
        }

        static void WorkingWithEncodingsMethod()
        {
            WriteLine("Encodings");
            WriteLine("[1] ASCII");
            WriteLine("[2] UTF-7");
            WriteLine("[3] UTF-8");
            WriteLine("[4] UTF-16 (Unicode)");
            WriteLine("[5] UTF-32");
            WriteLine("[any other key] Default");

            // choose an encoding
            WriteLine("Press a number to choose an encoding");
            ConsoleKey pressedKey = ReadKey(intercept: false).Key;
            WriteLine();
            WriteLine();

            Encoding encoder = pressedKey switch
            {
                ConsoleKey.D1 => Encoding.ASCII,
                ConsoleKey.D2 => Encoding.UTF7,
                ConsoleKey.D3 => Encoding.UTF8,
                ConsoleKey.D4 => Encoding.Unicode,
                ConsoleKey.D5 => Encoding.UTF32,
                            _ => Encoding.Default

            };

            // define a string to encode
            string message = "A pint of milk is £1.99";

            // encode a string into a byte array
            byte[] encodedMessage= encoder.GetBytes(message);

            // check how many bytes the encoding needed
            WriteLine($"{encoder.GetType().Name} uses {encodedMessage.Length} bytes");

            // enumerate each bute
            WriteLine("BYTE  HEX  CHAR");
            foreach (var b in encodedMessage)
            {
                WriteLine($"{b, 4} {b, 4:X} {(char)b, 5}");
            }

            // decode byte array back to string
            WriteLine($"{encoder.GetString(encodedMessage)}");
        }
    }
}
