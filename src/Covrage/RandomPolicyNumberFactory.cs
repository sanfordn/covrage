
namespace Covrage;

public class RandomPolicyNumberFactory() : IPolicyNumberFactory
{
    public string? GeneratePolicyNumber(Policy policy)
    {
        return policy.PolicyNumber ?? GenerateRandomPolicyNumber(policy);
    }

    private static string GenerateRandomPolicyNumber(Policy policy)
    {
        // determine the type of policy number, life, annuity, health, etc.
        // and name the policy number accordingly.
        Random random = new();
        return $"{policy.PolicyType?[..1].ToUpper()}{random.Next(1000, 9999)}";
    }
}
