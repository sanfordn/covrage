using Covrage.Domain.Policies;

namespace Covrage.Infrastructure;

public class InMemoryPolicyDatabase : IPolicyDatabase
{
    private Dictionary<string, Policy> _policies = new Dictionary<string, Policy>();

    public async Task<Policy?> GetPolicyAsync(string policyNumber)
    {
        if (_policies.TryGetValue(policyNumber, out var policy))
        {
            return policy;
        }
        return null;
    }

    public async Task SavePolicyAsync(Policy policy)
    {
        _policies[policy.PolicyNumber] = policy;
    }
}
