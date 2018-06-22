using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FrameworkLogger = Microsoft.Extensions.Logging;

namespace Ocelog.AspNetCore
{
    public class OcelogLogger : FrameworkLogger.ILogger
    {
        private readonly Logger _logger;
        private readonly FrameworkLogger.LoggerExternalScopeProvider _scopeProvider;
        private const string OriginalFormatPropertyName = "{OriginalFormat}";

        public OcelogLogger(Logger logger)
        {
            _logger = logger;
            _scopeProvider = new FrameworkLogger.LoggerExternalScopeProvider();
        }
        public void Log<TState>(FrameworkLogger.LogLevel logLevel, FrameworkLogger.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var structure = state as IEnumerable<KeyValuePair<string, object>>;

            if (!CanLog(logLevel, structure))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var messageStructure = new Dictionary<string, object>();

            foreach (var item in structure)
            {
                if (item.Key.Equals(OriginalFormatPropertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    messageStructure.Add("Message", formatter(state, exception));
                    break;
                }

                messageStructure.Add(item.Key, item.Value);
            }

            if (exception != null) messageStructure.Add("StackTrace", exception.StackTrace);

            var message = new
            {
                Message = formatter(state, exception),
                exception?.StackTrace
            };

            var stateType = state.GetType();
            var stateTypeInfo = stateType.GetTypeInfo();
            // Imperfect, but at least eliminates `1 names
            if (message.Message == null && !stateTypeInfo.IsGenericType)
            {

            }

            if (message.Message != null || exception != null)
            {
                switch (logLevel)
                {
                    case FrameworkLogger.LogLevel.Error:
                    case FrameworkLogger.LogLevel.Critical:
                        _logger.Error(messageStructure);
                        break;
                    case FrameworkLogger.LogLevel.Warning:
                        _logger.Warn(messageStructure);
                        break;
                    default:
                        _logger.Info(messageStructure);
                        break;
                }
            }
        }

        public bool IsEnabled(FrameworkLogger.LogLevel logLevel)
        {
            return logLevel > FrameworkLogger.LogLevel.Trace;
        }

        public bool CanLog(FrameworkLogger.LogLevel logLevel, IEnumerable<KeyValuePair<string, object>> state)
        {
            if (state == null) return false;

            var stateType = state.GetType();

            var namespaces = state.Select(item => item.Value?.ToString()).ToList();
            namespaces.Add(stateType.FullName);

            if (namespaces.Any(@namespace => @namespace?.StartsWith("Microsoft.AspNetCore") ?? false) && logLevel <= FrameworkLogger.LogLevel.Information)
                return false;

            return IsEnabled(logLevel);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _scopeProvider.Push(state);
        }
    }
}