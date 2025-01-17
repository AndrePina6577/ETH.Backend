using Autofac;

namespace ETH.Infrastructure;

/// <summary>
/// The dependency injection class for the infrastructure layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the infrastructure dependencies into the container.
    /// </summary>
    /// <returns>The <see cref="ContainerBuilder"/>.</returns>
    public static ContainerBuilder AddInfrastructure(this ContainerBuilder builder)
    {
        return builder;
    }
}
