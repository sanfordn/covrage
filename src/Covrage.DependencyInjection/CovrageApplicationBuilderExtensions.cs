using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Covrage.DependencyInjection;

public static class CovrageApplicationBuilderExtensions
{
    public static IServiceCollection AddCovrage(this IServiceCollection services, Action<PolicyAdministrationServicesConfiguration> configure = null)
    {
        var configuration = new PolicyAdministrationServicesConfiguration();
        configure?.Invoke(configuration);

        // Register default services if they haven't been overridden
        if (configuration.UnderwritingServiceType == null)
        {
            configuration.UnderwritingServiceType = typeof(DefaultUnderwritingService);
        }
        if (configuration.BillingServiceType == null)
        {
            configuration.BillingServiceType = typeof(DefaultBillingService);
        }
        if (configuration.PolicyIssuanceType == null)
        {
            configuration.PolicyIssuanceType = typeof(DefaultPolicyIssuance);
        }

        services.AddPolicyAdministrationServices(configuration);

        return services;
    }

    public static IApplicationBuilder UseCovrage(this IApplicationBuilder app)
    {
        // Configure your Covrage middleware here
        


        return app;
    }
}

