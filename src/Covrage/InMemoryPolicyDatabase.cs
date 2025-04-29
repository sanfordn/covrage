
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Covrage
{
    public class InMemoryPolicyDatabase : IPolicyDatabase
    {
        private readonly ConcurrentDictionary<string, Policy> _policies = new();

        public Task SavePolicyAsync(Policy policy)
        {
            if (_policies.ContainsKey(policy.PolicyNumber))
            {
                throw new System.InvalidOperationException("Policy already exists.");
            }
            _policies[policy.PolicyNumber] = policy;
            return Task.CompletedTask;
        }

        public Task<Policy?> GetPolicyAsync(string policyNumber)
        {
            _policies.TryGetValue(policyNumber, out var policy);
            return Task.FromResult(policy);
        }
    }
}