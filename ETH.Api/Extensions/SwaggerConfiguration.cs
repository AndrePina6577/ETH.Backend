using System;
using System.Collections.Generic;
using System.IO;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace ETH.Api.Extensions;

/// <summary>
/// The swagger configuration.
/// </summary>
public static class SwaggerConfiguration
{
    /// <summary>
    /// Configures swagger into the API.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="projectBasePath">The project base path.</param>
    /// <param name="isProduction">The is production.</param>
    /// <returns>The services.</returns>
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services, string projectBasePath, bool isProduction)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ETH.", Version = "v1" });

            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http, //In case we change Auth type, change this value to the new type
                Description = "Put your JWT Bearer token on textbox below!",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });

            if (!isProduction)
            {
                var filePaths = new List<string>
                {
                    Path.Combine(projectBasePath + @"ETH.Api\bin\Debug\net8.0\Documentation.xml"),
                    Path.Combine(projectBasePath + @"ETH.Contracts\bin\Debug\net8.0\Documentation.xml"),
                };

                foreach (var filePath in filePaths)
                {
                    try
                    {
                        c.IncludeXmlComments(filePath);
                    }
                    // ReSharper disable once EmptyGeneralCatchClause
                    catch
                    {
                    }
                }
            }

            c.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("09:00"),
            });

            services.AddEndpointsApiExplorer();

            //c.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));
            //c.TagActionsBy(api => api.GroupName);
        });

        services.AddFluentValidationRulesToSwagger();

        return services;
    }
}
