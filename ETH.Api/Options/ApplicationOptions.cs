using System;

namespace ETH.Api.Options;

/// <summary>
/// The application options.
/// </summary>
public class ApplicationOptions
{
    // /// <summary>
    // /// Gets the stripe api key.
    // /// </summary>
    // public string StripeApiKey { get; init; }
    //
    // /// <summary>
    // /// Gets the stripe webhook secret.
    // /// </summary>
    // public string StripeWebhookSecret { get; init; }

    /// <summary>
    /// Gets the environment.
    /// </summary>
    public string Environment { get; init; }

    /// <summary>
    /// Gets the frontend url.
    /// </summary>
    public Uri FrontendUrl { get; init; }

    /// <summary>
    /// Gets the token key.
    /// </summary>
    public string TokenKey { get; init; }

    /// <summary>
    /// Gets the token issuer.
    /// </summary>
    public string TokenIssuer { get; init; }

    /// <summary>
    /// Gets the elastic search link.
    /// </summary>
    public string ElasticSearchLink { get; init; }

    // /// <summary>
    // /// Gets the application insights connection string.
    // /// </summary>
    // public string ApplicationInsightsConnectionString { get; init; }

    /// <summary>
    /// Gets a value indicating whether the application is in test mode.
    /// </summary>
    public bool IsTestMode
    {
        get
        {
            return !Environment.Equals("Production");
        }
    }
}
