using Microsoft.Extensions.Logging;

namespace ElVegetarianoFurio.Logging
{
    public class TraceLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new DebugLogger(categoryName);

        public void Dispose() { }
    }
}