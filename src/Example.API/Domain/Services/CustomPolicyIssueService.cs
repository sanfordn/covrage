
using Covrage;
using Example.API.Domain.Policies;

namespace Example.API.Domain.Services;

public class CustomPolicyIssueService(ILogger<CustomPolicyIssueService> logger) : IPolicyIssuance
{
    public readonly ILogger<CustomPolicyIssueService> _logger = logger;

    public Task<Policy?> GetPolicyAsync(string policyNumber)
    {
        throw new NotImplementedException();
    }

    public async Task<IssuePolicyResult> IssuePolicyAsync(Policy policy)
    {
        var result = new IssuePolicyResult()
        {
            PolicyNumber = policy.PolicyNumber ?? GeneratePolicyNumber(policy),
            PolicyType = policy.GetType().Name,
            IssueDate = DateTime.UtcNow
        };

        _logger.LogInformation($"Policy issued: {result.PolicyNumber}");

        await Task.Delay(5);

        return result;
    }

    private string GeneratePolicyNumber(Policy policy)
    {
        return $"{policy.GetType().Name[..1].ToUpper()}{DateTime.UtcNow:yyyyMMdd}";
    }
}
