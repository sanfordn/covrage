using Covrage.DependencyInjection.Api;
using Covrage.DependencyInjection.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Covrage.DependencyInjection;

/// <summary>
/// Extension methods for registering and configuring Covrage API endpoints.
/// </summary>
public static class CovrageApiExtensions
{
    /// <summary>
    /// Adds Covrage policy API endpoints to the service collection.
    /// Registers a default IPolicyApiProvider unless the user specifies a custom one.
    /// </summary>
    public static IServiceCollection AddCovrageApi(
        this IServiceCollection services,
        Action<PolicyApiConfiguration>? configure = null)
    {
        var apiConfiguration = new PolicyApiConfiguration();
        configure?.Invoke(apiConfiguration);

        // Register default API provider if none specified
        apiConfiguration.PolicyApiProviderType ??= typeof(DefaultPolicyApiProvider);

        services.AddScoped(typeof(IPolicyApiProvider), apiConfiguration.PolicyApiProviderType);

        return services;
    }

    /// <summary>
    /// Maps Covrage policy API endpoints. Must be called on a WebApplication instance in Program.cs.
    /// Requires that AddCovrageApi() was called during service registration.
    /// </summary>
    public static WebApplication MapCovrageApi(this WebApplication app)
    {
        // Create a scoped service provider to resolve the API provider
        using var scope = app.Services.CreateScope();
        var apiProvider = scope.ServiceProvider.GetRequiredService<IPolicyApiProvider>();
        apiProvider.MapEndpoints(app);

        return app;
    }
}
