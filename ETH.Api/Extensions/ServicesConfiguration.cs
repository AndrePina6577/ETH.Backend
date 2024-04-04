using Ardalis.GuardClauses;
using ETH.Api.Options;
using ETH.Domain;
using Medallion.Threading;
using Medallion.Threading.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ETH.Api.Extensions;

/// <summary>
/// The services configuration.
/// </summary>
public static class ServicesConfiguration
{
    /// <summary>
    /// Configures the application services.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <param name="options">The application options.</param>
    /// <returns>The application builder.</returns>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder, ApplicationOptions options)
    {
        var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringOptions>();

        Guard.Against.Null(connectionStrings, nameof(connectionStrings));

        builder.Services.ConfigureIdentity();

        //builder.Services.ConfigureSecurity(builder.Configuration, _applicationOptions.TokenKey, _applicationOptions.TokenIssuer, !_applicationOptions.IsTestMode);

        builder
            .Services
            .AddDbContext<SchoolContext>(opts => opts.UseSqlServer(connectionStrings.SchoolConnection));

        builder
            .Services
            .AddDbContextFactory<SchoolContext>(opts => opts.UseSqlServer(connectionStrings.SchoolConnection), ServiceLifetime.Scoped);

        if (options.IsTestMode)
        {
            builder.Services.ConfigureSwagger(builder.Configuration["Project:BasePath"]!, options.IsTestMode);
        }

        builder
            .Services
            .Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new[] { "en" };

                opts.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures)
                    .ApplyCurrentCultureToResponseHeaders = true;
            });

        builder.Services.AddLocalization(/*options => options.ResourcesPath = Path.Combine(Directory.GetParent($"{Directory.GetCurrentDirectory()}\\")?.Parent?.FullName, "Infrastructure.Contracts.V1.Resources"/*, "V1", "Resources")*/);

        builder
            .Services
            .AddCors(opts => opts.AddPolicy("AllowAnyOrigins", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        builder
            .Services
            .AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));

        builder
            .Services
            .AddSingleton<IDistributedLockProvider>(_ => new SqlDistributedSynchronizationProvider(connectionStrings.SchoolConnection));

        builder.Services.AddSingleton(options);

        builder.Services.AddSingleton<ClaimsIdentityOptions>();

        // Allows serilog enricher to get the correlation id.
        builder.Services.AddHttpContextAccessor();

        //Must be here because of fluent validation in next method.
        builder.Services.AddMvc(opt =>
        {
            opt.EnableEndpointRouting = false;
        });

        builder.Services.ConfigureControllers();

        return builder;
    }
}
