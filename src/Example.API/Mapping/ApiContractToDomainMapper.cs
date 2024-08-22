using Covrage;
using Example.API.Contracts.Requests;

namespace Example.API.Mapping;

public static class ApiContractToDomainMapper
{
    // Map API Policy Request's instance to a Domain Policy
    public static Policy ToPolicy(this PolicyRequest policyRequest)
    {
        throw new NotImplementedException();
    }
}
