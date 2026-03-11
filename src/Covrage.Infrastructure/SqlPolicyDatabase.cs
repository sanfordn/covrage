using Covrage.Domain.Policies;

namespace Covrage.Infrastructure;

public class SqlPolicyDatabase : IPolicyDatabase
{
    public Task<Policy?> GetPolicyAsync(string policyNumber)
    {
        throw new NotImplementedException();
    }

    public Task SavePolicyAsync(Policy policy)
    {
        throw new NotImplementedException();
    }
}
