using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ElVegetarianoFurio.Logging
{
    public class DebugLogger : ILogger
    {
        private readonly string _categoryName;

        public DebugLogger(string categoryName) => this._categoryName = categoryName;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Debug.WriteLine($"{DateTime.Now:o} {logLevel} {eventId.Id} {this._categoryName}");
            Debug.WriteLine(formatter(state, exception));
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}