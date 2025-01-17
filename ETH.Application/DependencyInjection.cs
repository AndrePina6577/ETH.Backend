using Autofac;
using ETH.Application.Modules;

namespace ETH.Application;

/// <summary>
/// The dependency injection class for the application layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the application dependencies into the container.
    /// </summary>
    /// <returns>The <see cref="ContainerBuilder"/>.</returns>
    public static ContainerBuilder AddApplication(this ContainerBuilder builder)
    {
        builder
            .RegisterModule<AuthenticationModule>();

        return builder;
    }
}
