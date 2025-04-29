using Covrage.DependencyInjection.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Covrage.DependencyInjection;

public static class CovrageApplicationBuilderExtensions
{
    public static IServiceCollection AddCovrageServices(this IServiceCollection services, Action<PolicyAdministrationServicesConfiguration>? configure = null)
    {
        var serviceConfiguration = new PolicyAdministrationServicesConfiguration();
        configure?.Invoke(serviceConfiguration);

        // Register default services if they haven't been overridden
        serviceConfiguration.UnderwritingServiceType ??= typeof(DefaultUnderwritingService);
        serviceConfiguration.BillingServiceType ??= typeof(DefaultBillingService);
        serviceConfiguration.PolicyIssuanceType ??= typeof(DefaultPolicyIssuance);

        services.AddPolicyAdministrationServices(serviceConfiguration);

        return services;
    }

    public static IServiceCollection AddCovrageInfrastructure(this IServiceCollection services, Action<PolicyAdministrationInfrastructureConfiguration>? configure = null)
    {
        var infrastructureConfiguration = new PolicyAdministrationInfrastructureConfiguration();
        configure?.Invoke(infrastructureConfiguration);

        // Register default infrastructure if they haven't been overridden

        // if we're debugging, use the in-memory policy database
        if (Debugger.IsAttached)
            infrastructureConfiguration.PolicyRepositoryType ??= typeof(InMemoryPolicyDatabase);
        else
            infrastructureConfiguration.PolicyRepositoryType ??= typeof(SqlPolicyDatabase);
        infrastructureConfiguration.PolicyNumberFactoryType ??= typeof(RandomPolicyNumberFactory);

        services.AddPolicyAdministrationInfrastructure(infrastructureConfiguration);

        return services;
    }

    public static IApplicationBuilder UseCovrage(this IApplicationBuilder app)
    {
        // Configure your Covrage middleware here
        


        return app;
    }
}

