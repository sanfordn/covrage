using Covrage.Domain.Policies;

namespace Covrage.Infrastructure;

public interface IPolicyDatabase
{
    Task SavePolicyAsync(Policy policy);
    Task<Policy?> GetPolicyAsync(string policyNumber);
}
