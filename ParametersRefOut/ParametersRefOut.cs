using System;

namespace ParametersRefOut
{
    class ParametersRefOut
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int c = 30;
            Console.WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            PassingParameters(a, ref b, out c);
            Console.WriteLine($"After: a = {a}, b = {b}, c = {c}");

            int d = 10;
            int e = 20;
            Console.WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
            // simplified C# 7.0 syntax for the out parameter
            PassingParameters(d, ref e, out int f);
            Console.WriteLine($"After: d = {d}, e = {e}, f = {f}");
        }

        public static void PassingParameters(int x, ref int y, out int z)
        {
            // out parameters cannot have a default
            // AND must be initialized inside the method
            z = 99;

            // increment each parameter
            x++;
            y++;
            z++;
        }
    }
}
