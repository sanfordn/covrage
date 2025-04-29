using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covrage
{
    public class DefaultPolicyIssuance : IPolicyIssuance
    {
        private readonly IPolicyDatabase _policyDatabase;

        public DefaultPolicyIssuance(IPolicyDatabase policyDatabase)
        {
            _policyDatabase = policyDatabase;
        }

        public async Task<IssuePolicyResult> IssuePolicyAsync(Policy policy)
        {
            ValidatePolicy(policy);

            var issueDate = DateTime.UtcNow;
            policy.PolicyStatus = "Issued";
            policy.EffectiveDate = issueDate;

            await _policyDatabase.SavePolicyAsync(policy);

            return new IssuePolicyResult
            {
                PolicyNumber = policy.PolicyNumber,
                PolicyType = policy.GetType().Name,
                IssueDate = issueDate
            };
        }

        public async Task<Policy?> GetPolicyAsync(string policyNumber)
        {
            return await _policyDatabase.GetPolicyAsync(policyNumber);
        }

        private void ValidatePolicy(Policy policy)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(policy.PolicyNumber))
                errors.Add("Policy number is required.");
            if (policy.EffectiveDate == default)
                errors.Add("Effective date is required.");
            if (string.IsNullOrEmpty(policy.PolicyStatus))
                errors.Add("Policy status is required.");

            if (errors.Count > 0)
                throw new InvalidOperationException(string.Join("; ", errors));
        }
    }
}
