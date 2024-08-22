namespace Covrage;

public interface IPolicyIssuance
{
    Task<IssuePolicyResult> IssuePolicyAsync(Policy policy);
}