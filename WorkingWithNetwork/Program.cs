using System;
using System.Net;
using System.Net.NetworkInformation;

namespace WorkingWithNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Working with URIs, DNS, and IP addresses

            Console.WriteLine("Enter a valid web address:");
            string url = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(url))
            {
               url = "https://world.episerver.com/cms/?q=pagetype";
            }

            var uri = new Uri(url);

            Console.WriteLine($"URL: {url}");
            Console.WriteLine($"Scheme: {uri.Scheme}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Path: {uri.AbsolutePath}");
            Console.WriteLine($"Query: {uri.Query}");

            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine($"{entry.HostName} has the following IP addresses:");
            foreach (IPAddress address in entry.AddressList)
            {
                Console.WriteLine($" {address}");
            }


            //Pinging a server
            try
            {
                var ping = new Ping();
                Console.WriteLine("Pinging server. Please wait...");
                PingReply reply = ping.Send(uri.Host);
                Console.WriteLine($"{uri.Host} was pinged and replyed {reply.Status}");

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine($"Reply from {uri.Host} took {reply.RoundtripTime} ms");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().ToString()} says: {ex.Message}");
            }
        }
    }
}
