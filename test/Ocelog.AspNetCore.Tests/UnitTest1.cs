using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Microsoft.Extensions.Logging;
using Xunit;
using FrameworkLogger = Microsoft.Extensions.Logging;

namespace Ocelog.AspNetCore.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GivenLog_Then()
        {
            var output = new List<LogEvent>();
            var logger = new Logger(logEvents => logEvents
                .Subscribe(log => output.Add(log))
            );

            var wrapper = new OcelogLogger(logger);
            wrapper.LogInformation("Test message {Test}", new { Test = "christo" });
        }

        [Fact]
        public void GivenLog_Then2()
        {
            var output = new List<LogEvent>();
            var logger = new Logger(logEvents => logEvents
                .Subscribe(log => output.Add(log))
            );

            var wrapper = new OcelogLogger(logger);
            wrapper.LogInformation("Test message {Hello}", new { Test = "christo" });
        }
    }
}
