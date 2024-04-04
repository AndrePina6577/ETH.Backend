using System;
using ETH.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace ETH.Api.Extensions;

/// <summary>
/// The logging configuration.
/// </summary>
public static class LoggingConfiguration
{
    /// <summary>
    /// Configures the serilog logger.
    /// </summary>
    /// <param name="builder">The host builder.</param>
    /// <param name="options">The application options.</param>
    /// <returns>The host builder.</returns>
    public static IHostBuilder ConfigureSerilogLogging(this IHostBuilder builder, ApplicationOptions options)
    {
        return builder
            .UseSerilog((context, config) =>
            {
                config.Enrich.WithProperty("Application name", "ETH Api")
                    .Enrich.WithMachineName()
                    .Enrich.WithThreadId()
                    .Enrich.WithCorrelationId()
                    .Enrich.WithClientIp()
                    .Enrich.WithExceptionDetails()
                    .Enrich.WithProperty("Environment", options.Environment)
                    .Enrich.FromLogContext()
                    .WriteTo.Elasticsearch(ConfigureElasticSink(context.Configuration, options))
                    .ReadFrom.Configuration(context.Configuration)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning);
            });
    }

    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, ApplicationOptions applicationOptions)
    {
        return new ElasticsearchSinkOptions(new Uri(applicationOptions.ElasticSearchLink))
        {
            IndexFormat = $"eth-main-{applicationOptions.Environment.ToLowerInvariant()}-pt{DateTimeOffset.Now:yyyy-MM}",
            AutoRegisterTemplate = true,
            //ModifyConnectionSettings = x => x.BasicAuthentication("", ""),
            //OverwriteTemplate = true,
            //TemplateName = $"petwe-main-{environment}-template",
            //AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
            //TypeName = null,
            //BatchAction = ElasticOpType.Create,
            NumberOfShards = 2,
            NumberOfReplicas = 1,
        };
    }
}
