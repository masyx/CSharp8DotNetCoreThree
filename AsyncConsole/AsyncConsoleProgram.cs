using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncConsole
{
    class AsyncConsoleProgram
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://www.apple.com/");
            var amountOfBytesOnPage = response.Content.Headers.ContentLength;
            Console.WriteLine($"Apple's home page has {amountOfBytesOnPage:N0} bytes");
        }
    }
}
