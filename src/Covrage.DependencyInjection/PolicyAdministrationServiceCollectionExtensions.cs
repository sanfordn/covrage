
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
}
