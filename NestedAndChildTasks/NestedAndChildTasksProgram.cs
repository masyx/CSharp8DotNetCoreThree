using System;
using System.Threading;
using System.Threading.Tasks;

namespace NestedAndChildTasks
{
    class NestedAndChildTasksProgram
    {
        static void Main(string[] args)
        {
            var outer = Task.Factory.StartNew(OuterMethod, TaskCreationOptions.AttachedToParent);
            outer.Wait();
            Console.WriteLine("Console app is stopping.");
        }

        static void OuterMethod()
        {
            Console.WriteLine("Outer method starting...");
            var inner = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);
            Console.WriteLine("Outer method finished.");
        }

        static void InnerMethod()
        {
            Console.WriteLine("Inner method starting...");
            Thread.Sleep(2000);
            Console.WriteLine("Inner method finished.");
        }
    }
}
