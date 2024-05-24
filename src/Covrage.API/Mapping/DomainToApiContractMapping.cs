
using Covrage.API.Contracts.Responses;
using Covrage.API.Domain;

namespace Covrage.API.Mapping;

public static class DomainToApiContractMapping
{
    public static CreatePolicyResponse ToCreatePolicyResponse(this Policy policy)
    {
        return new CreatePolicyResponse
        {
            PolicyNumber = policy.PolicyNumber,
            PolicyHolder = policy.PolicyHolder,
            PolicyType = policy.PolicyType,
            Premium = policy.Premium,
            StartDate = policy.StartDate,
            EndDate = policy.EndDate
        };
    }
}
