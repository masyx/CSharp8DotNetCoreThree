using System;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizingResourceAccess
{
    class SynchronizingResourceAccessProgram
    {
        static Random random = new Random();
        static StringBuilder Message = new StringBuilder();
        static object locker = new object();
        static int Counter;

        static void Main(string[] args)
        {
            Console.WriteLine("Please wait for the tasks to complete");
            var stopwatch = Stopwatch.StartNew();
            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);
            Task.WaitAll(new Task[] { a, b });
            stopwatch.Stop();
            Console.WriteLine($"\nResult: {Message}");
            Console.WriteLine($"Elapsed milliseconds: {stopwatch.ElapsedMilliseconds:#,##0}");
            Console.WriteLine($"{Counter} string modifications.");

        }

        static void MethodA()
        {
            try
            {
                if (Monitor.TryEnter(locker, TimeSpan.FromMilliseconds(15000)))
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Thread.Sleep(random.Next(2000));
                        Message.Append("A");
                        Interlocked.Increment(ref Counter);
                        Console.Write(".");
                    }
                }
                else
                {
                    Console.WriteLine("MethodA failed to enter a monitor lock");
                }              
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        static void MethodB()
        {
            for (int i = 1; i <= 5; i++)
            {
                lock (locker)
                {
                    Thread.Sleep(random.Next(2000));
                    Message.Append("B");
                    Interlocked.Increment(ref Counter);
                    Console.Write(".");
                }              
            }
        }
    }
}
