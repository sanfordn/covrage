using Covrage.API.Domain;

namespace Covrage.API.Services
{
    public interface IPolicyService
    {
        Task CreateAsync(Policy policy);
    }
}
