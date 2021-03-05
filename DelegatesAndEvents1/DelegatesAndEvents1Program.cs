using System;

namespace DelegatesAndEvents1
{
    class DelegatesAndEvents1Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter threshold value: ");
            if (int.TryParse(Console.ReadLine(), out int threshold))
            {
                var counter = new Counter(threshold);
                counter.ThresholdReached = new EventHandler<ThresholdReachedEventArgs>(HHH);
                Console.WriteLine("Press 'a' to increase total");
                while (Console.ReadKey(true).KeyChar == 'a')
                {
                    Console.WriteLine("Adding one");
                    counter.Add(1);
                }
            }
            else if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(999);
            }
            else
            {
                Console.WriteLine("Please enter a number or press Esc to cancel program");
            }


        }

        public static void HHH(object sender, ThresholdReachedEventArgs eventArgs)
        {
            Console.WriteLine($"Threshhold reached on: {eventArgs.TimeThresholdReached}");
        }
    }
}
