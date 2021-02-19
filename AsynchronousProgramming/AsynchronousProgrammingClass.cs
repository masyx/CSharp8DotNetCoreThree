using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;


namespace AsynchronousProgramming
{
    class AsynchronousProgrammingClass
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            //WriteLine("Running methods synchronously on one thread.");
            //MethodA();
            //MethodB();
            //MethodC();

            WriteLine("Running methods asynchronously on multiple threads.");
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));

            WriteLine($"{stopwatch.ElapsedMilliseconds:#,##0}ms elapsed.");
        }

        static void MethodA()
        {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // simulate three seconds of work WriteLine("Finished Method A.");
        }
        static void MethodB()
        {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // simulate two seconds of work WriteLine("Finished Method B.");
        }
        static void MethodC()
        {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // simulate one second of work WriteLine("Finished Method C.");
        }
    }
}
