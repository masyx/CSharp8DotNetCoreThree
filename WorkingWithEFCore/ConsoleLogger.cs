using System;
using Microsoft.Extensions.Logging;

namespace Packt.Shared
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            //return new ConsoleLogger();
        }

        // i
        public void Dispose(){}
    }

    public class ConsoleLogger
    {
        
    }
}
