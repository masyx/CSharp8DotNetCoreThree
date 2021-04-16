using System;

namespace DelegatesAndEvents1
{
    // CLASS THAT SUBSCRIBES TO THE EVENT
    internal class DelegatesAndEvents1Program
    {
        private static void Main(string[] args)
        {
            StartOver:
            Console.WriteLine("Enter threshold value: ");

            var conversionSuccessful = int.TryParse(Console.ReadLine(), out int threshold);

           
            if (conversionSuccessful)
            {
                var counter = new Counter(threshold);
                // SUBSCRIBE TO THE EVENT
                //counter.ThresholdReached += new EventHandler<ThresholdReachedEventArgs>(Counter_ThreasholdReached);
                counter.ThresholdReached += Counter_ThresholdReached;
                
                Console.WriteLine("Press 'a' to increase total");
                while (Console.ReadKey(true).KeyChar == 'a')
                {
                    Console.WriteLine("Adding one");
                    counter.Add(1);
                }
            }
            else
            {
                Console.WriteLine("Enter a valid number.\n");
                goto StartOver;
            }
        }

        // Define what actions to take when event is raised
        // this is EVENT HANDLER
        public static void Counter_ThresholdReached(object sender, ThresholdReachedEventArgs eventArgs)
        {
            Console.WriteLine($"Threshold was set to {eventArgs.Threshold} and reached on: {eventArgs.TimeThresholdReached}");
            Environment.Exit(1);
        }
    }
}
