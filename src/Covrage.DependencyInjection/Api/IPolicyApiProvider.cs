using Microsoft.AspNetCore.Builder;

namespace Covrage.DependencyInjection.Api;

/// <summary>
/// Provides policy API endpoints mapping. Implementations can define custom CRUD operations
/// for the policy domain or extend with additional business logic.
/// </summary>
public interface IPolicyApiProvider
{
    /// <summary>
    /// Maps policy API endpoints to the given WebApplication.
    /// </summary>
    /// <param name="app">The WebApplication to map endpoints to</param>
    void MapEndpoints(WebApplication app);
}
