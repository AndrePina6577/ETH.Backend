using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ETH.Api.Modules;
using ETH.Api.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;

namespace ETH.Api.Extensions;

/// <summary>
/// The host configuration.
/// </summary>
public static class HostConfiguration
{
    /// <summary>
    /// The host configuration.
    /// </summary>
    /// <param name="builder">The web application builder.</param>
    /// <returns></returns>
    public static WebApplicationBuilder ConfigureHost(this WebApplicationBuilder builder, ApplicationOptions options)
    {
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddJsonFile($"appsettings.json", false, true);
                config.AddJsonFile($"appsettings.{options.Environment}.json");

                config.AddEnvironmentVariables();
            });

        if (options.IsTestMode)
        {
            builder.Host.ConfigureSerilogLogging(options);
        }
        else
        {
            // Do nothing for now since API is not deployed.
        }

        builder.Host.ConfigureContainer<ContainerBuilder>((_, build) =>
        {
            var applicationAssemblies = GetApplicationAssemblies();

            build.ConfigureAutomapper(applicationAssemblies);

            build.RegisterModule<FluentValidationModule>();
        });

        return builder;
    }

    private static List<Assembly> GetApplicationAssemblies()
    {
        var nonServiceableAssemblies = new List<Assembly>();

        foreach (var library in DependencyContext.Default.CompileLibraries)
        {
            try
            {
                nonServiceableAssemblies.Add(Assembly.Load(new AssemblyName(library.Name)));
            }
            catch
            {
                // ignored
            }
        }

        return nonServiceableAssemblies;
    }
}
