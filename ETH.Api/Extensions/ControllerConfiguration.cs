using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ETH.Api.Extensions;

/// <summary>
/// The controller configuration.
/// </summary>
public static class ControllerConfiguration
{
    /// <summary>
    /// Configures the controller's pipeline.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers(_ =>
            {
                //options.Filters.Add<ValidationFilter>();
                //options.Filters.Add(new AuthorizationFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                //options.SuppressConsumesConstraintForFormFileParameters = true;
                //options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
                ////options.SuppressMapClientErrors = true;
                //options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
                //    "https://httpstatuses.com/404";
            });
            // .AddFluentValidation(fv =>
            // {
            //     //fv.RegisterValidatorsFromAssemblyContaining<FluentValidationModule>();
            // });

        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationAutoValidation();

        return services;
    }
}
