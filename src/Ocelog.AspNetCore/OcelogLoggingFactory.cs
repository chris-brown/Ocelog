using Microsoft.Extensions.Logging;

namespace Ocelog.AspNetCore
{
    public class OcelogLoggingFactory : ILoggerFactory
    {
        private readonly OcelogLoggingProvider _provider;

        public OcelogLoggingFactory(Logger logger)
        {
            _provider = new OcelogLoggingProvider(logger);
        }
        public void Dispose()
        {
            _provider.Dispose();
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return _provider.CreateLogger(categoryName);
        }

        public void AddProvider(Microsoft.Extensions.Logging.ILoggerProvider provider) { }
    }
}