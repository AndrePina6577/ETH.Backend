using ETH.Api.TokenProviders.ChangeEmailConfirmation;
using ETH.Domain;
using ETH.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ETH.Api.Extensions;

/// <summary>
/// THe identify configuration.
/// </summary>
public static class IdentityConfiguration
{
    /// <summary>
    /// Configures the application's identity provider.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>The services.</returns>
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddTransient<CustomChangeEmailConfirmationTokenProvider<User>>();

        services.AddIdentity<User, Role<string>>(cfg =>
            {
                cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                cfg.Tokens.ProviderMap.Add("CustomChangeEmailConfirmation", new(typeof(CustomChangeEmailConfirmationTokenProvider<User>)));
                cfg.Tokens.ChangeEmailTokenProvider = "CustomChangeEmailConfirmation";

                cfg.SignIn.RequireConfirmedEmail = true;

                cfg.User.RequireUniqueEmail = true;

                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = true;
                cfg.Password.RequireNonAlphanumeric = true;
                cfg.Password.RequireUppercase = true;
                cfg.Password.RequiredLength = 8;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<SchoolContext>();

        return services;
    }
}
