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
            Write("Press ENTER to start stopwatch:");
            ConsoleKey pressedKey;

            do
            {
                pressedKey = ReadKey(intercept: false).Key;
                if (pressedKey == ConsoleKey.Enter)
                {
                    WriteLine("\nCalculating...");
                    stopWatch.Start();
                    IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);
                    var square = numbers.Select(number => number * number).ToArray();
                    // on my mac numbers.AsParallel() worked 13 times worse ¯\_(ツ)_/¯
                    stopWatch.Stop();
                    WriteLine($"Time passed: {stopWatch.ElapsedMilliseconds:#,##0} milliseconds.");
                }
                else if (pressedKey ==ConsoleKey.Escape)
                {
                    return;
                }
                else
                {
                    WriteLine("\nPress ENTER to start stopwatch or Escape to exit.");
                }

            } while (pressedKey != ConsoleKey.Enter);
            
        }
    }
}
