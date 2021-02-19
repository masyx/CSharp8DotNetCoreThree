using System;
using System.Linq;
using Packt.Shared;

namespace PerformanceAndScalability
{
    class MonitoringApp
    {
        static void Main(string[] args)
        {
            //FirstTest();
            StringVsStringBuilderPerformance();
        }

        static void FirstTest()
        {
            Console.WriteLine("Processing, please wait...");
            Recorder.Start();

            // simulate a process that requires some memory resources
            int[] largeArrayOfInt = Enumerable.Range(1, 10_000).ToArray();

            // and takes some time to complete
            System.Threading.Thread.Sleep(new Random().Next(5, 10) * 1000);

            Recorder.Stop();
        }

        static void StringVsStringBuilderPerformance()
        {
            int[] largeArrayOfInt = Enumerable.Range(0, 50_000)
                .Select(i => new Random().Next(0, 999))
                .ToArray();
            
            Console.WriteLine("Using string with +");
            Recorder.Start();
            string s = string.Empty;

            for (int i = 0; i < largeArrayOfInt.Length; i++)
            {
                s += largeArrayOfInt[i].ToString() + ", ";
            }
            Recorder.Stop();


            Console.WriteLine($"\nUsing StringBuilder");
            Recorder.Start();
            var sb = new System.Text.StringBuilder();

            for (int i = 0; i < largeArrayOfInt.Length; i++)
            {
                sb.Append(largeArrayOfInt[i]).Append(", ");
            }   
            Recorder.Stop();
        }
    }
}
