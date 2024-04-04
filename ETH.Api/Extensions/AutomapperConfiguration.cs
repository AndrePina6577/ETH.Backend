using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;

namespace ETH.Api.Extensions;

/// <summary>
/// The automapper configuration.
/// </summary>
public static class AutomapperConfiguration
{
    /// <summary>
    /// Configures dependency injection with <see cref="AutoMapper"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/>.</param>
    /// <param name="assemblies">The scanned assemblies.</param>
    /// <returns>The <see cref="ContainerBuilder"/>.</returns>
    public static ContainerBuilder ConfigureAutomapper(this ContainerBuilder builder, List<Assembly> assemblies)
    {
        var config = new MapperConfiguration(config =>
        {
            config.AddMaps(assemblies);
        });

        builder
            .Register(c =>
            {
                var context = c.Resolve<IComponentContext>();

                return config.CreateMapper(context.Resolve);
            });

        return builder;
    }
}
