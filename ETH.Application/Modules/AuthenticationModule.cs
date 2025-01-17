using Autofac;
using ETH.Application.Services.Authentication;

namespace ETH.Application.Modules;

/// <summary>
/// The autofac authentication module.
/// </summary>
public class AuthenticationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<AuthenticationService>()
            .As<IAuthenticationService>();
    }
}
