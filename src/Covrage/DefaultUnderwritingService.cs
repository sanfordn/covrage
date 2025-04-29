using Covrage;

namespace Covrage;

public class DefaultUnderwritingService : IUnderwritingService
{
    public Task<UnderwritingResult> UnderwritePolicyAsync(Policy policy)
    {
        // Implement your default underwriting logic here
        throw new NotImplementedException();
    }
}
