using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Sergeys.WebServer
{
    /// <summary>
    /// A lean and mean web server
    /// </summary>
    public class Server
    {
        private static HttpListener listener;
        public static int maxSimultaneousConnections = 20;
        // set up a semaphore that waits for a specified number of simultaneously allowed connections
        private static Semaphore sem = new Semaphore(maxSimultaneousConnections, maxSimultaneousConnections);

        /// <summary>
        /// Returns list of ip adresses assigned to localhost network devices,
        /// such as hardwired ethernet, wireless, etc.
        /// </summary>
        /// <returns></returns>
        private static List<IPAddress> GetLocalHostIPs()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            List<IPAddress> ret = host.AddressList.
                Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToList();

            return ret;
        }

        /// <summary>
        /// Instantiate the HttpListener and add the localhost prefixes
        /// </summary>
        /// <param name="localHostIPs">List of ip adresses assigned to localhost network devices</param>
        /// <returns></returns>
        private static HttpListener InitializeListener(List<IPAddress> localHostIPs)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost/");

            // Listen to IP address as well
            localHostIPs.ForEach(ip =>
            {
                Console.WriteLine($"Listening on IP http://{ip}/");
                listener.Prefixes.Add($"http://{ip}/");
            });

            return listener;
        }

        /// <summary>
        /// Await connections
        /// </summary>
        /// <param name="listener"></param>
        private static async void StartConnectionListener(HttpListener listener)
        {
            // Wait for a connection. Return to caller while we wait.
            HttpListenerContext context = await listener.GetContextAsync();

            // Release the semaphore so that another listener can be immediately started up.
            sem.Release();

            // We have a connection, do something...
        }
    }
}
