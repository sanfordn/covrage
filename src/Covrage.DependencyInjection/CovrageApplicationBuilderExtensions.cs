using Covrage.DependencyInjection.Configuration;
using Covrage.Application.Underwriting;
using Covrage.Application.Billing;
using Covrage.Application.Issuance;
using Covrage.Infrastructure;
using Covrage.Infrastructure.Underwriting;
using Covrage.Infrastructure.Billing;
using Covrage.Infrastructure.Issuance;
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
        
        // Use in-memory policy database by default
        infrastructureConfiguration.PolicyRepositoryType ??= typeof(InMemoryPolicyDatabase);
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

