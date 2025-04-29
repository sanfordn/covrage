
using System.Threading.Tasks;

namespace Covrage
{
    public interface IPolicyDatabase
    {
        Task SavePolicyAsync(Policy policy);

        Task<Policy?> GetPolicyAsync(string policyNumber);
    }
}