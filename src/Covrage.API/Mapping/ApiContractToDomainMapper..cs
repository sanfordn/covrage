using Covrage.API.Contracts.Requests;
using Covrage.API.Domain;

namespace Covrage.API.Mapping;

public static class ApiContractToDomainMapper
{
    public static Policy ToPolicy(this CreatePolicyRequest request)
    {
        return new Policy
        {
            PolicyNumber = request.PolicyNumber,
            PolicyHolder = request.PolicyHolder,
            PolicyType = request.PolicyType,
            Premium = request.Premium,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
    }
}
