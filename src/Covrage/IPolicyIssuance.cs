namespace Covrage;

public interface IPolicyIssuance
{
    Task<IssuePolicyResult> IssuePolicyAsync(Policy policy);
    Task<Policy?> GetPolicyAsync(string policyNumber);
}