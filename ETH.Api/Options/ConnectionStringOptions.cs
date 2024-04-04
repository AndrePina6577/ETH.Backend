namespace ETH.Api.Options;

/// <summary>
/// The connection strings options
/// </summary>
public class ConnectionStringOptions
{
    /// <summary>
    /// Gets the school connection.
    /// </summary>
    public string SchoolConnection { get; init; }

    /// <summary>
    /// Gets the storage account.
    /// </summary>
    public string StorageAccount { get; init; }

    /// <summary>
    /// Gets the azure service bus.
    /// </summary>
    public string AzureServiceBus { get; init; }
}
