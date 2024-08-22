
using Covrage;

namespace Example.API.Domain.Services;

public class CustomPolicyIssueService : IPolicyIssuance
{
    public Task<IssuePolicyResult> IssuePolicyAsync(Policy policy)
    {
        throw new NotImplementedException();
    }
}
