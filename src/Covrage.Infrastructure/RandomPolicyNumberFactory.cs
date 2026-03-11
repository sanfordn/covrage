using Covrage.Domain.Policies;

namespace Covrage.Infrastructure;

public class RandomPolicyNumberFactory : IPolicyNumberFactory
{
    public string GeneratePolicyNumber(Policy policy)
    {
        return $"POL-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
    }
}
