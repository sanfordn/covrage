namespace Covrage;

public class DefaultPolicyIssuance : IPolicyIssuance
{
    public Task<IssuePolicyResult> IssuePolicyAsync(Policy policy)
    {
        // Implement your default policy issuance logic here
        throw new NotImplementedException();
    }
}
