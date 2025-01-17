using System;
using ETH.Api.Extensions;
using ETH.Api.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var applicationOptions = new ApplicationOptions
{
    // StripeApiKey = Environment.GetEnvironmentVariable("STRIPE_APIKEY"),
    // StripeWebhookSecret = Environment.GetEnvironmentVariable("STRIPE_WEBHOOK_SECRET"),
    Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!,
    FrontendUrl = new Uri(Environment.GetEnvironmentVariable("FrontendLink")!)!,
    TokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY")!,
    TokenIssuer = Environment.GetEnvironmentVariable("TOKEN_ISSUER")!,
    // ApplicationInsightsConnectionString = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING"),
    ElasticSearchLink = Environment.GetEnvironmentVariable("ELASTICSEARCH_LINK")!,
};

builder.ConfigureHost(applicationOptions);

// ValidatorOptions.Global.LanguageManager = new CustomLanguageManager
// {
//     Culture = new CultureInfo("en"),
// };

builder.ConfigureServices(applicationOptions);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
