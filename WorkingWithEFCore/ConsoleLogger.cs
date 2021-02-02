using System;
using Microsoft.Extensions.Logging;

namespace Packt.Shared
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        // if your logger uses unmanaged resources
        // you can release the memory here
        public void Dispose(){}
    }

    public class ConsoleLogger : ILogger
    {
        // if your logger uses unmanaged resources,
        // you can return the class that implements IDesposable here
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // to avoid overlogging you can filet
            // on the log level
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (eventId.Id == 20100)
            {
                // log the level and event identirier
                Console.Write($"Level: {logLevel}, Event ID: {eventId.Id}");

                // only output the state or exception if it exists
                if (state is not null)
                {
                    Console.Write($", State: {state}");
                }
                if (exception != null)
                {
                    Console.Write($", Exception: {exception.Message}");
                }
                Console.WriteLine();
            }
        }
    }
}
