using Autofac;
using ETH.Contracts.Modules;

namespace ETH.Contracts;

/// <summary>
/// The dependency injection class for the contracts layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the contracts dependencies into the container.
    /// </summary>
    /// <returns>The <see cref="ContainerBuilder"/>.</returns>
    public static ContainerBuilder AddContracts(this ContainerBuilder builder)
    {
        builder
            .RegisterModule<FluentValidationModule>();

        return builder;
    }
}
