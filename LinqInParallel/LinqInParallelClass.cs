using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LinqInParallel
{
    class LinqInParallelClass
    {
        static void Main(string[] args)
        {
            //Add statements to Main to create a stopwatch to record timings,
            //wait for a keypress before starting the timer, create 2 billion integers,
            //square each of them, stop the timer, and display the elapsed milliseconds

            var stopWatch = new Stopwatch();
            WriteLine("Press ENTER to start stopwatch:");
            ConsoleKey pressedKey;

            do
            {
                pressedKey = ReadKey(intercept: false).Key;
                if (pressedKey == ConsoleKey.Enter)
                {
                    stopWatch.Start();
                    IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);
                    var square = numbers.Select(number => number * number).ToArray();
                    stopWatch.Stop();
                    WriteLine($"Time passed: {stopWatch.ElapsedMilliseconds:#,##0}");
                }
                else
                {
                    WriteLine("Press ONLY ENTER to start stopwatch: ");
                }

            } while (pressedKey != ConsoleKey.Enter);
            
        }
    }
}
