using Covrage.Domain.Policies;
using Covrage.Domain.Issuance;

namespace Covrage.Application.Issuance;

public interface IPolicyIssuance
{
    Task<IssuePolicyResult> IssuePolicyAsync(Policy policy);
    Task<Policy?> GetPolicyAsync(string policyNumber);
}
