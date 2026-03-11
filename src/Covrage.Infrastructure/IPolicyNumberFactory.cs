using Covrage.Domain.Policies;

namespace Covrage.Infrastructure;

public interface IPolicyNumberFactory
{
    string GeneratePolicyNumber(Policy policy);
}
