using System;
using Sergeys.WebServer;

namespace ConsoleWebServer
{
    class ConsoleWebServer_Program
    {
        static void Main(string[] args)
        {
            Server.Start();
            Console.ReadLine();
        }
    }
}
