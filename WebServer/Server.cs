using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Sergeys.WebServer
{
    /// <summary>
    /// A lean and mean web server
    /// </summary>
    public class Server
    {
        private static HttpListener listener;

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
    }
}
