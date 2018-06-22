using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ocelog.AspNetCore
{
    public static class OcelogWebHostBuilderExtensions
    {
        public static ILoggingBuilder AddOcelog(this ILoggingBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddSingleton<ILoggerFactory>(provider => new OcelogLoggingFactory(provider.GetService<Logger>()));

            return builder;
        }
        public static IWebHostBuilder UseOcelog(this IWebHostBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.ConfigureServices((context, collection) =>
            {
                collection.AddSingleton<ILoggerFactory>(provider => new OcelogLoggingFactory(provider.GetService<Logger>()));
            });
            return builder;
        }
    }
}
