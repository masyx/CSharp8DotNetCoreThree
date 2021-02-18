using System;
using System.Linq;
using Packt.Shared;

namespace PerformanceAndScalability
{
    class MonitoringApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing, please wait...");
            Recorder.Start();

            // simulate a process that requires some memory resources
            int[] largeArrayOfInt = Enumerable.Range(1, 10_000).ToArray();

            // and takes some time to complete
            System.Threading.Thread.Sleep(new Random().Next(5, 10) * 1000);

            Recorder.Stop();
        }
    }
}
