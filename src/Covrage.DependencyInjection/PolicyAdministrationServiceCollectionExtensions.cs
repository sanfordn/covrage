
using Covrage.DependencyInjection.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Covrage.DependencyInjection;

public static class PolicyAdministrationServiceCollectionExtensions
{
    public static IServiceCollection AddPolicyAdministrationServices(
        this IServiceCollection services,
        PolicyAdministrationServicesConfiguration configuration)
    {
        services.AddScoped(typeof(IUnderwritingService), configuration.UnderwritingServiceType);
        services.AddScoped(typeof(IBillingService), configuration.BillingServiceType);
        services.AddScoped(typeof(IPolicyIssuance), configuration.PolicyIssuanceType);
        // Add other services as needed...

        return services;
    }

    public static IServiceCollection AddPolicyAdministrationInfrastructure(
        this IServiceCollection services,
        PolicyAdministrationInfrastructureConfiguration configuration)
    {
        services.AddScoped(typeof(IPolicyDatabase), configuration.PolicyRepositoryType);
        services.AddScoped(typeof(IPolicyNumberFactory), configuration.PolicyNumberFactoryType);
        // Add other infrastructure services as needed...
        return services;
    }
}
