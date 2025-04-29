namespace Covrage.DependencyInjection.Configuration;

public class PolicyAdministrationServicesConfiguration
{
    public Type UnderwritingServiceType { get; set; }
    public Type BillingServiceType { get; set; }
    public Type PolicyIssuanceType { get; set; }
    public Type PolicyNumberFactoryType { get; set; }
    // Add other service types as needed...
}
