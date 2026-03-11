namespace Covrage.DependencyInjection.Configuration;

/// <summary>
/// Configuration for policy API endpoints. Allows users to customize which
/// IPolicyApiProvider implementation to use.
/// </summary>
public class PolicyApiConfiguration
{
    /// <summary>
    /// The type implementing IPolicyApiProvider. Defaults to DefaultPolicyApiProvider if not specified.
    /// </summary>
    public Type? PolicyApiProviderType { get; set; }
}
