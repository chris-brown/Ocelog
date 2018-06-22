using Microsoft.Extensions.Logging;

namespace Ocelog.AspNetCore
{
    public class OcelogLoggingProvider : ILoggerProvider
    {
        private readonly Logger _logger;

        public OcelogLoggingProvider(Logger logger)
        {
            _logger = logger;
        }
        public void Dispose()
        {
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return new OcelogLogger(_logger);
        }
    }
}